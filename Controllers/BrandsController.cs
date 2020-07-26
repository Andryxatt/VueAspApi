using System;
using Microsoft.AspNetCore.Mvc;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Brands")]
    public class BrandsController : Controller
    {
        private IRepositoryWrapper _repoWrapp;
        public BrandsController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapp = repositoryWrapper;
        }
        // GET: api/Brands
        [HttpGet]
        public JsonResult Get()
        {
            var brands = _repoWrapp.Brand.GetBrands();
            return Json(brands);
        }
        // GET: api/Brands/5
        [HttpGet("{id}", Name = "GetBrand")]
        public Brand Get(Guid id)
        {
            return _repoWrapp.Brand.GetBrandById(id);
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
                _repoWrapp.Brand.Create(saveBrand);
                _repoWrapp.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }
        // PUT: api/Brands/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Brand brand)
        {
            brand.BrandId = id;
            _repoWrapp.Brand.UpdateBrand(brand);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Brand brand)
        {
            _repoWrapp.Brand.DeleteBrand(brand);
        }
    }
}
