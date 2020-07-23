using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;

namespace VueAsp.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BazaDataBase _repoContext;
        private IBrandRepository _brand;
        private IProductRepository _product;

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

        public ICategoryRepository Category => throw new NotImplementedException();

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
