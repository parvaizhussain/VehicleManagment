using Application.Responses;

namespace Application.Features.Session.Commands.CreateSession
{
    public class CreateSessionCommandResponse : BaseResponse
    {
        public CreateSessionCommandResponse() : base()
        {

        }

        public CreateSessionDto SessionDto { get; set; }
    }
}
