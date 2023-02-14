using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class AirportController : Controller
    {
        private readonly IAirportRepository _AirportRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;
        public AirportController(IAirportRepository AirportRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _AirportRepository = AirportRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        
        public async Task<IActionResult> Index()
        
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Utility.Models.Airport> Airportlist = (List<Utility.Models.Airport>)await _AirportRepository.GetAllAsync(Extensions.SharedBag.Airportlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = Airportlist.OrderByDescending(x => x.AirportID) });

            ViewBag.JsonData = json;
            return View(Airportlist);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.Airport Obj)
        {

            if (ModelState.IsValid)
            {
                if (Obj.AirportID == 0)
                {
                    var deptobj = await _AirportRepository.CreateAsyncJson(Extensions.SharedBag.AirportUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _AirportRepository.GetAllAsync(Extensions.SharedBag.Airportlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.AirportID) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _AirportRepository.UpdateAsync(Extensions.SharedBag.AirportUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _AirportRepository.GetAllAsync(Extensions.SharedBag.Airportlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.AirportID) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Utility.Models.Airport Obj)
        {

            if (Obj.AirportID != 0)
            {

                var deptobj = await _AirportRepository.UpdateAsync(Extensions.SharedBag.AirportDelete, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                var datajson = await _AirportRepository.GetAllAsync(Extensions.SharedBag.Airportlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.AirportID) });
                return Json(new { datasuccess = deptobj, json = jsondata });

            }

            return View(Obj);
        }


    }
}
