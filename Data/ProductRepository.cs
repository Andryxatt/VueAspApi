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
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(BazaDataBase repositoryContext)
           : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public PagedList<Product> GetProducts(ProductParameters productParameters)
        {
            return PagedList<Product>.ToPagedList(FindAll().OrderBy(on => on.Model).Include(d => d.Photos).Include(b => b.Brand),
                productParameters.PageNumber,
                productParameters.PageSize);
        }

        public Product GetProductWithDetails(Guid productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product dbProduct, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
