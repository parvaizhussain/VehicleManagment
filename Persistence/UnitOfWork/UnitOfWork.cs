using Application.Contracts.IUOW;
using Application.Contracts.Persistence;
using Domain.Entities;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.UOW
{
    public class UnitOfWork : IAsyncUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ApplicationDbContext _dbContextErr;
        private bool disposedValue;

        public UnitOfWork(ApplicationDbContext dbContext, ApplicationDbContext dbContextErr)
        {
            _dbContext = dbContext;
            _dbContextErr = dbContextErr;
            User = new UserRepository(_dbContext);
            Region = new RegionRepository(_dbContext);
            Branch = new BranchRepository(_dbContext);
            City = new CityRepository(_dbContext);
            Department = new DepartmentRepository(_dbContext);
            Group = new GroupRepository(_dbContext);
            Network = new NetworkRepository(_dbContext);
            Session = new SessionRepository(_dbContext);
           
            Driver= new DriverRepository(_dbContext);
            FuelCard= new FuelCardRepository(_dbContext);
            Airport= new AirportRepository(_dbContext);
            VehicleBrands = new VehicleBrandsRepository(_dbContext);
            VehicleCompany= new VehicleCompanyRepository(_dbContext);
            VehicleDetails = new VehicleDetailsRepository(_dbContext);  
            ServiceCenter=new ServiceCenterRepository(_dbContext);  
            MaintainaceHistory =  new MaintainaceHistoryRepository(_dbContext);
            AccessRights = new AccessRightsRepository(_dbContext);
            VehicleRequest = new VehicleRequestRepository(_dbContext);
            Booking = new BookingRepository(_dbContext);
        }
        public IUserRepository User { get; set; }
        public IRegionRepository Region { get; set; }
        public IBranchRepository Branch { get; set; }
        public ICityRepository City { get; set; }
        public IDepartmentRepository Department { get; set; }
        public IGroupRepository Group { get; set; }
        public INetworkRepository Network { get; set; }
        public ISessionRepository Session { get; set; }
        public IDriverRepository Driver { get; set; }
        public IFuelCardRepository FuelCard { get; set; }
        public IAirportRepository Airport { get; set; }
        public IVehicleBrandsRepository VehicleBrands { get; set; }
        public IVehicleCompanyRepository VehicleCompany { get; set; }
        public IVehicleDetailsRepository VehicleDetails{ get; set; }
        public IServiceCenterRepository ServiceCenter{ get; set; }
        public IMaintainaceHistoryRepository MaintainaceHistory{ get; set; }
        public IAccessRightsRepository AccessRights{ get; set; }
        public IVehicleRequestRepository VehicleRequest { get; set; }
        public IBookingRepository Booking { get; set; }





        public async Task<object> Commit(object obj)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return obj;
        }
        public async Task<object> Commit(List<object> obj)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                }
            }
            return obj;
        }
        public async Task<object> Commit(object obj, string action, string controller)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {

                    await _dbContext.SaveChangesAsync();
                    transaction.Commit();


                }
                catch (Exception ex)
                {

                    transaction.Rollback();
                    throw;
                }
            }
            return obj;
        }
        public async Task Commit()
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<object> RemoveRow(object obj)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Remove(obj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return obj;
        }
        public async Task<object> RemoveList(IQueryable<object> obj)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.RemoveRange(obj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return obj;
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}


