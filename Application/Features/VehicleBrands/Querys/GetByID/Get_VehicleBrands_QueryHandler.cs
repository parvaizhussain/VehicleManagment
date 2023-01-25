using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleBrands.Querys.GetByID
{
    public class Get_VehicleBrands_QueryHandler : IRequestHandler<Get_VehicleBrands_Query, Get_VehicleBrands_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_VehicleBrands_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_VehicleBrands_VM> Handle(Get_VehicleBrands_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.VehicleBrands.GetAll(x => x.VehicleBrandId == request.VehicleBrandId, null, "VehicleCompany");
            var CityDto = _mapper.Map<Get_VehicleBrands_VM>(model.FirstOrDefault());

            return CityDto;
        }
    }
}