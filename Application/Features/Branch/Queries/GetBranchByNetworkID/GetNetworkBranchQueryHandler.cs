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

namespace Application.Features.Branch.Queries.GetBranchByNetworkID
{
    public class GetNetworkBranchQueryHandler : IRequestHandler<GetNetworkBranchQuery, List<GetBranchVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNetworkBranchQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetBranchVM>> Handle(GetNetworkBranchQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Branch.GetAll(x=>x.NetworkId == request.NetworkId, null, "Network");
            var BranchDto = _mapper.Map<List<GetBranchVM>>(model);

            return BranchDto;
        }
    }
}
