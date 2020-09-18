using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Data
{
    public class AddressOrderRepository : RepositoryBase<AddressOrder>, IAddressOrderRepository, IDisposable
    {
        public AddressOrderRepository(BazaDataBase repositoryContext)
            :base(repositoryContext)
        {
        }

        public void CreateAddress(AddressOrder addressOrder)
        {
            throw new NotImplementedException();
        }

        public void DeleteAddress(AddressOrder addressOrder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AddressOrder> GetAddress()
        {
            throw new NotImplementedException();
        }

        public Order GetAddressById(Guid addresId)
        {
            throw new NotImplementedException();
        }

        public Order GetAddressWithDateils(Guid orderId, Guid addresId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(AddressOrder addressOrder)
        {
            throw new NotImplementedException();
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
    }
}
