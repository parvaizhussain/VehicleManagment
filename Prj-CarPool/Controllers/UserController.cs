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
using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Graph;

namespace Prj_CarPool.Controllers
{
    [Authorize]
   // [Route("[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        private readonly ApplicationIdentityDbContext _dbi;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<UserController> _logger;
        private readonly IMemoryCache _memoryCache;
        internal DbSet<UserViewModel> _dbSet;
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
        [Authorize("Authorization")]
        public async Task<IActionResult> Index()
        {
            var Data = _memoryCache.Get(SharedBag.UserAccountDetail);
            var UserData = JsonSerializer.Deserialize<UserViewModel>((string)Data);
            ViewBag.JsonUserData = Data;
            var userViewModel = new List<UserViewModel>();

            try
            {
               var newdata = await (from us in _dbi.Users
                                     join reg in _dbi.Region
                                     on us.RegionId equals reg.RegionId into _reg
                                     from reg in _reg.DefaultIfEmpty()
                                     where us.RegionId == UserData.RegionId
                                     select us).Where(x => x.IsDeleted == false).ToListAsync();
               
                var userView = new List<UserViewModel>();
                var userFinddetails = _dbi.Users.Where(x => x.IsDeleted == false).Include(x => x.AccessRights).Include(x => x.Region).ToList();

                foreach (var item in userFinddetails)
                {
                    var userRoleId = await _dbi.UserRoles.Where(x => x.UserId == item.Id).Select(x => x.RoleId).FirstOrDefaultAsync();
                    var allRoles = await _dbi.Roles.Where(x => x.Id == userRoleId).ToListAsync();
                    userView.Add(new UserViewModel()
                    {

                        UserName = item.UserName,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Id = item.Id,
                        AccessRightsId = item.AccessRightsId,
                        RegionId = item.RegionId,
                        IsActive = item.IsActive,
                        UserImage = item.UserImage,
                        AccessRights= item.AccessRights,
                        Region= item.Region,
                        Roles = allRoles.Select(x => new RoleViewModel()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Group = x.Group
                        }).ToArray()


                });

                }





                var userFinddetailsnew = userView;// _dbi.Users.Include(x => x.AccessRights).Include(x => x.Region).ToList();

                //var result = _dbi.Users.GroupJoin(_dbi.Region, maintbl => maintbl.RegionId, regiontbl => regiontbl.RegionId, (maintbl, regiontbl) => new { maintbl, regiontbl }).SelectMany(
                //    result => result.regiontbl,(result, regiontbl) => new { result.maintbl, regiontbl }).GroupJoin(
                //    _dbi.AccessRights, result => result.maintbl.AccessRightsId, accestbl => accestbl.AccessId, (result, accestbl) => new { result.maintbl, result.regiontbl, accestbl }).SelectMany(
                //    result => result.accestbl.DefaultIfEmpty(), (result, accestbl) => new { result.maintbl, result.regiontbl, accestbl });



                var users2 = userView;//await(from u in _dbi.Users where u.RegionId == UserData.RegionId select u).ToListAsync();

               // users.AddRange(users2);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = users2 });

                ViewBag.JsonData = json;

               // ViewBag.Users = users2.Distinct().ToList();

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
            }

