using Application.Contracts.IUOW;
using Application.Features.Driver.Command.Delete;
using Application.Features.Driver.Querys.GetByID;
using Application.Features.ServiceCenter.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Command.Delete
{
    public class Delete_ServiceCenter_CommandsHandler : IRequestHandler<Delete_ServiceCenter_Commands, Get_ServiceCenter_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_ServiceCenter_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_ServiceCenter_VM> Handle(Delete_ServiceCenter_Commands request, CancellationToken cancellationToken)
        {

            var VehicleDetailsToUpdate = await _unitOfWork.ServiceCenter.GetByIdAsync(request.ServiceCenterId);
            if (VehicleDetailsToUpdate.IsDeleted)
                VehicleDetailsToUpdate.IsDeleted = false;
            else
                VehicleDetailsToUpdate.IsDeleted = true;
            await _unitOfWork.ServiceCenter.UpdateAsync(VehicleDetailsToUpdate);
            await _unitOfWork.Commit();

            var VehicleDetailsDto = _mapper.Map<Get_ServiceCenter_VM>(VehicleDetailsToUpdate);

            return VehicleDetailsDto;
        }
    }
}