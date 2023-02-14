using Prj_CarPool.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Prj_CarPool.Handlers
{
	public class AuthorizationRequirement : IAuthorizationRequirement
	{
		public AuthorizationRequirement(string permissionName)
		{
			PermissionName = permissionName;
		}

		public string PermissionName { get; }
	}

	public class PermissionHandler : AuthorizationHandler<AuthorizationRequirement>
	{
		private readonly IDataAccessService _dataAccessService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public PermissionHandler(IDataAccessService dataAccessService,IHttpContextAccessor httpContextAccessor)
		{
			_dataAccessService = dataAccessService;
            _httpContextAccessor = httpContextAccessor;
		}

		protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationRequirement requirement)
		{
            var endpoint = _httpContextAccessor.HttpContext.GetEndpoint();
            var descriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
            var controllerName = descriptor.ControllerName;
            var actionName = descriptor.ActionName;
            if (context.User.Identity.IsAuthenticated)
            {
             //   endpoint.RoutePattern.RequiredValues.TryGetValue("controller", out var _controller);
               // endpoint.RoutePattern.RequiredValues.TryGetValue("action", out var _action);

              //  endpoint.RoutePattern.RequiredValues.TryGetValue("page", out var _page);
            //    endpoint.RoutePattern.RequiredValues.TryGetValue("area", out var _area);

                // Check if a parent action is permitted then it'll allow child without checking for child permissions
                if (!string.IsNullOrWhiteSpace(requirement?.PermissionName) && !requirement.PermissionName.Equals("Authorization"))
                {
                    actionName = requirement.PermissionName;
                }

                if (context.User.Identity.IsAuthenticated && controllerName != null && actionName != null &&
                    await _dataAccessService.GetMenuItemsAsync(context.User, controllerName.ToString(), actionName.ToString()))
                {
                    context.Succeed(requirement);
                }
            }
           

         //   if (context.User.Identity.IsAuthenticated && controllerName != null && actionName != null &&
        	//await _dataAccessService.GetMenuItemsAsync(context.User, controllerName.ToString(), actionName.ToString()))
         //   {


         //       context.Succeed(requirement);
         //   }

            await Task.CompletedTask;
		}
	}
}
