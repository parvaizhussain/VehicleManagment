using Utility.Models;
namespace Prj_CarPool.IServices.Services
{
    public class AirpotRepository : Repository<Airport>, IAirportRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public AirpotRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}