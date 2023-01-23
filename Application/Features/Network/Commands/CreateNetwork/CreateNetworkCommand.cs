using MediatR;
using System;


namespace Application.Features.Network.Commands.CreateNetwork
{
   public  class CreateNetworkCommand : IRequest<CreateNetworkCommandResponse>
    {
        public string NetworkName { get; set; }

        public string NormalizedName { get; set; }

        public int CityId { get; set; }
    }
}
