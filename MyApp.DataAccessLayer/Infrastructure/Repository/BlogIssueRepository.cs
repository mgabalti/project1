using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class BlogIssueRepository : Repository<BlogIssue>, IBlogIssueRepository
    {
        private DatabaseContext _context;
        public BlogIssueRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }
        public void Update(BlogIssue blogIssue)
        {
           var iss =  _context.BlogIssues.FirstOrDefault(x=>x.IssueId == blogIssue.IssueId);
            if(iss != null)
            {
                iss.IssueId = blogIssue.IssueId;    
                iss.IssueTitle = blogIssue.IssueTitle;
                iss.IssueDescription= blogIssue.IssueDescription;

            }
        }
    }
}
