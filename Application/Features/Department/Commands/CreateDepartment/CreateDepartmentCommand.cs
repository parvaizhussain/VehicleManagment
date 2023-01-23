using MediatR;
using System;


namespace Application.Features.Department.Commands.CreateDepartment
{
   public  class CreateDepartmentCommand : IRequest<CreateDepartmentCommandResponse>
    {
        public string DepartmentName { get; set; }
        public string NormalizedName { get; set; }
    }
}
