using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleDetails.Querys.GetByList
{
    public class Get_VehicleDetails_ListQueryHandler : IRequestHandler<Get_VehicleDetails_ListQuery, List<Get_VehicleDetails_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_VehicleDetails_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_VehicleDetails_ListVM>> Handle(Get_VehicleDetails_ListQuery request, CancellationToken cancellationToken)
        {
            var allCity = (await _unitOfWork.VehicleDetails.GetAll(null, null, "VehicleBrands,Region"));
            return _mapper.Map<List<Get_VehicleDetails_ListVM>>(allCity);
        }
    }
}
