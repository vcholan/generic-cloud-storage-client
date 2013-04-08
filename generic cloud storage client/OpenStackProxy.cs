using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generic_cloud_storage_client
{
    class OpenStackProxy:ICloudRequest{
        private string  username;
        private string password;
        private string token;
        public OpenStack openstackobject;
    
       public  OpenStackProxy(String username,String password){
        this.username=username;
        this.password = password;
        
        }
        public string Authenticate(string username, string password)
        {
            if (this.username == username && this.password == password)
            {
                openstackobject = new OpenStack();
                return "Please check your username and password";
            }
            else
            {
                Console.Write("Áccess granted");
                return token;
            }

        }

        public bool CreateFolder(string foldername)
        {
            if (this.openstackobject != null)
            {
                openstackobject.CreateFolder(foldername);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteFolder(string foldername)
        {
            if (this.openstackobject != null)
            {
                openstackobject.DeleteFolder(foldername); ;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListFolders()
        {
            if (this.openstackobject != null)
            {
                openstackobject.ListFolders();
                
            }
            else
            {
               
        }

        public bool UploadFile(string filename)
        {
            if (this.openstackobject != null)
            {
                openstackobject.UploadFile(filename);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DownloadFile(string filename)
        {
            if (this.openstackobject != null)
            {
                openstackobject.DownloadFile(filename);
               
            }
            else
            {
               
            }
        }

        public bool DeleteFile(string filename)
        {
            if (this.openstackobject != null)
            {
                openstackobject.DeleteFile(filename);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListFiles()
        {
            if (this.openstackobject != null)
            {
                openstackobject.ListFiles();

            }
            else
            {
                
            }
        }
    }
}
