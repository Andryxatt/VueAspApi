using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private IRepositoryWrapper _repoWrapp;
        public ProductController(IHostingEnvironment _hostingEnvironment, IRepositoryWrapper repositoryWrapper)
        {
           
            hostingEnvironment = _hostingEnvironment;
            _repoWrapp = repositoryWrapper;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult GetProducts([FromQuery] ProductParameters productParameters)
        {
            var products = _repoWrapp.Product.GetProducts(productParameters);
          
           
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
            var product = _repoWrapp.Product.GetProductById(id);
            var sizesProd = _repoWrapp.SizePorduct.GetProductSizes(product.ProductId);
            return Json( new { 
                product,
                sizesProd });
           
        }
        // POST: api/Product
        [HttpPost]
        public void Post(IFormFileCollection files, string model, string priceBy, string brandId, int countBoxes, int countPairsInBox, string sizesInBox, float priceSalleUS, float priceSalleUAH, bool isDiscount, int discountUAH, int discountUS)
        {
            Product product = new Product
            {
                ProductId = Guid.NewGuid(),
                BrandId = Guid.Parse(brandId),
                Model = model,
                PriceBy = float.Parse(priceBy),
                CountBoxes = countBoxes,
                CountPairsInBox = countPairsInBox,
                SizesInBox = sizesInBox,
                DiscountUAH = discountUAH,
                isDiscount = isDiscount,
                DiscountUS = discountUS,
                PriceSalleUAH = priceSalleUAH,
                PriceSalleUS = priceSalleUS
                //SubId = Guid.NewGuid()
            };
            _repoWrapp.Product.Create(product);
            _repoWrapp.Save();
            PhotoController photo = new PhotoController(_repoWrapp, hostingEnvironment);
            photo.Post(files, product.ProductId);
        }
        // PUT: api/Product/5
        [HttpPut]
        public void Put([FromBody] Product product)
        {
            product.Brand = _repoWrapp.Brand.GetBrandById(product.BrandId);
            if (ModelState.IsValid)
            {
                _repoWrapp.Product.UpdateProduct(product);
                _repoWrapp.Save();
            }
        }
        //Delete product and images directory for current product
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public string Delete(Guid id)
        {
            Product product = _repoWrapp.Product.GetProductById(id);
            string path = Path.Combine(hostingEnvironment.WebRootPath, "imagesProduct", product.Model);
            if (Directory.Exists(path))
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(path);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                IEnumerable<Photo> photos = _repoWrapp.Photo.GetPhotosByProductId(id);
                _repoWrapp.Photo.DeletePhotoRange(photos);
             
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                }
            }
            _repoWrapp.Product.Delete(product);
            _repoWrapp.Save();
            return "Product Deleted";
        }
    }
}
