using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleRequest.Querys.GetByList
{
    public class Get_VehicleRequest_ListQueryHandler : IRequestHandler<Get_VehicleRequest_ListQuery, List<Get_VehicleRequest_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_VehicleRequest_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_VehicleRequest_ListVM>> Handle(Get_VehicleRequest_ListQuery request, CancellationToken cancellationToken)
        {
            var allCity = (await _unitOfWork.VehicleRequest.GetAll(null, null, "Region"));
            return _mapper.Map<List<Get_VehicleRequest_ListVM>>(allCity);
        }
    }
}