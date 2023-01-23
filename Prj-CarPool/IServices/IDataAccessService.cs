using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Prj_CarPool.IServices
{
    public interface IDataAccessService
    {
        Task<List<NavigationMenuViewModel>> GetApprovalButtonsAsync(ClaimsPrincipal principal);
        Task<bool> GetMenuItemsAsync(ClaimsPrincipal ctx, string ctrl, string act);
        Task<List<NavigationMenuViewModel>> GetMenuItemsAsync(ClaimsPrincipal principal);
        Task<List<NavigationMenuViewModel>> GetPermissionsByRoleIdAsync(string id);
        Task<List<NavigationMenuValueViewModel>> GetPermissionsByRoleValueAsync(string id);

        Task<bool> SetPermissionsByRoleIdAsync(string id, IEnumerable<int> permissionIds);

    }
}
