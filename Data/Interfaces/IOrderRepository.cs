using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.Data.Interfaces
{
   public interface IOrderRepository : IRepositoryBase<Order>
    {
		IEnumerable<Order> GetOrders();
		Order GetOrderById(Guid orderId);
		Order GetOrderWithDateils(Guid orderId);
		void CreateOrder(Order order);
		void UpdateOrder(Order order);
		void DeleteOrder(Order order);
	}
}
