using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Data.Interfaces;
using VueAsp.Models;

namespace VueAsp.Data
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository, IDisposable
    {
        public OrderRepository(BazaDataBase repositoryContext):
            base(repositoryContext)
        {
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

        public IEnumerable<Order> GetOrders()
        {
          return  this.RepositoryContext.Orders;
        }

        public Order GetOrderById(Guid orderId)
        {
            return this.RepositoryContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
        }

        public Order GetOrderWithDateils(Guid orderId)
        {
            return this.RepositoryContext.Orders.Where(o => o.Id == orderId).FirstOrDefault();
        }

        public void CreateOrder(Order order)
        {
            this.RepositoryContext.Orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            this.RepositoryContext.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            this.RepositoryContext.Orders.Remove(order);
        }
    }
}
