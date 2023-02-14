using Prj_CarPool.Handlers;
using Prj_CarPool.IServices;
using Prj_CarPool.IServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prj_CarPool.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IDataAccessService, DataAccessService>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            services.AddSingleton<IBranchRepository,  BranchRepository>();
            services.AddSingleton<IVehicleCompanyRepository, VehicleCompanyRepository>();
            services.AddSingleton<IVehicleBrandRepository,VehicleBrandRepository>();
            services.AddSingleton<IVehicleDetailsRepository,VehicleDetailsRepository>();
            services.AddSingleton<IServiceCenterRepository,ServiceCenterRepository>();
            services.AddSingleton<IMaintainanceHistoryRepository,MaintainanceHistoryRepository>();
            services.AddSingleton<IRegionRepository,RegionRepository>();
            services.AddSingleton<IAccessRightsRepository,AccessRightsRepository>();
            services.AddSingleton<IAirportRepository, AirpotRepository>();
            services.AddSingleton<ICityRepository, CityRepository>();
            services.AddSingleton<IDriverRepository, DriverRepository>();
            services.AddSingleton<IFuelCardRepository, FuelCardRepository>();
            return services;
        }
    }
}
