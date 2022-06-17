using Leaf.xNet;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quantify
{
    public static class ssss
    {
       
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) - new DateTime(1970, 1, 1)).TotalSeconds;
        }
        public static string GetMachineGuid()
        {
            string location = @"SOFTWARE\Microsoft\Cryptography";
            string name = "MachineGuid";

            using (RegistryKey localMachineX64View =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                using (RegistryKey rk = localMachineX64View.OpenSubKey(location))
                {
                    if (rk == null)
                        throw new KeyNotFoundException(
                            string.Format("Key Not Found: {0}", location));

                    object machineGuid = rk.GetValue(name);
                    if (machineGuid == null)
                        throw new IndexOutOfRangeException(
                            string.Format("Index Not Found: {0}", name));

                    return machineGuid.ToString();
                }
            }
        }
        public static string ToUTF8(this string text)
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(text));
        }
        public static string Base64Decode(string value)
        {
            try
            {
                var valueBytes = System.Convert.FromBase64String(value);
                return System.Text.Encoding.UTF8.GetString(valueBytes);
            }
            catch { return Base64Decode(value + "="); }
        }
        private static readonly NumberStyles _style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        private static readonly IFormatProvider _provider = new CultureInfo("en-US");
        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);
        public static void AntiReverse()
        {
            while (true)
            {
                CAntiReverse.Run();
                Thread.Sleep(1);
            }
        }
        public static string Encrypt(string str, string key)
        {
            AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider();
            byte[] byteBuff;
            try
            {
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);

                aesCryptoProvider.GenerateIV();
                aesCryptoProvider.IV = aesCryptoProvider.IV;
                byteBuff = Encoding.UTF8.GetBytes(str);

                byte[] encoded = aesCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length);

                string ivHexString = ToHexString(aesCryptoProvider.IV);
                string encodedHexString = ToHexString(encoded);


                return ivHexString + ':' + encodedHexString;

            }
            catch (Exception ex)
            {
                Environment.Exit(0);
                return null;
            }
        }
        public static string Decrypt(string encodedStr, string key)
        {
            AesCryptoServiceProvider aesCryptoProvider = new AesCryptoServiceProvider();

            byte[] byteBuff;

            try
            {
                aesCryptoProvider.Key = Encoding.UTF8.GetBytes(key);
                string[] textParts = encodedStr.Split(':');
                byte[] iv = FromHexString(textParts[0]);
                aesCryptoProvider.IV = iv;
                byteBuff = FromHexString(textParts[1]);
                string plaintext = Encoding.UTF8.GetString(aesCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                return plaintext;

            }
            catch (Exception ex)
            {
                Environment.Exit(1); return null;
            }
        }
        public static string ToHexString(byte[] str)
        {
            var sb = new StringBuilder();

            var bytes = str;
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
        public static byte[] FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return bytes;
        }
        public static List<string> ActiveProcceses = new List<string>();
        public static string[] DebugTitles = new string[]
        {
            "ILSpy",
            "0harmony",
            "0Harmony",
            "x32dbg",
            "sharpod",
            "xd",
            "extremedumper",
            "dojandqwklndoqwd",
            "dojandqwklndoqwd-x86",
            "ksdumper",
            "KsDumper",
            "KsDumper v1.1 - By EquiFox",
            "ksdumper v1.1 - by equifox",
            "x64dbg",
            "x32_dbg",
            "x64_dbg",
            "strongod",
            "PhantOm",
            "titanHide",
            "scyllaHide",
            "ilspy",
            "graywolf",
            "simpleassemblyexplorer",
            "MegaDumper",
            "megadumper",
            "X64NetDumper",
            "x64netdumper",
            "process hacker 2",
            "ollydbg",
            "x32dbg",
            "x64dbg",
            "ida -",
            "charles",
            "dnspy",
            "httpanalyzer",
            "httpdebug",
            "fiddler",
            "wireshark",
            "proxifier",
            "mitmproxy",
            "process hacker",
            "process monitor",
            "process hacker 2",
            "system explorer",
            "systemexplorer",
            "systemexplorerservice",
            "WPE PRO",
            "ghidra",
            "x32dbg",
            "x64dbg",
            "ollydbg",
            "ida -",
            "charles",
            "dnspy",
            "dnSpy",
            "httpanalyzer",
            "httpdebug",
            "harmony",
            "http debugger",
            "fiddler",
            "wireshark",
            "dbx",
            "mdbg",
            "gdb",
            "windbg",
            "dbgclr",
            "kdb",
            "httpdebugger",
            "kgdb",
            "mdb",
            "folderchangesview"
        };
        public static void DebugProtection()
        {
            for (; ; )
            {
                Process[] processes = Process.GetProcesses();
                foreach (Process process in processes)
                {
                    if (DebugTitles.Contains(process.ProcessName))
                    {
                        Environment.Exit(0);
                    }
                    for (int i = 0; i < DebugTitles.Length; i++)
                    {
                        if (process.MainWindowTitle.ToLower().Contains(DebugTitles[i].ToLower()))
                        {
                            Environment.Exit(0);
                        }
                    }
                }
                Thread.Sleep(5000);
            }
        }
        public static void KillSwitch()
        {
            using (HttpRequest httpRequest = new HttpRequest
            {
                KeepAlive = true,
                IgnoreProtocolErrors = true
            })
            {
                httpRequest.SslCertificateValidatorCallback = (RemoteCertificateValidationCallback)Delegate.Combine(httpRequest.SslCertificateValidatorCallback, new RemoteCertificateValidationCallback((object obj, X509Certificate cert, X509Chain ssl, SslPolicyErrors error) => (cert as X509Certificate2).Verify()));
                string a = httpRequest.Get("https://raw.githubusercontent.com/WaterAIO/AIO/main/killer").ToString().ToLower();
                if (a == "true")
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
