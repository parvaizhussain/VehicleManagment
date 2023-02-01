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
    public class AccessRightsController : Controller
    {
        private readonly IAccessRightsRepository _accessRightsRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public AccessRightsController(IAccessRightsRepository accessRightsRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _accessRightsRepository = accessRightsRepository;
            _memoryCache = memoryCache;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            // List<Domain.Entities.Branch> branch = _db.Branch.ToList();
            List<AccessRight> branch = (List<AccessRight>)await _accessRightsRepository.GetAllAsync(Extensions.SharedBag.AccessRightslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = branch.OrderByDescending(x => x.AccessId) });

            ViewBag.JsonData = json;
            return View(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.AccessRight Obj)
        {
            if (ModelState.IsValid)
            {
                if (Obj.AccessId == 0)
                {
                    var deptobj = await _accessRightsRepository.CreateAsyncJson(Extensions.SharedBag.AccessRightsUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _accessRightsRepository.GetAllAsync(Extensions.SharedBag.AccessRightslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.AccessId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _accessRightsRepository.UpdateAsync(Extensions.SharedBag.AccessRightsUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _accessRightsRepository.GetAllAsync(Extensions.SharedBag.AccessRightslist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.AccessId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
            }
            return View(Obj);
        }

    }
}
