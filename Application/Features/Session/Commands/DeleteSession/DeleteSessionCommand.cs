using Application.Features.Session.Queries.GetSessionByID;
using MediatR;
using System;

namespace Application.Features.Session.Commands.DeleteSession
{
    public class DeleteSessionCommand : IRequest<GetSessionVM>
    {
        public int SessionId { get; set; }
    }
}
