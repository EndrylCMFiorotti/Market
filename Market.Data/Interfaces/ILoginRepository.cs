using Market.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Data.Interfaces {
    public interface ILoginRepository {
        Task<User> LogIn(User user);
        Task LogOut(User user);
    }
}
