using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VehicleCompanyRepository : BaseRepository<VehicleCompany>, IVehicleCompanyRepository
    {
        public VehicleCompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
