using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.City.Queries.GetCityList
{
    public class GetCityListQuery : IRequest<List<GetCityListVM>>
    {

    }
}
