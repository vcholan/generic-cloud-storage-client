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
            OpenStack o = new OpenStack("hello","e4rr43w");
           string token=o.Authenticate();
           Console.WriteLine(token);
           Console.Read();
        }
    }
}
