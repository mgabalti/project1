using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class BlogPostVM 
    {
        public BlogPost blogPost { get; set; } = new BlogPost();
        [ValidateNever]
        public IEnumerable<BlogPost> blogPosts { get; set; } = new List<BlogPost>();
        [ValidateNever]
        public List<SelectListItem> selectLstItem { get; set; }
        [ValidateNever]
        public List<SelectListItem> blogIssueVM { get; set; }
        [ValidateNever]
        public List<SelectListItem> blogInstance { get; set; }


    }
}
