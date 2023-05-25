using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _Context;
        public ICategoryRepository categoryRepository { get; private set; }
        public IBlogInstanceRepository blogInstanceRepository { get; private set; }
        public IBlogIssueRepository blogIssueRepository { get; private set; }
        public IBlogPostRepository blogPostRepository { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {

            _Context = context;
            categoryRepository = new CategoryRepository(context);
            blogInstanceRepository= new BlogInstanceRepository(context);
            blogIssueRepository= new BlogIssueRepository(context);
            blogPostRepository= new BlogPostRepository(context);
        }

    public void save()
        {
            _Context.SaveChanges();
        }
    }
}
