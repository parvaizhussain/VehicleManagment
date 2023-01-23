using Identity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class UserCity_Network_Branch 
    {
        [Key]

        public int City_Network_BranchId { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int? CityId { get; set; }

        public virtual City City { get; set; }

        public int? NetworkId { get; set; }

        public virtual Network Network { get; set; }

        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }

    }
}
