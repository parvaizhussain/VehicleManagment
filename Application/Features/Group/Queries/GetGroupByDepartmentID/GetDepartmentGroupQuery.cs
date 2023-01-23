using Application.Features.Group.Queries.GetGroupByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Group.Queries.GetDepartmentGroupByID
{
    public class GetDepartmentGroupQuery : IRequest<List<GetGroupVM>>
    {
        public int DepartmentId { get; set; }
    }
}
