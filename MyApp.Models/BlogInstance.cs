using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class BlogInstance
    {
        [Key]
        public int InstanceId { get; set; }
        [Required]
        public string InstanceName { get; set; }
        public string InstanceDescription { get; set; }
        public DateTime OccuranceDate { get; set; }
        public int BlogIssueId { get; set; }
        [ValidateNever]
        public virtual ICollection<BlogIssue> InstanceOfIssue { get; set; }
    }
}
