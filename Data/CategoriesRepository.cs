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
    public class CategoriesRepository : RepositoryBase<Category>, ICategoryRepository, IDisposable
    {
        public CategoriesRepository(BazaDataBase repositoryContext)
           : base(repositoryContext)
        {
        }
        public void CreateCategory(Category category)
        {
            RepositoryContext.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            RepositoryContext.Remove(category);
        }

        public PagedList<Category> GetCategories(CategoryParameters categoryParameters)
        {
            return PagedList<Category>.ToPagedList(FindAll().OrderBy(on => on.NameCategory),
                categoryParameters.PageNumber,
                categoryParameters.PageSize);
        }

        public Category GetCategoryById(Guid categoryId)
        {
            return RepositoryContext.Categories.Find(categoryId);
        }

        public Category GetCategoryWithDetails(Guid categoryId)
        {
           return RepositoryContext.Categories.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            RepositoryContext.Categories.Update(category);
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
