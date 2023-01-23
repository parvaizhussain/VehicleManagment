using Application.Features.Group.Queries.GetGroupByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Group.Queries.GetGroupByShortName
{
    public class GetGroupByShortNameQuery : IRequest<GetGroupVM>
    {
        public string ShortName { get; set; }
    }
}
