using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class BlogIssueVM
    {
        public BlogIssue BlogIssue { get;set; } = new BlogIssue();
        public IEnumerable<BlogIssue> BlogIssues { get;set; } = new List<BlogIssue>();
    }
    
}
