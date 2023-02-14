using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;

using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class VehicleBrandsController : Controller
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;
        public VehicleBrandsController(IVehicleBrandRepository vehicleBrandRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _vehicleBrandRepository = vehicleBrandRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Utility.Models.VehicleBrands> vehicleBrandlist = (List<Utility.Models.VehicleBrands>)await _vehicleBrandRepository.GetAllAsync(Extensions.SharedBag.VehicleBrandslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = vehicleBrandlist.OrderByDescending(x => x.VehicleBrandId) });

            ViewBag.JsonData = json;
            return View(vehicleBrandlist);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.VehicleBrands Obj)
        {
            
            if (ModelState.IsValid)
            {
                if (Obj.VehicleBrandId == 0)
                {
                    var deptobj = await _vehicleBrandRepository.CreateAsyncJson(Extensions.SharedBag.VehicleBrandsUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleBrandRepository.GetAllAsync(Extensions.SharedBag.VehicleBrandslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.VehicleBrandId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _vehicleBrandRepository.UpdateAsync(Extensions.SharedBag.VehicleBrandsUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleBrandRepository.GetAllAsync(Extensions.SharedBag.VehicleBrandslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.VehicleBrandId) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }

        public IActionResult upload()
        {

            //  var drives = _db.Drivers.FirstOrDefault();


            //  return Json(drives);



            byte[] imageData = System.IO.File.ReadAllBytes("D:\\user\\2.jfif");


            var driver = _db.Drivers.Where(x => x.DriverID == 2).FirstOrDefault();
            driver.DriverImage = imageData;
            _db.Drivers.Update(driver);
            _db.SaveChanges();
            return View();
        }
    }
}
