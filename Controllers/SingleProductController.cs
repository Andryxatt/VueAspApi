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
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/SingleProduct")]
    public class SingleProductController : Controller
    {
        private BazaDataBase db;
        private IRepositoryWrapper _repoWrapp;

        public SingleProductController(BazaDataBase _db, IRepositoryWrapper wrapp)
        {
            _repoWrapp = wrapp;
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
        public JsonResult Post([FromBody] List<ProdSizes> sizes)
        {
            try
            {
                if (sizes.Count() > 0)
                {
                    foreach (var item in sizes)
                    {
                        var prodSize = _repoWrapp.SizePorduct.GetProductSizes(item.ProductId).Where(s => s.SizeId == item.SizeId).FirstOrDefault();
                        if (prodSize != null)
                        {
                            prodSize.Count = item.Count;
                            _repoWrapp.SizePorduct.UpdateProdSize(prodSize);
                            _repoWrapp.Save();
                        }
                        else
                        {
                            item.Id = Guid.NewGuid();
                            _repoWrapp.SizePorduct.Create(item);
                            _repoWrapp.Save();
                        }
                    }
                  
                }
                return new JsonResult(sizes)
                {
                    StatusCode = StatusCodes.Status201Created // Status code here 
                };
            }
            catch (Exception)
            {
                return new JsonResult(sizes)
                {
                    StatusCode = StatusCodes.Status400BadRequest // Status code here 
                };
            }
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
