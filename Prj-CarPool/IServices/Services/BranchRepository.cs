using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Utility.Models;

namespace Prj_CarPool.IServices.Services
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public BranchRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}