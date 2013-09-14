
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCloudStorageClient
{
    class GoogleCloudStorage:ICloudRequest
    {
        public string Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool CreateFolder(string foldername)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFolder(string foldername)
        {
            throw new NotImplementedException();
        }

        public void ListFolders()
        {
            throw new NotImplementedException();
        }

        public bool UploadFile(string filename)
        {
            throw new NotImplementedException();
        }

        public void DownloadFile(string filename)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFile(string filename)
        {
            throw new NotImplementedException();
        }

        public void ListFiles()
        {
            throw new NotImplementedException();
        }
    }
}
