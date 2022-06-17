using Leaf.xNet;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Quantify
{
	internal class Threading
	{
		static List<Action<string>> pickedModules = new List<Action<string>>();
		public static void StartMethod()
		{
			while (!Vars.ComboList.IsEmpty)
			{
				string arg;
				bool flag = Vars.ComboList.TryDequeue(out arg);
				if (flag)
				{
					foreach (Action<string> checkFunction in pickedModules.Distinct())
					{
					   checkFunction(arg);
					   Thread.Sleep(1);
					}
					Thread.Sleep(1);
				}
				Thread.Sleep(1);
			}
		} 
		public static void StartChecking(Action<string> Target)
		{
			ThreadingSystem1(Target);
		}
		public static void Threader(ThreadStart meth)
		{
			for (int i = 0; i < Vars.ThreadsToUse; i++)
			{
				Vars.Threads.Add(new Thread(meth));
			}
		}
		public static void ThreadStart()
		{
			Vars.IsRunning = true;
			Vars.ShowTitle = true;
			Vars.UIEnabled = true;
			Vars.UiStat = true;
			Functions.PrintCUI();
			for (int i = 0; i < Vars.Threads.Count; i++)
			{
				Vars.Threads[i].Start();
			}
			for (int j = 0; j < Vars.Threads.Count; j++)
			{
				Vars.Threads[j].Join();
			}
		}
		public static void ThreadingSystem1(Action<string> Target)
		{
			Console.Clear();
			Utilities.Logo();
			try
			{
				pickedModules.Add(Target);
				Threader(new ThreadStart(StartMethod));
				ThreadStart();
				Functions.DoneCUI();
			}
			catch
			{
				Vars.Errors++;
			}
		} 
		public static void Start()
		{
			foreach (Task task in Tasks)
			{
				task.Start();
			}
		}
		public static List<Task> Tasks = new List<Task>();
		public static void Process(int start, int end, string[] Combo, Action<string> doMethod)
		{
			for (int i = start; i <= end; i++)
			{
				doMethod(Combo[i]);
			}
		}
	}
}