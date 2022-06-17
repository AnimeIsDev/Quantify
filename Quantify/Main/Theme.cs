#region
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using Console = Colorful.Console;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Linq;
using Newtonsoft.Json.Linq;
using CaptchaSharp.Services;
using CaptchaSharp.Services.More;
using CaptchaSharp;
#endregion

namespace Quantify
{
    internal class Theme
    {
        public static void GetColors()
        {
            foreach (object colorValue in Enum.GetValues(typeof(KnownColor)))
            {
                Color coloor = Color.FromKnownColor((KnownColor)colorValue);
                colorss.Add(coloor);
            }
        }
        public static JObject res;

        public static string json;
         
        public static string Create()
        {
            return new JObject
            {
                {
                    "Design",
                    "CUI"
                },
                {
                    "Console Refresh Rate",
                    1500
                },
                {
                    "Beep On Hit",
                    false
                },
                {
                    "Theme",
                    "128"
                },
                {
                    "SecondaryTheme",
                    "66"
                },
                {
                    "Logo",
                    4
                }
            }.ToString();
        }
        public static void SetConfig()
        {
            File.WriteAllText("Quantify\\Settings.JSON", res.ToString());
            Read();
        }
        public static void Read()
        {
            if (!Directory.Exists("Quantify"))
            {
                Directory.CreateDirectory("Quantify");
            }
            try
            {
                json = File.ReadAllText("Quantify\\Settings.JSON");
            }
            catch
            {
                Console.Clear();
                Utilities.Logo(); 
                var flag2 = File.Exists("Quantify\\Settings.JSON");
                if (flag2) File.Delete("Quantify\\Settings.JSON");
                json = Create();
                Colorful.Console.WriteLineFormatted(" {2} {3}!{4} {1} Creating Default Settings!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                File.WriteAllText("Quantify\\Settings.JSON", json);
                Thread.Sleep(1500);
            }
            try
            {
                res = JObject.Parse(json);
                Vars.Design = res["Design"].ToString();
                Vars.RefreshRate = Convert.ToInt32(res["Console Refresh Rate"]);
                Vars.BeepOnHit = Convert.ToBoolean(res["Beep On Hit"]);
                Utilities.Theme = res["Theme"].ToString();
                Utilities.Theme1 = res["SecondaryTheme"].ToString();
                int num = Convert.ToInt32(Utilities.Theme);
                Utilities.ThemeColor = colorss[num];
                int num2 = Convert.ToInt32(Utilities.Theme1);
                Utilities.ThemeColor2 = colorss[num2];
                Utilities.Loggo = Int32.Parse(res["Logo"].ToString());
            }
            catch
            {
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Error Found In Default Settings!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                var flag3 = File.Exists("Quantify\\Settings.JSON");
                if (flag3) File.Delete("Quantify\\Settings.JSON");
                Thread.Sleep(2000);
                Read();
                Utilities.Logo();
            }

        }
        public static List<Color> colorss = new List<Color>();
        public static Random _random = new Random();
        public static int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public static void RandomTheme()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            int num = 0;
            for (int i = 0; i < colorss.Count; i++)
            {
                string coll = colorss[i].ToString();
                coll = coll.Replace("Color ", "");
                coll = coll.Replace("[", "");
                coll = coll.Replace("]", "");
                num++;
            }
            int numm = RandomNumber(0, colorss.Count);
            int numm2 = RandomNumber(0, colorss.Count);
            Utilities.ThemeColor = colorss[numm];
            Utilities.ThemeColor2 = colorss[numm2];
            res["Theme"] = numm.ToString();
            res["SecondaryTheme"] = numm2.ToString();
            SetConfig();
            SettingsMenu();
        }
        public static void RandomLogo()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            int num = 0;
            for (int i = 0; i < colorss.Count; i++)
            {
                string coll = colorss[i].ToString();
                coll = coll.Replace("Color ", "");
                coll = coll.Replace("[", "");
                coll = coll.Replace("]", "");
                num++;
            }
            int numm = RandomNumber(0, colorss.Count);
            int numm2 = RandomNumber(0, colorss.Count);
            Utilities.ThemeColor = colorss[numm];
            Utilities.ThemeColor2 = colorss[numm2];
            res["Theme"] = numm.ToString();
            res["SecondaryTheme"] = numm2.ToString();
            SetConfig();
            SettingsMenu();
        }
        public static void Svar(int Logo)
        {
            try
            {
                Console.Write(" - [", Utilities.ThemeColor);
                Console.Write(Logo.ToString(), Color.LimeGreen);
                Console.Write("]", Utilities.ThemeColor);
                Console.WriteLine();
            }
            catch
            {
                Console.Write("Error.\n", Color.Pink);
            }
        }
        public static void Svarr(string Logo)
        {
            try
            {
                Console.Write(" - [", Utilities.ThemeColor);
                Console.Write(Logo, Color.LimeGreen);
                Console.Write("]", Utilities.ThemeColor);
                Console.WriteLine();
            }
            catch
            {
                Console.Write("Error.\n", Color.Pink);
            }
        }
        public static string BoolChecker(bool does)
        {
            Colorful.Console.CursorVisible = false;
            Colorful.Console.ForegroundColor = Color.Aqua;
            try
            {
                if (does)
                {
                    Colorful.Console.Write(" - [", Utilities.ThemeColor);
                    Colorful.Console.Write("True", Color.LimeGreen);
                    Colorful.Console.Write("]", Utilities.ThemeColor);
                    Colorful.Console.WriteLine();
                }
                else
                {
                    Colorful.Console.Write(" - [", Utilities.ThemeColor);
                    Colorful.Console.Write("False", Color.Red);
                    Colorful.Console.Write("]", Utilities.ThemeColor);
                    Colorful.Console.WriteLine();
                }
            }
            catch
            {
                Colorful.Console.Write("Error.\n", Color.Pink);
            }
            return "";
        }
        public static void SettingsMenu()
        {
            Console.Clear();
            Utilities.Logo();
            Console.ForegroundColor = Color.Aqua;
            Utilities.Status = "Looking at Settings";
            Console.Title = "☪︎ Quantify AIO | Looking at Settings";
            Utilities.Upd();
            Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}1{4} {1} Design", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Svarr(Vars.Design);
            Colorful.Console.WriteFormatted(" {2} {3}2{4} {1} Console Refresh Rate", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Svar(Vars.RefreshRate);
            Colorful.Console.WriteFormatted(" {2} {3}3{4} {1} Beep On Hit", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.BeepOnHit);
            Colorful.Console.WriteFormatted(" {2} {3}4{4} {1} Change Logo", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Svar(Utilities.Loggo);
            Colorful.Console.WriteLineFormatted(" {2} {3}5{4} {1} Change Color", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}TAB{4} {1} Capture Settings", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
          //  Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
         //   Colorful.Console.WriteLineFormatted(" {2} {3}TAB{4} {1} Captcha Settings", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            var option = System.Console.ReadKey();
            if (option.Key == ConsoleKey.Tab)
            {
                CustomCapture.CaptureMenu();
            }
            if (option.Key == ConsoleKey.D1)
            {
                bool beepOnHit = Vars.Design.Contains("CUI");
                if (beepOnHit)
                {
                    res["Design"] = "LOG";
                }
                else
                {
                    res["Design"] = "CUI";
                }
                SetConfig();
                SettingsMenu();
            }
            if (option.Key == ConsoleKey.D2)
            {
            YE: Console.Clear();
                Utilities.Logo();
                Console.ForegroundColor = Color.Aqua;
                Utilities.Status = "Editing Console Refresh Rate";
                Console.Title = "☪︎ Quantify AIO | Editing Console Refresh Rate";
                Utilities.Upd();
                
                Colorful.Console.WriteLineFormatted(" {2} {3}#{4} {1} Recommended Settings For Console Refresh Rate [1500]", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteFormatted(" {2} {3}#{4} {1} Console Refresh Rate In MS: ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                try
                {
                    int x = int.Parse(Colorful.Console.ReadLine());
                    res["Console Refresh Rate"] = x;
                    if (x >= 500)
                    {

                        SetConfig();
                        SettingsMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Utilities.Logo();
                        Colorful.Console.WriteLineFormatted(" {2} {3}!{4} {1} Please Use Over 500! Its Not Recommended To Use Lower Than 500!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                        Colorful.Console.WriteLine();
                        Thread.Sleep(1000);
                        goto YE;
                    }
                }
                catch
                {
                    Console.Clear();
                    Utilities.Logo();
                    Colorful.Console.WriteLineFormatted(" {2} {3}!{4} {1} An Error Occured. Please Try Again!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                    Colorful.Console.WriteLine();
                    Thread.Sleep(1000);
                    goto YE;
                }
                SetConfig();
                SettingsMenu();
            }
            if (option.Key == ConsoleKey.D3)
            {
                var beepOnHit = Vars.BeepOnHit;
                if (beepOnHit)
                {
                    res["Beep On Hit"] = false;
                }
                else
                {
                    res["Beep On Hit"] = true;
                }
                SetConfig();
                SettingsMenu();
            }
            if (option.Key == ConsoleKey.D4)
            {
                var flag15 = Utilities.Loggo;
                switch (flag15)
                {
                    case 1:
                        res["Logo"] = 2;
                        SetConfig();
                        SettingsMenu();
                        break;

                    case 2:
                        res["Logo"] = 3;
                        SetConfig();
                        SettingsMenu();
                        break;

                    case 3:
                        res["Logo"] = 4;
                        SetConfig();
                        SettingsMenu();
                        break;
                    case 4:
                        res["Logo"] = 5;
                        SetConfig();
                        SettingsMenu();
                        break;
                    case 5:
                        res["Logo"] = 6;
                        SetConfig();
                        SettingsMenu();
                        break;
                    case 6:
                        res["Logo"] = 1;
                        SetConfig();
                        SettingsMenu();
                        break;
                    default:
                        res["Logo"] = 1;
                        SetConfig();
                        SettingsMenu();
                        break;
                }
            }
            if (option.Key == ConsoleKey.D5)
            {
                RandomTheme();
            }
           //if (option.Key == ConsoleKey.Tab)
           //{
           //    MainSettingsCaptcha();
           //}
            if (option.Key == ConsoleKey.X)
            {
                Console.Clear();
                Utilities.Logo();
                Console.ForegroundColor = Color.Aqua;
                Colorful.Console.WriteLineFormatted(" {2} {3}+{4} {1} Saving Config", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Thread.Sleep(500);
                Program.Menu();
            }
            else SettingsMenu();
        } 
    }
}