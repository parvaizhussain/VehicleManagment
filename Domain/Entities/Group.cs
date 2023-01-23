using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Group : AuditableEntity
    {
        [Key]
        public int GroupId { get; set; }

        public string GroupName{ get; set; }

        public string NormalizedName { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

    }
}
