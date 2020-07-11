using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueAsp.Data;
using VueAsp.Models;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsController : Controller
    {
        private BazaDataBase db;
        public BrandsController(BazaDataBase _db)
        {
            db = _db;
        }
        // GET: api/Brands
        [HttpGet]
        public JsonResult Get()
        {
            return Json(db.Brands.ToList());
        }

        // GET: api/Brands/5
        [HttpGet("{id}", Name = "GetBrand")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Brands
        [HttpPost]
        public void Post([FromBody]Brand brand)
        {
            Brand saveBrand = new Brand();
            saveBrand.BrandId = Guid.NewGuid();
            saveBrand.NameBrand = brand.NameBrand;
            saveBrand.Description = brand.Description;
            try
            {
                db.Brands.Add(saveBrand);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
        
        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
