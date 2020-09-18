using System;
using Microsoft.AspNetCore.Mvc;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Sizes")]
    public class SizesController : Controller
    {
        private IRepositoryWrapper _repoWrapp;
        public SizesController(IRepositoryWrapper wrapper)
        {
            _repoWrapp = wrapper;
        }
        // GET: api/Sizes
        [HttpGet]
        public JsonResult GetAllItems()
        {
            var sizes = _repoWrapp.Size.GetSizes();
            return Json(sizes);
        }

        // GET: api/Sizes/5
        [HttpGet("{id}", Name = "GetSize")]
        public JsonResult GetSingleItem(Guid sizeId)
        {
            var size = _repoWrapp.Size.GetSizeById(sizeId);
            return Json(size);
        }
        
        // POST: api/Sizes
        [HttpPost]
        public void Post(string sizeEU, string sizeUS, string cm, string sizeUK, Floor floor)
        {
            Size newSize = new Size
            {
                SizeId = Guid.NewGuid(),
                SizeEU = sizeEU,
                SizeUS = sizeUS,
                CM = cm,
                SizeUK = sizeUK,
                Floor = floor
            };
            _repoWrapp.Size.Create(newSize);
            _repoWrapp.Save();
        }
        
        // PUT: api/Sizes/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Size size)
        {
            if (ModelState.IsValid)
            {
                _repoWrapp.Size.UpdateSize(size);
                _repoWrapp.Save();
            }
        }
        
        // DELETE: api/ApiWithActions/guid<string>
        [HttpDelete("{id}")]
        public void Delete(Guid Id)
        {
            Size size = _repoWrapp.Size.GetSizeById(Id);
            _repoWrapp.Size.DeleteSize(size);
            _repoWrapp.Save();
          
        }
    }
}
