using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/SubCategory")]
    public class SubCategoryController : Controller
    {

        private IRepositoryWrapper _repoWrapp;
        public SubCategoryController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapp = repositoryWrapper;
        }
        [HttpGet("{id}")]
        public JsonResult Get(Guid id)
        {
            var categories = _repoWrapp.SubCategory.GetSubCategories(id);
            return Json(categories);
        }
        // POST: api/subCategories
        [HttpPost]
        public JsonResult Post([FromBody]SubCategory subCategory)
        {
            if (subCategory != null)
            {
                subCategory.SubId = Guid.NewGuid();
                _repoWrapp.SubCategory.CreateSubCategory(subCategory);
                _repoWrapp.Save();
                return Json("Category added ");
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { IsCreated = false, ErrorMessage = "My error message" });
            }

        }
    }
}