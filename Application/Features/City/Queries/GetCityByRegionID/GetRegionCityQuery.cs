using Application.Features.City.Queries.GetCityByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.City.Queries.GetRegionCityByID
{
    public class GetRegionCityQuery : IRequest<List<GetCityVM>>
    {
        public int RegionId { get; set; }
    }
}
