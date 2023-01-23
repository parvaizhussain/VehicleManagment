using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
    public class VehicleCompanyRepository : Repository<VehicleCompany>, IVehicleCompanyRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public VehicleCompanyRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}