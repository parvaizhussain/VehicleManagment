using MediatR;
using System;

namespace Application.Features.Session.Commands.CreateSession
{
    public class CreateSessionCommand : IRequest<CreateSessionCommandResponse>
    {
      
        
        public int RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TemporaryOrignal { get; set; }
        public string TemporaryExtention { get; set; }
    }
}
