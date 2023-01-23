using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Department.Commands.CreateDepartment
{
    public class CreateDepartmentDto
    {
        public string DepartmentName { get; set; }
        public string NormalizedName { get; set; }

    }
}
