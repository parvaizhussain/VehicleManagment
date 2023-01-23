using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Session.Commands.CreateSession
{
    public class CreateSessionDto
    {
       
        public int SessionID { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TemporaryOrignal { get; set; }
        public string TemporaryExtention { get; set; }
    }
}
