using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.Data.Interfaces
{
    public interface ISizeRepository : IRepositoryBase<Size>
    {
		IEnumerable<Size> GetSizes();
		Size GetSizeById(Guid sizeId);
		Size GetSizeWithDetails(Guid sizeId);
		void CreateSize(Size size);
		void UpdateSize(Size size);
		void DeleteSize(Size size);
	}
}
