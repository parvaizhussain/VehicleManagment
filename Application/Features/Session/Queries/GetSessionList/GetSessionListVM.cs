using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Session.Queries.GetSessionList
{
    public class GetSessionListVM
    {
        public int SessionID { get; set; }
        public int? RegionId { get; set; }
        public Domain.Entities.Region Region { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TemporaryOrignal { get; set; }
        public string TemporaryExtention { get; set; }

        public bool IsDeleted { get; set; }
    }
}
