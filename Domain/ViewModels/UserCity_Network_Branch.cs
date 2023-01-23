using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.ViewModels
{
    public class UserCity_Network_Branch
    {
        public string UserId { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public int NetworkId { get; set; }
        public Network Network { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
