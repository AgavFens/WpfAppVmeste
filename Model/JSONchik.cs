using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppVmeste
{
    internal class JSONchik
    {
        public static void mySerialize<T>(T list)
        {
            string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\6 практическая.json";
            if (!File.Exists(PathToDesktop))
            {
                File.Create(PathToDesktop).Close();
            }
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(PathToDesktop, json);
        }
        public static T myDeserialize<T>()
        {
            string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\6 практическая.json";
            if (!File.Exists(PathToDesktop))
            {
                File.Create(PathToDesktop).Close();
            }
            string json = File.ReadAllText(PathToDesktop);
            T list = JsonConvert.DeserializeObject<T>(json);
            return list;
        }
    }
}
