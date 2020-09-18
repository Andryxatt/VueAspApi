using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data
{
    public class SizeProdRepository : RepositoryBase<ProdSizes>, ISizePorductRepository, IDisposable
    {
        public SizeProdRepository(BazaDataBase repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProdSize(List<ProdSizes> prodSizes)
        {
            this.RepositoryContext.ProdSizes.AddRange(prodSizes);
        }

        public void DeleteProdSize(ProdSizes prodSize)
        {
            this.RepositoryContext.ProdSizes.Remove(prodSize);
        }

        public ProdSizes GetProdSizeById(Guid sizeId)
        {
            return this.RepositoryContext.ProdSizes.Include(s=>s.Size).Where(p=>p.SizeId == sizeId).FirstOrDefault();
        }

        public ProdSizes GetProdSizeWithDetails(Guid sizeId)
        {
            return this.RepositoryContext.ProdSizes.Find(sizeId);
        }

        public IEnumerable<ProdSizes> GetProductSizes(Guid productId)
        {
            return RepositoryContext.ProdSizes.OrderBy(s => s.Size.SizeEU).Where(p=>p.ProductId == productId).Include(s=>s.Size).ToList();
        }

        public void UpdateProdSize(ProdSizes prodSize)
        {
            this.RepositoryContext.ProdSizes.Update(prodSize);
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
