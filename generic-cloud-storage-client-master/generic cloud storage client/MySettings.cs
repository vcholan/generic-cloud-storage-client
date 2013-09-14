using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace generic_cloud_storage_client
{
    /// <summary>
    /// This class is used to save the default settings for the app by saving the username and password
    /// Author- Riju Vashisht date - 05/21/2013
    /// Please do not change it unless you know what you are doing.
    /// </summary>
  public   class MySettings
    {
        public string Username{get; set;}
        public string Password { get; set; }

        public void Save()
        {
          using(Stream stream= File.Create(SettingsFile))//FIle returns stream

            {
                try
                {

                    XmlSerializer ser = new XmlSerializer(this.GetType());//writes bytes in the file
                    ser.Serialize(stream, this);
                }
                catch (InvalidOperationException)
                {
                    stream.Close();


                }
         }
        }
     
      /// <summary>
      /// load if not curropted if curropted file do not hang check the catch block and close the file and load again with defualt settings
      /// </summary>
      /// <returns></returns>
      public static MySettings Load()
        {
            if (!File.Exists(SettingsFile))
                return DefaultSettings;
                 using(Stream stream = File.OpenRead(SettingsFile))
              
                 {
                     try{

                    XmlSerializer ser=new XmlSerializer(typeof(MySettings));

                     return (MySettings)ser.Deserialize(stream);
                 }
                     catch (InvalidOperationException)
                     {
                         stream.Close();
                         File.Delete(SettingsFile);
                         return DefaultSettings;
                     }
                     
                 }
        
          
        }
/// <summary>
/// To save the settings or password file in the appdata
/// file,directory and path
/// </summary>
        public static string SettingsFolder
        {
            get
            {
                string folder = Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData);
                folder = Path.Combine(folder,"OpenStack");
                folder = Path.Combine(folder,"MyApp");
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                return folder;
            }
        }

        public static string SettingsFile
        {
            get
            {
                return Path.Combine(SettingsFolder, "settings.xml");
            }
        }


        /// <summary>
        /// Creates Default settings if there is no settings
        /// 
        /// </summary>
        private static MySettings DefaultSettings {
            get
            {
                return new MySettings { 
                    Username = "",
                    Password = new Encrypt().Encrypting(""),
                
                };

            }
        }
            

    }
}
