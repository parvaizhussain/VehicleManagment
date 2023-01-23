using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Department.Queries.GetDepartmentList
{
    public class GetDepartmentListQuery : IRequest<List<GetDepartmentListVM>>
    {
    }
}
