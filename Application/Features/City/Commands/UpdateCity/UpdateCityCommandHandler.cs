using Application.Contracts.IUOW;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.City.Commands.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {

            var CityToUpdate = await _unitOfWork.City.GetByIdAsync(request.CityId);

            if (CityToUpdate == null)
            {
                throw new NotFoundException(nameof(City), request.CityId);
            }

            var validator = new UpdateCityCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, CityToUpdate, typeof(UpdateCityCommand), typeof(Domain.Entities.City));

            await _unitOfWork.City.UpdateAsync(CityToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}