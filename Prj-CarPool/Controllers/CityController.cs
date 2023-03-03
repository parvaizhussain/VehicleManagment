
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class CityController : Controller
    {
        private readonly ICityRepository _CityRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;
        public CityController(ICityRepository CityRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _CityRepository = CityRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()

        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Utility.Models.City> Citylist = (List<Utility.Models.City>)await _CityRepository.GetAllAsync(Extensions.SharedBag.Citylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = Citylist.OrderByDescending(x => x.CityId) });

            ViewBag.JsonData = json;
            return View(Citylist);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.City Obj)
        {

            if (ModelState.IsValid)
            {
                Obj.CityCode = Obj.CityName.Substring(0, 3).Trim().ToUpper(); 
                Obj.NormalizedName = Obj.CityName.Trim().ToUpper();
                if (Obj.CityId == 0)
                {
                   
                    var deptobj = await _CityRepository.CreateAsyncJson(Extensions.SharedBag.CityUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _CityRepository.GetAllAsync(Extensions.SharedBag.Citylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.CityId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    Obj.CityCode = "000";
                    var deptobj = await _CityRepository.UpdateAsync(Extensions.SharedBag.CityUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _CityRepository.GetAllAsync(Extensions.SharedBag.Citylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.CityId) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Utility.Models.City Obj)
        {

                if (Obj.CityId != 0)
                {

                var deptobj = await _CityRepository.UpdateAsync(Extensions.SharedBag.CityDelete, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                var datajson = await _CityRepository.GetAllAsync(Extensions.SharedBag.Citylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.CityId) });
                return Json(new { datasuccess = deptobj, json = jsondata });

            }
        
            return View(Obj);
        }


    }
}
