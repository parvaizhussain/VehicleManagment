using Application.Contracts.IUOW;
using Application.Features.Booking.Command.Delete;
using Application.Features.Booking.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.booking.Command.Delete
{
 


public class Delete_booking_CommandsHandler : IRequestHandler<Delete_booking_Commands, Get_booking_VM>
{
    private readonly IAsyncUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Delete_booking_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Get_booking_VM> Handle(Delete_booking_Commands request, CancellationToken cancellationToken)
    {

        var DeletetoUpdate = await _unitOfWork.Booking.GetByIdAsync(request.BookingMID);
        if (DeletetoUpdate.IsDeleted)
            DeletetoUpdate.IsDeleted = false;
        else
            DeletetoUpdate.IsDeleted = true;
        await _unitOfWork.Booking.UpdateAsync(DeletetoUpdate);
        await _unitOfWork.Commit();

        var bookingDto = _mapper.Map<Get_booking_VM>(DeletetoUpdate);

        return bookingDto;
    }


}
}

