using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using net.openstack.Core;
using net.openstack.Core.Domain;
using net.openstack.Core.Exceptions;
using net.openstack.Core.Caching;
using net.openstack.Core.Providers;
using net.openstack.Core.Validators;
using net.openstack.Core.Exceptions.Response;
using net.openstack.Providers.Rackspace;
using net.openstack.Providers.Rackspace.Exceptions;
using net.openstack.Providers.Rackspace.Objects;
using net.openstack.Providers.Rackspace.Validators;
using System.IO;


namespace generic_cloud_storage_client
{
    //Created By: Jagmeet Singh Sanga
    class Rackspace : ICloudRequest
    {
        private string username;//private variable for username     
        private string apiKey;//private variable for api access key
        private IdentityToken token;//Creating an object of IdentityToken class
        private UserDetails userdetails;//Creating an object of UserDetails class        
        public string TokenId { get; set; }//Creating a property for setting and getting the TokenId

        private CloudIdentity identity;//Creating an object of CloudIdentity class
        private CloudIdentityProvider provider;//Creating an object of CloudIdentityProvider class
        private CloudFilesProvider cloudFiles;//Creating an object of CloudFilesProvider class

        public IEnumerable<Container> container;//creating an IEnumerable that will hold the list of containers(folders)
        public IEnumerable<ContainerObject> containerObject;//creating a IEnumerable that will hold the list of container objects(files)

        //Constructor accpeting the username, password or apikey
        public Rackspace(string username, string apiKey)
        {
            this.username = username; //setting the username property       
            this.apiKey = apiKey; //setting the apikey property
            //Creating an instance of CloudIdentity
            identity = new CloudIdentity();

            identity.Username = username; 
            identity.APIKey = apiKey; 
        }
        //Method to Authenticate the credentials and obtain token
        public void Authenticate()
        {
            try
            {
                //Creating an instance of CloudIdentityProvider providing the CloudIdentity object and urls in the constructor
                provider = new CloudIdentityProvider(identity, "https://identity.api.rackspacecloud.com/v1.0", "https://lon.identity.api.rackspacecloud.com/v1.0");
                //Calling the authenticate method which returns an UserAccess object containing token and user details
                UserAccess access = provider.Authenticate(identity);

                token = access.Token;
                
                userdetails = access.User;
                //Set the TokenId property 
                TokenId = token.Id;
                //Verify with other programmers to make this method void
                cloudFiles = new CloudFilesProvider(identity);
                //return token.Id;
            }

            catch (UserAuthenticationException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (UserAuthorizationException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (UserNotAuthorizedException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        //Method to create a container
        public bool CreateFolder(string foldername)
        {
            try
            {
                //Creating an instance of CloudFilesProvider
                
                if (cloudFiles.CreateContainer(foldername, null, false, null) == ObjectStore.ContainerExists || cloudFiles.CreateContainer(foldername, null, false, null) == ObjectStore.Unknown)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (ContainerNameException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
        //Method to delete a container
        public bool DeleteFolder(string foldername)
        {
            try
            {                
                if (cloudFiles.DeleteContainer(foldername, true, null, false, null) == ObjectStore.ContainerDeleted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (ContainerNameException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            
        }
        //Method to List the folders
        public void ListFolders()
        {
            //throw new NotImplementedException();
            try
            {                
                List<Container> cont = new List<Container>();
                container = cloudFiles.ListContainers(null, null, null, null, false, null);                

                foreach (Container c in container)
                {
                    Console.WriteLine(c.Name);
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public bool UploadFile(string filename)
        {
            throw new NotImplementedException();            
        }
        //Method to upload a file to  container
        public bool UploadFile(string container,string filename)
        {
            try
            {
                FileInfo info = new FileInfo(filename);
                int size = Convert.ToInt32(info.Length);
                //cloudFiles = new CloudFilesProvider(identity);
                cloudFiles.CreateObjectFromFile(container, info.FullName, info.Name, size, null, null, null, false, null);
                return true;
            }
            catch (ObjectNameException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;  
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }            
        }

        public void DownloadFile(string filename)
        {
            throw new NotImplementedException();
        }
        //Method to download a file from a container
        public void DownloadFile(string container, string saveDirectory,string objectName)
        {
            try
            {
                //cloudFiles = new CloudFilesProvider(identity);
                cloudFiles.GetObjectSaveToFile(container, saveDirectory, objectName, null, 65536, null, null, false, null, false, null);
            }
            catch (ObjectNameException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public bool DeleteFile(string filename)
        {
            throw new NotImplementedException();
        }
        //Method to delete a file froma container
        public bool DeleteFile(string container,string objectName)
        {
            try
            {
                //cloudFiles = new CloudFilesProvider(identity);
                if (cloudFiles.DeleteObject(container, objectName, null, true, null, false, null) == ObjectStore.ObjectDeleted)
                {
                    return true;
                }
                else
                {
                    return false;
                }                
            }
            catch (ObjectNameException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public void ListFiles()
        {
            throw new NotImplementedException();
        }
        //Method to list files in a container
        public void ListFiles(string container)
        {
            try
            {
                //cloudFiles = new CloudFilesProvider(identity);
                
                containerObject = cloudFiles.ListObjects(container, null, null, null, null, false, null);

                foreach (ContainerObject cb in containerObject)
                {               
                    Console.WriteLine(cb.Name);
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
