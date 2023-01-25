using Prj_CarPool.Extensions;
using Domain.ViewModels;
using Identity.Models;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Persistence;
using System.Text.Json;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationIdentityDbContext _dbi;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMemoryCache _memoryCache;

        public UserController(
                ApplicationIdentityDbContext dbi,
                ApplicationDbContext db,
                UserManager<ApplicationUser> userManager,
                RoleManager<ApplicationRole> roleManager,
                ILogger<UserController> logger,
                 IMemoryCache memoryCache)
        {
            _dbi = dbi;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _memoryCache = memoryCache;
        }
       // [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            var Data = _memoryCache.Get(SharedBag.UserAccountDetail);
            var UserData = JsonSerializer.Deserialize<UserViewModel>((string)Data);
            ViewBag.JsonUserData = Data;
            var userViewModel = new List<UserViewModel>();

            try
            {
                List<int> BranchIds = new List<int>();
                if (!UserData.IsCluster)
                    BranchIds.AddRange(UserData.City_Network_Branch.Select(x => Convert.ToInt32(x.BranchId)).Distinct().ToList());
                else
                    BranchIds.AddRange(UserData.Cluster_Branch.Select(x => Convert.ToInt32(x.BranchId)).Distinct().ToList());

                var users = await(from u in _dbi.Users
                                  join ucb in _dbi.Cluster_Branch
                                  on u.Id equals ucb.UserId into u_c_b
                                  from ucb in u_c_b.DefaultIfEmpty()
                                  join ucnb in _dbi.UserCity_Network_Branch
                                  on u.Id equals ucnb.UserId into u_c_n_b
                                  from ucnb in u_c_n_b.DefaultIfEmpty()
                                  where BranchIds.Contains(ucb.BranchId) || BranchIds.Contains((int)ucnb.BranchId)
                                  select u).ToListAsync();

                var users2 = await(from u in _dbi.Users where u.PasswordHash == null select u).ToListAsync();
                users.AddRange(users2);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = users });

                ViewBag.JsonData = json;

                ViewBag.Users = users.Distinct().ToList();

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
            }

            return View(userViewModel);
           // return View();

        }
    }
}
