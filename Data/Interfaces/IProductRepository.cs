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

		IQueryable<Product> GetAllProducts();
		Product GetProductById(Guid productId);
		Product GetProductWithDetails(string name);
		void CreateProduct(Product product);
		void UpdateProduct(Product product);
		void DeleteProduct(Product product);
		
	}
}
