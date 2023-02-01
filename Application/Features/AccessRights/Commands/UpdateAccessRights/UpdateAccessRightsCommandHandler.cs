using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AccessRights.Commands.UpdateAccessRights
{
    public class UpdateAccessRightsCommandHandler : IRequestHandler<UpdateAccessRightsCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAccessRightsCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateAccessRightsCommand request, CancellationToken cancellationToken)
        {

            var accessRightsToUpdate = await _unitOfWork.AccessRights.GetByIdAsync(request.AccessId);

            if (accessRightsToUpdate == null)
            {
                throw new NotFoundException(nameof(AccessRights), request.AccessId);
            }

            var validator = new UpdateAccessRightsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, accessRightsToUpdate, typeof(UpdateAccessRightsCommand), typeof(Domain.Entities.AccessRights));

            await _unitOfWork.AccessRights.UpdateAsync(accessRightsToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}