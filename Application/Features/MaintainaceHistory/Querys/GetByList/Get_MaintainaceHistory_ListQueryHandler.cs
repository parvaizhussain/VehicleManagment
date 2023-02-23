using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Querys.GetByList
{
    public class Get_MaintainaceHistory_ListQueryHandler : IRequestHandler<Get_MaintainaceHistory_ListQuery, List<Get_MaintainaceHistory_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_MaintainaceHistory_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_MaintainaceHistory_ListVM>> Handle(Get_MaintainaceHistory_ListQuery request, CancellationToken cancellationToken)
        {
            var allCity = (await _unitOfWork.MaintainaceHistory.GetAll(null, null, "ServiceCenter"));
            return _mapper.Map<List<Get_MaintainaceHistory_ListVM>>(allCity);
        }
    }
}