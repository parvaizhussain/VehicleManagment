using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
namespace Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, CreateBranchCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBranchCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateBranchCommandResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var createBranchCommandResponse = new CreateBranchCommandResponse();

            var validator = new CreateBranchCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createBranchCommandResponse.Success = false;
                createBranchCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createBranchCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createBranchCommandResponse.Success)
            {
                var Branch = _mapper.Map<Domain.Entities.Branch>(request);
                Branch = await _unitOfWork.Branch.AddAsync(Branch);
                Branch = (Domain.Entities.Branch)await _unitOfWork.Commit(Branch);
                createBranchCommandResponse.Branch = _mapper.Map<CreateBranchDto>(Branch);
            }

            return createBranchCommandResponse;
        }

    }
}
