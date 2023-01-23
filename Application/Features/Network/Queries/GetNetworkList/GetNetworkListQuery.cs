using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Queries.GetNetworkList
{
    public class GetNetworkListQuery : IRequest<List<GetNetworkListVM>>
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string NormalizedName { get; set; }
        public int CityId { get; set; }
    }
}

