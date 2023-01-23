using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Queries.GetNetworkList
{
    public class GetNetworkListVM
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string NormalizedName { get; set; }
        public Domain.Entities.City City { get; set; }
        public bool IsDeleted { get; set; }
    }
}



