/*Author- Dalvir Singh
 *Class to implement methods of cloud requests made by client
 *Date created 3/26/2013
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;

namespace generic_cloud_storage_client
{
    class Google : ICloudRequest
    {
        /// <summary>
        /// Authenticate using username and password
        /// </summary>
        /// <param name="username">Username of string type</param>
        /// <param name="password">Password of string type</param>
        /// <returns>Returns a token of String type</returns>
        public String Authenticate(String username, String password) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a folder inside the container
        /// </summary>
        /// <param name="folderName">Folder name of string type</param>
        /// <returns>Returns true if folder is created, otherwise false</returns>
        public  Boolean CreateFolder(String folderName) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a folder
        /// </summary>
        /// <param name="folderName">Folder name of String type</param>
        /// <returns>Returns true if folder is deleted, otherwise false </returns>
        public  Boolean DeleteFolder(String folderName) 
        {
            throw new NotImplementedException();
            
        }

        /// <summary>
        /// List all the folders
        /// </summary>
        public  void ListFolder() 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Upload a file
        /// </summary>
        /// <param name="filename">File Name of String type</param>
        /// <returns>Returns true if file is successfully uploaded, otherwise false</returns>
        public  Boolean UploadFile(String fileName) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Download a file
        /// </summary>
        /// <param name="filename">File Name of String type</param>
        /// <returns>Returns true if file is successfully deleted, otherwise false</returns>
        public  Boolean DownloadFile(String fileName) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete a file
        /// </summary>
        /// <param name="fileName">File Name of String type</param>
        /// <returns>Returns true if file is successfully deleted, otherwise false</returns>
        public  Boolean DeleteFile(String fileName) 
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// List all files in a folder
        /// </summary>
        public  void ListFiles() 
        {
            throw new NotImplementedException();
        }



        public void ListFolders()
        {
            throw new NotImplementedException();
        }

        void ICloudRequest.DownloadFile(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
