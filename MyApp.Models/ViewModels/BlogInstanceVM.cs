using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class BlogInstanceVM
    {
        public BlogInstance blogInstance { get; set; }
        public IEnumerable<BlogInstance> blogInstances { get;set; } = new List<BlogInstance>();
        [ValidateNever]
        public IEnumerable<SelectListItem> InstanceOfIssue { get; set; }

    }
    
}
