using Domain.ViewModels;
using Identity;
using Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Prj_CarPool.Extensions
{
    public class CurrentUserDetail
    {
        private readonly ApplicationIdentityDbContext _dbi;
        private readonly ApplicationDbContext _db;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _session;

        public CurrentUserDetail(
             ApplicationIdentityDbContext dbi,
             ApplicationDbContext db,
             IMemoryCache memoryCache,
             IHttpContextAccessor session

         )
        {
            _db = db;
            _dbi = dbi;
            _memoryCache = memoryCache;
            _session = session;

        }

        public  async Task<object> GetUserDetail(string Name)
        
        {
            try
            {
                var cacheKey = Extensions.SharedBag.UserAccountDetail;
                UserViewModel UserDetail = new UserViewModel();
                string Session = "";
                if (_memoryCache.Get(cacheKey) == null)
                {
                    

                        var user = await _dbi.Users.Where(x => x.UserName == Name).Include(x => x.AccessRights).FirstOrDefaultAsync();
                        string UserId = user.Id;
                        if (user != null)
                        {
                            UserDetail.Id = UserId;
                            UserDetail.FirstName = user.FirstName;
                            UserDetail.LastName = user.LastName;
                            UserDetail.Email = user.Email;
                            //UserDetail.RegionId = user.RegionId;
                            //UserDetail.Region = user.Region;
                            UserDetail.AccessRightsId = user.AccessRightsId;
                            UserDetail.AccessRights = user.AccessRights;
                            UserDetail.pwd = user.pwd;
                            UserDetail.IsCluster = user.IsCluster;

                            var userRoleId = await _dbi.UserRoles.Where(x => x.UserId == UserId).Select(x => x.RoleId).FirstOrDefaultAsync();
                            var allRoles = await _dbi.Roles.Where(x => x.Id == userRoleId).Include(x => x.Group.Department).ToListAsync();
                            if (allRoles.Count > 0)
                            {
                                UserDetail.Roles = allRoles.Select(x => new RoleViewModel()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Group = x.Group
                                }).ToArray();
                            }

                            var r = await _dbi.User_Region.Where(x => x.UserId == UserId).Include(x => x.Region).ToListAsync();
                            var urList = new List<User_Region>();
                            for (int i = 0; i < r.Count; i++)
                            {
                                var ur = new User_Region();
                                ur.UserId = UserId;
                                ur.RegionId = Convert.ToInt32(r[i].RegionId);
                                ur.Region = r[i].Region;
                                urList.Add(ur);
                            }
                            UserDetail.User_Region = urList;

                            //if (user.RegionId != null)
                            //{                         
                            if (UserDetail.IsCluster)
                            {
                                var cb = await _dbi.Cluster_Branch
                                  .Where(x => x.UserId == UserId)
                                  .Include(x => x.Branch.Network.City)
                                  .ToListAsync();

                                var ucbList = new List<Cluster_Branch>();
                                for (int i = 0; i < cb.Count; i++)
                                {
                                    var ucb = new Cluster_Branch();
                                    ucb.UserId = UserId;
                                    ucb.BranchId = Convert.ToInt32(cb[i].BranchId);
                                    ucb.Branch = cb[i].Branch;
                                    ucbList.Add(ucb);
                                }
                                UserDetail.Cluster_Branch = ucbList;
                            }
                            else
                            {
                                var cnb = await _dbi.UserCity_Network_Branch
                                .Where(x => x.UserId == UserId)
                                .Include(x => x.City)
                                .Include(x => x.Network)
                                .Include(x => x.Branch)
                                .ToListAsync();

                                var ucnbList = new List<UserCity_Network_Branch>();
                                for (int i = 0; i < cnb.Count; i++)
                                {
                                    var ucnb = new UserCity_Network_Branch();
                                    ucnb.UserId = UserId;
                                    ucnb.CityId = Convert.ToInt32(cnb[i].CityId);
                                    ucnb.City = cnb[i].City;
                                    ucnb.NetworkId = Convert.ToInt32(cnb[i].NetworkId);
                                    ucnb.Network = cnb[i].Network;
                                    ucnb.BranchId = Convert.ToInt32(cnb[i].BranchId);
                                    ucnb.Branch = cnb[i].Branch;
                                    ucnbList.Add(ucnb);
                                }
                                UserDetail.City_Network_Branch = ucnbList;
                            }
                            // For Session
                            int CurrentYear = DateTime.Now.Year;
                            int CurrentMonth = DateTime.Now.Month;
                            List<Tuple<int,int?>> SessionIds = new List<Tuple<int, int?>>();
                            for (int a = 0; a < r.Count; a++)
                            {

                                if (CurrentMonth < 8)
                                    Session = Convert.ToString(CurrentYear - 1 + "-" + CurrentYear + " " + r[a].Region.NormalizedName);
                                else
                                    Session = Convert.ToString(CurrentYear + "-" + (CurrentYear + 1).ToString() + " " + r[a].Region.NormalizedName);

                                if (Session != null)
                                {
                                int SessionId = _db.Sessions.Where(x => x.Name == Session).Select(x => x.SessionID).FirstOrDefault();
                                int? regionID = _db.Sessions.Where(x => x.Name == Session).Select(x => x.RegionId).FirstOrDefault();
                                SessionIds.Add(new Tuple<int, int?>(SessionId, regionID));
                                UserDetail.SessionId = SessionIds;
                                }
                            }

                        }
                        var cacheExpiryOptions = new MemoryCacheEntryOptions
                        {
                            //AbsoluteExpiration = DateTime.Now.AddMinutes(20),
                            Priority = CacheItemPriority.High,
                            //SlidingExpiration = TimeSpan.FromMinutes(20)
                        };
                        _memoryCache.Set(cacheKey, JsonSerializer.Serialize(UserDetail), cacheExpiryOptions);
                        return _memoryCache.Get(cacheKey);
                        //}
                        //else
                        //    return null;
                    
                    
                }
                else
                    return _memoryCache.Get(cacheKey);


            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
