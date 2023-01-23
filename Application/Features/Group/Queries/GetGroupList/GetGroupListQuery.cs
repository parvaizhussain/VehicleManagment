using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Group.Queries.GetGroupList
{
    public class GetGroupListQuery : IRequest<List<GetGroupListVM>>
    {
    }
}
