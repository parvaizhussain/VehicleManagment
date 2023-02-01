using Application.Features.AccessRights.Queries.GetAccessRightsByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.AccessRights.Queries.GetAccessRightsByShortName
{
    public class GetAccessRightsByShortNameQuery : IRequest<GetAccessRightsVM>
    {
        public string ShortName { get; set; }
    }
}
