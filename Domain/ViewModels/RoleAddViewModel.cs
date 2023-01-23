using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.ViewModels
{
    public class RoleAddViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Name", Prompt = "Name")]

        public string Name { get; set; }

        public string ShortName { get; set; }
         

        public int GroupId { get; set; }
       
       
    }
}
