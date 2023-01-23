using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.City.Queries.GetCityByID
{
    public class GetCityByIDQueryHandler : IRequestHandler<GetCityQuery, GetCityVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCityVM> Handle(GetCityQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.City.GetAll(x=>x.CityId == request.CityId,null, "Region");
            var CityDto = _mapper.Map<GetCityVM>(model.FirstOrDefault());

            return CityDto;
        }
    }
}
