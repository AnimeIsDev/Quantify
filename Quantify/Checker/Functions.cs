using Leaf.xNet;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantify
{
    internal class Functions
    {
        public static int CCount(String haystack, String needle)
        {
            return haystack.Split(new[] { needle }, StringSplitOptions.None).Length - 1;
        }
        public static void SetupRequest(HttpRequest request)
        {
            request.IgnoreProtocolErrors = true;
            request.EnableEncodingContent = true;
            request.AllowAutoRedirect = true;
            request.KeepAlive = true;
            request.ConnectTimeout = 60000;
            request.KeepAliveTimeout = 60000;
            request.ReadWriteTimeout = 60000;
            request.UseCookies = true;
        }
        public static void Write(string m)
        {
            List<string> Msg = new List<string>();
            foreach (char ch in m)
            {
                Msg.Add(ch.ToString());
            }
            string[] message = Msg.ToArray();
            Colorful.Console.WriteWithGradient(message, Utilities.ThemeColor, Utilities.ThemeColor, 5);
        }
        public static void Writer(string[] Text)
        {
            Colorful.Console.WriteLineWithGradient(Text, Utilities.ThemeColor, Utilities.ThemeColor, 5);
        }
        public static double presenter(int num)
        {
            var value = num / (double)Vars.loadedCombos * 100.0;
            return Math.Round(value, 2);
        }
        public static void StartChecker(string module)
        {
            Vars.Module = module;
            if (!Directory.Exists("Results/" + module + "/" + Process.GetCurrentProcess().StartTime.ToString("dd-MM-yyyy-hh-mm")))
            {
                Directory.CreateDirectory("Results/" + module + "/" + Process.GetCurrentProcess().StartTime.ToString("dd-MM-yyyy-hh-mm"));
            }
        REDO:
            Console.Clear();
            Colorful.Console.ForegroundColor = Utilities.ThemeColor;
            for (; ; )
            {
                Utilities.Status = "Setting Up Module - " + module;
                Console.Title = "☪︎ Quantify AIO | Setting Up Module - " + module;
                Utilities.Upd();
                Console.Clear();
                Utilities.Logo();
                Colorful.Console.ForegroundColor = Color.Purple;
                Console.CursorVisible = false;
                Colorful.Console.WriteLineFormatted(" {2} {3}Quantify{4} - Setting Up Module - " + module, Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}X{4} {1} Go Back!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2} {3}#{4} - How Many Threads Would You Like To Use!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteLineFormatted(" {2}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                Colorful.Console.WriteFormatted(" {2} {3}#{4} - ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"║", (char)26, (object)"|", (object)"[", (object)"]");
                try
                {
                    string input = Colorful.Console.ReadLine();
                    try
                    {
                        Vars.ThreadsToUse = int.Parse(input);
                        if (0 >= Vars.ThreadsToUse)
                        {
                            goto REDO;
                        }
                        else if (Vars.ThreadsToUse > 2000)
                        {
                            goto REDO;
                        }
                        else
                            break;
                    }
                    catch
                    {
                        if (input.ToLower().Equals("x"))
                        {
                            Program.Menu();
                        }
                        else
                        {
                            goto REDO;
                        }
                    }
                }
                catch
                {
                    goto REDO;
                }
            }
            Convert.ToInt32(Vars.Threadss);
            Loader.LoadProxyCombo(module);
        }

        private static Random rnd = new Random();
        private static string abc()
        {
            string text = "abcdefghijklmnopqrstuvwxyz";
            string str = "";
            return str + text[rnd.Next(0, text.Length)].ToString();
        }
        private static string Numbers()
        {
            string text = "0123456789";
            string str = "";
            return str + text[rnd.Next(0, text.Length)].ToString();
        }

        private static string Cool()
        {
            string text = "0123456789abcdefghijklmnopqrstuvwxyz";
            string str = "";
            return str + text[rnd.Next(0, text.Length)].ToString();
        }

        private static string ABC()
        {
            string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string str = "";
            return str + text[rnd.Next(0, text.Length)].ToString();
        }
        public static string StringGen(string str)
        {
            string text = "";
            for (int i = 0; i < str.Length; i++)
            {
                string text2 = str[i].ToString() + str[i + 1].ToString();
                string a = text2;
                if (!(a == "?m"))
                {
                    if (!(a == "?h"))
                    {
                        if (!(a == "?r"))
                        {
                            if (!(a == "?t"))
                            {
                                text += str[i].ToString();
                            }
                            else
                            {
                                text += Numbers();
                                i++;
                            }
                        }
                        else
                        {
                            text += Cool();
                            i++;
                        }
                    }
                    else
                    {
                        text += abc();
                        i++;
                    }
                }
                else
                {
                    text += ABC();
                    i++;
                }
            }
            return text;
        }
        public static void CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch
            {
            }
        }
        public static List<Thread> threads = new List<Thread>();

        public static IEnumerable<string> JSON(string input, string field, bool recursive = false, bool useJToken = false)
        {
            var list = new List<string>();

            if (useJToken)
            {
                if (recursive)
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        var jsonlist = json.SelectTokens(field, false);
                        foreach (var j in jsonlist)
                            list.Add(j.ToString());
                    }
                }
                else
                {
                    if (input.Trim().StartsWith("["))
                    {
                        JArray json = JArray.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                    else
                    {
                        JObject json = JObject.Parse(input);
                        list.Add(json.SelectToken(field, false).ToString());
                    }
                }
            }
            else
            {
                var jsonlist = new List<KeyValuePair<string, string>>();
                parseJSON("", input, jsonlist);
                foreach (var j in jsonlist)
                    if (j.Key == field)
                        list.Add(j.Value);

                if (!recursive && list.Count > 1) list = new List<string>() { list.First() };
            }

            return list;
        }
        private static void parseJSON(string A, string B, List<KeyValuePair<string, string>> jsonlist)
        {
            jsonlist.Add(new KeyValuePair<string, string>(A, B));

            if (B.StartsWith("["))
            {
                JArray arr = null;
                try { arr = JArray.Parse(B); } catch { return; }

                foreach (var i in arr.Children())
                    parseJSON("", i.ToString(), jsonlist);
            }

            if (B.Contains("{"))
            {
                JObject obj = null;
                try { obj = JObject.Parse(B); } catch { return; }

                foreach (var o in obj)
                    parseJSON(o.Key, o.Value.ToString(), jsonlist);
            }
        }
        public static IEnumerable<string> LR(string input, string left, string right, bool recursive = false, bool useRegex = false, bool de = false)
        {
            IEnumerable<string> result;

            if (left == string.Empty && right == string.Empty)
            {
                result = new[]
                {
                    input
                };
            }
            else if ((left != string.Empty && !input.Contains(left)) ||
                     (right != string.Empty && !input.Contains(right)))
            {
                result = new string[0];
            }
            else
            {
                var text = input;
                var list = new List<string>();

                if (recursive)
                {
                    if (useRegex)
                        try
                        {
                            var pattern = BuildLRPattern(left, right);
                            var matchCollection = Regex.Matches(text, pattern);

                            foreach (var obj in matchCollection)
                            {
                                var match = (Match)obj;
                                list.Add(match.Value);
                            }

                            goto IL_243;
                        }
                        catch
                        {
                            goto IL_243;
                        }

                    try
                    {
                        while (left == string.Empty ||
                               (text.Contains(left) && (right == string.Empty || text.Contains(right))))
                        {
                            var startIndex = left == string.Empty ? 0 : text.IndexOf(left) + left.Length;
                            text = text.Substring(startIndex);
                            var length = right == string.Empty ? text.Length - 1 : text.IndexOf(right);
                            var text2 = text.Substring(0, length);
                            list.Add(text2);
                            text = text.Substring(text2.Length + right.Length);
                        }

                        goto IL_243;
                    }
                    catch
                    {
                        goto IL_243;
                    }
                }

                if (useRegex)
                {
                    var pattern2 = BuildLRPattern(left, right);
                    var matchCollection2 = Regex.Matches(text, pattern2);

                    if (matchCollection2.Count > 0) list.Add(matchCollection2[0].Value);
                }
                else
                {
                    try
                    {
                        var startIndex = left == string.Empty ? 0 : text.IndexOf(left) + left.Length;
                        text = text.Substring(startIndex);
                        var length = right == string.Empty ? text.Length : text.IndexOf(right);
                        list.Add(text.Substring(0, length));
                    }
                    catch
                    {
                    }
                }

            IL_243:
                if (de)
                {
                    result = list;
                }
            else
                {
                    result = list.Distinct();
                }
            }

            return result;
        }

        private static string BuildLRPattern(string ls, string rs)
        {
            var text = string.IsNullOrEmpty(ls) ? "^" : Regex.Escape(ls);
            var text2 = string.IsNullOrEmpty(rs) ? "$" : Regex.Escape(rs);

            return string.Concat("(?<=", text, ").+?(?=", text2, ")");
        }
        public static string Parse(string source, string left, string right)
        {
            try
            {
                return source.Split(new[] { left }, StringSplitOptions.None)[1].Split(new[] { right }, StringSplitOptions.None)[0];
            }
            catch
            {
                return " ";
            }
        }
        public static int MultipleChoice(bool canCancel, params string[] options)
        {
            const int startX = 1;
            const int startY = 0;
            const int optionsPerLine = 1;
            const int spacingPerLine = 14;
            int currentSelection = 0;
            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {

                for (int i = 0; i < options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);
                    if (i == currentSelection)
                        Console.Write("> ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(options[i]);
                    Console.ResetColor();
                }
                key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            }
            while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;
            return currentSelection;
        }
        public static string RandomString(string Randomize)
        {
            var text = "";
            var text2 = "123456789abcdef";
            var text3 = "abcdefghijklmnopqrstuvwxyz";
            var text4 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var text5 = "1234567890";
            var text6 = "!@#$%^&*()_+";
            var text7 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var text8 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var random = new Random();

            for (var i = 0; i < Randomize.Length - 1; i++)
            {
                var flag = (Randomize[i] + Randomize[i + 1].ToString()).Equals("?h");

                if (flag)
                {
                    text += text2[random.Next(0, text2.Length)].ToString();
                }
                else
                {
                    var flag2 = (Randomize[i] + Randomize[i + 1].ToString()).Equals("?l");

                    if (flag2)
                    {
                        text += text3[random.Next(0, text3.Length)].ToString();
                    }
                    else
                    {
                        var flag3 = (Randomize[i] + Randomize[i + 1].ToString()).Equals("?u");

                        if (flag3)
                        {
                            text += text4[random.Next(0, text4.Length)].ToString();
                        }
                        else
                        {
                            var flag4 = (Randomize[i] + Randomize[i + 1].ToString()).Equals("?d");

                            if (flag4)
                            {
                                text += text5[random.Next(0, text5.Length)].ToString();
                            }
                            else
                            {
                                var flag5 = (Randomize[i] + Randomize[i + 1].ToString()).Equals("?m");

                                if (flag5)
                                {
                                    text += text7[random.Next(0, text7.Length)].ToString();
                                }
                                else
                                {
                                    var flag6 = (Randomize[i] + Randomize[i + 1].ToString()).Equals("?i");

                                    if (flag6)
                                    {
                                        text += text8[random.Next(0, text8.Length)].ToString();
                                    }
                                    else
                                    {
                                        var flag7 = (Randomize[i] + Randomize[i + 1].ToString()).Equals("?s");

                                        if (flag7)
                                        {
                                            text += text6[random.Next(0, text6.Length)].ToString();
                                        }
                                        else
                                        {
                                            var flag8 = Randomize[i].ToString().Contains("-");

                                            if (flag8)
                                            {
                                                text += "-";
                                            }
                                            else
                                            {
                                                var flag9 = Randomize[i - 1].ToString().Equals("-") &&
                                                            !Randomize[i].ToString().Equals("?");
                                                if (flag9) text += Randomize[i].ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return text;
        }
        public static string ReasultFolder = "Results/";
        public static string Date = DateTime.Now.ToString("MM-dd-yyyy H.mm");
        public static void CreateDir(string name)
        {
            var flag = !Directory.Exists(name);
            if (flag) Directory.CreateDirectory(name);
        }
        public static void MenuTab(string name, int num, Color col, bool n = false)
        {
            Colorful.Console.Write("\n  [", Utilities.ThemeColor);
            Colorful.Console.Write(num, col);
            Colorful.Console.Write("] ", Utilities.ThemeColor);
            Colorful.Console.Write(name, Utilities.ThemeColor2);
        }
        public static void InputTab(string name, Color col, bool n = false)
        {
            Colorful.Console.Write("\n  [", Utilities.ThemeColor);
            Colorful.Console.Write(name, col);
            Colorful.Console.Write("] ", Utilities.ThemeColor);
        }

        public static List<string> Combo = new List<string>();
        public static int num;
        public static void info(string name)
        {
            Console.Write("   [", Utilities.ThemeColor);
            Console.Write("!", Utilities.ThemeColor2);
            Console.Write("] ", Utilities.ThemeColor);
            Console.Write(name, Utilities.ThemeColor2);
            Console.WriteLine();
        }
        public static void Count(string name)
        {
            ++num;
            Console.Write("   [", Utilities.ThemeColor);
            Console.Write(num.ToString(), Utilities.ThemeColor2);
            Console.Write("] ", Utilities.ThemeColor);
            Console.Write(name, Utilities.ThemeColor2);
            Console.WriteLine();
        }
        public static void InputText()
        {
            Console.CursorVisible = false;
            Console.Write("   [", Utilities.ThemeColor);
            Console.Write(">", Utilities.ThemeColor2);
            Console.Write("] ", Utilities.ThemeColor);
            Console.Write("", Utilities.ThemeColor2);
        }
        public static void CUITab(string name, Color col, int value, Color valCol)
        {
            Colorful.Console.Write("  [", Utilities.ThemeColor);
            Colorful.Console.Write("+", Utilities.ThemeColor2);
            Colorful.Console.Write("] ", Utilities.ThemeColor);
            Colorful.Console.Write(name, Utilities.ThemeColor2);
            Colorful.Console.Write(" > ", Utilities.ThemeColor);
            Colorful.Console.Write(value.ToString() + "\n", Utilities.ThemeColor2);
        }
        public static void LockWrite(string text, Color color)
        {
            TextWriter @out = Colorful.Console.Out;
            lock (@out)
            {
                Colorful.Console.WriteLine(text, color);
            }
        }
        public static int GetCurrentCPM()
        {
            DateTime dateTime = Vars.currentCpmDatetime;
            if ((DateTime.Now - Vars.currentCpmDatetime).Minutes >= 1)
            {
                Vars.lastCpms.Add(Vars.currentCpm);
                Vars.currentCpm = 0;
                Vars.currentCpmDatetime = DateTime.Now;
            }
            int num = Vars.currentCpm;
            for (int i = 0; i < Vars.lastCpms.Count; i++)
            {
                num += Vars.lastCpms[i];
            }
            int result;
            if (Vars.lastCpms.Count == 0)
            {
                result = num;
            }
            else
            {
                result = num / Vars.lastCpms.Count;
            }
            return result;
        }
        public static Stopwatch ElapsedTime = new Stopwatch();
        
        public static void PrintCUI()
        {
            Utilities.Logo();
            ElapsedTime.Start();
            UpdateRPC();
            Task.Factory.StartNew(delegate ()
            {
                while (Vars.UIEnabled)
                {
                    bool flag = Vars.Checked >= Vars.loadedCombos;
                    if (flag)
                    {
                        Vars.IsRunning = false;
                        Vars.ShowTitle = false;
                        Vars.UIEnabled = false;
                        Vars.UiStat = false;
                        Vars.IsPaused = true;
                        break;
                    }
                    bool uiStat = Vars.UiStat;
                    if (uiStat)
                    {
                        bool flag2 = Vars.Checked >= Vars.loadedCombos;
                        if (flag2)
                        {
                            Vars.IsRunning = false;
                            Vars.ShowTitle = false;
                            Vars.UIEnabled = false;
                            Vars.UiStat = false;
                            Vars.IsPaused = true;
                            break;
                        }
                        TimeSpan elapsed = ElapsedTime.Elapsed;
                        string text = string.Format("{0}:{1}:{2}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
                        bool Print = Vars.Design == "CUI";
                        if (Print)
                        {
                            bool Type = Vars.Module.Contains("VM");
                            if (Type)
                            {
                                Console.Title = $"Checking ~ {Vars.Module} | {Vars.Checked}/{Vars.ComboList.Count} ~ {Functions.presenter(Vars.Checked)}% | Valids: {Vars.Hits} ~ Invalid: {Vars.Bad} ~ CPM: {GetCurrentCPM()} ~ Retries: {Vars.Retries} ~ Errors: {Vars.Errors} | Time Running: {text}";
                                Console.Clear();
                                Utilities.Logo();
                                Console.CursorVisible = false;
                                Colorful.Console.WriteLineFormatted("  [{0}] Module   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Module));
                                Console.WriteLine();                                 
                                Colorful.Console.WriteLineFormatted("  [{0}] Running  | {1}.txt", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.FileName));
                                Colorful.Console.WriteLineFormatted("  [{0}] Progress | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Functions.presenter(Vars.Checked).ToString() + " %", (object)"|"));
                                Colorful.Console.WriteLineFormatted("  [{0}] Checked  | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)$"{Vars.Checked}/{Vars.ComboList.Count}", (object)"|"));
                                Console.WriteLine();                                  
                                Colorful.Console.WriteLineFormatted("  [{0}] Hits     | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Hits));
                                Colorful.Console.WriteLineFormatted("  [{0}] Invalid  | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Bad));
                                Console.WriteLine();                                  
                                Colorful.Console.WriteLineFormatted("  [{0}] Threads  | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.ThreadsToUse));
                                Colorful.Console.WriteLineFormatted("  [{0}] Errors   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Errors));
                                Colorful.Console.WriteLineFormatted("  [{0}] Retries  | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Retries));
                                Colorful.Console.WriteLineFormatted("  [{0}] CPM      | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)GetCurrentCPM().ToString()));
                                Thread.Sleep(Vars.RefreshRate);
                            }
                            else
                            {
                                Console.Title = $"Checking ~ {Vars.Module} | {Vars.Checked}/{Vars.ComboList.Count} ~ {Functions.presenter(Vars.Checked)}% | Valids: {Vars.Hits} ~ With CC: {Vars.Cards} ~ With Bank: {Vars.Banks} ~ With Bank + CC+: {Vars.CCAndBank} ~ No CC Or Bank: {Vars.NoCCAndBank} ~ Limited: {Vars.Limited} ~ Locked: {Vars.Locked} ~ Expired: {Vars.Expired} ~ 2FA: {Vars.TwoFa} ~ Customs: {Vars.Custom} ~ Invalid: {Vars.Bad} ~ CPM: {GetCurrentCPM()} ~ Retries: {Vars.Retries} ~ Errors: {Vars.Errors} | Time Running: {text}";
                                Console.Clear();
                                Utilities.Logo();
                                Console.CursorVisible = false;
                                Colorful.Console.WriteLineFormatted("  [{0}] Module    | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Module));
                                Console.WriteLine();
                                Colorful.Console.WriteLineFormatted("  [{0}] Running   | {1}.txt", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.FileName));
                                Colorful.Console.WriteLineFormatted("  [{0}] Progress  | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Functions.presenter(Vars.Checked).ToString() + " %", (object)"|"));
                                Colorful.Console.WriteLineFormatted("  [{0}] Checked   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)$"{Vars.Checked}/{Vars.ComboList.Count}", (object)"|"));
                                Console.WriteLine();
                                Colorful.Console.WriteFormatted("  [{0}] Hits      | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Hits));
                                Colorful.Console.SetCursorPosition(22, 15);
                                Colorful.Console.WriteLineFormatted("      [{0}]  Personal  | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Personal));
                                Colorful.Console.WriteFormatted("  [{0}] Limted    | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Limited));
                                Colorful.Console.SetCursorPosition(22, 16);
                                Colorful.Console.WriteLineFormatted("      [{0}]  Business  | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Business));
                                Colorful.Console.WriteFormatted("  [{0}] Locked    | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Locked));
                                Colorful.Console.SetCursorPosition(22, 17);
                                Colorful.Console.WriteLineFormatted("      [{0}]  Other     | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Other));
                                Colorful.Console.WriteLineFormatted("  [{0}] Customs   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Custom));
                                Colorful.Console.WriteFormatted("  [{0}] Expired   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Expired));
                                Colorful.Console.SetCursorPosition(22, 19);
                                Colorful.Console.WriteLineFormatted("      [{0}]  USA       | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.USA));
                                Colorful.Console.WriteFormatted("  [{0}] 2FA       | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.TwoFa));
                                Colorful.Console.SetCursorPosition(22, 20);
                                Colorful.Console.WriteLineFormatted("      [{0}]  UK        | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.UK));
                                Colorful.Console.WriteFormatted("  [{0}] Invalid   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Bad));
                                Colorful.Console.SetCursorPosition(22, 21);
                                Colorful.Console.WriteLineFormatted("      [{0}]  Other     | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.OTHERCOUNTRY));
                                Console.WriteLine();
                                Colorful.Console.WriteFormatted("  [{0}] With Card | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Cards));
                                Colorful.Console.SetCursorPosition(22, 23);
                                Colorful.Console.WriteLineFormatted("      [{0}]  W Balance | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.WithBal));
                                Colorful.Console.WriteFormatted("  [{0}] With Bank | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Banks));
                                Colorful.Console.SetCursorPosition(22, 24);
                                Colorful.Console.WriteLineFormatted("      [{0}]  T Balance | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.TotalBal));
                                Colorful.Console.WriteLineFormatted("  [{0}] With Both | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.CCAndBank));
                                Console.WriteLine();
                                Colorful.Console.WriteLineFormatted("  [{0}] Empty     | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.NoCCAndBank));
                                Console.WriteLine();
                                Colorful.Console.WriteLineFormatted("  [{0}] Threads   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.ThreadsToUse));
                                Colorful.Console.WriteLineFormatted("  [{0}] Errors    | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Errors));
                                Colorful.Console.WriteLineFormatted("  [{0}] Retries   | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Retries));
                                Colorful.Console.WriteLineFormatted("  [{0}] CPM       | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Functions.GetCurrentCPM().ToString()));
                                Thread.Sleep(Vars.RefreshRate);
                            }
                        }
                        else
                        {
                            bool Type = Vars.Module.Contains("VM");
                            if (Type)
                            {
                                Console.Title = $"Checking ~ {Vars.Module} | {Vars.Checked}/{Vars.ComboList.Count} ~ {Functions.presenter(Vars.Checked)}% | Valids: {Vars.Hits} ~ Invalid: {Vars.Bad} ~ CPM: {GetCurrentCPM()} ~ Retries: {Vars.Retries} ~ Errors: {Vars.Errors} | Time Running: {text}";
                            }
                            else
                            {
                                Console.Title = $"Checking ~ {Vars.Module} | {Vars.Checked}/{Vars.ComboList.Count} ~ {Functions.presenter(Vars.Checked)}% | Valids: {Vars.Hits} ~ With CC: {Vars.Cards} ~ With Bank: {Vars.Banks} ~ With Bank + CC+: {Vars.CCAndBank} ~ No CC Or Bank: {Vars.NoCCAndBank} ~ Expired: {Vars.Expired} ~ 2FA: {Vars.TwoFa} ~ Customs: {Vars.Custom} ~ Invalid: {Vars.Bad} ~ CPM: {GetCurrentCPM()} ~ Retries: {Vars.Retries} ~ Errors: {Vars.Errors} | Time Running: {text}";
                            }
                        }
                    }
                }
            });
        }
        public static bool TryConvertToInt32(decimal val, out int intval)
        {
            if (val > int.MaxValue || val < int.MinValue)
            {
                intval = 0; // assignment required for out parameter
                return false;
            }

            intval = Decimal.ToInt32(val);

            return true;
        }
        public static void DoneCUI()
        {
            Vars.IsPaused = true;
            Vars.ShowTitle = false;
            Vars.UiStat = false;
            Vars.IsRunning = false;
            TimeSpan elapsed = ElapsedTime.Elapsed;
            string text = string.Format("{0}:{1}:{2}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);
            Console.Title = $"Done Checking ~ {Vars.Module} | {Vars.Checked}/{Vars.ComboList.Count} ~ {Functions.presenter(Vars.Checked)}% | Valids: {Vars.Hits} ~ With CC: {Vars.Cards} ~ With Bank: {Vars.Banks} ~ With Bank + CC+: {Vars.CCAndBank} ~ No CC Or Bank: {Vars.NoCCAndBank} ~ Expired: {Vars.Expired} ~ 2FA: {Vars.TwoFa} ~ Customs: {Vars.Custom} ~ Invalid: {Vars.Bad} ~ CPM: {GetCurrentCPM()} ~ Retries: {Vars.Retries} ~ Errors: {Vars.Errors} | Time Running: {text}";
            Console.Clear();
            Utilities.Logo();
            Console.CursorVisible = false;
            Colorful.Console.WriteLineFormatted("  Press Any Key To Get To Main Menu!", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Module));
            Console.WriteLine();
            Colorful.Console.WriteLineFormatted("  [STATUS] Checker Done | ", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Module));
            Console.WriteLine();
            Colorful.Console.WriteLineFormatted("  [{0}] Module          | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Module));
            Console.WriteLine();
            Colorful.Console.WriteLineFormatted("  [{0}] Hits            | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Hits));
            Colorful.Console.WriteLineFormatted("  [{0}] Customs         | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Custom));
            Colorful.Console.WriteLineFormatted("  [{0}] Expired         | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Expired));
            Colorful.Console.WriteLineFormatted("  [{0}] 2FA             | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.TwoFa));
            Colorful.Console.WriteLineFormatted("  [{0}] Invalid         | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Bad));
            Console.WriteLine();
            Colorful.Console.WriteLineFormatted("  [{0}] With Card       | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Cards));
            Colorful.Console.WriteLineFormatted("  [{0}] With Bank       | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Banks));
            Colorful.Console.WriteLineFormatted("  [{0}] With Both       | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.CCAndBank));
            Colorful.Console.WriteLineFormatted("  [{0}] With Balance    | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.WithBal));
            Console.WriteLine();
            Colorful.Console.WriteLineFormatted("  [{0}] Captcha Balance | {1}", Utilities.ThemeColor, Utilities.ThemeColor2, (object)"~", (object)string.Format("{0}", (object)Vars.Balance));
            Console.ReadKey();
            Vars.TotalLoadedCombos = 0;
            Vars.TotalLoadedCombos = 0;
            Vars.TotalLoadedCombos = 0;
            Vars.TotalLoadedCombos = 0;
            Program.Menu();
        }

        public static void UpdateRPC()
        {
            Task.Factory.StartNew(delegate ()
            {
                for (; ; )
                {
                    Utilities.Update(string.Format("👻 Checking: {5} | With Payment Method: {6} | | Hits: {0} | 2FA: {1} | Expired: {2} | Invalids: {3} | CPM: {4} ", new object[]
                    {
                       Vars.Hits,
                       Vars.TwoFa,
                       Vars.Expired,
                       Vars.Bad,
                       GetCurrentCPM(),
                       Vars.Module,
                       Vars.CCAndBank + Vars.Cards + Vars.Banks
                    }));
                    Thread.Sleep(Vars.RefreshRate);
                }
            });
        }
        public static void UpdateTitle()
        {
            Task.Factory.StartNew(delegate ()
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                for (; ; )
                {
                    Colorful.Console.Title = string.Format("👻 Quantify | Module: {0} | Checked: {1}/{2} | Hits: {3} | 2FA: {4} | Expired: {5} | Invalids: {6} | CPM: {7}", new object[]
                    {
                        Vars.Module,
                        Vars.Checked,
                        Vars.Total,
                        Vars.Hits,
                        Vars.TwoFa,
                        Vars.Expired,
                        Vars.Bad,
                        GetCurrentCPM()
                    });
                }
            });
        }
    }
}

