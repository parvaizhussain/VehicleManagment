using Application.Contracts.IUOW;
using Application.Features.Receipt.Command.Delete;
using Application.Features.Receipt.Querys.GetByID;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Command.Delete
{
    public class Delete_Receipt_CommandsHandler : IRequestHandler<Delete_Receipt_Commands, Get_Receipt_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Delete_Receipt_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_Receipt_VM> Handle(Delete_Receipt_Commands request, CancellationToken cancellationToken)
        {

            var DeletetoUpdate = await _unitOfWork.Receipt.GetByIdAsync(request.ReceiptId);
            if (DeletetoUpdate.IsDeleted)
                DeletetoUpdate.IsDeleted = false;
            else
                DeletetoUpdate.IsDeleted = true;
            await _unitOfWork.Receipt.UpdateAsync(DeletetoUpdate);
            await _unitOfWork.Commit();

            var ReceiptDto = _mapper.Map<Get_Receipt_VM>(DeletetoUpdate);

            return ReceiptDto;
        }


    }
}

