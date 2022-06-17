using Leaf.xNet;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantify
{
    internal class Loader
    {
        public static void LoadProxyCombo(string module)
        {
            Utilities.Status = "Selecting Combo For Module - " + module;
            Console.Title = "☪︎ Quantify AIO | Selecting Combo For Module - " + module;
            Utilities.Upd();
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.ForegroundColor = Color.Purple;
            Console.CursorVisible = false;
            var openFileDialog = new OpenFileDialog();
            string fileName; 
            do
            {
                openFileDialog.Title = "Select Combo";
                openFileDialog.DefaultExt = "txt";
                openFileDialog.Filter = "Text files|*.txt";
                openFileDialog.ShowDialog();
                fileName = openFileDialog.FileName;
            } while (!File.Exists(fileName) || fileName == null);
            Vars.ComboFileName = openFileDialog.FileName;
            Vars.FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            LoadFiles(module);
            Vars.TotalLoadedCombos = combosList.Count;
            proxyType();
            var flag = Vars.Proxytype != 5;
            if (flag) LoadProxiess();
        }
        public static List<string> CCombo = new List<string>();
        public static List<string> Prox = new List<string>();
        public static bool usegcs = false;
        public static int totalcombo = 0;
        public static int invalidlines = 0;
       
        public static bool LoadFiles(string module)
        {
            CCombo = new List<string>(File.ReadAllLines(Vars.ComboFileName));
            int count = CCombo.Count;
            CCombo = CCombo.Distinct<string>().ToList<string>();
            int num = count - CCombo.Count;
            bool flag = num != 0;
            foreach (string item in CCombo)
            {
                Vars.ComboList.Enqueue(item);
            }
            Vars.loadedCombos = Vars.ComboList.Count;
            if (Vars.ComboList.Count<string>() > 0)
            {
                return true;
            }
            LoadProxyCombo(module);
            return false;
        }
        public static List<string> combosList = new List<string>();
        public static void LoadProxiess()
        {
            LoadProxies();
        }
        public static void LoadProxies()
        {
            var openFileDialog = new OpenFileDialog();
            string fileName;
            do
            {
                openFileDialog.Title = "Choose Proxies";
                openFileDialog.DefaultExt = "txt";
                openFileDialog.Filter = "Text files|*.txt";
                openFileDialog.ShowDialog();
                fileName = openFileDialog.FileName;
            } while (!File.Exists(fileName) || fileName == null);
            var array = File.ReadAllLines(openFileDialog.FileName);
            foreach (var item2 in array) Vars.Proxiess.Add(item2);
        }
        public static void proxyType()
        {
            Utilities.Status = "Setting Proxy Type For Module - " + Vars.Module;
            Console.Title = "☪︎ Quantify AIO | Setting Proxy Type For Module - " + Vars.Module;
            Utilities.Upd();
        REDO:
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.ForegroundColor = Color.Purple;
            Console.CursorVisible = false;
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Setting Proxy Type For Module - " + Vars.Module, Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}#{4} - What Proxy Type", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}1{4} - HTTPS", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}2{4} - SOCKS4", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}3{4} - SOCKS5", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}4{4} - PROXYLESS", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Vars.proxyType = ProxyType.HTTP;
            var aa = Console.ReadKey(true).KeyChar;
            var a = aa.ToString();
            if (!(a == "1"))
            {
                if (!(a == "2"))
                {
                    if (!(a == "3"))
                    {
                        if (a == "x" || a == "X")
                        {
                            LoadProxyCombo(Vars.Module);
                        }
                        else
                        {
                            if (!(a == "4")) 
                            {
                                goto REDO;
                            }
                            Vars.Proxytype = 5;
                            Vars.proxyType = ProxyType.HTTP;
                        }
                    }
                    else
                    {
                        Vars.Proxytype = 3;
                        Vars.proxyType = ProxyType.Socks5;
                    }
                }
                else
                {
                   Vars.Proxytype = 2;
                    Vars.proxyType = ProxyType.Socks4;
                }
            }
            else
            {
               Vars.Proxytype = 1;
                Vars.proxyType = ProxyType.HTTP;
            }
        }
    }
}
