using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Network.Queries.GetNetworkByID
{
    public class GetNetworkVM
    {
        public int NetworkId { get; set; }
        public string NetworkName { get; set; }
        public string NormalizedName { get; set; }

        public bool IsDeleted { get; set; }
        public Domain.Entities.City City { get; set; }
    }
}

