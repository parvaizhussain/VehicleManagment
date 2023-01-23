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

namespace Application.Features.Region.Queries.GetRegionByID
{
    public class GetRegionByIDQueryHandler : IRequestHandler<GetRegionQuery, GetRegionVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRegionByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetRegionVM> Handle(GetRegionQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Region.GetByIdAsync(request.RegionId);
            var RegionDto = _mapper.Map<GetRegionVM>(model);

            return RegionDto;
        }
    }
}
