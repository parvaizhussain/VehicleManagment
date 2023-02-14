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
    public class RegionController : Controller
    {
        private readonly IRegionRepository  _regionRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public RegionController(IRegionRepository regionRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _regionRepository = regionRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            // List<Domain.Entities.Branch> branch = _db.Branch.ToList();
            List<Region> branch = (List<Region>)await _regionRepository.GetAllAsync(Extensions.SharedBag.Regionlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = branch.Where(x => x.IsDeleted == false).OrderByDescending(x => x.RegionId) });

            ViewBag.JsonData = json;
            return View(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.Region Obj)
        {
            if (ModelState.IsValid)
            {
                if (Obj.RegionId == 0)
                {
                    var deptobj = await _regionRepository.CreateAsyncJson(Extensions.SharedBag.RegionUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _regionRepository.GetAllAsync(Extensions.SharedBag.Regionlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.RegionId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _regionRepository.UpdateAsync(Extensions.SharedBag.RegionUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _regionRepository.GetAllAsync(Extensions.SharedBag.Regionlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.RegionId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
            }
            return View(Obj);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Utility.Models.Region Obj)
        {

            if (Obj.RegionId != 0)
            {
                var deptobj = await _regionRepository.UpdateAsync(Extensions.SharedBag.RegionDelete, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                var datajson = await _regionRepository.GetAllAsync(Extensions.SharedBag.Regionlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x=>x.IsDeleted == false).OrderByDescending(x => x.RegionId) });
                return Json(new { datasuccess = deptobj, json = jsondata });

            }

            return View(Obj);
        }
    }
}
