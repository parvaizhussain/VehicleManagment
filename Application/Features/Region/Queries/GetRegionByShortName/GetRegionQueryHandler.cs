using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Region.Queries.GetRegionByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Region.Queries.GetRegionByShortName
{
    public class GetRegionByShortNameQueryHandler : IRequestHandler<GetRegionByShortNameQuery, GetRegionVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRegionByShortNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetRegionVM> Handle(GetRegionByShortNameQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Region.ListAllAsync()).Where(x=>x.NormalizedName == request.ShortName).FirstOrDefault();
            var RegionDto = _mapper.Map<GetRegionVM>(model);

            return RegionDto;
        }
    }
}
