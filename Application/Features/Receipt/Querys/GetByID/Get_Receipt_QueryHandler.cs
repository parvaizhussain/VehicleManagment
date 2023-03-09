using Application.Contracts.IUOW;

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Querys.GetByID
{
    public class Get_Receipt_QueryHandler : IRequestHandler<Get_Receipt_Query, Get_Receipt_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_Receipt_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_Receipt_VM> Handle(Get_Receipt_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.Receipt.GetAll(x => x.ReceiptId == request.ReceiptId, null, "Receipts");
            var ReceiptDto = _mapper.Map<Get_Receipt_VM>(model.FirstOrDefault());

            return ReceiptDto;
        }
    }
}