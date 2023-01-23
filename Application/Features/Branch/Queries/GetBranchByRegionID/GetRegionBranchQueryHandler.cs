using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Branch.Queries.GetBranchByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Branch.Queries.GetBranchByRegionID
{
    public class GetRegionBranchQueryHandler : IRequestHandler<GetRegionBranchQuery, object>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRegionBranchQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<object> Handle(GetRegionBranchQuery request, CancellationToken cancellationToken)
        {
            var Cities = (await _unitOfWork.City.ListAllAsync()).Where(x => x.RegionId == request.RegionId).Select(x => x.CityId).ToArray();
            var Networks = (await _unitOfWork.Network.ListAllAsync()).Where(x=> Cities.Contains(x.CityId)).Select(x => x.NetworkId).ToArray();
            var Branches = (await _unitOfWork.Branch.ListAllAsync()).Where(x => Networks.Contains(x.NetworkId)).Select(x=> new { x.BranchId, x.BranchName }).ToList();
            //var BranchDto = _mapper.Map<List<GetBranchVM>>(model);

            return Branches;
        }
    }
}
