using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class BlogIssue
    {
        [Key]
        public int IssueId { get; set; }
        [Required]
        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }
    }
}
