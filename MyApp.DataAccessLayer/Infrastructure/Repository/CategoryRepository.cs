using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<PostCategory>,ICategoryRepository
    {
        private DatabaseContext _Context;
        public CategoryRepository(DatabaseContext context) : base(context)
        {
            _Context = context;
        }

        public void Update(PostCategory category)
        {
            
            var cat = _Context.PostCategories.FirstOrDefault(x => x.Id == category.Id);
            if (cat != null) 
            {
                cat.CatName = category.CatName;
                cat.CatCreatedDate = DateTime.Now;
            }

        }
    }
}
