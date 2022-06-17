using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading;
using System.Drawing;
using Leaf.xNet;
using System.Net.Http;
using System.Threading.Tasks;
using Authenty;
using System.IO;
using Console = Colorful.Console;
using System.Diagnostics;
using Microsoft.Win32;
using AntiRE.Runtime;
using System.Security.Cryptography;

namespace Quantify
{ 
    public static class Program
    {
        public static Licensing A = new Licensing(new AppSettings()
        {
            ApplicationId = 7891452,
            RsaPubKey = "MIIDazCCAlOgAwIBAgIUUMNm4Ou9vVZfi6pKjus9xfePQy0wDQYJKoZIhvcNAQEFBQAwRTELMAkGA1UEBhMCVVMxEzARBgNVBAgMClNvbWUtU3RhdGUxITAfBgNVBAoMGEludGVybmV0IFdpZGdpdHMgUHR5IEx0ZDAeFw0yMTAyMDUxNzQ3MjZaFw0zMTAyMDMxNzQ3MjZaMEUxCzAJBgNVBAYTAlVTMRMwEQYDVQQIDApTb21lLVN0YXRlMSEwHwYDVQQKDBhJbnRlcm5ldCBXaWRnaXRzIFB0eSBMdGQwggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQDjZ9oY2BbaB3aIS01XywV4Vfskn6JvzZvvei+tKvm4f41tqiq+jdg6odNAoooN5pzkOLvZB+dzuprcJet9ZP03wAHPGXqCF6X35ATNnngtbwYpUOXqY838JVRTLLFy4R7Ar3amxTuJgEjqEQrghqR/uUVtbUR/3DAoAwkJZuPS8pfjdz5Qksab3KptiZJEhO9eVfw4DTWzJLh7L2C2yyMLvbIcbAZfWHEz0qlAKWydApwckRFKqD2oTFIDO0UmOQKTtCEPO10VjqFdwxDME1ukWcXqjO8GOf4L+UrZDWDJ/paS7/Xv/vi2nTt5Pdxv8MAMS00Rl7PSVpyZlzKq/5IFAgMBAAGjUzBRMB0GA1UdDgQWBBQSfYVVjpegtsnC1ceFk9HlHVmYFTAfBgNVHSMEGDAWgBQSfYVVjpegtsnC1ceFk9HlHVmYFTAPBgNVHRMBAf8EBTADAQH/MA0GCSqGSIb3DQEBBQUAA4IBAQA+roXv/PrYW5l/em2BOEtElP7DF7Q9NhKRtZdJQnpNNd6/294wYorAQrwRdKuS86DrRClicM2ewdYFDlOpNK2cFtKnii4lvqcziXdFWGCVIshEoPg2M+FbAdgi7JICOanuyICrAqslJ7xU9iaonI2RTecfG8m9NDMDEJ17Ltj16QtD4PivUj3boxxUpHdNXORC1EFg3YEcCu3+QxKOlXIZfho/uz9/njW97r3ZJi53SNd8YUeXP+E1kN3Zi9Zc0Ln59F0u0UEvve7XXsA3Qum1EughaoLnxDngbueo5ColNSTZUBLEfjPUsTqwyGd8tJwfPHGy2BnCNlLecIzbBR3q",
            ApplicationKey = "76e0956e5f798009bd1bbf062e509058",
            ApplicationVersion = "1.0.0"
        });
        public static void UserInformation()
        {
            Utilities.Status = "Looking At User Information"; 
            Console.Title = "👻 Quantify AIO | Looking At User Information";
            Utilities.Upd();
            Console.Clear();
            Console.CursorVisible = false;
            Utilities.Logo();
            Colorful.Console.ForegroundColor = Color.Purple;
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - User Information", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}{5}{4} Username {1} {6}   ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]", (char)15, A.UserInfo.Username);
            Colorful.Console.WriteLineFormatted(" {2} {3}{5}{4} Email {1} {6}      ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]", (char)15, A.UserInfo.Email);
            Colorful.Console.WriteLineFormatted(" {2} {3}{5}{4} HWID {1} {6}       ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]", (char)15, A.UserInfo.HWID);
            Colorful.Console.WriteLineFormatted(" {2} {3}{5}{4} Level {1} {6}      ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]", (char)15, A.UserInfo.Level);
            Colorful.Console.WriteLineFormatted(" {2} {3}{5}{4} Expire-Date {1} {6}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]", (char)15, A.UserInfo.ExpireDate);
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}{1}{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            var option1 = System.Console.ReadKey();
            if (option1.Key == ConsoleKey.X)
            {
                Menu();
            }
            else UserInformation();
        }
        [STAThread]
        public static void Menu()
        {
            Utilities.Status = "Start Menu";
            Console.Title = "👻 Quantify AIO | Start Menu";
            Utilities.Upd();
            Console.Clear();
            Console.CursorVisible = false;
            Utilities.Logo();
            Colorful.Console.ForegroundColor = Color.Purple;
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Start Menu", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}1{4} - Modules", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}2{4} - Settings", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}3{4} - User Information ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted("  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            var option1 = System.Console.ReadKey();
            if (option1.Key == ConsoleKey.D1)
            {
                Modules();
            }
            if (option1.Key == ConsoleKey.D2)
            {
                Theme.SettingsMenu();
            }
            if (option1.Key == ConsoleKey.D3)
            {
                UserInformation();
            } 
            else Menu();
        }
        public static void Modules()
        {
            Utilities.Status = "Modules Menu";
            Console.Title = "👻 Quantify AIO | Modules Menu";
            Utilities.Upd();
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.ForegroundColor = Color.Purple;
            Console.CursorVisible = false;
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Modules Menu", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}1{4} - Login Modules ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}2{4} - Valid Mail Modules ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} {3}3{4} - Extra Modules ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted("  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted("  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            var option1 = System.Console.ReadKey();
            if (option1.Key == ConsoleKey.D1)
            {
            HERE:
                Utilities.Status = "Login Modules Menu";
                Console.Title = "👻 Quantify AIO | Login Modules Menu";
                Utilities.Upd();
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.ForegroundColor = Color.Purple;
                Console.CursorVisible = false;
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Login Modules Menu", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}1{4} - Brute API #1", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}2{4} - Capture API #1", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                var option11 = System.Console.ReadKey();
                if (option11.Key == ConsoleKey.D1)
                {
                    Functions.CreateDirectory("Results/LoginBruteV1/" + Vars.Now);
                    Vars.Module = "Login Brute V1";
                    Functions.StartChecker("Login Brute V1");
                    ThreadPool.SetMinThreads(Vars.ThreadsToUse, Vars.ThreadsToUse);
                    Threading.StartChecking(BruteV1.Start);
                    Functions.DoneCUI();
                }
                if (option11.Key == ConsoleKey.D2)
                {
                    Functions.CreateDirectory("Results/LoginCaptureV1/" + Vars.Now);
                    Vars.Module = "Login Capture V1";
                    Functions.StartChecker("Login Capture V1");
                    ThreadPool.SetMinThreads(Vars.ThreadsToUse, Vars.ThreadsToUse);
                    Threading.StartChecking(CaptureV1.Start);
                    Functions.DoneCUI();
                }
                if (option11.Key == ConsoleKey.X)
                {
                    Modules();
                }
                else goto HERE;
            }
            if (option1.Key == ConsoleKey.D2)
            {
            HERE:
                Utilities.Status = "VM Modules Menu";
                Console.Title = "👻 Quantify AIO | VM Modules Menu";
                Utilities.Upd();
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.ForegroundColor = Color.Purple;
                Console.CursorVisible = false;
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - VM Modules Menu", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}1{4} - VM Brute API #1", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted("  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted("  ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                var option11 = System.Console.ReadKey();
                if (option11.Key == ConsoleKey.D1)
                {
                    Functions.CreateDirectory("Results/VM-BRUTE/" + Vars.Now);
                    Vars.Module = "VM BRUTE";
                    Functions.StartChecker("VM BRUTE");
                    ThreadPool.SetMinThreads(Vars.ThreadsToUse, Vars.ThreadsToUse);
                    Threading.StartChecking(VMBruteV1.Start);
                    Functions.DoneCUI(); 
                } 
                if (option11.Key == ConsoleKey.X)
                {
                    Modules();
                }
                else goto HERE;
            }
            if (option1.Key == ConsoleKey.D3)
            {
            HERE:
                Utilities.Status = "Extra Modules Menu";
                Console.Title = "👻 Quantify AIO | Extra Modules Menu";
                Utilities.Upd();
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.ForegroundColor = Color.Purple;
                Console.CursorVisible = false;
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Captcha Modules Menu", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}1{4} - Valid Password Filter", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                var option11 = System.Console.ReadKey();
                if (option11.Key == ConsoleKey.D1)
                {
                    Functions.CreateDirectory("Results/PasswordFilter/" + Vars.Now);
                    Vars.Module = "Password Filter";
                    Functions.StartChecker("Password Filter");
                    ThreadPool.SetMinThreads(Vars.ThreadsToUse, Vars.ThreadsToUse);
                    Threading.StartChecking(PasswordFilter.Start);
                    Functions.DoneCUI();
                }
                if (option11.Key == ConsoleKey.X)
                {
                    Modules();
                }
                else goto HERE;
            }
            if (option1.Key == ConsoleKey.X)
            {
                Menu();
            }
            else Modules();
        }
       
        [STAThread]
        public static void Main()
        { 
            AntiSandBox.SelfDelete = true; 
            AntiSandBox.ShowAlert = true;
            var CurrentProcess = Process.GetCurrentProcess();
            AntiSandBox.Parse(CurrentProcess);
            AntiVirtualMachine.SelfDelete = true;
            AntiVirtualMachine.ShowAlert = true;
            AntiVirtualMachine.Parse(CurrentProcess);
            AntiSniff.SelfDelete = true;
            AntiSniff.ShowAlert = true;
            AntiReverserTools.SelfDelete = false;
            AntiReverserTools.ShowAlert = true;
            AntiReverserTools.Aggressive = false;  
            AntiReverserTools.IgnoreCase = true; 
            AntiReverserTools.WhiteList.Add("notepad");  
            AntiReverserTools.BlackList.Add("Fiddler");
            AntiReverserTools.BlackList.Add("Wireshark");
            AntiReverserTools.BlackList.Add("Dumper");
            AntiReverserTools.BlackList.Add("Reverser");
            AntiReverserTools.BlackList.Add("dumpcap");
            AntiReverserTools.BlackList.Add("dnspy");
            AntiReverserTools.BlackList.Add("dnSpy-x86");
            AntiReverserTools.BlackList.Add("cheatengine-x86_64");
            AntiReverserTools.BlackList.Add("HTTPDebuggerUI");
            AntiReverserTools.BlackList.Add("Procmon");
            AntiReverserTools.BlackList.Add("Procmon64");
            AntiReverserTools.BlackList.Add("Procmon64a");
            AntiReverserTools.BlackList.Add("ProcessHacker");
            AntiReverserTools.BlackList.Add("x32dbg");
            AntiReverserTools.BlackList.Add("x64dbg");
            AntiReverserTools.BlackList.Add("DotNetDataCollector32");
            AntiReverserTools.BlackList.Add("DotNetDataCollector64");
            AntiReverserTools.Start(CurrentProcess);
            AntiSniff.Parse(CurrentProcess);
            AntiDebugger.SelfDelete = true;
            AntiDebugger.ShowAlert = true;
            AntiDebugger.Aggressive = false;
            AntiDebugger.KeepAlive = true;  
            AntiDebugger.Start(CurrentProcess);
            Thread tAntiReverse = new Thread(new ThreadStart(ssss.AntiReverse));
            tAntiReverse.Start();  
            Utilities.Initialize();
            Utilities.Status = "Starting Up";
            Console.Title = "👻 Quantify AIO | Starting Up";
            Utilities.Upd();
            Theme.GetColors();
            Theme.Read();
            CustomCapture.Read();
            Utilities.Logo();
            x_0x0123421();
        }
        internal static void x_0x0123421()
        {
            A.Connect();
            Utilities.Status = "Authentication Menu";
            Console.Title = "👻 Quantify AIO | Authentication";
            Utilities.Upd();
            Console.CursorVisible = false;
            string path = Environment.CurrentDirectory + "\\Quantify\\Credentials.Quantify";
            Console.CursorVisible = false;
            if (File.Exists(path))
            {
                Console.Clear();
                Utilities.Logo();
                string[] uu = File.ReadAllText(path).Split(':');
                Utilities.Status = "Logging In With Saved Credentials!";
                Console.Title = "👻 Quantify AIO | Logging In With Saved Credentials!";
                Utilities.Upd();
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Logging In With Saved Credentials!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Console.WriteLine();
                string text = uu[0];
                string password = uu[1].Replace("\r\n", "");
                if (A.Login(text, password))
                {
                    Utilities.Status = "Succesfully Logged In As " + text + "!";
                    Console.Title = "👻 Quantify AIO | Succesfully Logged In As " + text + "!";
                    Utilities.Upd();
                    Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Succesfully Logged In As " + text + "!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                    Thread.Sleep(1500);
                    Colorful.Console.Clear();
                    Menu();
                }
                else
                {
                    Console.WriteLine();
                    Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Invalid Username Or Password", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                    Thread.Sleep(2500);
                    Sus();
                }
            }
            else
            {
                Utilities.Status = "Authentication Menu";
                Console.Title = "👻 Quantify AIO | Authentication";
                Utilities.Upd();
                Console.CursorVisible = false;
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Authentication", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}1{4} - Login", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}2{4} - Register", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                var option1 = System.Console.ReadKey();
                if (option1.Key == ConsoleKey.D1) Sus();
                if (option1.Key == ConsoleKey.D2) Register();
                else
                    x_0x0123421();
            }
        }
        internal static void Sus()
        {
            Utilities.Status = "Logging In";
            Console.Title = "👻 Quantify AIO | Logging In";
            Utilities.Upd();
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Logging In", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}Username{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.ForegroundColor = Color.White;
            string text = Colorful.Console.ReadLine();
            Console.WriteLine(); 
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo(); 
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Logging In", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}Password{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.ForegroundColor = Color.White;
            string strr = "";
            for (ConsoleKeyInfo consoleKeyInfo = Colorful.Console.ReadKey(true); consoleKeyInfo.Key != ConsoleKey.Enter; consoleKeyInfo = Colorful.Console.ReadKey(true))
            {
                if (consoleKeyInfo.Key != ConsoleKey.Backspace)
                {
                    Colorful.Console.Write("*");
                    strr += consoleKeyInfo.KeyChar.ToString();
                }
                else if (consoleKeyInfo.Key == ConsoleKey.Backspace && !string.IsNullOrEmpty(strr))
                {
                    strr = strr.Substring(0, strr.Length - 1);
                    int cursorLeft = Colorful.Console.CursorLeft;
                    Colorful.Console.SetCursorPosition(cursorLeft - 1, Colorful.Console.CursorTop);
                    Colorful.Console.Write(" ");
                    Colorful.Console.SetCursorPosition(cursorLeft - 1, Colorful.Console.CursorTop);
                }
            } 
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Checking Credentials", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.ForegroundColor = Color.White;
            if (A.Login(text, strr))
            {
               Console.WriteLine();
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Succesfully Logged In As " + text + "!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                using (var streamWriter = new StreamWriter("Quantify//Credentials.Quantify", true))
                {
                    streamWriter.WriteLine(text + ":" + strr, Encoding.UTF8);
                }
                Thread.Sleep(1500);
                Colorful.Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine();
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Invalid Username Or Password", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)" |", (object)"[", (object)"]");
                Thread.Sleep(2500);
                Sus();
            }
        }
        internal static void Register()
        {
            Utilities.Status = "Signing Up";
            Console.Title = "👻 Quantify AIO | Signing Up";
            Utilities.Upd();
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Signing Up", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}Username{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.ForegroundColor = Color.White;
            string text = Colorful.Console.ReadLine();
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Signing Up", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}Password{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.ForegroundColor = Color.White;
            string text2 = Colorful.Console.ReadLine();
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Signing Up", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}Email{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.ForegroundColor = Color.White;
            string email = Colorful.Console.ReadLine();
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Signing Up", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteLineFormatted(" {2} ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.WriteFormatted(" {2} {3}Key{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
            Colorful.Console.ForegroundColor = Color.White;
            string license = Colorful.Console.ReadLine(); 
            Console.CursorVisible = false;
            Console.Clear();
            Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Logging in", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)" |", (object)"[", (object)"]");
            if (A.Register(text, text2, email, license))
            {
                using (StreamWriter streamWriter = File.CreateText(Environment.CurrentDirectory + "\\Quantify\\Credentials.Quantify"))
                {
                    streamWriter.WriteLine(text + ":" + text2);
                }
                Console.Clear();
                Utilities.Logo();
            Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Succesfully Registered As " + text, Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)" |", (object)"[", (object)"]");
                Thread.Sleep(1500);
                Colorful.Console.Clear();
                Menu();
            }
            else
            {
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Invalid Key", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)" |", (object)"[", (object)"]");
                Thread.Sleep(1000);
                Colorful.Console.Clear();
                Process.GetCurrentProcess().Close();
            }
        }
    }
}
