using Prj_CarPool.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using Prj_CarPool.Extensions;

namespace Prj_CarPool.Controllers
{
    public class ServiceCenterController : Controller
    {
        private readonly IVehicleCompanyRepository _vehicleCompanyRepository;
        private readonly IMemoryCache _memoryCache;
        private readonly ApplicationDbContext _db;

        public ServiceCenterController(IVehicleCompanyRepository vehicleCompanyRepository, IMemoryCache memoryCache, ApplicationDbContext db)
        {
            _vehicleCompanyRepository = vehicleCompanyRepository;
            _memoryCache = memoryCache;
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            List<Utility.Models.VehicleCompany> vehicleComapanylist = (List<Utility.Models.VehicleCompany>)await _vehicleCompanyRepository.GetAllAsync(Extensions.SharedBag.VehicleCompanylist, HttpContext.Session.GetString(Extensions.SharedBag.JWToken));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = vehicleComapanylist.OrderByDescending(x => x.VehicleCompanyID) });

            ViewBag.JsonData = json;
            return View(vehicleComapanylist);
        }


      
    }
}
