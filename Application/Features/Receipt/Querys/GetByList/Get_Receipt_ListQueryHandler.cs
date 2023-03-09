using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Querys.GetByList
{
    public class Get_Receipt_ListQueryHandler : IRequestHandler<Get_Receipt_ListQuery, List<Get_Receipt_ListVM>>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_Receipt_ListQueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Get_Receipt_ListVM>> Handle(Get_Receipt_ListQuery request, CancellationToken cancellationToken)
        {
            var allReceipt = (await _unitOfWork.Receipt.GetAll(null, null, "Receipts"));
            return _mapper.Map<List<Get_Receipt_ListVM>>(allReceipt);
        }
    }
}