using Application.Contracts.IUOW;
using Application.Exceptions;
using Application.Features.Branch.Queries.GetBranchByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Branch.Commands.DeleteBranch
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, GetBranchVM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBranchCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetBranchVM> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {

            var BranchToUpdate =  await _unitOfWork.Branch.GetByIdAsync(request.BranchId);
            if (BranchToUpdate.IsDeleted)
                BranchToUpdate.IsDeleted = false; 
            else
                BranchToUpdate.IsDeleted = true;

            await _unitOfWork.Branch.UpdateAsync(BranchToUpdate);
            await _unitOfWork.Commit();

            var BranchDto = _mapper.Map<GetBranchVM>(BranchToUpdate);

            return BranchDto;
        }
    }
}