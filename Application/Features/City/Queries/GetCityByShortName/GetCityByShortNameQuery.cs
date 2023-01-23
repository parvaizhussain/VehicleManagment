using Application.Features.City.Queries.GetCityByID;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.City.Queries.GetCityByShortName
{
    public class GetCityByShortNameQuery : IRequest<GetCityVM>
    {
        public string ShortName { get; set; }
    }
}
