using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Booking.Querys.GetByID
{
    public class Get_booking_QueryHandler : IRequestHandler<Get_booking_Query, Get_booking_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_booking_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_booking_VM> Handle(Get_booking_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Booking.GetAll(x => x.BookingMID == request.BookingMID, null, "BookingMasters");
            var BookingDto = _mapper.Map<Get_booking_VM>(model.FirstOrDefault());

            return BookingDto;
        }
    }
}