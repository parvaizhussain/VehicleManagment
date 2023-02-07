using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
	public class DriverRepository : Repository<Driver>, IDriverRepository
	{
		private readonly IHttpClientFactory _clientFactory;
		public DriverRepository(IHttpClientFactory clientFactory) : base(clientFactory)
		{
			_clientFactory = clientFactory;
		}
	}
}