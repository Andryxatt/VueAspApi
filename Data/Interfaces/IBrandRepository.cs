using System;
using System.Collections.Generic;
using System.Linq;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data.Interfaces
{
   public interface IBrandRepository : IRepositoryBase<Brand>
    {
		IEnumerable<Brand> GetBrands();
		PagedList<Brand> GetBrands(BrandParameters brandParameters);
		Brand GetBrandById(Guid brandId);
		Brand GetBrandWithDetails(Guid brandId);
		void CreateBrand(Brand brand);
		void UpdateBrand(Brand brand);
		void DeleteBrand(Brand brand);
        Brand GetBrandById(Guid? brandId);
    }
}
