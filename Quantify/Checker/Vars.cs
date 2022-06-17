using Leaf.xNet;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;	
using System.Threading;
using System.Threading.Tasks;
namespace Quantify
{
    
    public static class Vars
	{
		public static bool AdvancedBalanceCapture;
		public static bool PhoneCapture;
		public static bool BankCapture;
		public static bool BalanceCapture;
		public static bool CardCapture;
		public static bool CountryCapture;
		public static bool RetrictedCapture;
		public static bool VerifiedCapture;
		public static bool CreditCapture;
		public static bool LockedCapture;
		public static bool CookieCapture;
		public static bool NameCapture;
		public static bool TotalCards;
		public static bool TotalBanks;
		public static bool EmaiLVerified;
		public static bool CardType;
		public static bool CardLast4;
		public static bool BankLast4;
		public static bool AccountType;
		public static bool AddressCapture;
		public static bool AdvancedDetailsCapture;








		public static DateTime Now = DateTime.Now;
		public static int loadedCombos = 0;
		public static int ThreadsToUse = 0;  
		public static string Design = "";
		public static string OutputType;
		public static bool BeepOnHit;
        public static int RefreshRate = 0;
		public static ReaderWriterLockSlim ReadWriteLock = new ReaderWriterLockSlim();
		public static void Write(string Path, string Data)
		{
			ReadWriteLock.EnterWriteLock();
			StreamWriter streamWriter = new StreamWriter(Path, true);
			streamWriter.Write(Data + Environment.NewLine);
			streamWriter.Flush();
			streamWriter.Close();
			ReadWriteLock.ExitWriteLock();
		}
		public static List<string> AlreadyChecked = new List<string>();
		public static List<string> retryaccounts = new List<string>();
		public static ConcurrentQueue<string> ComboList = new ConcurrentQueue<string>();
		public static List<ProxyClient> ProxyList = new List<ProxyClient>();
		public static int Captchasolved;
		public static string Module;
		public static int cpmm = 0;
		public static int[] cpmList = new int[60];
		public static int cpmI = 0;
		public static string FileName = "";
		public static double procent = Functions.presenter(Checked);
		public static bool IsRunning;
		public static bool IsPaused;
		public static bool UiStat = true;
		public static bool ShowTitle = true;
		public static bool UIEnabled = true;
		public static int TotalLoadedCombos = 0;
		public static string ComboFileName = "";
		public static string ProxyFileName = "";
		public static DateTime currentCpmDatetime;
		public static int currentCpm;
		public static List<int> lastCpms = new List<int>();
		public static readonly object WriteLock = new object();
		public static string Date = DateTime.Now.ToString("MM-dd-yyyy H.mm");

		public static int Hits = 0;
		public static int Bad = 0;
		public static int Free = 0;
		public static int Retries = 0;
		public static int Cards = 0;
		public static int Personal = 0;
		public static int Business = 0;
		public static int Other = 0;
		public static int WithBal = 0;
		public static int USA = 0;
		public static int UK = 0;
		public static int OTHERCOUNTRY = 0;
		public static int TotalBal;
		public static int Balance = 0;
		public static int Banks = 0;
		public static int NoCCAndBank = 0;
		public static int Expired = 0;
		public static int TwoFa = 0;
		public static int Locked = 0;
		public static int Limited = 0;
		public static int CCAndBank = 0;
		public static int Unknown = 0;
		public static int Cps = 0;
		public static int ReCheck = 0;
		public static int Total = 0;
		public static int Check = 0;
		public static int Custom = 0;
		public static int Checked = 0;
		public static int Errors = 0;
		 
		public static List<Func<string, bool>> Modules = new List<Func<string, bool>>();
		public static List<string> AllModules = new List<string>();

		public static List<string> Proxiess = new List<string>();
		public static string[] Combo;

		public static List<Thread> ThreadsList = new List<Thread>();

		public static List<ThreadStart> ThisThread = new List<ThreadStart>();

		public static List<string> mod = new List<string>();

		public static List<string> mod1 = new List<string>();

        public static int UI, Proxytype;
		public static List<string> keys = new List<string>();

		public static List<string> keys1 = new List<string>();
        public static ProxyType proxyType { get; set; } = ProxyType.HTTP;
		public static List<Thread> Threads = new List<Thread>();
		public static string Threadss;
		public static List<Func<string, bool>> Methods = new List<Func<string, bool>>();
		public static List<Func<string>> Methodss = new List<Func<string>>();
	}
}
