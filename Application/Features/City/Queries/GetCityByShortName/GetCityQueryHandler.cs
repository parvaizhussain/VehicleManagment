using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.City.Queries.GetCityByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.City.Queries.GetCityByShortName
{
    public class GetCityByShortNameQueryHandler : IRequestHandler<GetCityByShortNameQuery, GetCityVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityByShortNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetCityVM> Handle(GetCityByShortNameQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.City.ListAllAsync()).Where(x=>x.NormalizedName == request.ShortName).FirstOrDefault();
            var CityDto = _mapper.Map<GetCityVM>(model);

            return CityDto;
        }
    }
}
