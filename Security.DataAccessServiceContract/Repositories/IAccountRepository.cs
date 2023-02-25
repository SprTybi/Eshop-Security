using Security.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.DataAccessServiceContract.Repositories
{
    public class IAccountRepository
    {
        public UserInfo GetUserInf{ get; set; }
        public User MyProperty { get; set; }
    }
}

