using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Persistence;
using Domain.Entities;
namespace Persistence.Repositories
{
     class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}