using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Group.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGroupCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {

            var GroupToUpdate = await _unitOfWork.Group.GetByIdAsync(request.GroupId);

            if (GroupToUpdate == null)
            {
                throw new NotFoundException(nameof(Group), request.GroupId);
            }

            var validator = new UpdateGroupCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, GroupToUpdate, typeof(UpdateGroupCommand), typeof(Domain.Entities.Group));

            await _unitOfWork.Group.UpdateAsync(GroupToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}