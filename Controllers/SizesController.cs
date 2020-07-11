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
    [Route("api/Sizes")]
    public class SizesController : Controller
    {
        private BazaDataBase db;
        public SizesController(BazaDataBase _db)
        {
            db = _db;
        }
        // GET: api/Sizes
        [HttpGet]
        public JsonResult GetAllItems()
        {
            var sizes = db.Sizes.ToList();
            return Json(sizes);
        }

        // GET: api/Sizes/5
        [HttpGet("{id}", Name = "GetSize")]
        public JsonResult GetSingleItem(Guid sizeId)
        {
            var size = db.Sizes.Where(p => p.SizeId == sizeId).FirstOrDefault();
            return Json(size);
        }
        
        // POST: api/Sizes
        [HttpPost]
        public void Post(string sizeUA, string sizeUSA)
        {
            Size newSize = new Size
            {
                SizeId = Guid.NewGuid(),
                SizeUA = sizeUA,
                SizeUSA = sizeUSA

            };
            db.Sizes.Add(newSize);
            db.SaveChanges();
        }
        
        // PUT: api/Sizes/5
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
