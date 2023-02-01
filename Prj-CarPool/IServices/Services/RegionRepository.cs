using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public RegionRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}