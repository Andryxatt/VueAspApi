using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data.Interfaces
{
   public interface IBrandRepository : IRepositoryBase<Brand>
    {
		IEnumerable<Brand> GetBrands();
		Brand GetBrandById(Guid brandId);
		Brand GetBrandWithDetails(Guid brandId);
		void CreateBrand(Brand brand);
		void UpdateBrand(Brand dbBrand, Brand brand);
		void DeleteBrand(Brand brand);
	}
}
