using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Querys.GetByID
{
    public class Get_VehicleRequest_QueryHandler : IRequestHandler<Get_VehicleRequest_Query, Get_VehicleRequest_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_VehicleRequest_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_VehicleRequest_VM> Handle(Get_VehicleRequest_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.VehicleRequest.GetAll(x => x.RequestID == request.RequestID, null, "Region");
            var CityDto = _mapper.Map<Get_VehicleRequest_VM>(model.FirstOrDefault());

            return CityDto;
        }
    }
}