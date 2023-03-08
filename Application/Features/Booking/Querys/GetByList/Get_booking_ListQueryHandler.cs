using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Booking.Querys.GetByList
{
    public class Get_booking_ListQueryHandler : IRequestHandler<Get_booking_ListQuery, List<Get_booking_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_booking_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_booking_ListVM>> Handle(Get_booking_ListQuery request, CancellationToken cancellationToken)
        {
            var allbookings = (await _unitOfWork.Booking.GetAll(null, null, "BookingMasters"));
            return _mapper.Map<List<Get_booking_ListVM>>(allbookings);
        }
    }
}