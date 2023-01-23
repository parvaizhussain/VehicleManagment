using Application.Features.Region.Queries.GetRegionByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Region.Queries.GetRegionByShortName
{
    public class GetRegionByShortNameQuery : IRequest<GetRegionVM>
    {
        public string ShortName { get; set; }
    }
}
