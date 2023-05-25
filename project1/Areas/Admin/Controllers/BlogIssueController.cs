using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;

namespace MyAppWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogIssueController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BlogIssueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            BlogIssueVM blogIssueVM = new BlogIssueVM();
            blogIssueVM.BlogIssues = _unitOfWork.blogIssueRepository.GetAll();
            return View(blogIssueVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            BlogIssueVM vm = new BlogIssueVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.BlogIssue = _unitOfWork.blogIssueRepository.GetT(x => x.IssueId == id);
                if(vm.BlogIssue == null)
                {
                    return NotFound();
                }
                               
                return View(vm);
            }

        }
        [HttpPost]
        public IActionResult CreateUpdate(BlogIssueVM vm)
        {

            if (ModelState.IsValid)
            {
                if (vm.BlogIssue.IssueId ==0)
                {
                _unitOfWork.blogIssueRepository.Add(vm.BlogIssue);

                }
                else
                {
                _unitOfWork.blogIssueRepository.Update(vm.BlogIssue);

                }
                _unitOfWork.save();
                TempData["success"] = "Category Update Sucessfully";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CreateUpdate");
            }
        }

        [HttpGet]
        public IActionResult DeletePost(int? id)
        {
            var category = _unitOfWork.blogIssueRepository.GetT(x => x.IssueId == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.blogIssueRepository.Delete(category);
            _unitOfWork.save();
            TempData["success"] = "Category Delete Sucessfully";
            return RedirectToAction("Index");

        }
    }
}
