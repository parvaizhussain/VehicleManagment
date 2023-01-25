using Prj_CarPool.IServices;
using Utility.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Prj_CarPool.Extensions;
using Persistence;
using Microsoft.AspNetCore.Authorization;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class BranchController : Controller
    {
        private readonly IBranchRepository _BranchRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public BranchController(IBranchRepository BranchRepository, IMemoryCache memoryCache,ApplicationDbContext db)
        {
            _BranchRepository = BranchRepository;
            _memoryCache = memoryCache;
            _db = db;   
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            // List<Domain.Entities.Branch> branch = _db.Branch.ToList();
            List<Utility.Models.Branch> branch = (List<Utility.Models.Branch>)await _BranchRepository.GetAllAsync(Extensions.SharedBag.Branchlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = branch.OrderByDescending(x => x.BranchId) });

            ViewBag.JsonData = json;
            return View(branch);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.Branch Obj)
        {
            if (ModelState.IsValid)
            {
                if (Obj.BranchId == 0)
                {
                   var deptobj = await _BranchRepository.CreateAsyncJson(Extensions.SharedBag.BranchUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                   var datajson = await _BranchRepository.GetAllAsync(Extensions.SharedBag.Branchlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.OrderByDescending(x => x.BranchId) });
                    return Json(new { datasuccess = true , json  = jsondata });

                }
                else
                {
                    var deptobj = await _BranchRepository.UpdateAsync(Extensions.SharedBag.BranchUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    return Json(new { data = deptobj });

                }
            }
            return View(Obj);
        }


        [HttpPatch]
        public async Task<IActionResult> deleteBranch(Branch deleteObj)
        {
            if (ModelState.IsValid)
            {
                var deptobj = await _BranchRepository.UpdateAsync(Extensions.SharedBag.BranchDelete, deleteObj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                return Json(new { data = deptobj });

            }
            return View(deleteObj);
        }
    
    }
}
