using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Queries.GetNetworkByID
{
    public class GetNetworkQuery : IRequest<GetNetworkVM>
    {
        public int NetworkId { get; set; }
    }
}
