﻿using Prj_CarPool.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Utility.Models;
using Prj_CarPool.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Prj_CarPool.Controllers
{
    public class ServiceCenterController : Controller
    {
        private readonly IServiceCenterRepository _serviceCenterRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public ServiceCenterController(IServiceCenterRepository serviceCenterRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _serviceCenterRepository = serviceCenterRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<ServiceCenter> ServiceCenterlist = (List<ServiceCenter>)await _serviceCenterRepository.GetAllAsync(Extensions.SharedBag.ServiceCenterlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = ServiceCenterlist.Where(x => x.IsDeleted == false).OrderByDescending(x => x.VehicleCompanyID) });

            ViewBag.JsonData = json;
            return View(ServiceCenterlist);
        }
        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.ServiceCenter Obj)
        {

            if (ModelState.IsValid)
            {
                if (Obj.ServiceCenterId == 0)
                {
                    if (Obj.DealerType == false)
                    {
                        Obj.DealerID = null;
                    }
                    var deptobj = await _serviceCenterRepository.CreateAsyncJson(Extensions.SharedBag.ServiceCenterUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _serviceCenterRepository.GetAllAsync(Extensions.SharedBag.ServiceCenterlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));

                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ServiceCenterId) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    if (Obj.DealerType == false)
                    {
                        Obj.DealerID = null;
                    }
                    var deptobj = await _serviceCenterRepository.UpdateAsync(Extensions.SharedBag.ServiceCenterUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _serviceCenterRepository.GetAllAsync(Extensions.SharedBag.ServiceCenterlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ServiceCenterId) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Utility.Models.ServiceCenter Obj)
        {

            if (Obj.ServiceCenterId != 0)
            {
                var deptobj = await _serviceCenterRepository.UpdateAsync(Extensions.SharedBag.ServiceCenterDelete, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                var datajson = await _serviceCenterRepository.GetAllAsync(Extensions.SharedBag.ServiceCenterlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x=>x.IsDeleted == false).OrderByDescending(x => x.ServiceCenterId) });
                return Json(new { datasuccess = deptobj, json = jsondata });

            }

            return View(Obj);
        }


    }
}
