using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueAsp.Models;

namespace VueAsp.Data.Interfaces
{
    public interface IAddressOrderRepository : IRepositoryBase<AddressOrder>
    {
		IEnumerable<AddressOrder> GetAddress();
		Order GetAddressById(Guid addresId);
		Order GetAddressWithDateils(Guid orderId, Guid addresId);
		void CreateAddress(AddressOrder addressOrder);
		void UpdateAddress(AddressOrder addressOrder);
		void DeleteAddress(AddressOrder addressOrder);
	}
}
