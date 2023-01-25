using Application.Contracts.IUOW;
using Application.Features.VehicleBrands.Command.Delete;
using Application.Features.VehicleBrands.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Command.Delete
{
    public class Delete_VehicleBrands_CommandsHandler : IRequestHandler<Delete_VehicleBrands_Commands, Get_VehicleBrands_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_VehicleBrands_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_VehicleBrands_VM> Handle(Delete_VehicleBrands_Commands request, CancellationToken cancellationToken)
        {

            var VehicleCompanyToUpdate = await _unitOfWork.VehicleBrands.GetByIdAsync(request.VehicleBrandId);
            if (VehicleCompanyToUpdate.IsDeleted)
                VehicleCompanyToUpdate.IsDeleted = false;
            else
                VehicleCompanyToUpdate.IsDeleted = true;
            await _unitOfWork.VehicleBrands.UpdateAsync(VehicleCompanyToUpdate);
            await _unitOfWork.Commit();

            var VehicleCompanyDto = _mapper.Map<Get_VehicleBrands_VM>(VehicleCompanyToUpdate);

            return VehicleCompanyDto;
        }
    }
}