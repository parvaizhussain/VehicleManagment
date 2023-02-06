using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Airport.Querys.GetByID
{
    public class Get_Airport_QueryHandler : IRequestHandler<Get_Airport_Query, Get_Airport_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_Airport_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_Airport_VM> Handle(Get_Airport_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Airport.GetAll(x => x.AirportID == request.AirportID, null, "Region,City");
            var AirportDto = _mapper.Map<Get_Airport_VM>(model.FirstOrDefault());

            return AirportDto;
        }
    }
}