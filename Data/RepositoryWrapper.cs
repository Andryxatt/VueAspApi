using VueAsp.Data.Interfaces;

namespace VueAsp.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BazaDataBase _repoContext;
        private IBrandRepository _brand;
        private IProductRepository _product;
        private ICategoryRepository _category;
        private ISizeRepository _size;
        private IPhotoRepository _photo;
        private ISizePorductRepository _sizeProd;
        private IOrderRepository _order;
        private IAddressOrderRepository _addressOrder;
        private ISubCategoryRepository _subCategory;
        public IBrandRepository Brand
        {
            get
            {
                if (_brand == null)
                {
                    _brand = new BrandRepository(_repoContext);
                }

                return _brand;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }

                return _product;
            }
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoriesRepository(_repoContext);
                }

                return _category;
            }
        }
        public ISizeRepository Size
        {
            get
            {
                if (_size == null)
                {
                    _size = new SizeRepository(_repoContext);
                }

                return _size;
            }
        }
        public IPhotoRepository Photo
        {
            get
            {
                if (_photo == null)
                {
                    _photo = new PhotoRepository(_repoContext);
                }

                return _photo;
            }
        }
        public ISizePorductRepository SizePorduct
        {
            get
            {
                if (_sizeProd == null)
                {
                    _sizeProd = new SizeProdRepository(_repoContext);
                }

                return _sizeProd;
            }
        }


        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_repoContext);
                }

                return _order;
            }
        }
        public IAddressOrderRepository AddressOrder
        {
            get
            {
                if (_addressOrder == null)
                {
                    _addressOrder = new AddressOrderRepository(_repoContext);
                }

                return _addressOrder;
            }
        }
        public ISubCategoryRepository SubCategory
        {
            get
            {
                if (_subCategory == null)
                {
                    _subCategory = new SubCategoryRepository(_repoContext);
                }

                return _subCategory;
            }
        }

        public RepositoryWrapper(BazaDataBase repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
