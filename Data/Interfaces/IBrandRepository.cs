using System;
using System.Collections.Generic;
using VueAsp.Models;

namespace VueAsp.Data.Interfaces
{
   public interface IBrandRepository : IRepositoryBase<Brand>
    {
		IEnumerable<Brand> GetBrands();
		Brand GetBrandById(Guid brandId);
		Brand GetBrandWithDetails(Guid brandId);
		void CreateBrand(Brand brand);
		void UpdateBrand(Brand brand);
		void DeleteBrand(Brand brand);
	}
}
