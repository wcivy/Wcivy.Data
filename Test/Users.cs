using DapperExtensions.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Users
    {
        public int id { get; set; }
        
        public string userId { get; set; }
        public string userName { get; set; }
        public int state { get; set; }
    }

    public class UsersMapper : ClassMapper<Users>
    {
        public UsersMapper()
        {
            Table("Users");
            Map(f => f.id).Column("id").Key(KeyType.Identity);
            AutoMap();
        }
    }
}
