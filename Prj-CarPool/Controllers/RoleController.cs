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
using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;

namespace Prj_CarPool.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationIdentityDbContext _dbi;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IDataAccessService _dataAccessService;
        private readonly ILogger<RoleController> _logger;
        private readonly IMemoryCache _memoryCache;
        public RoleController(
                ApplicationIdentityDbContext dbi,
                RoleManager<ApplicationRole> roleManager,
                IDataAccessService dataAccessService,
                ILogger<RoleController> logger,
                IMemoryCache memoryCache, UserManager<ApplicationUser> userManager)
        {
            _dbi = dbi;
            _roleManager = roleManager;
            _userManager = userManager;
            _dataAccessService = dataAccessService;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);

                var roleViewModel = new List<RoleViewModel>();
                try
                {


                    var roles = await _roleManager.Roles.Include(x => x.Group).ToListAsync();
                    foreach (var item in roles)
                    {
                        var roleUSerViewModel = new List<RoleUserViewModel>();
                        var list = _dbi.UserRoles.Where(x => x.RoleId == item.Id).ToList();
                        foreach (var itemRole in list)
                        { 
                            roleUSerViewModel.Add(new RoleUserViewModel()
                            {
                                UserIdName =  _dbi.Users.Where(x=>x.Id == itemRole.UserId).FirstOrDefault().FirstName + " " + _dbi.Users.Where(x => x.Id == itemRole.UserId).FirstOrDefault().LastName
                               
                            });
                         }

                        roleViewModel.Add(new RoleViewModel()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            ShortName = item.NormalizedName,
                            Group = item.Group,
                            roleUsers = roleUSerViewModel

                        }) ;
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, ex.GetBaseException().Message);
                }

                return View(roleViewModel);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IActionResult> GetAll()
        {
            var roleViewModel = new List<RoleViewModel>();
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                foreach (var item in roles)
                {
                    roleViewModel.Add(new RoleViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ShortName = item.NormalizedName
                    });
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
            }

            return Json(roleViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> CreateRole(RoleAddViewModel viewModel, int[] permissionIds)
        {
            try
            {


                if (ModelState.IsValid)
                {
                    var Checkrole = _roleManager.Roles.Where(x => x.NormalizedName == viewModel.ShortName).FirstOrDefault();
                    if (Checkrole == null)
                    {
                        var result = await _roleManager.CreateAsync(new ApplicationRole() { Name = viewModel.Name, GroupId = viewModel.GroupId });
                        if (result.Succeeded)
                        {
                            var lastItemTole = _roleManager.Roles.Where(x => x.NormalizedName == viewModel.Name.ToUpper()).FirstOrDefault();
                            await _dataAccessService.SetPermissionsByRoleIdAsync(lastItemTole.Id, permissionIds);
                            //Added View
                            var roleViewModel = new List<RoleViewModel>();
                            try
                            {


                                var roles = await _roleManager.Roles.Include(x => x.Group).ToListAsync();
                                foreach (var item in roles)
                                {
                                    var roleUSerViewModel = new List<RoleUserViewModel>();
                                    var list = _dbi.UserRoles.Where(x => x.RoleId == item.Id).ToList();
                                    foreach (var itemRole in list)
                                    {
                                        roleUSerViewModel.Add(new RoleUserViewModel()
                                        {
                                            UserIdName = _dbi.Users.Where(x => x.Id == itemRole.UserId).FirstOrDefault().FirstName + " " + _dbi.Users.Where(x => x.Id == itemRole.UserId).FirstOrDefault().LastName

                                        });
                                    }

                                    roleViewModel.Add(new RoleViewModel()
                                    {
                                        Id = item.Id,
                                        Name = item.Name,
                                        ShortName = item.NormalizedName,
                                        Group = item.Group,
                                        roleUsers = roleUSerViewModel

                                    });
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger?.LogError(ex, ex.GetBaseException().Message);
                            }
                            //Added View



                            return Json(new { Message = "Role Created Successfully", Created = true,datarefresh = roleViewModel });
                        }
                        else
                        {
                            return Json(new { Message = "Role Not Created", Created = false });
                        }
                    }
                    else
                        return Json(new { Message = "Role Already Exist", Created = false });
                }
                else
                    return Json(false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetRolePermission(string id)
        {
            try
            {


                var permissions = new List<NavigationMenuViewModel>();
                if (!string.IsNullOrWhiteSpace(id))
                {
                    permissions = await _dataAccessService.GetPermissionsByRoleIdAsync(id);
                }

                return Json(permissions);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetRolePermissionVal(string id)
        {
            try
            {
                var roles = await _roleManager.Roles.Include(x => x.Group).Where(x=>x.Id == id).FirstOrDefaultAsync();
                var permissions = new List<NavigationMenuValueViewModel>();
                if (!string.IsNullOrWhiteSpace(id))
                {
                    permissions = await _dataAccessService.GetPermissionsByRoleValueAsync(id);
                }

                return Json(new { datamenu = permissions, rolesdata = roles });
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]

        public async Task<IActionResult> EditRolePermission(RoleViewEditModel viewModel, int[] permissionIds)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var Checkrole = _roleManager.Roles.Where(x => x.NormalizedName == viewModel.ShortName && x.Id != viewModel.Id).FirstOrDefault();
                    if (Checkrole == null)
                    {
                        var role = _roleManager.Roles.Where(x => x.Id == viewModel.Id).FirstOrDefault();
                        role.Name = viewModel.Name;
                        role.GroupId = viewModel.GroupId;
                        await _dbi.SaveChangesAsync();

                        await _dataAccessService.SetPermissionsByRoleIdAsync(viewModel.Id, permissionIds);
                        //Added View
                        var roleViewModel = new List<RoleViewModel>();
                        try
                        {


                            var roles = await _roleManager.Roles.Include(x => x.Group).ToListAsync();
                            foreach (var item in roles)
                            {
                                var roleUSerViewModel = new List<RoleUserViewModel>();
                                var list = _dbi.UserRoles.Where(x => x.RoleId == item.Id).ToList();
                                foreach (var itemRole in list)
                                {
                                    roleUSerViewModel.Add(new RoleUserViewModel()
                                    {
                                        UserIdName = _dbi.Users.Where(x => x.Id == itemRole.UserId).FirstOrDefault().FirstName + " " + _dbi.Users.Where(x => x.Id == itemRole.UserId).FirstOrDefault().LastName

                                    });
                                }

                                roleViewModel.Add(new RoleViewModel()
                                {
                                    Id = item.Id,
                                    Name = item.Name,
                                    ShortName = item.NormalizedName,
                                    Group = item.Group,
                                    roleUsers = roleUSerViewModel

                                });
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger?.LogError(ex, ex.GetBaseException().Message);
                        }


                        return Json(new { Message = "Role Edited Successfully", Edited = true,DataRefresh= roleViewModel });
                    }
                    else
                        return Json(new { Message = "Role Already Exist", Edited = false });
                }
                else
                    return Json(false);
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public async Task<IActionResult> GetUser(string id)
        {
            try
            {

                var viewModel = new UserViewModel();
                if (!string.IsNullOrWhiteSpace(id))
                {
                    var user = await _dbi.Users
                        //.Include(x => x.Region)
                        .Include(x => x.AccessRights)
                        .Where(x => x.Id == id).FirstOrDefaultAsync();
                    //var user = await _userManager.FindByIdAsync(id);
                    viewModel.Id = id;
                    viewModel.FirstName = user.FirstName;
                    viewModel.LastName = user.LastName;
                    viewModel.UserName = user.UserName;
                    viewModel.Email = user.Email;
                    viewModel.AccessRightsId = user.AccessRightsId;
                    viewModel.AccessRights = user.AccessRights;
                    //viewModel.RegionId = user.RegionId;
                    //viewModel.Region = user.Region;
                    viewModel.IsCluster = user.IsCluster;
                    var userRoleId = await _dbi.UserRoles.Where(x => x.UserId == id).Select(x => x.RoleId).FirstOrDefaultAsync();
                    var allRoles = await _roleManager.Roles.Where(x => x.Id == userRoleId).Include(x => x.Group.Department).ToListAsync();
                    viewModel.Roles = allRoles.Select(x => new RoleViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Group = x.Group
                    }).ToArray();

                    var r = await _dbi.User_Region
                                .Where(x => x.UserId == id)
                                .Include(x => x.Region)
                                .ToListAsync();

                    var urList = new List<User_Region>();
                    for (int i = 0; i < r.Count; i++)
                    {
                        var ur = new User_Region();
                        ur.UserId = id;
                        ur.RegionId = Convert.ToInt32(r[i].RegionId);
                        ur.Region = r[i].Region;
                        urList.Add(ur);
                    }
                    viewModel.User_Region = urList;

                    if (viewModel.IsCluster)
                    {
                        var cb = await _dbi.Cluster_Branch
                        .Where(x => x.UserId == id)
                        .Include(x => x.Branch.Network.City)
                        .ToListAsync();

                        var ucbList = new List<Cluster_Branch>();
                        for (int i = 0; i < cb.Count; i++)
                        {
                            var ucb = new Cluster_Branch();
                            ucb.UserId = id;
                            ucb.BranchId = Convert.ToInt32(cb[i].BranchId);
                            ucb.Branch = cb[i].Branch;
                            ucbList.Add(ucb);
                        }
                        viewModel.Cluster_Branch = ucbList;
                    }
                    else
                    {
                        var cnb = await _dbi.UserCity_Network_Branch
                        .Where(x => x.UserId == id)
                        .Include(x => x.City)
                        .Include(x => x.Network)
                        .Include(x => x.Branch)
                        .ToListAsync();

                        var ucnbList = new List<UserCity_Network_Branch>();
                        for (int i = 0; i < cnb.Count; i++)
                        {
                            var ucnb = new UserCity_Network_Branch();
                            ucnb.UserId = id;
                            ucnb.CityId = Convert.ToInt32(cnb[i].CityId);
                            ucnb.City = cnb[i].City;
                            ucnb.NetworkId = Convert.ToInt32(cnb[i].NetworkId);
                            ucnb.Network = cnb[i].Network;
                            ucnb.BranchId = Convert.ToInt32(cnb[i].BranchId);
                            ucnb.Branch = cnb[i].Branch;
                            ucnbList.Add(ucnb);
                        }
                        viewModel.City_Network_Branch = ucnbList;
                    }


                    return Json(viewModel);

                }
                else
                    return Json(false);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }
}
