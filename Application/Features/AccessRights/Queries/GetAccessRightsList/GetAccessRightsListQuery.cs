using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AccessRights.Queries.GetAccessRightsList
{
    public class GetAccessRightsListQuery : IRequest<List<GetAccessRightsListVM>>
    {
    }
}
