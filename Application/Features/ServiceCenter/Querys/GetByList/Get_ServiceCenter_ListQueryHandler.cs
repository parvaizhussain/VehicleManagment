using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ServiceCenter.Querys.GetByList
{
    public class Get_ServiceCenter_ListQueryHandler : IRequestHandler<Get_ServiceCenter_ListQuery, List<Get_ServiceCenter_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_ServiceCenter_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_ServiceCenter_ListVM>> Handle(Get_ServiceCenter_ListQuery request, CancellationToken cancellationToken)
        {
            var allCity = (await _unitOfWork.ServiceCenter.GetAll(null, null, "VehicleCompany"));
            return _mapper.Map<List<Get_ServiceCenter_ListVM>>(allCity);
        }
    }
}