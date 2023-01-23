using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Persistence;
using Domain.Entities;
namespace Persistence.Repositories
{
    class NetworkRepository : BaseRepository<Network>, INetworkRepository
    {
        public NetworkRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
