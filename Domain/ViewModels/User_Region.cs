using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ViewModels
{
    public class User_Region
    {
        public int User_RegionId { get; set; }

        public string UserId { get; set; }

        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
