using Application.Contracts.IUOW;
using Application.Exceptions;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Booking.Command.Update
{
    public class Update_booking_CommadsHandler : IRequestHandler<Update_booking_Commads>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Update_booking_CommadsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(Update_booking_Commads request, CancellationToken cancellationToken)
        {

            var BookingToUpdate = await _unitOfWork.Booking.GetByIdAsync(request.BookingMID);

            if (BookingToUpdate == null)
            {
                throw new NotFoundException(nameof(Booking), request.BookingMID);
            }

            var validator = new Update_booking_CommadsValidators();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, BookingToUpdate, typeof(Update_booking_Commads), typeof(Domain.Entities.BookingMaster));

            await _unitOfWork.Booking.UpdateAsync(BookingToUpdate);
            await _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}