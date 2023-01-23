using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Group.Queries.GetGroupByID
{
    public class GetGroupQuery : IRequest<GetGroupVM>
    {
        public int GroupId { get; set; }
    }
}
