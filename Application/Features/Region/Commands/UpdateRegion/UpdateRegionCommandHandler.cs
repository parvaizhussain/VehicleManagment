using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Region.Commands.UpdateRegion
{
    public class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRegionCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateRegionCommand request, CancellationToken cancellationToken)
        {

            var RegionToUpdate = await _unitOfWork.Region.GetByIdAsync(request.RegionId);

            if (RegionToUpdate == null)
            {
                throw new NotFoundException(nameof(Region), request.RegionId);
            }

            var validator = new UpdateRegionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, RegionToUpdate, typeof(UpdateRegionCommand), typeof(Domain.Entities.Region));

            await _unitOfWork.Region.UpdateAsync(RegionToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}