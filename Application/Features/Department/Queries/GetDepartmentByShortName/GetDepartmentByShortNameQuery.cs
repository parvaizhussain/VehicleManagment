using Application.Features.Department.Queries.GetDepartmentByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Department.Queries.GetDepartmentByShortName
{
    public class GetDepartmentByShortNameQuery : IRequest<GetDepartmentVM>
    {
        public string ShortName { get; set; }
    }
}
