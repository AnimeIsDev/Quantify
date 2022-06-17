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
#endregion

namespace Quantify
{
    internal class CustomCapture
    {
      
        public static JObject res;

        public static string json;
  
        public static string Create()
        {
            return new JObject
            {
                {
                    "Phone Capture",
                    true
                },
                {
                    "Cookie Capture",
                    true
                },
                {
                    "Name Capture",
                    true
                },
                {
                  "Address Capture",
                    true
                },
                {
                    "Bank Capture",
                    true
                },
                {
                    "Card Capture",
                    true
                },
                {
                   "Country Capture",
                    true
                },
                {
                   "Retricted Capture",
                    true
                },
                {
                    "Locked Capture",
                    true
                },
                {
                    "Balance Capture",
                    true
                },
                {
                    "Credit Capture",
                    true
                },
                {
                    "Total Cards Capture",
                    true
                },
                {
                    "Total Banks Capture",
                    true
                },
                {
                    "Email Verified Capture",
                    true
                },
                {
                    "Card Type Capture",
                    true
                },
                {
                    "Card Last 4 Capture",
                    true
                },
                {
                    "Bank Last 4 Capture",
                    true
                },
                {
                    "Account Type Capture",
                    true
                }
            }.ToString();
        }
        public static void SetConfig()
        {
            File.WriteAllText("Quantify\\Capture.json", res.ToString());
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
                json = File.ReadAllText("Quantify\\Capture.json");
            }
            catch
            {
                Console.Clear();
                Utilities.Logo(); 
                var flag2 = File.Exists("Quantify\\Capture.json");
                if (flag2) File.Delete("Quantify\\Capture.json");
                json = Create();
                Colorful.Console.WriteLineFormatted(" {2} {3}!{4} {1} Creating Default Capture!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                File.WriteAllText("Quantify\\Capture.json", json);
                Thread.Sleep(1500);
            }
            try
            {
                res = JObject.Parse(json);
                Vars.PhoneCapture = Convert.ToBoolean(res["Phone Capture"]);
                Vars.CookieCapture = Convert.ToBoolean(res["Cookie Capture"]);
                Vars.NameCapture = Convert.ToBoolean(res["Name Capture"]);
                Vars.AddressCapture = Convert.ToBoolean(res["Address Capture"]);
                Vars.BankCapture = Convert.ToBoolean(res["Bank Capture"]);
                Vars.CardCapture = Convert.ToBoolean(res["Card Capture"]);
                Vars.CountryCapture = Convert.ToBoolean(res["Country Capture"]);
                Vars.RetrictedCapture = Convert.ToBoolean(res["Retricted Capture"]);
                Vars.LockedCapture = Convert.ToBoolean(res["Locked Capture"]);
                Vars.AdvancedBalanceCapture = Convert.ToBoolean(res["Balance Capture"]);
                Vars.CreditCapture = Convert.ToBoolean(res["Credit Capture"]);
                Vars.TotalCards = Convert.ToBoolean(res["Total Cards Capture"]);
                Vars.TotalBanks = Convert.ToBoolean(res["Total Banks Capture"]);
                Vars.EmaiLVerified = Convert.ToBoolean(res["Email Verified Capture"]);
                Vars.CardType = Convert.ToBoolean(res["Card Type Capture"]);
                Vars.CardLast4 = Convert.ToBoolean(res["Card Last 4 Capture"]);
                Vars.BankLast4 = Convert.ToBoolean(res["Bank Last 4 Capture"]);
                Vars.AccountType = Convert.ToBoolean(res["Account Type Capture"]);
            }
            catch
            {
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Error Found In Default Capture!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                var flag3 = File.Exists("Quantify\\Capture.json");
                if (flag3) File.Delete("Quantify\\Capture.json");
                Thread.Sleep(2000);
                Read();
                Utilities.Logo();
            }
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
         
        public static void CaptureMenu()
        {
            	 
            Console.Clear();
            Utilities.Logo();
            Console.ForegroundColor = Color.Aqua;
            Utilities.Status = "Looking at Capture Capture";
            Console.Title = "☪︎ Quantify AIO | Looking at Capture Capture";
            Utilities.Upd();
            Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}1{4} {1} Phone   ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.PhoneCapture);                           
            Colorful.Console.WriteFormatted(" {2} {3}2{4} {1} Cookie  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.CookieCapture);                                    
            Colorful.Console.WriteFormatted(" {2} {3}3{4} {1} Name    ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.NameCapture);                                      
            Colorful.Console.WriteFormatted(" {2} {3}4{4} {1} Address ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.AddressCapture);                                   
            Colorful.Console.WriteFormatted(" {2} {3}5{4} {1} Bank    ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.BankCapture);                                      
            Colorful.Console.WriteFormatted(" {2} {3}6{4} {1} Card    ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.CardCapture);                                      
            Colorful.Console.WriteFormatted(" {2} {3}7{4} {1} Country ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.CountryCapture);                         
            Colorful.Console.WriteFormatted(" {2} {3}8{4} {1} Limited ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.RetrictedCapture);                       
            Colorful.Console.WriteFormatted(" {2} {3}9{4} {1} Locked  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.LockedCapture);                          
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}F1{4} {1} Balance      ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.AdvancedBalanceCapture);                        
            Colorful.Console.WriteFormatted(" {2} {3}F2{4} {1} Credit       ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.CreditCapture);
            Colorful.Console.WriteFormatted(" {2} {3}F3{4} {1} Total CC     ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.TotalCards);
            Colorful.Console.WriteFormatted(" {2} {3}F4{4} {1} Total Bank   ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.TotalBanks);
            Colorful.Console.WriteFormatted(" {2} {3}F5{4} {1} Verified     ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.EmaiLVerified);
            Colorful.Console.WriteFormatted(" {2} {3}F6{4} {1} Card Type    ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.CardType);
            Colorful.Console.WriteFormatted(" {2} {3}F7{4} {1} Card Last 4  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.CardLast4);
            Colorful.Console.WriteFormatted(" {2} {3}F8{4} {1} Bank Last 4  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.BankLast4);
            Colorful.Console.WriteFormatted(" {2} {3}F9{4} {1} Account Type ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            BoolChecker(Vars.AccountType);
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            var option = System.Console.ReadKey();
            if (option.Key == ConsoleKey.D1)
            {
                var beepOnHit = Vars.PhoneCapture;
                if (beepOnHit)
                {
                    res["Phone Capture"] = false;
                }
                else
                {
                    res["Phone Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D2)
            {
                var beepOnHit = Vars.CookieCapture;
                if (beepOnHit)
                {
                    res["Cookie Capture"] = false;
                }
                else
                {
                    res["Cookie Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D3)
            {
                var beepOnHit = Vars.NameCapture;
                if (beepOnHit)
                {
                    res["Name Capture"] = false;
                }
                else
                {
                    res["Name Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D4)
            {
                var beepOnHit = Vars.AddressCapture;
                if (beepOnHit)
                {
                    res["Address Capture"] = false;
                }
                else
                {
                    res["Address Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D5)
            {
                var beepOnHit = Vars.BankCapture;
                if (beepOnHit)
                {
                    res["Bank Capture"] = false;
                }
                else
                {
                    res["Bank Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D6)
            {
                var beepOnHit = Vars.CardCapture;
                if (beepOnHit)
                {
                    res["Card Capture"] = false;
                }
                else
                {
                    res["Card Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D7)
            {
                var beepOnHit = Vars.CountryCapture;
                if (beepOnHit)
                {
                    res["Country Capture"] = false;
                }
                else
                {
                    res["Country Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D8)
            {
                var beepOnHit = Vars.RetrictedCapture;
                if (beepOnHit)
                {
                    res["Retricted Capture"] = false;
                }
                else
                {
                    res["Retricted Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.D9)
            {
                var beepOnHit = Vars.LockedCapture;
                if (beepOnHit)
                {
                    res["Locked Capture"] = false;
                }
                else
                {
                    res["Locked Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F1)
            {
                var beepOnHit = Vars.AdvancedBalanceCapture;
                if (beepOnHit)
                {
                    res["Balance Capture"] = false;
                }
                else
                {
                    res["Balance Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }   
            if (option.Key == ConsoleKey.F2)
            {
                var beepOnHit = Vars.CreditCapture;
                if (beepOnHit)
                {
                    res["Credit Capture"] = false;
                }
                else
                {
                    res["Credit Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F3)
            {
                var beepOnHit = Vars.TotalCards;
                if (beepOnHit)
                {
                    res["Total Cards Capture"] = false;
                }
                else
                {
                    res["Total Cards Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F4)
            {
                var beepOnHit = Vars.TotalBanks;
                if (beepOnHit)
                {
                    res["Total Banks Capture"] = false;
                }
                else
                {
                    res["Total Banks Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F5)
            {
                var beepOnHit = Vars.EmaiLVerified;
                if (beepOnHit)
                {
                    res["Email Verified Capture"] = false;
                }
                else
                {
                    res["Email Verified Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F6)
            {
                var beepOnHit = Vars.CardType;
                if (beepOnHit)
                {
                    res["Card Type Capture"] = false;
                }
                else
                {
                    res["Card Type Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F7)
            {
                var beepOnHit = Vars.CardLast4;
                if (beepOnHit)
                {
                    res["Card Last 4 Capture"] = false;
                }
                else
                {
                    res["Card Last 4 Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F8)
            {
                var beepOnHit = Vars.BankLast4;
                if (beepOnHit)
                {
                    res["Bank Last 4 Capture"] = false;
                }
                else
                {
                    res["Bank Last 4 Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.F9)
            {
                var beepOnHit = Vars.AccountType;
                if (beepOnHit)
                {
                    res["Account Type Capture"] = false;
                }
                else
                {
                    res["Account Type Capture"] = true;
                }
                SetConfig();
                CaptureMenu();
            }
            if (option.Key == ConsoleKey.X)
            {
                Console.Clear();
                Utilities.Logo();
                Console.ForegroundColor = Color.Aqua;
                Colorful.Console.WriteLineFormatted(" {2} {3}+{4} {1} Saving Config", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Thread.Sleep(500);
                Program.Menu();
            }
            else CaptureMenu();
        }
    }
}