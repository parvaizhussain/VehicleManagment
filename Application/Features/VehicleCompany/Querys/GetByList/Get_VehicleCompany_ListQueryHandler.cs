using Application.Contracts.IUOW;
using Application.Features.City.Queries.GetCityList;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.VehicleCompany.Querys.GetByList
{
    public class Get_VehicleCompany_ListQueryHandler : IRequestHandler<Get_VehicleCompany_ListQuery, List<Get_VehicleCompany_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_VehicleCompany_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_VehicleCompany_ListVM>> Handle(Get_VehicleCompany_ListQuery request, CancellationToken cancellationToken)
        {
            var allCity = (await _unitOfWork.VehicleCompany.GetAll(null, null, null)) ;
            return _mapper.Map<List<Get_VehicleCompany_ListVM>>(allCity);
        }
    }
}
