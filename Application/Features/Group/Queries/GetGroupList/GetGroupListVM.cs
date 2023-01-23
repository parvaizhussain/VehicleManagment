using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Group.Queries.GetGroupList
{
    public class GetGroupListVM
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string NormalizedName { get; set; }

        public Domain.Entities.Department Department { get; set; }

        public bool IsDeleted { get; set; }
    }
}


