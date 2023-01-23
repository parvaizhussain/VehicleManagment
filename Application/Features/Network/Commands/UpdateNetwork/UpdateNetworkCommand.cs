using MediatR;
using System;

namespace Application.Features.Network.Commands.UpdateNetwork
{
    public class UpdateNetworkCommand : IRequest
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }

        public string NormalizedName { get; set; }

        public int CityId { get; set; }
    }
}
