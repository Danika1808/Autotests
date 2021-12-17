using System;
using System.IO;
using System.Xml.Serialization;

namespace Autotests.Models.Settings
{
    public class Settings
    {
        public AuthenticationData AuthenticationData { get; set; }
        public SiteData SiteData { get; set; }

        public Settings()
        {
        }
        
        public static Settings CreateInstance(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new Exception("Problem: settings file not found: " + filePath);
            }

            return (Settings) new XmlSerializer(typeof(Settings))
                .Deserialize(new StreamReader(filePath));
        }
    }
}