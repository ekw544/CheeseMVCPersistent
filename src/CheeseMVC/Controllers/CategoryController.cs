using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheeseMVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<CheeseCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        private readonly CheeseDbContext context;

        public CategoryController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Add the new category to my existing categories
                CheeseCategory newCategory = new CheeseCategory
                {
                    Name = addCategoryViewModel.Name,

                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
                
            }

            return View(addCategoryViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Categories";
            ViewBag.categories = context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] categoryIds)
        {
            foreach (int categoryId in categoryIds)
            {
                CheeseCategory theCategory = context.Categories.Single(c => c.ID == categoryId);
                context.Categories.Remove(theCategory);
            }

            context.SaveChanges();

            return Redirect("/Category");
        }
    }
}
