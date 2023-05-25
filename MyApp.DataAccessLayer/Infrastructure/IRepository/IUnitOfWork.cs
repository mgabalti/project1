using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository categoryRepository { get; }
        IBlogInstanceRepository blogInstanceRepository { get; }
        IBlogIssueRepository blogIssueRepository { get; }
        IBlogPostRepository blogPostRepository { get; }
        void save();

    }
}
