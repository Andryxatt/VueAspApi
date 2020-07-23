using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using QRCoder;
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
        [HttpGet("{qrText}")]
        public IActionResult Get(string qrText)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText,
            QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return View(BitmapToBytes(qrCodeImage));
        }
        private static Byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
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
                        Size = db.Sizes.Where(s => s.SizeId == SizeId).FirstOrDefault(),
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
