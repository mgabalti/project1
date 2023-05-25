using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class BlogsFurtherParts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FurtherPartBodyHtml { get; set; }
        public string FurtherPartType { get; set; }
        [Required]
        public int FurtherPartOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<BlogPost> blogPosts { get; set; }


    }
}
