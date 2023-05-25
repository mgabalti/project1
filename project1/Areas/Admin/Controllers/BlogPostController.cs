using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;

namespace MyAppWeb.Areas.Admin.Controllers
{
    public class BlogPostController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IWebHostEnvironment _hostingEnvironment;
        public BlogPostController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {

            return View();
        }

        #region APICALL
      
        #endregion

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePost(BlogPost blog)
        {
            if (ModelState.IsValid)
            {
                //_DbContext.BlogPost.Add(blog);
                //_DbContext.SaveChanges();
                //return RedirectToAction("CreatePost");
            }
            return View();
        }

    }
}
