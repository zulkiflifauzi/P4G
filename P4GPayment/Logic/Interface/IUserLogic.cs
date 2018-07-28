using P4GPayment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4GPayment.Logic.Interface
{
    public interface IUserLogic : IBaseLogic<ApplicationUser>
    {
        List<ApplicationUser> GetFreeUsers();
    }
}
