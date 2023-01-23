using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Region.Queries.GetRegionList
{
    public class GetRegionListQueryHandler : IRequestHandler<GetRegionListQuery, List<GetRegionListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRegionListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetRegionListVM>> Handle(GetRegionListQuery request, CancellationToken cancellationToken)
        {
            var allRegion = (await _unitOfWork.Region.ListAllAsync());
            return _mapper.Map<List<GetRegionListVM>>(allRegion);
        }
    }
}
