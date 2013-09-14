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


        public String Encrypting(String st)
        {
            Byte[] _OriginalBytes;
            Byte[] _EncodedBytes;
            MD5 _Md5;

            _Md5 = new MD5CryptoServiceProvider();
            _OriginalBytes = ASCIIEncoding.Default.GetBytes(st);
            _EncodedBytes = _Md5.ComputeHash(_OriginalBytes);

            //Convert encoded bytes back to a 'readable' string
            return BitConverter.ToString(_EncodedBytes);
        }




    }


}

