using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.City.Queries.GetCityList
{
    public class GetCityListQueryHandler : IRequestHandler<GetCityListQuery, List<GetCityListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetCityListVM>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
        {
            var allCity = (await _unitOfWork.City.GetAll(null,null,"Region"));
            return _mapper.Map<List<GetCityListVM>>(allCity.Where(x=> x.IsDeleted == false));
        }
    }
}
