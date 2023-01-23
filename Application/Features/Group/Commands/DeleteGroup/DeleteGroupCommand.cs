using Application.Features.Group.Queries.GetGroupByID;
using MediatR;
using System;

namespace Application.Features.Group.Commands.DeleteGroup
{
    public class DeleteGroupCommand : IRequest<GetGroupVM>
    {
        public int GroupId { get; set; }
    }
}
