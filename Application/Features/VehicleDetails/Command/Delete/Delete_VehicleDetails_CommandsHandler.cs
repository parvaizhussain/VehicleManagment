using Application.Contracts.IUOW;
using Application.Features.VehicleDetails.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Command.Delete
{
    public class Delete_VehicleDetails_CommandsHandler : IRequestHandler<Delete_VehicleDetails_Commands, Get_VehicleDetails_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_VehicleDetails_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_VehicleDetails_VM> Handle(Delete_VehicleDetails_Commands request, CancellationToken cancellationToken)
        {

            var VehicleDetailsToUpdate = await _unitOfWork.VehicleDetails.GetByIdAsync(request.VehicleID);
            if (VehicleDetailsToUpdate.IsDeleted)
                VehicleDetailsToUpdate.IsDeleted = false;
            else
                VehicleDetailsToUpdate.IsDeleted = true;
            await _unitOfWork.VehicleDetails.UpdateAsync(VehicleDetailsToUpdate);
            await _unitOfWork.Commit();

            var VehicleDetailsDto = _mapper.Map<Get_VehicleDetails_VM>(VehicleDetailsToUpdate);

            return VehicleDetailsDto;
        }
    }
}