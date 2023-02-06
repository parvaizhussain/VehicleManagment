using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Querys.GetByList
{
    public class Get_Airport_ListQueryHandler : IRequestHandler<Get_Airport_ListQuery, List<Get_Airport_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_Airport_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_Airport_ListVM>> Handle(Get_Airport_ListQuery request, CancellationToken cancellationToken)
        {
            var allAirport = (await _unitOfWork.Airport.GetAll(null, null, "Region,City"));
            return _mapper.Map<List<Get_Airport_ListVM>>(allAirport);
        }
    }
}