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
		Category GetCategoryById(Guid categoryId);
		Category GetCategoryWithDetails(Guid categoryId);
		void CreateCategory(Category category);
		void UpdateCategory(Category category);
		void DeleteCategory(Category category);
	}
}
