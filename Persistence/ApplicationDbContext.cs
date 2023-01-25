using Application.Contracts;
using Domain.Common;
using Domain.ViewModels;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }


        public DbSet<DatabaseLog> DatabaseLogs { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Network> Network { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SetIcon> SetIcons { get; set; }
        //public DbSet<VehicleSpecification> VehicleSpecifications { get; set; }
       // public DbSet<VehicleDetail> VehicleDetails { get; set; }
        public DbSet<FuelCard> FuelCards { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<VehicleCompany> VehicleCompanies { get; set; }
        public DbSet<VehicleBrands> VehicleBrands { get; set; }
        public DbSet<Set_VehicleDetails> Set_VehicleDetails { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);


        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = _loggedInUserService.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
