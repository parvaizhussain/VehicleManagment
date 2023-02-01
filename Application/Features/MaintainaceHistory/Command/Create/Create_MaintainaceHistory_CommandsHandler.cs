using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MaintainaceHistory.Command.Create
{
    public class Create_MaintainaceHistory_CommandsHandler : IRequestHandler<Create_MaintainaceHistory_Commands, Create_MaintainaceHistory_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_MaintainaceHistory_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_MaintainaceHistory_CommandsResponse> Handle(Create_MaintainaceHistory_Commands request, CancellationToken cancellationToken)
        {
            var createMaintainaceHistoryCommandResponse = new Create_MaintainaceHistory_CommandsResponse();

            var validator = new Create_MaintainaceHistory_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createMaintainaceHistoryCommandResponse.Success = false;
                createMaintainaceHistoryCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createMaintainaceHistoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createMaintainaceHistoryCommandResponse.Success)
            {
                var MaintainaceHistory = _mapper.Map<Domain.Entities.MaintainaceHistory>(request);
                MaintainaceHistory = await _unitOfWork.MaintainaceHistory.AddAsync(MaintainaceHistory);
                MaintainaceHistory = (Domain.Entities.MaintainaceHistory)await _unitOfWork.Commit(MaintainaceHistory, "Insert", "MaintainaceHistory");
                createMaintainaceHistoryCommandResponse._MaintainaceHistory_Dto = _mapper.Map<Create_MaintainaceHistory_Dto>(MaintainaceHistory);
            }

            return createMaintainaceHistoryCommandResponse;
        }

    }
}
