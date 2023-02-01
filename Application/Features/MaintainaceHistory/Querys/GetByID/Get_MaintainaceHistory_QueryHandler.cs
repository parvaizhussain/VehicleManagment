using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Querys.GetByID
{
    public class Get_MaintainaceHistory_QueryHandler : IRequestHandler<Get_MaintainaceHistory_Query, Get_MaintainaceHistory_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_MaintainaceHistory_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_MaintainaceHistory_VM> Handle(Get_MaintainaceHistory_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.MaintainaceHistory.GetAll(x => x.MaintainaceHistoryId == request.MaintainaceHistoryId, null, null);
            var CityDto = _mapper.Map<Get_MaintainaceHistory_VM>(model.FirstOrDefault());

            return CityDto;
        }
    }
}