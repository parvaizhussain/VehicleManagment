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

namespace Application.Features.Branch.Queries.GetBranchByShortName
{
    public class GetBranchByShortNameQueryHandler : IRequestHandler<GetBranchByShortNameQuery, GetBranchVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBranchByShortNameQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetBranchVM> Handle(GetBranchByShortNameQuery request, CancellationToken cancellationToken)
        {
            var model = (await _unitOfWork.Branch.ListAllAsync()).Where(x=>x.NormalizedName == request.ShortName).FirstOrDefault();
            var BranchDto = _mapper.Map<GetBranchVM>(model);

            return BranchDto;
        }
    }
}
