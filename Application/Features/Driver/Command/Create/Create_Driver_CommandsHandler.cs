using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Driver.Command.Create
{
    public class Create_Driver_CommandsHandler : IRequestHandler<Create_Driver_Commands, Create_Driver_CommandsResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public Create_Driver_CommandsHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<Create_Driver_CommandsResponse> Handle(Create_Driver_Commands request, CancellationToken cancellationToken)
        {
            var createDriverCommandResponse = new Create_Driver_CommandsResponse();

            var validator = new Create_Driver_CommandsValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createDriverCommandResponse.Success = false;
                createDriverCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createDriverCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createDriverCommandResponse.Success)
            {
                var Driver = _mapper.Map<Domain.Entities.Driver>(request);
                Driver = await _unitOfWork.Driver.AddAsync(Driver);
                Driver = (Domain.Entities.Driver)await _unitOfWork.Commit(Driver, "Insert", "Drivers");
                createDriverCommandResponse._Create_Driver_Dto = _mapper.Map<Create_Driver_Dto>(Driver);
            }

            return createDriverCommandResponse;
        }

    }
}
