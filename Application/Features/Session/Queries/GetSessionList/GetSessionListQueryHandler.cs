using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Session.Queries.GetSessionList
{
    public class GetSessionListQueryHandler : IRequestHandler<GetSessionListQuery, List<GetSessionListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSessionListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetSessionListVM>> Handle(GetSessionListQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _unitOfWork.Session.GetAll(null, null, "Region")).OrderBy(x => x.Name);
            return _mapper.Map<List<GetSessionListVM>>(allCategories);
        }
    }
}
