using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.City.Queries.GetCityByID
{
    public class GetCityQuery : IRequest<GetCityVM>
    {
        public int CityId { get; set; }
    }
}
