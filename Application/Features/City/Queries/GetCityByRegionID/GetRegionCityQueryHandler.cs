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

namespace Application.Features.City.Queries.GetRegionCityByID
{
    public class GetRegionCityByIDQueryHandler : IRequestHandler<GetRegionCityQuery, List<GetCityVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRegionCityByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetCityVM>> Handle(GetRegionCityQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.City.GetAll(x=>x.RegionId == request.RegionId,null, "Region")).ToList();
            var CityDto = _mapper.Map<List<GetCityVM>>(model);

            return CityDto;
        }
    }
}
