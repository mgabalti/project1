
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        public string posttitle { get; set; }
        public string postbodyhtml { get; set; }

        [ValidateNever]
        public string? postimageurl { get; set; }
        public DateTime postpublishdate { get; set; } = DateTime.Now;
        public Boolean postpublish { get; set; }
        public string postauther { get; set; }

        public string postcategory { get; set; }

        [ValidateNever]
        public virtual ICollection<PostCategory> category { get; set; }
        public string postIssue { get; set; }
        [ValidateNever]
        public virtual ICollection<BlogIssue> BlogIssues { get; set; }
        public string postInstance {get; set;}
        [ValidateNever]
        public virtual ICollection<BlogInstance> BlogInstances { get; set; }


    }
}
