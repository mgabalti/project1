using Microsoft.EntityFrameworkCore;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class BlogInstanceRepository : Repository<BlogInstance>, IBlogInstanceRepository
    {
        private DatabaseContext _context;
        public BlogInstanceRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<BlogInstance> GetBlogInstances()
        {
            var data = GetQueryable().Include(x => x.InstanceOfIssue).ToList();
            return data;
        }

        public void Update(BlogInstance blogInstance)
        {
          var ins = _context.BlogInstances.FirstOrDefault(x=>x.InstanceId == blogInstance.InstanceId);
            if (ins != null)
            {
                ins.InstanceId = blogInstance.InstanceId;
                ins.InstanceName = blogInstance.InstanceName;
                ins.InstanceDescription = blogInstance.InstanceDescription;
                ins.InstanceOfIssue = blogInstance.InstanceOfIssue; 
                ins.OccuranceDate = blogInstance.OccuranceDate;
            }
        }
    }
}
