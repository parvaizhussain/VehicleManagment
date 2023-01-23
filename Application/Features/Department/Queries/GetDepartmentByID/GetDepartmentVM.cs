using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Department.Queries.GetDepartmentByID
{
    public class GetDepartmentVM
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string NormalizedName { get; set; }
    }
}
