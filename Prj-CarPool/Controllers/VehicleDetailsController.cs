using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class VehicleDetailsController : Controller
    {
        private readonly IVehicleDetailsRepository _vehicleDetailsRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;
        public VehicleDetailsController(IVehicleDetailsRepository vehicleDetailsRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _vehicleDetailsRepository = vehicleDetailsRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Utility.Models.Set_VehicleDetails> vehicleBrandlist = (List<Utility.Models.Set_VehicleDetails>)await _vehicleDetailsRepository.GetAllAsync(Extensions.SharedBag.VehicleDetailslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = vehicleBrandlist.Where(x => x.IsDeleted == false).OrderByDescending(x => x.VehicleID) });

            ViewBag.JsonData = json;
            return View(vehicleBrandlist);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.Set_VehicleDetails Obj)
        {

            if (ModelState.IsValid)
            {
                if (Obj.VehicleID == 0)
                {
                    var deptobj = await _vehicleDetailsRepository.CreateAsyncJson(Extensions.SharedBag.VehicleDetailsUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleDetailsRepository.GetAllAsync(Extensions.SharedBag.VehicleDetailslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.VehicleID) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _vehicleDetailsRepository.UpdateAsync(Extensions.SharedBag.VehicleDetailsUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleDetailsRepository.GetAllAsync(Extensions.SharedBag.VehicleDetailslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.VehicleID) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Utility.Models.Set_VehicleDetails Obj)
        {

            if (Obj.VehicleID != 0)
            {
                var deptobj = await _vehicleDetailsRepository.UpdateAsync(Extensions.SharedBag.VehicleDetailsDelete, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                var datajson = await _vehicleDetailsRepository.GetAllAsync(Extensions.SharedBag.VehicleDetailslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x=>x.IsDeleted == false).OrderByDescending(x => x.VehicleID) });
                return Json(new { datasuccess = deptobj, json = jsondata });

            }

            return View(Obj);
        }
    }
}
