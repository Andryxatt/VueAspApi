using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data.Interfaces
{
   public interface IProductRepository : IRepositoryBase<Product>
    {
		PagedList<Product> GetProducts(ProductParameters productParameters);
		Product GetProductById(Guid productId);
		Product GetProductWithDetails(Guid productId);
		void CreateProduct(Product product);
		void UpdateProduct(Product dbProduct, Product product);
		void DeleteProduct(Product product);
	}
}
