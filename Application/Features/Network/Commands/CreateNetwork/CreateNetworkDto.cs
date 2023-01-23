using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Commands.CreateNetwork
{
    public class CreateNetworkDto
    {
        public string NetworkName { get; set; }

        public string NormalizedName { get; set; }

        public Domain.Entities.City City { get; set; }
    }
}
