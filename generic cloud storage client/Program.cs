using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_cloud_storage_client
{
    class Program
    {
      
        static void Main(string[] args)
        {
            String token;
            OpenStack o = new OpenStack("helo","e4rr4");
           token=o.Authenticate();
           Console.WriteLine(token);
           OpenStack o1 = new OpenStack("helo1", "e4rr41");
           token=o1.Authenticate();
           Console.WriteLine(token);
           OpenStack o2 = new OpenStack("helo", "e4rr4");
           token = o2.Authenticate();
           Console.WriteLine(token);
           Console.Read();
        }
    }
}
