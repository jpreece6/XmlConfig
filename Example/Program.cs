using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlConfig;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Config.Default.App.Name} : Version {Config.Default.App.Version}");

            Console.WriteLine("\nFeel the power of simple xml configuration");

            SuperSecret(Config.Default.Secret.Show);

            Config.Default.Secret.Show = true;
            Config.Save();

            SuperSecret(Config.Default.Secret.Show);
            

            Console.ReadKey();
        }

        private static void SuperSecret(bool flag)
        {
            if (flag)
                Console.WriteLine("\nPowered by the force...");
        }
    }
}
