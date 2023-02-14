using Prj_CarPool.Extensions;
using Prj_CarPool.Models;
using Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prj_CarPool.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationIdentityDbContext _dbi;
        private readonly ApplicationDbContext _db;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _session;
        public HomeController(
               ILogger<HomeController> logger,
               ApplicationIdentityDbContext dbi,
               ApplicationDbContext db,
               IMemoryCache memoryCache,
               IHttpContextAccessor session
       )
        {
            _logger = logger;
            _dbi = dbi;
            _db = db;
            _memoryCache = memoryCache;
            _session = session;
        }
        public async Task<IActionResult> Index()
        {
            var UserData = new CurrentUserDetail(_dbi, _db, _memoryCache, _session);
            ViewBag.JsonUserData = await UserData.GetUserDetail(User.Identity.Name);

            if (ViewBag.JsonUserData != null)
            {
                return View();
            }
            else
                return Redirect("/Identity/Account/Login");
        }
    }
}
