using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Group.Commands.CreateGroup
{
    public class CreateGroupDto
    {
        public string GroupName { get; set; }

        public string NormalizedName { get; set; }

        public Domain.Entities.Department Department { get; set; }
    }
}
