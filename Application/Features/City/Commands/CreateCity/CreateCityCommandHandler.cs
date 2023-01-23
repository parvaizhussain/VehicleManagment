using AutoMapper;
using Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Contracts.IUOW;
namespace Application.Features.City.Commands.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityCommandResponse>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CreateCityCommandResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var createCityCommandResponse = new CreateCityCommandResponse();

            var validator = new CreateCityCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCityCommandResponse.Success = false;
                createCityCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    createCityCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (createCityCommandResponse.Success)
            {
                var City = _mapper.Map<Domain.Entities.City>(request);
                City = await _unitOfWork.City.AddAsync(City);
                City = (Domain.Entities.City)await _unitOfWork.Commit(City,"Insert","City");
                createCityCommandResponse.City = _mapper.Map<CreateCityDto>(City);
            }

            return createCityCommandResponse;
        }

    }
}
