using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
    public class FuelCardRepository : Repository<FuelCard>, IFuelCardRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public FuelCardRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}