using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XmlConfig
{
    public static class Config
    {
        public static dynamic Default = new ConfigObject();
        public static string SavePath;

        static Config()
        {
            SavePath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + @"\config.xml";
            Load(SavePath);
        }

        public static void Save(ConfigObject config)
        {
            Serialise(config);
        }

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
