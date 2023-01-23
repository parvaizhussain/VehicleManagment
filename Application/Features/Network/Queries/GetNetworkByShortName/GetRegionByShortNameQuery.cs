using Application.Features.Network.Queries.GetNetworkByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Queries.GetNetworkByShortName
{
    public class GetNetworkByShortNameQuery : IRequest<GetNetworkVM>
    {
        public string ShortName { get; set; }
    }
}
