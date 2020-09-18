using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueAsp.Data;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private IRepositoryWrapper _repoWrapp;
        public CategoriesController(IRepositoryWrapper repoWrapp)
        {
            _repoWrapp = repoWrapp;
        }
        // GET: api/Categories
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _repoWrapp.Category.FindAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "GetCategory")]
        public Category Get(Guid id)
        {
            return _repoWrapp.Category.GetCategoryById(id);
        }
        
        // POST: api/Categories
        [HttpPost]
        public JsonResult Post([FromBody]Category category)
        {
            if (category != null)
            {
                category.CategoryId = Guid.NewGuid();
                _repoWrapp.Category.CreateCategory(category);
                _repoWrapp.Save();
                return Json("Category added ");
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { IsCreated = false, ErrorMessage = "My error message" });
            }
                
        }
        
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Category category)
        {
            category.CategoryId = id;
            _repoWrapp.Category.UpdateCategory(category);
            _repoWrapp.Save();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Category category)
        {
            _repoWrapp.Category.DeleteCategory(category);
            _repoWrapp.Save();

        }
    }
}
