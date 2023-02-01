using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Persistence;
using Domain.Entities;
namespace Persistence.Repositories
{
    class AccessRightsRepository : BaseRepository<AccessRights>, IAccessRightsRepository
    {
        public AccessRightsRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}