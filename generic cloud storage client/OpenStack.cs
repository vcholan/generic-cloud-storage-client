using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenStack.Swift;

namespace generic_cloud_storage_client
{
    class OpenStack:ICloudRequest{
        private string  username;
        private string password;
        private string token;
        public OpenStack openstackobject;
        private MySettings settings;
        private Dictionary<string, string> headers;
        private Dictionary<string, string> query;
        private static bool isSaved=false;
    
       public  OpenStack(String user,String pass){
        this.username=user;
        this.password = pass;
        if (!isSaved)
        {
            settings = new MySettings();
            settings.Username = user;
            settings.Password = new Encrypt().Encrypting(pass);
            settings.Save();
            isSaved = true;
        }
       
        
        }
        public string Authenticate()
        {
            settings = MySettings.Load();//geting password and username from my settings file
            
            if (!(this.username == settings.Username && new Encrypt().Encrypting(this.password) == settings.Password))
            {
                
                return "Please check your username and password";
            }
            else
            {
               
                SwiftClient SC = new SwiftClient();
                headers = new Dictionary<string, string>();
                query = new Dictionary<string, string>();
              //  SC.GetAuth("localhost","jdoe","a86850",headers,query,false);//requires host....
                Console.Write("Áccess granted");
               // settings.Save();
                token = "true";
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
