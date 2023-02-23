using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Utility.Models;
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;


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
            List<VehicleRequest> ServiceCenterlist = (List<VehicleRequest>)await _vehicleRequestRepository.GetAllAsync(Extensions.SharedBag.VehicleRequestlist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = ServiceCenterlist.OrderByDescending(x => x.RequestID) });

            ViewBag.JsonData = json;
            return View(ServiceCenterlist);
        }
    }
}
