using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ServiceCenterRepository : BaseRepository<ServiceCenter>, IServiceCenterRepository
    {
        public  ServiceCenterRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
