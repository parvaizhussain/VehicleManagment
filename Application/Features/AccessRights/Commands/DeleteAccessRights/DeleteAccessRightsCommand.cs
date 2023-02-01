using Application.Features.AccessRights.Queries.GetAccessRightsByID;
using MediatR;
using System;

namespace Application.Features.AccessRights.Commands.DeleteAccessRights
{
    public class DeleteAccessRightsCommand : IRequest<GetAccessRightsVM>
    {
        public int AccessId { get; set; }
    }
}
