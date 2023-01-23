using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Querys.GetByID
{
    public class Get_VehicleCompany_QueryHandler : IRequestHandler<Get_VehicleCompany_Query, Get_VehicleCompany_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_VehicleCompany_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_VehicleCompany_VM> Handle(Get_VehicleCompany_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.VehicleCompany.GetAll(x => x.VehicleCompanyID == request.VehicleCompanyId, null, null);
            var CityDto = _mapper.Map<Get_VehicleCompany_VM>(model.FirstOrDefault());

            return CityDto;
        }
    }
}