using Application.Contracts.IUOW;
using Application.Exceptions;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Command.Update
{
    public class Update_Airport_CommadsHandler : IRequestHandler<Update_Airport_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_Airport_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_Airport_Commads request, CancellationToken cancellationToken)
        {

            var VehicleBrandToUpdate = await _unitOfWork.Airport.GetByIdAsync(request.AirportID);

            if (VehicleBrandToUpdate == null)
            {
                throw new NotFoundException(nameof(Airport), request.AirportID);
            }

            var validator = new Update_Airport_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, VehicleBrandToUpdate, typeof(Update_Airport_Commads), typeof(Domain.Entities.Airport));

            await _unitOfWork.Airport.UpdateAsync(VehicleBrandToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}