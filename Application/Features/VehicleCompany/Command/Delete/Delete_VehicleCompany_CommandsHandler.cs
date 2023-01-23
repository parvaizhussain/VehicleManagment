using Application.Contracts.IUOW;

using Application.Features.VehicleCompany.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Command.Delete
{
    public class Delete_VehicleCompany_CommandsHandler : IRequestHandler<Delete_VehicleCompany_Commands, Get_VehicleCompany_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_VehicleCompany_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_VehicleCompany_VM> Handle(Delete_VehicleCompany_Commands request, CancellationToken cancellationToken)
        {

            var VehicleCompanyToUpdate = await _unitOfWork.VehicleCompany.GetByIdAsync(request.VehicleCompanyId);
            if (VehicleCompanyToUpdate.IsDeleted)
                VehicleCompanyToUpdate.IsDeleted = false;
            else
                VehicleCompanyToUpdate.IsDeleted = true;
            await _unitOfWork.VehicleCompany.UpdateAsync(VehicleCompanyToUpdate);
            await _unitOfWork.Commit();

            var VehicleCompanyDto = _mapper.Map<Get_VehicleCompany_VM>(VehicleCompanyToUpdate);

            return VehicleCompanyDto;
        }
    }
}