using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;
using Utility.Models;

namespace Prj_CarPool.Controllers
{
	[Authorize]
	public class DriversController : Controller
	{
		private readonly IDriverRepository _driverRepository;
		private readonly IMemoryCache _memoryCache;
		private readonly ApplicationDbContext _db;

		public DriversController(IDriverRepository driverRepository, IMemoryCache memoryCache, ApplicationDbContext db)
		{
			_driverRepository = driverRepository;
			_memoryCache = memoryCache;
			_db = db;
		}

		public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Driver> DriverList = (List<Driver>)await _driverRepository.GetAllAsync(Extensions.SharedBag.Driverlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = DriverList.OrderByDescending(x => x.DriverID) });

            ViewBag.JsonData = json;
            return View(DriverList);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.Driver Obj)
        {

            if (ModelState.IsValid)
            {
                if (Obj.DriverID == 0)
                {
                    var exsit = _db.Drivers.Where(x => x.DriverCNIC == Obj.DriverCNIC).ToList();
                    if (exsit.Count == 0)
                    {
                        var deptobj = await _driverRepository.CreateAsyncJson(Extensions.SharedBag.DriverUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                        var datajson = await _driverRepository.GetAllAsync(Extensions.SharedBag.Driverlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                        string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.DriverID) });
                        return Json(new { datasuccess = true, json = jsondata });
                    }
                    else
                    {
                        return Json(new { datasuccess = false, jsonerror = "This Driver Already Exsit!" });
                    }
                }
                else
                {
                    var deptobj = await _driverRepository.UpdateAsync(Extensions.SharedBag.DriverUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _driverRepository.GetAllAsync(Extensions.SharedBag.Driverlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.DriverID) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }
    }
}
