using System;
using System.Collections.Generic;
using System.Text;
using Application.Contracts.Persistence;
using Domain.Entities;
namespace Persistence.Repositories
{
    class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}