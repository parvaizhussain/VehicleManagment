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

namespace Application.Features.Branch.Queries.GetBranchByID
{
    public class GetBranchByIDQueryHandler : IRequestHandler<GetBranchQuery, GetBranchVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBranchByIDQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetBranchVM> Handle(GetBranchQuery request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Branch.GetAll(x=>x.BranchId == request.BranchId,null, "Network");
            var BranchDto = _mapper.Map<GetBranchVM>(model.FirstOrDefault());

            return BranchDto;
        }
    }
}
