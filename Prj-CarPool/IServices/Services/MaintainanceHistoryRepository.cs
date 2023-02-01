using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
    public class MaintainanceHistoryRepository : Repository<MaintainaceHistory>, IMaintainanceHistoryRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public MaintainanceHistoryRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}