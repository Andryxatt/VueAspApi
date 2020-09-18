using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data.Interfaces
{
    public interface ISizePorductRepository : IRepositoryBase<ProdSizes>
	{
		IEnumerable<ProdSizes> GetProductSizes(Guid productId);
		ProdSizes GetProdSizeById(Guid sizeId);
		ProdSizes GetProdSizeWithDetails(Guid sizeId);
		void CreateProdSize(List<ProdSizes> prodSizes);
		void UpdateProdSize(ProdSizes prodSize);
		void DeleteProdSize(ProdSizes prodSize);
	}
}
