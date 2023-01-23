using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Session : AuditableEntity
    {
        [Key]
        public int SessionID { get; set; }
        public int? RegionId { get; set; }
        public virtual Region Region { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TemporaryOrignal { get; set; }
        public string TemporaryExtention { get; set; }

    }
}
