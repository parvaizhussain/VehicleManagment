using Prj_CarPool.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class VehicleCompanyController : Controller
    {
        private readonly IVehicleCompanyRepository _vehicleCompanyRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public VehicleCompanyController(IVehicleCompanyRepository vehicleCompanyRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _vehicleCompanyRepository = vehicleCompanyRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
           List<Utility.Models.VehicleCompany> vehicleComapanylist = (List<Utility.Models.VehicleCompany>)await _vehicleCompanyRepository.GetAllAsync(Extensions.SharedBag.VehicleCompanylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = vehicleComapanylist.Where(x => x.IsDeleted == false).OrderByDescending(x => x.VehicleCompanyID) });

            ViewBag.JsonData = json;
            return View(vehicleComapanylist);
        }


        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.VehicleCompany Obj)
        {
            if (ModelState.IsValid)
            {
                if (Obj.VehicleCompanyID == 0)
                {
                    var deptobj = await _vehicleCompanyRepository.CreateAsyncJson(Extensions.SharedBag.VehicleCompanyUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleCompanyRepository.GetAllAsync(Extensions.SharedBag.VehicleCompanylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.VehicleCompanyID) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _vehicleCompanyRepository.UpdateAsync(Extensions.SharedBag.VehicleCompanyUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleCompanyRepository.GetAllAsync(Extensions.SharedBag.VehicleCompanylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.VehicleCompanyID) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Utility.Models.VehicleCompany Obj)
        {

            if (Obj.VehicleCompanyID != 0)
            {

                var deptobj = await _vehicleCompanyRepository.UpdateAsync(Extensions.SharedBag.VehicleCompanyDelete, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                var datajson = await _vehicleCompanyRepository.GetAllAsync(Extensions.SharedBag.VehicleCompanylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x=>x.IsDeleted == false).OrderByDescending(x => x.VehicleCompanyID) });
                return Json(new { datasuccess = deptobj, json = jsondata });

            }

            return View(Obj);
        }
    }
}
