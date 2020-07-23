using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
		PagedList<Category> GetCategories(CategoryParameters categoryParameters);
		Category GetCategoryById(Guid productId);
		Category GetCategoryWithDetails(Guid productId);
		void CreateCategory(Category product);
		void UpdateCategory(Category dbProduct, Category product);
		void DeleteCategory(Category product);
	}
}
