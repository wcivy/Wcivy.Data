using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcivy.Data.Dapper;
using Wcivy.Data.Dapper.Core;

namespace Test
{
    public class UsersRepostity : MSSqlRepository<Users, int>, IUsersRepostity
    {
        public UsersRepostity() : base()
        {
        }
        public UsersRepostity(IUnitOfWork unitofwork) : base(unitofwork)
        {
        }
    }
}
