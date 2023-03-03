using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Utility.Models;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;
using System.Text.Json;
using Domain.ViewModels;


namespace Prj_CarPool.Controllers
{
    public class RequestManageController : Controller
    {
        private readonly IVehicleRequestRepository _vehicleRequestRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public RequestManageController(IVehicleRequestRepository vehicleRequestRepository, IMemoryCache memoryCache, ApplicationDbContext db)
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
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = ServiceCenterlist.Where(x=>x.HODApproval == true && x.Status == 1).OrderByDescending(x => x.RequestID) });

            ViewBag.JsonData = json;
            return View(ServiceCenterlist);
        }
    }
}
