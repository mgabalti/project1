using Microsoft.AspNetCore.Mvc;
using MyApp.DataAccessLayer;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using MyApp.Models.ViewModels;

namespace MyAppWeb.Areas.Admin.Controllers
{
    
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            CategoryVM categoryVM = new CategoryVM();
            categoryVM.PostCategories = _unitOfWork.categoryRepository.GetAll();
            return View(categoryVM);
        }

        [HttpGet]
        public IActionResult GetAllCat()
        {
            CategoryVM vm = new CategoryVM();
            vm.PostCategories = _unitOfWork.categoryRepository.GetAll();
            return Json(new { data = vm.PostCategories });

        }
        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CategoryVM vm = new CategoryVM();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.PostCategory = _unitOfWork.categoryRepository.GetT(x => x.Id == id);
                if(vm.PostCategory == null)
                {
                    return NotFound();
                }
                               
                return View(vm);
            }

        }
        [HttpPost]
        public IActionResult CreateUpdate(CategoryVM vm)
        {

            if (ModelState.IsValid)
            {
                if (vm.PostCategory.Id==0)
                {
                _unitOfWork.categoryRepository.Add(vm.PostCategory);

                }
                else
                {
                _unitOfWork.categoryRepository.Update(vm.PostCategory);

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
            var category = _unitOfWork.categoryRepository.GetT(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.categoryRepository.Delete(category);
            _unitOfWork.save();
            TempData["success"] = "Category Delete Sucessfully";
            return RedirectToAction("Index");

        }
    }
}
