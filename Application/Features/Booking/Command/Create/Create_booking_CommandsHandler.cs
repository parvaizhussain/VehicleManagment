using Application.Contracts.IUOW;
using Application.Features.Booking.Command.Create;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Booking.Command.Create
{
    public class Create_booking_CommandsHandler : IRequestHandler<Create_booking_Commands, Create_booking_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_booking_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_booking_CommandsResponse> Handle(Create_booking_Commands request, CancellationToken cancellationToken)
        {
            var Create_booking_CommandsResponse = new Create_booking_CommandsResponse();

            var validator = new Create_booking_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                Create_booking_CommandsResponse.Success = false;
                Create_booking_CommandsResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    Create_booking_CommandsResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (Create_booking_CommandsResponse.Success)
            {
                try
                {

                
                var booking = _mapper.Map<Domain.Entities.BookingMaster>(request);
                booking = await _unitOfWork.Booking.AddAsync(booking);
                booking = (Domain.Entities.BookingMaster)await _unitOfWork.Commit(booking, "Insert", "BookingMasters");
                Create_booking_CommandsResponse._Create_booking_Dto = _mapper.Map<Create_booking_Dto>(booking);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return Create_booking_CommandsResponse;
        }

    }
}
