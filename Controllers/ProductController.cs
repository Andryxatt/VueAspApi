using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VueAsp.Data;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private BazaDataBase db;
        private IHostingEnvironment hostingEnvironment;
        private IRepositoryWrapper repoWrapp;
        public ProductController(BazaDataBase _db, IHostingEnvironment _hostingEnvironment, IRepositoryWrapper repositoryWrapper)
        {
            db = _db;
            hostingEnvironment = _hostingEnvironment;
            repoWrapp = repositoryWrapper;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts([FromQuery] ProductParameters productParameters)
        {
            var products = repoWrapp.Product.GetProducts(productParameters);
            //var products = db.Products.Include(d=>d.Photos).Include(b=>b.Brand).ToList();
            //return Json(products);
            var metadata = new
            {
                products.TotalCount,
                products.PageSize,
                products.CurrentPage,
                products.TotalPages,
                products.HasNext,
                products.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(products);
        }
        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetProduct")]
        public JsonResult Get(Guid id)
        {
            var product = db.Products.Where(d=>d.ProductId == id).Include(d => d.Photos).Include(b => b.Brand).FirstOrDefault();
            var sizesProd = db.ProdSizes.Where(d => d.ProductId == id).Include(s=>s.Size).ToList();
            return Json( new { 
                product,
                sizesProd });
           
        }
        // POST: api/Product
        [HttpPost]
        public void Post(IFormFileCollection files, string model, string priceBy, string brandId)
        {

            Product product = new Product
            {
                ProductId = Guid.NewGuid(),
                BrandId = Guid.Parse(brandId),
                Model =model,
                PriceBy = float.Parse(priceBy),
                SubId = Guid.NewGuid()
            };
            db.Products.Add(product);
            db.SaveChanges();
            PhotoController photo = new PhotoController(db, hostingEnvironment);
            photo.Post(files, product.ProductId);
        }
        // PUT: api/Product/5
        [HttpPut]
        public void Put(Guid id, string model, string priceBy, string brandId)
        {

        }
        //Delete product and images directory for current product
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            Product product = db.Products.Where(p => p.ProductId == Guid.Parse(id)).FirstOrDefault();
            string path = Path.Combine(hostingEnvironment.WebRootPath, "imagesProduct", product.Model);
            if (Directory.Exists(path))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                List<Photo> photos = db.Photos.Where(p => p.ProductId == product.ProductId).ToList();
                db.Photos.RemoveRange(photos);
             
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                }
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return "Product Deleted";

        }
      
    }
}
