using MediatR;
using System;

namespace Application.Features.Group.Commands.UpdateGroup
{
    public class UpdateGroupCommand : IRequest
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public string NormalizedName { get; set; }

        public int DepartmentId { get; set; }

    }
}
