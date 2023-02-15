using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.FuelCard.Querys.GetByList
{
    public class Get_FuelCard_ListQueryHandler : IRequestHandler<Get_FuelCard_ListQuery, List<Get_FuelCard_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_FuelCard_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_FuelCard_ListVM>> Handle(Get_FuelCard_ListQuery request, CancellationToken cancellationToken)
        {
            var allfuelcard = (await _unitOfWork.FuelCard.GetAll(null, null, null));
            return _mapper.Map<List<Get_FuelCard_ListVM>>(allfuelcard.Where(x=> x.IsDeleted == false));
        }
    }
}