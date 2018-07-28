using P4GPayment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4GPayment.Repositories.Interfaces
{
    public interface IAddressRepository : IBaseRepository<Address>
    {
        List<int> GetAttachedUserIds();

        bool IsAddressExist(string street, int number, int? exceptionId = null);
    }
}
