using P4GPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4GPayment.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<ApplicationUser>
    {
        List<ApplicationUser> GetFreeUsers(List<int> exceptions);
    }
}
