using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using VueAsp.Data;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Photo")]
    public class PhotoController : Controller
    {
        private BazaDataBase db;
        private IHostingEnvironment hostingEnvironment;
        public PhotoController(BazaDataBase _db, IHostingEnvironment _environment)
        {
            db = _db;
            hostingEnvironment = _environment;
        }
        // GET: api/Photo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET: api/Photo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        // Stored list of photo files for model product
        // POST: api/Photo
        [HttpPost]
        public void Post(IFormFileCollection files, Guid productId)
        {
            var product = db.Products.Where(d => d.ProductId == productId).FirstOrDefault();
            // create directory for product by model name
            string pathModel = Path.Combine(hostingEnvironment.WebRootPath, "imagesProduct", product.Model).ToLower();
            //if path does not exist -> create it
            if (!Directory.Exists(pathModel)) Directory.CreateDirectory(pathModel);
            if (files.GetFiles("files").Count() > 0)
            {
                foreach (var fileU in files.GetFiles("files"))
                {
                    var image = Image.Load(fileU.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save(Path.Combine(pathModel, fileU.FileName));

                    Photo photo = new Photo
                    {
                        PhotoId = Guid.NewGuid(),
                        ProductId = productId,
                        Path = pathModel + fileU.FileName,
                        ByteImage = System.IO.File.ReadAllBytes(Path.Combine(pathModel, fileU.FileName))
                    };
                    db.Photos.Add(photo);
                }
                db.SaveChanges();
            }
        }
        // PUT: api/Photo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE: api/photo/5
        [HttpDelete("{id}")]
        public void Delete(Guid Id)
        {

        }



    }
}
