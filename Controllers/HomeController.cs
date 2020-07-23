using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VueAsp.Data;
using VueAsp.ViewModels;

namespace VueAsp.Controllers
{
    public class HomeController : Controller
    {
        private BazaDataBase db;
        public HomeController(BazaDataBase _db)
        {
            db = _db;
        }
        
        public IActionResult Index()
        {
          
            return View();
        }
        public IActionResult ShopHome()
        {
            var products = db.Products.Include(d=>d.Brand).Include(p=>p.Photos).ToList();
            //var products = db.Products.Include(d=>d.Photos).Include(b=>b.Brand).ToList();
            //return Json(products);
            //var metadata = new
            //{
            //    products.TotalCount,
            //    products.PageSize,
            //    products.CurrentPage,
            //    products.TotalPages,
            //    products.HasNext,
            //    products.HasPrevious
            //};
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return View(products);
        }
        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
