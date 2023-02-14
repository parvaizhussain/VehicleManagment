using Prj_CarPool.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Prj_CarPool.Controllers
{
    public class MaintenanceHistoryController : Controller
    {
        private readonly IMaintainanceHistoryRepository _maintainanceHistoryRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public MaintenanceHistoryController(IMaintainanceHistoryRepository maintainanceHistoryRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _maintainanceHistoryRepository = maintainanceHistoryRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Utility.Models.MaintainaceHistory> vehicleComapanylist = (List<Utility.Models.MaintainaceHistory>)await _maintainanceHistoryRepository.GetAllAsync(Extensions.SharedBag.MainTainanceHistorylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = vehicleComapanylist.OrderByDescending(x => x.MaintainaceHistoryId) });

            ViewBag.JsonData = json;
            return View(vehicleComapanylist);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.MaintainaceHistory Obj)
        {

            if (ModelState.IsValid)
            {
                if (Obj.MaintainaceHistoryId == 0)
                {
                    var deptobj = await _maintainanceHistoryRepository.CreateAsyncJson(Extensions.SharedBag.MainTainanceHistoryUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _maintainanceHistoryRepository.GetAllAsync(Extensions.SharedBag.MainTainanceHistorylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.MaintainaceHistoryId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _maintainanceHistoryRepository.UpdateAsync(Extensions.SharedBag.MainTainanceHistoryUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _maintainanceHistoryRepository.GetAllAsync(Extensions.SharedBag.MainTainanceHistorylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.MaintainaceHistoryId) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }


    }
}
