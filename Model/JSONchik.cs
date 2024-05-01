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
        public static void mySerialize<T>(T notebook)
        {
            string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\6 практическая.json";
            string json = JsonConvert.SerializeObject(notebook);
            File.WriteAllText(PathToDesktop, json);
        }
        public static T myDeserialize<T>()
        {
            string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\6 практическая.json";
            string json = File.ReadAllText(PathToDesktop);
            T notebookdeser = JsonConvert.DeserializeObject<T>(json);
            return notebookdeser;
        }
    }
}
