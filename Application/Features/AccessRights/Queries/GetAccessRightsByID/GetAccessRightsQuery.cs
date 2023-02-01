using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AccessRights.Queries.GetAccessRightsByID
{
    public class GetAccessRightsQuery : IRequest<GetAccessRightsVM>
    {
        public int AccessRightsId { get; set; }
    }
}
