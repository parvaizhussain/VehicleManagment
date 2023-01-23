using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Department.Queries.GetDepartmentByID
{
    public class GetDepartmentQuery : IRequest<GetDepartmentVM>
    {
        public int DepartmentId { get; set; }
    }
}
