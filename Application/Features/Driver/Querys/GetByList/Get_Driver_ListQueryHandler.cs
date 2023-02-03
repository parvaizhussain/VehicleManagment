using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Querys.GetByList
{
    public class Get_Driver_ListQueryHandler : IRequestHandler<Get_Driver_ListQuery, List<Get_Driver_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_Driver_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_Driver_ListVM>> Handle(Get_Driver_ListQuery request, CancellationToken cancellationToken)
        {
            var allCity = (await _unitOfWork.Driver.GetAll(null, null, null));
            return _mapper.Map<List<Get_Driver_ListVM>>(allCity);
        }
    }
}