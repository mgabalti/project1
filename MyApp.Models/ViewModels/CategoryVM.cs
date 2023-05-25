using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class CategoryVM
    {
        public PostCategory PostCategory { get; set; } = new PostCategory();
        public IEnumerable<PostCategory> PostCategories { get; set; } = new List<PostCategory>();
    }
}
