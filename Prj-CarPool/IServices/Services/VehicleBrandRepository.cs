
using Utility.Models;
namespace Prj_CarPool.IServices.Services
{
    public class VehicleBrandRepository : Repository<VehicleBrands>, IVehicleBrandRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public VehicleBrandRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}