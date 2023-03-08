using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    class BookingRepository : BaseRepository<BookingMaster>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}