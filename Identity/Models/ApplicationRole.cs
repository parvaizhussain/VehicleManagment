using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;

namespace Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
