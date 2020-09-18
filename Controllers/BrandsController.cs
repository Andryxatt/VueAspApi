using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

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
        public JsonResult Get([FromQuery] BrandParameters brandParameters)
        {
            var brands = _repoWrapp.Brand.GetBrands(brandParameters);
            var metadata = new
            {
                brands.TotalCount,
                brands.PageSize,
                brands.CurrentPage,
                brands.TotalPages,
                brands.HasNext,
                brands.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
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
        public JsonResult Put(Guid id, [FromBody]Brand brand, BrandParameters brandParameters)
        {
            _repoWrapp.Brand.UpdateBrand(brand);
            _repoWrapp.Save();
            var brands = _repoWrapp.Brand.GetBrands(brandParameters);
            return Json(brands);
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Brand brand)
        {
            _repoWrapp.Brand.DeleteBrand(brand);
        }
    }
}
