using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Utility.Models;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;
using System.Text.Json;
using Domain.ViewModels;
using System.Globalization;

namespace Prj_CarPool.Controllers
{
    public class VehicleUserRequestController : Controller
    {
        private readonly IVehicleRequestRepository _vehicleRequestRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public VehicleUserRequestController(IVehicleRequestRepository vehicleRequestRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _vehicleRequestRepository = vehicleRequestRepository;
            _memoryCache = memoryCache;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            UserViewModel CurUserdata = JsonSerializer.Deserialize<Domain.ViewModels.UserViewModel>(_memoryCache.Get(SharedBag.UserAccountDetail).ToString());
            List<VehicleRequest> ServiceCenterlist = (List<VehicleRequest>)await _vehicleRequestRepository.GetAllAsync(Extensions.SharedBag.VehicleRequestlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = ServiceCenterlist.Where(x=>x.EmployeeID.ToString() == CurUserdata.EmployeeID).OrderByDescending(x => x.RequestID ) });

            ViewBag.JsonData = json;
            return View(ServiceCenterlist);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(Utility.Models.VehicleRequest Obj)
        {
            UserViewModel CurUserdata = JsonSerializer.Deserialize<Domain.ViewModels.UserViewModel>(_memoryCache.Get(SharedBag.UserAccountDetail).ToString());
            if (ModelState.IsValid)
            {
                if (Obj.RequestID == 0)
                {
                    

                   //DateTime time = DateTime.ParseExact(Obj.RequestTime,"h:mm tt",CultureInfo.InvariantCulture);
                    //Obj.RequestTime = time.ToString("h:mm:ss");
                   Obj.EmployeeID = int.Parse(CurUserdata.EmployeeID);
                    Obj.HODEmpID = CurUserdata.HODEmpID;
                    var deptobj = await _vehicleRequestRepository.CreateAsyncJson(Extensions.SharedBag.VehicleRequestUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleRequestRepository.GetAllAsync(Extensions.SharedBag.VehicleRequestlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.EmployeeID.ToString() == CurUserdata.EmployeeID).OrderByDescending(x => x.RequestID) });
                    return Json(new { datasuccess = true, json = jsondata });

                }
                else
                {
                    var deptobj = await _vehicleRequestRepository.UpdateAsync(Extensions.SharedBag.VehicleRequestUpsert, Obj, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    var datajson = await _vehicleRequestRepository.GetAllAsync(Extensions.SharedBag.VehicleRequestlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
                    string jsondata = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = datajson.Where(x => x.EmployeeID.ToString() == CurUserdata.EmployeeID && x.Status == 0).OrderByDescending(x => x.RequestID) });
                    return Json(new { datasuccess = deptobj, json = jsondata });

                }
            }
            return View(Obj);
        }
      
        public async Task<IActionResult> EmpReqList()

        { 
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            UserViewModel CurUserdata = JsonSerializer.Deserialize<Domain.ViewModels.UserViewModel>(_memoryCache.Get(SharedBag.UserAccountDetail).ToString());
            List<VehicleRequest> ServiceCenterlist = (List<VehicleRequest>)await _vehicleRequestRepository.GetAllAsync(Extensions.SharedBag.VehicleRequestlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = ServiceCenterlist.Where(x => x.HODEmpID.ToString() == CurUserdata.EmployeeID && x.Status == 0).OrderByDescending(x => x.RequestID) });

            ViewBag.JsonData = json;
            return View(ServiceCenterlist);
        }
    }
}
