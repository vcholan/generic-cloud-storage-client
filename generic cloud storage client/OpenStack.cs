using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenStack.Swift;

namespace generic_cloud_storage_client
{
    class OpenStack:ICloudRequest{
        private string  _Username;
        private string _Password;
        private string _Token;
        public OpenStack _Openstackobject;
        private MySettings _Settings;
        private Dictionary<string, string> _Headers;
        private Dictionary<string, string> _Query;
        private static bool isSaved=false;
    
       public  OpenStack(String user,String pass){
        this._Username=user;
        this._Password = pass;
        if (!isSaved)
        {
            _Settings = new MySettings();
            _Settings.Username = user;
            _Settings.Password = new Encrypt().Encrypting(pass);
            _Settings.Save();
            isSaved = true;
        }
       
        
        }
        public string Authenticate()
        {
            _Settings = MySettings.Load();//geting password and username from my settings file
            
            if (!(this._Username == _Settings.Username && new Encrypt().Encrypting(this._Password) == _Settings.Password))
            {
                
                return "Please check your username and password";
            }
            else
            {
               
                SwiftClient SC = new SwiftClient();
                _Headers = new Dictionary<string, string>();
                _Query = new Dictionary<string, string>();
              //  SC.GetAuth("localhost","jdoe","a86850",headers,query,false);//requires host....
                Console.Write("Áccess granted");
               // settings.Save();
                _Token = "true";
                return _Token;
            }

        }

        public bool CreateFolder(string foldername)
        {
            if (this._Openstackobject != null)
            {
                _Openstackobject.CreateFolder(foldername);
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteFolder(string foldername)
        {
            if (this._Openstackobject != null)
            {
                _Openstackobject.DeleteFolder(foldername); ;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListFolders()
        {
            if (this._Openstackobject != null)
            {
                _Openstackobject.ListFolders();
                
            }
           
               
        }

        public bool UploadFile(string filename)
        {
            if (this._Openstackobject != null)
            {
                _Openstackobject.UploadFile(filename);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DownloadFile(string filename)
        {
            if (this._Openstackobject != null)
            {
                _Openstackobject.DownloadFile(filename);
               
            }
            else
            {
               
            }
        }

        public bool DeleteFile(string filename)
        {
            if (this._Openstackobject != null)
            {
                _Openstackobject.DeleteFile(filename);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListFiles()
        {
            if (this._Openstackobject != null)
            {
                _Openstackobject.ListFiles();

            }
            else
            {
                
            }
        }
    }
}
