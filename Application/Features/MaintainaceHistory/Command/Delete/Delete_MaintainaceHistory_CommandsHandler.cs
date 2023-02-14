using Application.Contracts.IUOW;
using Application.Features.MaintainaceHistory.Command.Delete;
using Application.Features.MaintainaceHistory.Querys.GetByID;
using Application.Features.ServiceCenter.Command.Delete;
using Application.Features.ServiceCenter.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiMaintainaceHistoryceCenter.Command.Delete
{
    public class Delete_MaintainaceHistory_CommandsHandler : IRequestHandler<Delete_MaintainaceHistory_Commands, Get_MaintainaceHistory_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_MaintainaceHistory_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_MaintainaceHistory_VM> Handle(Delete_MaintainaceHistory_Commands request, CancellationToken cancellationToken)
        {

            var VehicleDetailsToUpdate = await _unitOfWork.MaintainaceHistory.GetByIdAsync(request.MaintainaceHistoryId);
            if (VehicleDetailsToUpdate.IsDeleted)
                VehicleDetailsToUpdate.IsDeleted = false;
            else
                VehicleDetailsToUpdate.IsDeleted = true;
            await _unitOfWork.MaintainaceHistory.UpdateAsync(VehicleDetailsToUpdate);
            await _unitOfWork.Commit();

            var VehicleDetailsDto = _mapper.Map<Get_MaintainaceHistory_VM>(VehicleDetailsToUpdate);

            return VehicleDetailsDto;
        }
    }
}