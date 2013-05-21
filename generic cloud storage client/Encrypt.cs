using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace generic_cloud_storage_client
{
   public class Encrypt
    {
                  
        
        public  String Encrypting(String st){
           Byte[] originalBytes;
  Byte[] encodedBytes;
  MD5 md5;

   md5 = new MD5CryptoServiceProvider();
  originalBytes = ASCIIEncoding.Default.GetBytes(st);
  encodedBytes = md5.ComputeHash(originalBytes);

  //Convert encoded bytes back to a 'readable' string
  return BitConverter.ToString(encodedBytes);
       }
       
    
    
    
    }


    }