            return View(userViewModel);
           // return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserViewModel userViewModel)
        {
            try
            {
                var applicationUser = new ApplicationUser
                {
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    UserName = userViewModel.UserName,
                    Email = userViewModel.Email,
                    AccessRightsId = userViewModel.AccessRightsId,
                    RegionId = userViewModel.RegionId,
                    UserImage = userViewModel.UserImage,
                    EmailConfirmed = true,
                    pwd = userViewModel.Password
                };

                //if (userViewModel.RegionId == 0)
                //	applicationUser.RegionId = null;

                var user = await _userManager.FindByEmailAsync(applicationUser.Email);

                if (user == null)
                {
                    var CreateUser = await _userManager.CreateAsync(applicationUser, userViewModel.Password);
                    if (CreateUser.Succeeded)
                    {
                        await _userManager.AddToRolesAsync(applicationUser, userViewModel.Roles.Select(x => x.Name));
                        var LastAddedUserId = await _dbi.Users.Where(x => x.Email == applicationUser.Email).Select(x => x.Id).FirstOrDefaultAsync();


                        var userView = new List<UserViewModel>();
                        var userFinddetails = _dbi.Users.Where(x => x.IsDeleted == false).Include(x => x.AccessRights).Include(x => x.Region).ToList();

                        foreach (var item in userFinddetails)
                        {
                            var userRoleId = await _dbi.UserRoles.Where(x => x.UserId == item.Id).Select(x => x.RoleId).FirstOrDefaultAsync();
                            var allRoles = await _dbi.Roles.Where(x => x.Id == userRoleId).ToListAsync();
                            userView.Add(new UserViewModel()
                            {

                                UserName = item.UserName,
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                Email = item.Email,
                                Id = item.Id,
                                AccessRightsId = item.AccessRightsId,
                                RegionId = item.RegionId,
                                IsActive = item.IsActive,
                                UserImage = item.UserImage,
                                AccessRights = item.AccessRights,
                                Region = item.Region,
                                Roles = allRoles.Select(x => new RoleViewModel()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Group = x.Group
                                }).ToArray()


                            });

                        }

                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = userView });

                        return Json(new { Messeage = "User Created Successfully!", Created = true, dataresult = json });
                    }
                    else
                        return Json(new { Messeage = "User Not Created!", Created = false });
                }
                else
                    return Json(new { Messeage = "User Already Exists!", Created = false });


            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(UserViewModel viewModel)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var user = await _dbi.Users
                      //.Include(x => x.Region)
                      .Include(x => x.AccessRights)
                      .Where(x => x.Id == viewModel.Id).FirstOrDefaultAsync();
                    //var user = await _userManager.FindByIdAsync(viewModel.Id);
                    user.FirstName = viewModel.FirstName;
                    user.LastName = viewModel.LastName;
                    user.UserName = viewModel.UserName;
                    user.Email = viewModel.Email;
                    user.AccessRightsId = viewModel.AccessRightsId;
                    user.RegionId = viewModel.RegionId;
                    user.IsActive = viewModel.IsActive;
                   
                    _dbi.SaveChanges();

                    var userRoles = await _userManager.GetRolesAsync(user);

                    await _userManager.RemoveFromRolesAsync(user, userRoles);
                    await _userManager.AddToRolesAsync(user, viewModel.Roles.Select(x => x.Name));
                    var userView = new List<UserViewModel>();
                    var userFinddetails = _dbi.Users.Where(x => x.IsDeleted == false).Include(x => x.AccessRights).Include(x => x.Region).ToList();

                    foreach (var item in userFinddetails)
                    {
                        var userRoleId = await _dbi.UserRoles.Where(x => x.UserId == item.Id).Select(x => x.RoleId).FirstOrDefaultAsync();
                        var allRoles = await _dbi.Roles.Where(x => x.Id == userRoleId).ToListAsync();
                        userView.Add(new UserViewModel()
                        {

                            UserName = item.UserName,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            Email = item.Email,
                            Id = item.Id,
                            AccessRightsId = item.AccessRightsId,
                            RegionId = item.RegionId,
                            IsActive = item.IsActive,
                            UserImage = item.UserImage,
                            AccessRights = item.AccessRights,
                            Region = item.Region,
                            Roles = allRoles.Select(x => new RoleViewModel()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Group = x.Group
                            }).ToArray()


                        });

                    }

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = userView });
                    return Json(new { Messeage = "User Edited Successfully!", Edited = true, dataresult = json });
                }
                else
                    return Json(new { Edited = false });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string Uid)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var user = await _dbi.Users
                      //.Include(x => x.Region)
                      .Include(x => x.AccessRights)
                      .Where(x => x.Id == Uid).FirstOrDefaultAsync();
                    
                    user.IsDeleted = true;

                    _dbi.SaveChanges();

                    var userRoles = await _userManager.GetRolesAsync(user);

                    await _userManager.RemoveFromRolesAsync(user, userRoles);
                   
                    var userView = new List<UserViewModel>();
                    var userFinddetails = _dbi.Users.Where(x=>x.IsDeleted).Include(x => x.AccessRights).Include(x => x.Region).ToList();

                    foreach (var item in userFinddetails)
                    {
                        var userRoleId = await _dbi.UserRoles.Where(x => x.UserId == item.Id).Select(x => x.RoleId).FirstOrDefaultAsync();
                        var allRoles = await _dbi.Roles.Where(x => x.Id == userRoleId).ToListAsync();
                        userView.Add(new UserViewModel()
                        {

                            UserName = item.UserName,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            Email = item.Email,
                            Id = item.Id,
                            AccessRightsId = item.AccessRightsId,
                            RegionId = item.RegionId,
                            IsActive = item.IsActive,
                            UserImage = item.UserImage,
                            AccessRights = item.AccessRights,
                            Region = item.Region,
                            Roles = allRoles.Select(x => new RoleViewModel()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Group = x.Group
                            }).ToArray()


                        });

                    }

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = userView });
                    return Json(new { Messeage = "User Edited Successfully!", Deleted = true, dataresult = json });
                }
                else
                    return Json(new { Deleted = false });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UserFind(string id)
        {
            var userView = new List<UserViewModel>();
            var userFinddetails = _dbi.Users.Where(x => x.IsDeleted == false).Include(x => x.AccessRights).Include(x => x.Region).Where(x => x.Id == id).ToList();

            foreach (var item in userFinddetails)
            {
                var userRoleId = await _dbi.UserRoles.Where(x => x.UserId == item.Id).Select(x => x.RoleId).FirstOrDefaultAsync();
                var allRoles = await _dbi.Roles.Where(x => x.Id == userRoleId).ToListAsync();
                userView.Add(new UserViewModel()
                {

                    UserName = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Id = item.Id,
                    AccessRightsId = item.AccessRightsId,
                    RegionId = item.RegionId,
                    IsActive = item.IsActive,
                    UserImage = item.UserImage,
                    AccessRights = item.AccessRights,
                    Region = item.Region,
                    Roles = allRoles.Select(x => new RoleViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Group = x.Group
                    }).ToArray()


                });

            }

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = userView });
            //var userFinddetails = _dbi.Users.Include(x=>x.AccessRights).Include(x=>x.Region).Where(x=>x.Id== id).FirstOrDefault();
            if(userView.Count > 0)
            {
                return Json(new {data = userView.FirstOrDefault()});

            }
            return Json("error");
        }

    }
}
