using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Data
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    {
        public BrandRepository(BazaDataBase repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
