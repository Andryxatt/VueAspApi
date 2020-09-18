using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Data
{
    public class SubCategoryRepository : RepositoryBase<SubCategory>, ISubCategoryRepository, IDisposable
    {
        public SubCategoryRepository(BazaDataBase repositoryContext)
            :base(repositoryContext)
        {
        }
        public IEnumerable<SubCategory> GetSubCategories(Guid catId)
        {
            return RepositoryContext.SubCategories.Where(c=>c.CategoryId == catId);
        }

        public SubCategory GetSubCategoryById(Guid subCatID)
        {
            return RepositoryContext.SubCategories.Where(d=>d.CategoryId == subCatID).FirstOrDefault();
        }

        public SubCategory GetSubCategoryWithDetails(Guid subCatID)
        {
            return RepositoryContext.SubCategories.Where(d => d.CategoryId == subCatID).FirstOrDefault();
        }

        public void CreateSubCategory(SubCategory subCat)
        {
             RepositoryContext.SubCategories.Add(subCat);
        }

        public void UpdateSubCategory(SubCategory subCat)
        {
            RepositoryContext.SubCategories.Update(subCat);
        }

        public void DeleteSubCategory(SubCategory subCat)
        {
            RepositoryContext.SubCategories.Remove(subCat);
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
