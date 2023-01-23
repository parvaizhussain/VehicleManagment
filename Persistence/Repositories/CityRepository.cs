using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Persistence;
using Domain.Entities;
namespace Persistence.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
