using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Querys.GetByID
{
    public class Get_Driver_QueryHandler : IRequestHandler<Get_Driver_Query, Get_Driver_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_Driver_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_Driver_VM> Handle(Get_Driver_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Driver.GetAll(x => x.DriverID == request.DriverID, null, null);
            var CityDto = _mapper.Map<Get_Driver_VM>(model.FirstOrDefault());

            return CityDto;
        }
    }
}