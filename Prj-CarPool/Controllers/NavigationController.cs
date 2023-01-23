using Prj_CarPool.Extensions;
using Prj_CarPool.IServices;
using Domain.ViewModels;
using Identity;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Identity;
using System.Data;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class NavigationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ApplicationIdentityDbContext _dbi;
        private readonly IDataAccessService _dataAccessService;
        private readonly ILogger<NavigationController> _logger;
        private readonly IMemoryCache _memoryCache;
        public NavigationController(
                ApplicationDbContext db,
                ApplicationIdentityDbContext dbi,
                IDataAccessService dataAccessService,
                ILogger<NavigationController> logger,
                IMemoryCache memoryCache)
        {
            _db= db;
            _dbi = dbi;
            _dataAccessService = dataAccessService;
            _logger = logger;
            _memoryCache = memoryCache;
        }
        public IActionResult Index()
        {
            ViewBag.JsonUserData = _memoryCache.Get(SharedBag.UserAccountDetail);
            var navigationViewModel = new List<NavigationMenuViewModel>();
            try
            {
                var navigations = _dbi.NavigationMenu.Include(x => x.ParentNavigationMenu).ToList();
                foreach (var item in navigations)
                {
                    navigationViewModel.Add(new NavigationMenuViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        ControllerName = item.ControllerName,
                        Visible = item.Visible,
                        CssClass = item.CssClass,
                        DisplayOrder = item.DisplayOrder,
                        ParentMenuId = item.ParentNavigationMenu != null ? item.ParentNavigationMenu.Id : 0,
                        ParentMenuName = item.ParentNavigationMenu != null ? item.ParentNavigationMenu.Name : ""
                    });
                }
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
            }

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = navigationViewModel.OrderByDescending(x=>x.Id) });

            ViewBag.JsonData = json;

            return View(navigationViewModel);
        }

        [HttpPost]
        public IActionResult MenuList()
        {
            try
            {
                var navigations = _dbi.NavigationMenu.ToList();
                if (navigations != null)
                    return Json(navigations);
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
                return null;
            }


        }

        [HttpPost]
        public IActionResult MenuValList()
        {
            try
            {
                var NavigationMenuValueViewModel = new List<NavigationMenuValueViewModel>();
                var navigations = _dbi.NavigationMenu.ToList();
                foreach (var item in navigations)
                {
                    NavigationMenuValueViewModel.Add(new NavigationMenuValueViewModel()
                    {
                        value = item.Id,
                        Name = item.Name,
                        ActionName = item.ActionName,
                        ControllerName = item.ControllerName,   
                        DisplayOrder= item.DisplayOrder,
                        Visible= item.Visible,
                        ButtonClass = item.ButtonClass,
                        CssClass = item.CssClass,
                        ParentMenuId = item.ParentMenuId

                    });
                }
                    if (NavigationMenuValueViewModel != null)
                    return Json(NavigationMenuValueViewModel);
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
                return null;
            }

        }

        [HttpPost]
        public IActionResult IconList()
        {
            try
            {
                var setIcons = _db.SetIcons.ToList();
                if (setIcons != null)
                    return Json(setIcons);
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
                return null;
            }


        }

        [HttpPost]
        public async Task<IActionResult> CreateNavigation(NavigationMenuViewModel viewModel)
        {
            try
                {
                //ModelState["ParentNavigationMenu"].ValidationState = ModelValidationState.Unvalidated;
                if (ModelState.IsValid)
                {

                    var navigationMenu = new NavigationMenu
                    {
                        Id = viewModel.Id,
                        Name = viewModel.Name,
                        ControllerName = viewModel.ControllerName,
                        ParentMenuId = viewModel.ParentMenuId,
                        DisplayOrder = viewModel.DisplayOrder,
                        Visible = viewModel.Visible,
                        CssClass = viewModel.CssClass,
                        //Permitted = viewModel.Permitted,
                        ActionName = "Index"


                    };

                    _dbi.NavigationMenu.Add(navigationMenu);
                    await _dbi.SaveChangesAsync();
                    
                    var navigationViewModel = new List<NavigationMenuViewModel>();
                    try
                    {
                        var navigations = _dbi.NavigationMenu.Include(x => x.ParentNavigationMenu).ToList();
                        foreach (var item in navigations)
                        {
                            navigationViewModel.Add(new NavigationMenuViewModel()
                            {
                                Id = item.Id,
                                Name = item.Name,
                                ControllerName = item.ControllerName,
                                Visible = item.Visible,
                                DisplayOrder = item.DisplayOrder,
                                CssClass = item.CssClass,
                                ParentMenuId = item.ParentNavigationMenu != null ? item.ParentNavigationMenu.Id : 0,
                                ParentMenuName = item.ParentNavigationMenu != null ? item.ParentNavigationMenu.Name : ""
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex, ex.GetBaseException().Message);
                    }

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = navigationViewModel.OrderByDescending(x => x.Id) });


                    return Json(new {datasuccess = true, json = json });
                }
                else
                    return Json(false);
            }
            catch (Exception exs)
            {

                throw;
            }
        }

        [HttpPost]

        public async Task<IActionResult> EditNavigation(NavigationMenuViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var nav = _dbi.NavigationMenu.Where(x => x.Id == viewModel.Id).FirstOrDefault();

                    nav.Name = viewModel.Name;
                    nav.ControllerName = viewModel.ControllerName;
                    nav.ParentMenuId = viewModel.ParentMenuId == 0 ? null: viewModel.ParentMenuId;
                    nav.DisplayOrder = viewModel.DisplayOrder;
                    nav.Visible = viewModel.Visible;
                    nav.CssClass = viewModel.CssClass;
                    //nav.Permitted = viewModel.Permitted;
                    nav.ActionName = "Index";


                    await _dbi.SaveChangesAsync();

                    var navigationViewModel = new List<NavigationMenuViewModel>();
                    try
                    {
                        var navigations = _dbi.NavigationMenu.Include(x => x.ParentNavigationMenu).ToList();
                        foreach (var item in navigations)
                        {
                            navigationViewModel.Add(new NavigationMenuViewModel()
                            {
                                Id = item.Id,
                                Name = item.Name,
                                ControllerName = item.ControllerName,
                                Visible = item.Visible,
                                DisplayOrder = item.DisplayOrder,
                                ParentMenuId = item.ParentNavigationMenu != null ? item.ParentNavigationMenu.Id : 0,
                                CssClass = item.CssClass,
                                ParentMenuName = item.ParentNavigationMenu != null ? item.ParentNavigationMenu.Name : ""
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger?.LogError(ex, ex.GetBaseException().Message);
                    }

                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(new { data = navigationViewModel.OrderByDescending(x => x.Id) });


                    return Json(new { datasuccess = true, json = json });

                  //  return Json(true);
                }
                else
                    return Json(false);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult MenuListForSearch()
        {
            try
            {
                var navigations = _dbi.NavigationMenu.Select(x=> new { x.Name, x.ControllerName,x.CssClass}).ToList();
                              
                var userSearchViewModels = new List<UserSearchViewModel>();
                try
                {
                    var users = _dbi.Users.Select(x => new { x.FirstName, x.LastName, x.Email, x.AccessRights.AccessName }).ToList();
                    // var navigations = _dbi.NavigationMenu.Include(x => x.ParentNavigationMenu).ToList();
                    foreach (var item in users)
                    {
                        userSearchViewModels.Add(new UserSearchViewModel()
                        {
                            name = item.FirstName + " " + item.LastName,
                            subtitle = item.AccessName,
                            src = item.Email,
                            url = "Users"
                        });
                    }
                }
                catch (Exception ex)
                {
                    _logger?.LogError(ex, ex.GetBaseException().Message);
                }
                List<UserSearchViewModel> userSearch = new List<UserSearchViewModel>();

                if (navigations != null)
                    return Json(new { pages = navigations, files = userSearch, members = userSearchViewModels });
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, ex.GetBaseException().Message);
                return null;
            }


        }
    }
}
