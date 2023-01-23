using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class FuelCardRepository : BaseRepository<FuelCard>, IFuelCardRepository
    {
        public FuelCardRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
