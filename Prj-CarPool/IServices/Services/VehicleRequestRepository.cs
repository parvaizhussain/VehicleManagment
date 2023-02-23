using Utility.Models;
namespace Prj_CarPool.IServices.Services
{
    public class VehicleRequestRepository : Repository<VehicleRequest>, IVehicleRequestRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public VehicleRequestRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}