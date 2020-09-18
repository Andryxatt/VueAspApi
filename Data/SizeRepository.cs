using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Data
{
    public class SizeRepository : RepositoryBase<Size>, ISizeRepository, IDisposable
    {
        public SizeRepository(BazaDataBase repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateSize(Size size)
        {
            this.RepositoryContext.Sizes.Add(size);
        }

        public void DeleteSize(Size size)
        {
            this.RepositoryContext.Sizes.Remove(size);
        }

        public Size GetSizeById(Guid sizeId)
        {
            return this.RepositoryContext.Sizes.Find(sizeId);
        }

        public IEnumerable<Size> GetSizes()
        {
            return RepositoryContext.Sizes.OrderBy(s=>s.SizeEU).ToList();
        }

        public Size GetSizeWithDetails(Guid sizeId)
        {
            return this.RepositoryContext.Sizes.Find(sizeId);
        }

        public void UpdateSize(Size size)
        {
            this.RepositoryContext.Sizes.Update(size);
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
