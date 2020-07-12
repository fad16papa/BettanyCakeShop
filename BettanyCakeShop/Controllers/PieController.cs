using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BettanyCakeShop.Models;
using BettanyCakeShop.Repository.Interface;
using BettanyCakeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BettanyCakeShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        //public ViewResult List()
        //{
        //    PiesListViewModel piesListViewModel = new PiesListViewModel();
        //    piesListViewModel.Pies = _pieRepository.AllPies;
        //    piesListViewModel.CurrentCategory = "Chesse cakes";

        //    return View(piesListViewModel);
        //}

        public IActionResult Details(int Id)
        {
            var pie = _pieRepository.GetPieById(Id);

            if(pie == null)
            {
                return NotFound();
            }

            return View(pie);
        }

        public IActionResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.Id);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category).OrderBy(p => p.Id);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });

        }
    }
}
