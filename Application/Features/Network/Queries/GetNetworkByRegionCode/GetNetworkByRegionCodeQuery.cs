using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Queries.GetNetworkByRegionCode
{
    public class GetNetworkByRegionCodeQuery : IRequest<List<GetNetworkByRegionCodeVM>>
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string NormalizedName { get; set; }
        public string RegionCode { get; set; }
        public int CityId { get; set; }
    }
}

