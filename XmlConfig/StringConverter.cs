using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlConfig
{
    public static class StringConverter
    {
        public const string Int32 = "System.Int32";
        public const string Int16 = "System.Int16";
        public const string Bool = "System.Boolean";

        public static object ConvertString(string typeKey, string val)
        {
            switch (typeKey)
            {
                case Int32:
                    return ToInt32(val);
                case Int16:
                    return ToInt16(val);
                case Bool:
                    return ToBool(val);
            }

            return val;
        }

        public static bool ToBool(string val)
        {
            return Convert.ToBoolean(val);
        }

        public static Int16 ToInt16(string val)
        {
            return Convert.ToInt16(val);
        } 

        public static int ToInt32(string val)
        {
            return Convert.ToInt32(val);
        }
    }
}
