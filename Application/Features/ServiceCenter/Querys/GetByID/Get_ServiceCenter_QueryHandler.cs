using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Querys.GetByID
{
    public class Get_ServiceCenter_QueryHandler : IRequestHandler<Get_ServiceCenter_Query, Get_ServiceCenter_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_ServiceCenter_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_ServiceCenter_VM> Handle(Get_ServiceCenter_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.ServiceCenter.GetAll(x => x.ServiceCenterId == request.ServiceCenterId, null, "VehicleCompany");
            var CityDto = _mapper.Map<Get_ServiceCenter_VM>(model.FirstOrDefault());

            return CityDto;
        }
    }
}