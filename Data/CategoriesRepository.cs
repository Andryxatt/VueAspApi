using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data
{
    public class CategoriesRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoriesRepository(BazaDataBase repositoryContext)
           : base(repositoryContext)
        {
        }
        public void CreateCategory(Category product)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category product)
        {
            throw new NotImplementedException();
        }

        public PagedList<Category> GetCategories(CategoryParameters categoryParameters)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryById(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryWithDetails(Guid productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category dbProduct, Category product)
        {
            throw new NotImplementedException();
        }
    }
}
