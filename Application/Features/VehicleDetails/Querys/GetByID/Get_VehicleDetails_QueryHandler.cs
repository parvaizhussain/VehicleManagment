using Application.Contracts.IUOW;
using Application.Features.VehicleBrands.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Querys.GetByID
{
    public class Get_VehicleDetails_QueryHandler : IRequestHandler<Get_VehicleDetails_Query, Get_VehicleDetails_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_VehicleDetails_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_VehicleDetails_VM> Handle(Get_VehicleDetails_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.VehicleDetails.GetAll(x => x.VehicleID == request.VehicleID, null, "VehicleBrands,Region");
            var _VehicleDetailsDto = _mapper.Map<Get_VehicleDetails_VM>(model.FirstOrDefault());

            return _VehicleDetailsDto;
        }
    }
}