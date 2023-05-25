using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;

namespace MyAppWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogInstanceController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public BlogInstanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            BlogInstanceVM vM= new BlogInstanceVM();
            vM.blogInstances = _unitOfWork.blogInstanceRepository.GetAll();
            return View(vM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            BlogInstanceVM vm = new BlogInstanceVM()
            {
                blogInstance = new(),
                InstanceOfIssue = _unitOfWork.blogIssueRepository.GetAll().Select(x =>
                new SelectListItem()
                {
                    Text = x.IssueTitle,
                    Value = x.IssueId.ToString()
                })
            };
            if (id == null || id ==0)
            {
                return View(vm);
            }
            else
            {
                vm.blogInstance = _unitOfWork.blogInstanceRepository.GetT(x => x.InstanceId == id);
                if(vm.blogInstance == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
        [HttpPost]
        public IActionResult CreateUpdate(BlogInstanceVM vM)
        { 
            if (ModelState.IsValid)
            {
                if (vM.blogInstance.InstanceId == 0)
                {
                    _unitOfWork.blogInstanceRepository.Add(vM.blogInstance);
                }
                else
                {
                    _unitOfWork.blogInstanceRepository.Update(vM.blogInstance);
                }
                _unitOfWork.save();
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("CreateUpdate");
            }
        }


        public IActionResult AjaxCall()
        {
            return View();
        }

        public IActionResult AjaxGetAll()
        {
            BlogInstanceVM vM = new BlogInstanceVM();
            vM.blogInstances = _unitOfWork.blogInstanceRepository.GetBlogInstances();

            //vM.BlogIssuevm = _unitOfWork.blogIssueRepository.GetAll();
            return Json(vM);
        }
         public IActionResult AjaxCreateUpdate(int id)
        {
            BlogInstanceVM vm = new BlogInstanceVM()
            {
                blogInstance = new(),
                InstanceOfIssue = _unitOfWork.blogIssueRepository.GetAll().Select(x =>
                new SelectListItem()
                {
                    Text = x.IssueTitle,
                    Value = x.IssueId.ToString()
                })
            };
           
          
                vm.blogInstance = _unitOfWork.blogInstanceRepository.GetT(x => x.InstanceId == id);
            //if (vm.blogInstance == null)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    return Json(vm);
            //}
            return Json(vm);

        }

        [HttpPost]
        public IActionResult AjaxCreateUpdate(BlogInstance vM)
        {
            if (ModelState.IsValid)
            {
                if (vM.InstanceId == 0)
                {
                    _unitOfWork.blogInstanceRepository.Add(vM);
                }
                else
                {
                    _unitOfWork.blogInstanceRepository.Update(vM);
                }
                _unitOfWork.save();

                return Json(new { status = true, message = "sucessfully created" });

            }
            else
            {
                return Json(new { status = false, msg = " some error" });
            }
            ;
        }
    }
}
