using MediatR;
using System;

namespace Application.Features.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string NormalizedName { get; set; }
    }
}
