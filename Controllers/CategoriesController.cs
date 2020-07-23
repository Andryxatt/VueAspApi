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
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private BazaDataBase db;
        public CategoriesController(BazaDataBase _db)
        {
            db = _db;
        }
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "GetCategory")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Categories
        [HttpPost]
        public JsonResult Post([FromBody]Category category)
        {
            if (category != null)
            {
                category.CategoryId = Guid.NewGuid();
                db.Categories.Add(category);
                db.SaveChanges();
                return Json("Category added ");
            }
            else
            {

                return Json("Error");
            }
                
        }
        
        // PUT: api/Categories/5
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
