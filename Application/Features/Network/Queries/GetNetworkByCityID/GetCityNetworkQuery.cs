using Application.Features.Network.Queries.GetNetworkByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Queries.GetNetworkByCityID
{
    public class GetCityNetworkQuery : IRequest<List<GetNetworkVM>>
    {
        public int CityId { get; set; }
    }
}
