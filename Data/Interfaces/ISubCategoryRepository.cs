using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.Data.Interfaces
{
   public interface ISubCategoryRepository : IRepositoryBase<SubCategory>
    {
		IEnumerable<SubCategory> GetSubCategories(Guid catId);
		SubCategory GetSubCategoryById(Guid subCatID);
		SubCategory GetSubCategoryWithDetails(Guid subCatID);
		void CreateSubCategory(SubCategory subCat);
		void UpdateSubCategory(SubCategory subCat);
		void DeleteSubCategory(SubCategory subCat);
	}
}
