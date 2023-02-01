
using Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.IUOW
{
    public interface IAsyncUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IRegionRepository Region { get; }
        public IBranchRepository Branch { get;}
        public ICityRepository City { get; }
        public IDepartmentRepository Department { get; }
        public IGroupRepository Group { get;}
        public INetworkRepository Network { get;}
        public ISessionRepository Session { get; }
        public IFuelCardRepository FuelCard { get; }
        public IAirportRepository Airport  { get; }
        public IDriverRepository Driver { get; }
        public IVehicleBrandsRepository VehicleBrands { get; }
        public IVehicleCompanyRepository VehicleCompany { get; }
        public IVehicleDetailsRepository VehicleDetails { get; }
        public IServiceCenterRepository ServiceCenter { get; }
        public IMaintainaceHistoryRepository MaintainaceHistory { get; }
        public IAccessRightsRepository AccessRights { get; }


        Task<object> Commit(object obj);
        Task<object> Commit(List<object> obj);
        Task<object> Commit(object obj, string action, string controller);
        Task<object> RemoveRow(object obj);
        Task<object> RemoveList(IQueryable<object> obj);
        Task Commit();
    }
}
