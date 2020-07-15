using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using VueAsp.Data;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/SingleProduct")]
    public class SingleProductController : Controller
    {
        private BazaDataBase db;

        public SingleProductController(BazaDataBase _db)
        {
            db = _db;
        }
        // GET: api/SingleProduct
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SingleProduct/5
        [HttpGet("{id}", Name = "GetSingleProduct")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/SingleProduct
        [HttpPost]
        public string Post(Guid SizeId, Guid productId, int count)
        {
            ProdSizes sizeProd = db.ProdSizes.Where(d => d.ProductId == productId && d.SizeId == SizeId).Include(d=>d.Size).FirstOrDefault();
            try
            {
                if(sizeProd!=null)
                {
                    sizeProd.Count = count;
                    db.ProdSizes.Update(sizeProd);
                }
                else
                {
                    ProdSizes prodSize = new ProdSizes
                    {
                        SizeId = SizeId,
                        Count = count,
                        Id = Guid.NewGuid(),
                        ProductId = productId
                    };
                    db.ProdSizes.Add(prodSize);
                }
               
                db.SaveChanges();
                
            }
            catch (Exception)
            {

                throw;
            }
            return "Succes added";



        }
        
        // PUT: api/SingleProduct/5
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
