using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels.RazorViewModels;

namespace VueAsp.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryWrapper _repoWrapp;
        public HomeController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapp = repositoryWrapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ControlPanel()
        {

            return PartialView();
        }
        public async Task<IActionResult> ShopHome(string sortOrder, string searchString, int page = 1)
        {
            ViewData["CurrentFilter"] = searchString;
            IQueryable<Product> source = _repoWrapp.Product.GetAllProducts();
            if (!String.IsNullOrEmpty(searchString))
            {
                source = source.Where(s => s.Model.Contains(searchString)
                                       || s.Brand.NameBrand.Contains(searchString));
            }
            int pageSize = 12;   // count elements per page
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PagePagilListViewModel pageViewModel = new PagePagilListViewModel(count, page, pageSize);
            var prod = new Product();
            IndexShopViewModel viewModel = new IndexShopViewModel
            {
                PagePagilList = pageViewModel,
                Products = items
            };
            ViewBag.sizes = _repoWrapp.Size.FindAll();
            //Example to store product to session storage
            //HttpContext.Session.SetObjectAsJson("Prod1", viewModel.Products.FirstOrDefault());
            //var myComplexObject = HttpContext.Session.GetObjectFromJson<Product>("Prod1");
            //ViewBag.prod = myComplexObject;
            return View(viewModel);
        }
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
        [Produces("application/json")]
        [HttpGet("searchmodel")]
        public IActionResult SearchModel()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = _repoWrapp.Product.GetAllProducts().Where(p => p.Model.Contains(term)).Select(p => p.Model).ToList();
                return Ok(names);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
