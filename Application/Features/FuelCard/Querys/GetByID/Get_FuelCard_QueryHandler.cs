using Application.Contracts.IUOW;
using AutoMapper;
using MediatR;

namespace Application.Features.FuelCard.Querys.GetByID
{
    public class Get_FuelCard_QueryHandler : IRequestHandler<Get_FuelCard_Query, Get_FuelCard_VM>
    {
        private readonly IAsyncUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Get_FuelCard_QueryHandler(IMapper mapper, IAsyncUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Get_FuelCard_VM> Handle(Get_FuelCard_Query request, CancellationToken cancellationToken)
        {
            var model = await _unitOfWork.FuelCard.GetAll(x => x.CardID == request.CardID, null, null);
            var FuelDto = _mapper.Map<Get_FuelCard_VM>(model.FirstOrDefault());

            return FuelDto;
        }
    }
}