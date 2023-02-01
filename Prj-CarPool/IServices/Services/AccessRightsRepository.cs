using Utility.Models;
namespace Prj_CarPool.IServices.Services
{
    public class AccessRightsRepository : Repository<AccessRight>, IAccessRightsRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public AccessRightsRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}