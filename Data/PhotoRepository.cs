using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Data
{
    public class PhotoRepository : RepositoryBase<Photo>, IPhotoRepository, IDisposable
    {
        public PhotoRepository(BazaDataBase repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreatePhoto(Photo photo)
        {
            this.RepositoryContext.Photos.Add(photo);
        }

        public void DeletePhoto(Photo photo)
        {
            this.RepositoryContext.Photos.Remove(photo);
        }

        public Photo GetPhotoById(Guid photoId)
        {
            return this.RepositoryContext.Photos.Find(photoId);
        }

        public IEnumerable<Photo> GetPhotosByProductId(Guid productId)
        {
            return RepositoryContext.Photos.Where(p=>p.ProductId == productId).ToList();
        }
       public void DeletePhotoRange(IEnumerable<Photo> photo)
        {
            this.RepositoryContext.Photos.RemoveRange(photo);
        }
        public Photo GetPhotoWithDetails(Guid photoId)
        {
            return this.RepositoryContext.Photos.Find(photoId);
        }

        public void UpdatePhoto(Photo photo)
        {
            this.RepositoryContext.Photos.Update(photo);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    RepositoryContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      
    }
}
