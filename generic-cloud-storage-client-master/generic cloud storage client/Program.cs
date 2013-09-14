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
           // String token;
           // OpenStack o = new OpenStack("helo","e4rr4");
           //token=o.Authenticate();
           //Console.WriteLine(token);
           //OpenStack o1 = new OpenStack("helo1", "e4rr41");
           //token=o1.Authenticate();
           //Console.WriteLine(token);
           //OpenStack o2 = new OpenStack("helo", "e4rr4");
           //token = o2.Authenticate();
           //Console.WriteLine(token);
           //Console.Read();
           
           Rackspace rackspace = new Rackspace("IDHere", "APIKeyHere");
           rackspace.Authenticate();
           Console.WriteLine("Token Recieved: " + rackspace.TokenId);
           //Console.WriteLine(rackspace.CreateFolder("TestFolder"));
           //Console.WriteLine(rackspace.CreateFolder("TestFolder1"));
           //Console.WriteLine(rackspace.DeleteFolder("TestFolder1"));
           //rackspace.ListFolders();
           //Console.WriteLine(rackspace.UploadFile("TestFolder", "PathHere\TestFile.txt"));
           //rackspace.DownloadFile("TestFolder", "PathHere", "TestFile.txt");
           //Console.WriteLine(rackspace.DeleteFile("TestFolder", "TestFile.txt"));
           //rackspace.ListFiles("TestFolder");
           Console.ReadLine();        
        }
    }
}
