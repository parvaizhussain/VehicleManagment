﻿using Prj_CarPool.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Prj_CarPool.ViewComponents
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IDataAccessService _dataAccessService;
        public NavigationMenuViewComponent(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _dataAccessService.GetMenuItemsAsync(HttpContext.User);

            return View(items);
        }
    }
}
