using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        private DatabaseContext _context;
        public BlogPostRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public void Update(BlogPost blogPost)
        {
            var bp = _context.BlogPost.FirstOrDefault(x => x.Id == blogPost.Id);
            if (bp != null)
            {
                bp.Id = blogPost.Id;
                bp.posttitle = blogPost.posttitle;
                bp.postbodyhtml = blogPost.postbodyhtml;
                bp.postimageurl = blogPost.postimageurl;
                bp.postpublishdate = DateTime.Now;
                bp.postpublish = blogPost.postpublish;
                bp.postauther = blogPost.postauther;
                bp.postcategory = blogPost.postcategory;

            }
        }
    }
}
