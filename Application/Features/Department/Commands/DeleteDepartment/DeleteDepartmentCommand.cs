using Application.Features.Department.Queries.GetDepartmentByID;
using MediatR;
using System;

namespace Application.Features.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<GetDepartmentVM>
    {
        public int DepartmentId { get; set; }
    }
}
