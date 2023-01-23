using MediatR;
using System;


namespace Application.Features.Group.Commands.CreateGroup
{
   public  class CreateGroupCommand : IRequest<CreateGroupCommandResponse>
    {
        public string GroupName { get; set; }

        public string NormalizedName { get; set; }

        public int DepartmentId { get; set; }
 
    }
}
