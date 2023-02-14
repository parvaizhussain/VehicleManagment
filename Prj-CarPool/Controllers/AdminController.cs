using Identity.Models;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Prj_CarPool.IServices;
using Domain.ViewModels;
using Microsoft.EntityFrameworkCore;
using Prj_CarPool.Extensions;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    [Route("[controller]/[action]/{id?}")]
    public class AdminController : Controller
    {
        private readonly ApplicationIdentityDbContext _dbi;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IDataAccessService _dataAccessService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(ApplicationIdentityDbContext dbi, ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IDataAccessService dataAccessService, ILogger<AdminController> logger)
        {
            _dbi = dbi;
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
            _dataAccessService = dataAccessService;
            _logger = logger;
        }

        [Authorize("Authorization")]
        public async Task<IActionResult> Roles()
        {
            var roleViewModel = new List<RoleViewModel>();
            try
            {
                var roles = await _roleManager.Roles.Include(x => x.Group).ToListAsync();
                foreach (var item in roles)
                {
                    roleViewModel.Add(new RoleViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Group = item.Group
                    });
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
            }

            return View(roleViewModel);
        }

        [Authorize("Roles")]
        public IActionResult CreateRole()
        {
            return View(new RoleViewModel());
        }

        [HttpPost]
        [Authorize("Roles")]
        public async Task<IActionResult> CreateRole(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new ApplicationRole() { Name = viewModel.Name });
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Roles));
                }
                else
                {
                    ModelState.AddModelError("Name", string.Join(",", result.Errors));
                }
            }

            return View(viewModel);
        }

        [Authorize("Authorization")]
        public async Task<IActionResult> Users()
        {
            var userViewModel = new List<UserViewModel>();

            try
            {
                var users = await _userManager.Users
                    //.Include(x=>x.Region)
                    .Include(x => x.AccessRights)
                    .ToListAsync();
                foreach (var item in users)
                {
                    userViewModel.Add(new UserViewModel()
                    {
                        Id = item.Id,
                        Email = item.Email,
                        UserName = item.UserName
                    });
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
            }

            return View(userViewModel);
        }

        [HttpPost]
        [Authorize("Users")]
        public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
        {
            var applicationUser = new ApplicationUser
            {
                FirstName = userViewModel.FirstName,
                LastName = userViewModel.LastName,
                UserName = userViewModel.UserName,
                Email = userViewModel.Email,
                AccessRightsId = userViewModel.AccessRightsId,
                //RegionId = userViewModel.RegionId,
                EmailConfirmed = true
            };

            var user = await _userManager.FindByEmailAsync(applicationUser.Email);

            if (user == null)
            {
                var CreateUser = await _userManager.CreateAsync(applicationUser, userViewModel.Password);
                if (CreateUser.Succeeded)
                {
                    await _userManager.AddToRoleAsync(applicationUser, userViewModel.Roles.FirstOrDefault().Name);

                }
            }

            return View(userViewModel);
        }

        [Authorize("Users")]
        public async Task<IActionResult> EditUser(string id)
        {
            var viewModel = new UserViewModel();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var user = await _userManager.FindByIdAsync(id);
                var userRoles = await _userManager.GetRolesAsync(user);

                viewModel.Email = user?.Email;
                viewModel.UserName = user?.UserName;

                var allRoles = await _roleManager.Roles.Include(x => x.Group).ToListAsync();
                viewModel.Roles = allRoles.Select(x => new RoleViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Group = x.Group,
                    Selected = userRoles.Contains(x.Name)
                }).ToArray();

                var cnb = await (from u in _dbi.Users
                                 join ucnb in _dbi.UserCity_Network_Branch
                                 on u.Id equals ucnb.UserId
                                 where u.Id == id
                                 select new UserCity_Network_Branch
                                 {
                                     UserId = ucnb.UserId,
                                     CityId = Convert.ToInt32(ucnb.CityId),
                                     NetworkId = Convert.ToInt32(ucnb.NetworkId),
                                     BranchId = Convert.ToInt32(ucnb.BranchId)
                                 }).AsNoTracking().ToListAsync();
              //  viewModel.City_Network_Branch = cnb;

            }

            return View(viewModel);
        }

        [HttpPost]
        [Authorize("Users")]
        public async Task<IActionResult> EditUser(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(viewModel.Id);
                var userRoles = await _userManager.GetRolesAsync(user);

                await _userManager.RemoveFromRolesAsync(user, userRoles);
                await _userManager.AddToRolesAsync(user, viewModel.Roles.Where(x => x.Selected).Select(x => x.Name));

                return RedirectToAction(nameof(Users));
            }

            return View(viewModel);
        }

        [Authorize("Authorization")]
        public async Task<IActionResult> EditRolePermission(string id)
        {
            HttpContext.Session.SetObject(Domain.Common.SD.SessionRoleId, id);

            var permissions = new List<NavigationMenuViewModel>();
            if (!string.IsNullOrWhiteSpace(id))
            {
                permissions = await _dataAccessService.GetPermissionsByRoleIdAsync(id);
            }

            return View(permissions);
        }

        [HttpPost]
        [Authorize("Authorization")]
        public async Task<IActionResult> EditRolePermission(string id, string RoleName, int GroupId, List<NavigationMenuViewModel> viewModel)
        {
            id = HttpContext.Session.GetObject<string>(Domain.Common.SD.SessionRoleId);
            if (ModelState.IsValid)
            {
                var role = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();
                role.Name = RoleName;
                role.GroupId = GroupId;
                await _dbi.SaveChangesAsync();

                var permissionIds = viewModel.Where(x => x.Permitted).Select(x => x.Id);
                await _dataAccessService.SetPermissionsByRoleIdAsync(id, permissionIds);
                return RedirectToAction(nameof(Roles));
            }
            return View(viewModel);
        }
    }
}
