using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quantify
{
    internal class Export
    {
        public static void AsResult(string fileName, string content)
        {
            object obj = Export.resultLock;
            lock (obj)
            { 
                File.AppendAllText((("Results/" + Vars.Module + "/" + Process.GetCurrentProcess().StartTime.ToString("dd-MM-yyyy-hh-mm") != null) ? "Results/" + Vars.Module + "/" + Process.GetCurrentProcess().StartTime.ToString("dd-MM-yyyy-hh-mm").ToString() : null) + fileName + ".txt", content + Environment.NewLine);
            }
        }
        public static void AsResultDirectory(string directory, string fileName, string content)
        {
            object obj = Export.resultLock;
            lock (obj)
            {
                Directory.CreateDirectory("Results/" + Vars.Module + "/" + Process.GetCurrentProcess().StartTime.ToString("dd-MM-yyyy-hh-mm") + "/" + directory); 
                File.AppendAllText("Results/" + Vars.Module + "/" + Process.GetCurrentProcess().StartTime.ToString("dd-MM-yyyy-hh-mm") + "/" + directory + "/" +  fileName + ".txt", content + Environment.NewLine);
            }
        }
        private static object resultLock = new object();
    }
    internal class Keychecks
    {
        private static readonly object _lock = new object();
        public static string Hit(string combo)
        {
            Interlocked.Increment(ref Vars.Hits);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            Export.AsResult("/Hits", combo);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                { 
                    Colorful.Console.WriteLine("  [HIT] " + combo, Color.LimeGreen);
                }
            }
            bool beep = Vars.BeepOnHit;
            if (beep)
            {
                Console.Beep();
            }
            return "";
        }
        public static string Empty(string combo)
        {
            Interlocked.Increment(ref Vars.Hits);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            Interlocked.Increment(ref Vars.NoCCAndBank);
            Export.AsResult("/Empty", combo);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                {
                    Colorful.Console.WriteLine("  [EMPTY] " + combo, Color.HotPink);
                }
            } 
            return "";
        }
        public static string Locked(string combo)
        {
            Interlocked.Increment(ref Vars.Locked);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            Export.AsResult("/Locked", combo);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                {
                    Colorful.Console.WriteLine("  [LOCKED] " + combo, Color.Orange);
                }
            }
            return "";
        }
        public static string Limited(string combo)
        {
            Interlocked.Increment(ref Vars.Limited);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            Export.AsResult("/Limited", combo);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                {
                    Colorful.Console.WriteLine("  [LIMITED] " + combo, Color.DarkOrange);
                }
            }
            return "";
        }

        public static string Free(string combo)
        {
            Interlocked.Increment(ref Vars.Free);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            Export.AsResult("/Free", combo);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                { 
                    Colorful.Console.WriteLine("  [FREE] " + combo, Color.HotPink);
                }
            }
            return "";
        }

        public static string Expired(string combo)
        {
            Interlocked.Increment(ref Vars.Expired);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            Export.AsResult("/Expired", combo);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                { 
                    Colorful.Console.WriteLine("  [EXPIRED] " + combo, Color.Purple);
                }
            }
            return "";
        }

        public static string Bad(string combo)
        {
            Interlocked.Increment(ref Vars.Bad);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm); 
            return "";
        }

        public static string Custom(string combo)
        {
            Export.AsResult("/Custom", combo);
            Interlocked.Increment(ref Vars.Custom);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm); 
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                { 
                    Colorful.Console.WriteLine("  [CUSTOM] " + combo, Color.Cyan);
                }
            }
            return "";
        }

        public static string twofa(string combo)
        {
            Export.AsResult("/2FA", combo);
            Interlocked.Increment(ref Vars.TwoFa);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                { 
                    Colorful.Console.WriteLine("  [2FA] " + combo, Color.Yellow);
                }
            }
            return "";
        }

        public static string Unknown(string combo)
        {
            Interlocked.Increment(ref Vars.Unknown);
            Interlocked.Increment(ref Vars.Checked);
            Interlocked.Increment(ref Vars.currentCpm);
            Export.AsResult("/Unknown", combo);
            bool Print = Vars.Design == "LOG";
            if (Print)
            {
                object writeLock = Vars.WriteLock;
                lock (writeLock)
                {
                    Colorful.Console.WriteLine("  [UNKNOWN] " + combo, Color.AliceBlue);
                }
            }
            return "";
        }

        public static string Retries(string combo)
        {
            object writeLock = Vars.WriteLock;
            lock (writeLock)
            {
                Interlocked.Increment(ref Vars.Retries);
                return "";
            }
        }
        public static string Errors(string combo)
        {
            object writeLock = Vars.WriteLock;
            lock (writeLock)
            {
                Interlocked.Increment(ref Vars.Errors);
                return "";
            }
        }
    }
}
