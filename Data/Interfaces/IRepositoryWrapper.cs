using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;

namespace VueAsp.Data.Interfaces
{
    public interface IRepositoryWrapper
    {
        IBrandRepository Brand { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        ISizeRepository Size { get; }
        IPhotoRepository Photo { get; }
        ISizePorductRepository SizePorduct { get; }
        IOrderRepository Order { get; }
        IAddressOrderRepository AddressOrder { get; }
        ISubCategoryRepository SubCategory { get; }
        void Save();
    }
}
