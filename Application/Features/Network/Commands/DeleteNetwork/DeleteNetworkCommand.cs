using Application.Features.Network.Queries.GetNetworkByID;
using MediatR;
using System;

namespace Application.Features.Network.Commands.DeleteNetwork
{
    public class DeleteNetworkCommand : IRequest<GetNetworkVM>
    {
        public int NetworkId { get; set; }
    }
}
