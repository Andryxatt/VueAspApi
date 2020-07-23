using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository, IDisposable
    {
        public ProductRepository(BazaDataBase repositoryContext)
           : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            RepositoryContext.Products.Add(product);
            RepositoryContext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            RepositoryContext.Products.Remove(product);
            RepositoryContext.SaveChanges();
        }

        public Product GetProductById(Guid productId)
        {
            return RepositoryContext.Products.Find(productId);

        }

        public PagedList<Product> GetProducts(ProductParameters productParameters)
        {
            return PagedList<Product>.ToPagedList(FindAll().OrderBy(on => on.Model).Include(d => d.Photos).Include(b => b.Brand).Include(s=>s.Sizes).ThenInclude(p=>p.Size),
                productParameters.PageNumber,
                productParameters.PageSize);
        }

        public Product GetProductWithDetails(string name)
        {
            return RepositoryContext.Products.Where(p => p.Model.Equals(name)).FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            RepositoryContext.Products.Update(product);
            RepositoryContext.SaveChanges();
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
