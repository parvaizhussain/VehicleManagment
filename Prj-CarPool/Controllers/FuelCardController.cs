using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class FuelCardController : Controller
    {
        private readonly IFuelCardRepository _FuelCardRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;
        public FuelCardController(IFuelCardRepository FuelCardRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _FuelCardRepository = FuelCardRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        public async Task<IActionResult> Index()

        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Utility.Models.FuelCard> FuelCardlist = (List<Utility.Models.FuelCard>)await _FuelCardRepository.GetAllAsync(Extensions.SharedBag.FuelCardlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = FuelCardlist.OrderByDescending(x => x.CardID) });

            ViewBag.JsonData = json;
            return View(FuelCardlist);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.FuelCard Obj)
        {

            if (ModelState.IsValid)
            {
                if (Obj.CardID == 0)
                {
                    var deptobj = await _FuelCardRepository.CreateAsyncJson(Extensions.SharedBag.FuelCardUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _FuelCardRepository.GetAllAsync(Extensions.SharedBag.FuelCardlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.CardID) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _FuelCardRepository.UpdateAsync(Extensions.SharedBag.FuelCardUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _FuelCardRepository.GetAllAsync(Extensions.SharedBag.FuelCardlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.CardID) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Utility.Models.FuelCard Obj)
        {

            if (Obj.CardID != 0)
            {
                var deptobj = await _FuelCardRepository.UpdateAsync(Extensions.SharedBag.FuelCardDelete, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                var datajson = await _FuelCardRepository.GetAllAsync(Extensions.SharedBag.FuelCardlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.CardID) });
                return Json(new { datasuccess = deptobj, json = jsondata });

            }

            return View(Obj);
        }

    }
}
