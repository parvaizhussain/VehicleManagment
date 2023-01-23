using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Application.Models.Mail
{
    public class EmailInfo
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
}
