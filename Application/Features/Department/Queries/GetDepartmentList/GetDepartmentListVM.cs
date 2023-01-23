using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Department.Queries.GetDepartmentList
{
    public class GetDepartmentListVM
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string NormalizedName { get; set; }
        public bool IsDeleted { get; set; }
    }
}


