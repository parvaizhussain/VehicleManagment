using Application.Contracts.IUOW;
using Application.Features.Receipt.Command.Create;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Receipt.Command.Create
{
    public class Create_Receipt_CommandsHandler : IRequestHandler<Create_Receipt_Commands, Create_Receipt_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_Receipt_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_Receipt_CommandsResponse> Handle(Create_Receipt_Commands request, CancellationToken cancellationToken)
        {
            var createReceiptCommandResponse = new Create_Receipt_CommandsResponse();

            var validator = new Create_Receipt_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createReceiptCommandResponse.Success = false;
                createReceiptCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createReceiptCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createReceiptCommandResponse.Success)
            {
                var Receipt = _mapper.Map<Domain.Entities.Receipt>(request);
                Receipt = await _unitOfWork.Receipt.AddAsync(Receipt);
                Receipt = (Domain.Entities.Receipt)await _unitOfWork.Commit(Receipt, "Insert", "Receipts");
                createReceiptCommandResponse._Create_Receipt_Dto = _mapper.Map<Create_Receipt_Dto>(Receipt);
            }

            return createReceiptCommandResponse;
        }

    }
}
