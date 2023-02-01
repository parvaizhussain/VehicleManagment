using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
    public class ServiceCenterRepository : Repository<ServiceCenter>, IServiceCenterRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public ServiceCenterRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}