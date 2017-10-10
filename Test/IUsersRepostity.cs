using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wcivy.Data.Dapper.Core;

namespace Test
{
    public interface IUsersRepostity : IRepository<Users, int>
    {
    }
}
