using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.DataAccessLayer.Migrations;
using MyApp.Models;
using MyApp.Models.ViewModels;
using Newtonsoft.Json;

namespace MyAppWeb.Controllers;


public class HomeController : Controller
{
    private IUnitOfWork _unitOfWork;
    private IWebHostEnvironment _HostEnvironment;

    public HomeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _HostEnvironment = hostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CreateUpdate(int? id)
    {
        BlogPostVM bp = new BlogPostVM();   

        if (id == 0 ||id == null)
        {
            List<SelectListItem> categoryList = _unitOfWork.categoryRepository.GetAll().Select(x => new SelectListItem()
            {
                Text = x.CatName,
                Value = x.Id.ToString(),
            }).ToList();

            List<SelectListItem> issue = _unitOfWork.blogIssueRepository.GetAll().Select(x => new SelectListItem() {
               Text = x.IssueTitle,
               Value = x.IssueId.ToString(),
            }).ToList();
            bp.blogIssueVM = issue;
            bp.selectLstItem = categoryList;
            return View(bp);

        }
        else
        {
            bp.blogPost = _unitOfWork.blogPostRepository.GetT(x => x.Id == id);
            if (bp.blogPost == null)
            {
                return NotFound();
            }

            return View(bp);
        }
    }
    [HttpPost]
    public IActionResult CreateUpdate(BlogPostVM blogPostVM, IFormFile? PostImageURLName)

    {
        if (ModelState.IsValid)
        {
            string fileName = string.Empty;
            if (PostImageURLName != null)
            {
                string uploadDir = Path.Combine(_HostEnvironment.WebRootPath, "Upload");
                fileName = Guid.NewGuid().ToString() + "-" + PostImageURLName.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    PostImageURLName.CopyTo(fileStream);
                }
                blogPostVM.blogPost.postimageurl = @"\Upload\" + fileName;
            }

            if (blogPostVM.blogPost.Id == 0)
            {
                _unitOfWork.blogPostRepository.Add(blogPostVM.blogPost);
            }
            else
            {
                _unitOfWork.blogPostRepository.Update(blogPostVM.blogPost);
            }
            _unitOfWork.save();
            return RedirectToAction("Index");
        }
        else
        {
            return View("CreateUpdate");
        }
    }
    [HttpGet]
    public IActionResult fetchInstance(int id)
    {
		BlogPostVM bp = new BlogPostVM();
       if(id != 0)
        {
            List<SelectListItem> instance = _unitOfWork.blogInstanceRepository.GetAll().Where(x => x.BlogIssueId == id).Select(x => new SelectListItem()
            {
                Text = x.InstanceName,
                Value = x.InstanceId.ToString(),
            }).ToList() ;
            bp.blogInstance = instance;
            
		}
		return Json(bp.blogInstance);
	}



}