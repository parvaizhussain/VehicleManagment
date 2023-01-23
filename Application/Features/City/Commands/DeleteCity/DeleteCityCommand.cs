using Application.Features.City.Queries.GetCityByID;
using MediatR;
using System;

namespace Application.Features.City.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<GetCityVM>
    {
        public int CityId { get; set; }
    }
}
