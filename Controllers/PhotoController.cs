using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using VueAsp.Data.Interfaces;
using VueAsp.Models;


namespace VueAsp.Controllers
{
    [Produces("application/json")]
    [Route("api/Photo")]
    public class PhotoController : Controller
    {
        private IRepositoryWrapper _repoWrapp;
        private IHostingEnvironment hostingEnvironment;
        public PhotoController(IRepositoryWrapper wrapper, IHostingEnvironment _environment)
        {
            _repoWrapp = wrapper;
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
        // Stored list of photo files for single product
        // POST: api/Photo
        [HttpPost]
        public void Post(IFormFileCollection files, Guid productId)
        {
            var product = _repoWrapp.Product.GetProductById(productId);
            // create directory for product by model name
            string pathModel = Path.Combine(hostingEnvironment.WebRootPath, "imagesProduct", product.Model).ToLower();
            //if path does not exist -> create it
            if (!Directory.Exists(pathModel)) Directory.CreateDirectory(pathModel);
            if (files.GetFiles("files").Count() > 0)
            {
                foreach (var fileU in files.GetFiles("files"))
                {
                    var image = Image.Load(fileU.OpenReadStream());
                    image.Mutate(x => x.Resize(640, 480));
                    image.Save(Path.Combine(pathModel, fileU.FileName));
                 

                    Photo photo = new Photo
                    {
                        PhotoId = Guid.NewGuid(),
                        ProductId = productId,
                        Path = pathModel + fileU.FileName,
                        ByteImage = System.IO.File.ReadAllBytes(Path.Combine(pathModel, fileU.FileName))
                    };
                    _repoWrapp.Photo.CreatePhoto(photo);
                }
                _repoWrapp.Save();
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
