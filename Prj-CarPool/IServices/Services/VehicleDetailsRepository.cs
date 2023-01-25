using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
    public class VehicleDetailsRepository : Repository<Set_VehicleDetails>, IVehicleDetailsRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public VehicleDetailsRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}