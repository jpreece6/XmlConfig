
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XmlConfig
{
    public static class Config
    {
        public static dynamic Default = new ConfigObject();
        public static string SavePath { get; set; }

        static Config()
        {
            try
            {
                SavePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) +
                           @"\config.xml";
            }
            catch (NullReferenceException nref)
            {
                SavePath = @"C:\config.xml";
            }

            if (File.Exists(SavePath) == false)
            {
                File.Create(SavePath).Close();
                File.WriteAllText(SavePath, "<?xml version=\"1.0\" encoding=\"utf-8\"?><ConfigObject></ConfigObject>");
            }

            Load(SavePath);
        }

        /// <summary>
        /// Saves configuration to disk
        /// </summary>
        public static void Save()
        {
            Serialise(Default);
        }

        /// <summary>
        /// Load a configuration from the save path location
        /// </summary>
        public static void Load()
        {
            Default = Deserialise(SavePath);
        }

        /// <summary>
        /// Load a configuration from a specified path
        /// </summary>
        /// <param name="path">Path to load from</param>
        public static void Load(string path)
        {
            Default = Deserialise(path);
        }

        private static ConfigObject Deserialise(string path)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ConfigObject));
            ConfigObject subReq;

            using (XmlReader reader = XmlReader.Create(path))
            {
                subReq = (ConfigObject)xsSubmit.Deserialize(reader);
            }

            return subReq;
        }

        private static void Serialise(ConfigObject data)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(ConfigObject));
            var subReq = data;

            using (XmlWriter writer = XmlWriter.Create(SavePath))
            {
                xsSubmit.Serialize(writer, subReq);
            }
        }
    }
}
