using Application.Contracts.IUOW;
using Application.Features.Driver.Querys.GetByID;
using Application.Features.VehicleDetails.Command.Delete;
using Application.Features.VehicleDetails.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Command.Delete
{
    public class Delete_Driver_CommandsHandler : IRequestHandler<Delete_Driver_Commands, Get_Driver_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_Driver_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_Driver_VM> Handle(Delete_Driver_Commands request, CancellationToken cancellationToken)
        {

            var VehicleDetailsToUpdate = await _unitOfWork.Driver.GetByIdAsync(request.DriverID);
            if (VehicleDetailsToUpdate.IsDeleted)
                VehicleDetailsToUpdate.IsDeleted = false;
            else
                VehicleDetailsToUpdate.IsDeleted = true;
            await _unitOfWork.Driver.UpdateAsync(VehicleDetailsToUpdate);
            await _unitOfWork.Commit();

            var VehicleDetailsDto = _mapper.Map<Get_Driver_VM>(VehicleDetailsToUpdate);

            return VehicleDetailsDto;
        }
    }
}