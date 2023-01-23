using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Branch.Queries.GetBranchList
{
    public class GetBranchListQueryHandler : IRequestHandler<GetBranchListQuery, List<GetBranchListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBranchListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetBranchListVM>> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
        {
            var allBranch = (await _unitOfWork.Branch.GetAll(null,null,"Network"));
            return _mapper.Map<List<GetBranchListVM>>(allBranch);
        }
    }
}
