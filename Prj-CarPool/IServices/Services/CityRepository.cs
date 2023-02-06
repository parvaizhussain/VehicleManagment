
using Utility.Models;
namespace Prj_CarPool.IServices.Services
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public CityRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}