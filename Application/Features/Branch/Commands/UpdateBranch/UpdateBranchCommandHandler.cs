using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Branch.Commands.UpdateBranch
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBranchCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {

            var BranchToUpdate = await _unitOfWork.Branch.GetByIdAsync(request.BranchId);

            if (BranchToUpdate == null)
            {
                throw new NotFoundException(nameof(Branch), request.BranchId);
            }

            var validator = new UpdateBranchCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, BranchToUpdate, typeof(UpdateBranchCommand), typeof(Domain.Entities.Branch));

            await _unitOfWork.Branch.UpdateAsync(BranchToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}