using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IUsersRepostity test = new UsersRepostity();
            
            var a = test.Query(p=>p.userId == "10001").Page(0, 5).OrderBy(o=>o.id).OrderBy(o=>o.userId).ToList();

            Console.WriteLine("Press RETURN to exit.");
            Console.ReadLine();
        }
    }
}
