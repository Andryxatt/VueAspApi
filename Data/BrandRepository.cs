﻿using System;
using System.Collections.Generic;
using System.Linq;
using VueAsp.Data.Interfaces;
using VueAsp.Models;
using VueAsp.ViewModels;

namespace VueAsp.Data
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository, IDisposable
    {
        public BrandRepository(BazaDataBase repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateBrand(Brand brand)
        {
            this.RepositoryContext.Brands.Add(brand);
        }

        public void DeleteBrand(Brand brand)
        {
            this.RepositoryContext.Brands.Remove(brand);
           
        }

        public Brand GetBrandById(Guid brandId)
        {
            return this.RepositoryContext.Brands.Find(brandId);
        }

        public IEnumerable<Brand> GetBrands()
        {
            return RepositoryContext.Brands.ToList();
        }

        public Brand GetBrandWithDetails(Guid brandId)
        {
            return this.RepositoryContext.Brands.Find(brandId);
        }

        public void UpdateBrand(Brand brand)
        {
            this.RepositoryContext.Brands.Update(brand);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    RepositoryContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public PagedList<Brand> GetBrands(BrandParameters brandParameters)
        {
            return PagedList<Brand>.ToPagedList(FindAll().OrderBy(on => on.NameBrand),
              brandParameters.PageNumber,
              brandParameters.PageSize);
        }

        public Brand GetBrandById(Guid? brandId)
        {
         return  this.RepositoryContext.Brands.Where(b=>b.BrandId == brandId).FirstOrDefault();
        }
    }
}
