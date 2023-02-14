using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string pwd { get; set; }

        public int? AccessRightsId { get; set; }
        public AccessRights AccessRights {get; set;}

        public int? RegionId { get; set; }
        public Region Region { get; set; }

        public bool IsCluster { get; set; }
        public bool IsActive { get; set; }
        public byte[]? UserImage { get; set; }
    }
}
