/*Author- Riju Vashisht
 *Interface for all cloud request made by client.
 *Date created 3/26/2013
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace generic_cloud_storage_client
{
    interface ICloudRequest
    {



        /// <summary>
        /// Authenticate user with username(String) and password(String)  
        /// </summary>
        /// <returns>returns a token which is  String type</returns>
        public virtual String Authenticate(String username, String password);

        /// <summary>
        /// Create Folder  foldername(String) if the space is available.  
        /// </summary>
        /// <returns>returns a boolean if succesfully folder is created</returns>
        public virtual Boolean CreateFolder(String foldername);

        /// <summary>
        /// Deletes a folder foldername(String) .  
        /// </summary>
        /// <returns>returns a boolean if succesfully folder is deleted</returns>
        public virtual Boolean DeleteFolder(String foldername);

        /// <summary>
        /// List all the folders on cloud  
        /// </summary>
        /// <returns>returns a token which is  String type</returns>
        public virtual void ListFolders();

        /// <summary>
        /// Uploads a file to the folder name (String)
        /// </summary>
        /// <returns>returns a true if the file is uploaded </returns>
        public virtual Boolean UploadFile(String filename);

        /// <summary>
        /// downloads a file form the selected folder.  
        /// </summary>
        /// <returns>Returns void</returns>
        public virtual void DownloadFile(String filename);

        /// <summary>
        /// Deletes a file in it is a valid file name
        /// </summary>
        /// <returns>returns true if the file is successfully deleted</returns>
        public virtual Boolean DeleteFile(String filename);

        /// <summary>
        /// List al the files in the cloud folders.
        /// </summary>
        /// <returns>returns void</returns>
        public virtual void ListFiles();





    }
}