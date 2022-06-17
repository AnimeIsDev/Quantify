using Leaf.xNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Console = Colorful.Console;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Quantify
{
	internal class PasswordFilter
	{
		public static void Start(string Combo)
		{
			MakeRequest(Combo);
		}
		public static bool HasSpecialChar(string input)
		{
			foreach (char value in "\\|!#$%&/()=?»«@£§€{}.-;'<>_,")
			{
				if (input.Contains(value))
				{
					return true;
				}
			}
			return false;
		}
		public static void MakeRequest(string c)
		{
			string email = string.Empty;
			string password = string.Empty;
			if (c.Contains(":"))
			{
				email = c.Split(new string[]
				{
					":"
				}, StringSplitOptions.None)[0];
				password = c.Split(new string[]
				{
					":"
				}, StringSplitOptions.None)[1];
			}
			else if (!c.Contains(":"))
			{
				return;
			}
			try
			{
				if (password.Length >= 8 && HasSpecialChar(password))
				{
					Keychecks.Hit(c);
				}
				else if (password.Length >= 8 && !HasSpecialChar(password))
				{
					Keychecks.Hit(c);
				}
				else if (password.Length < 8)
				{ 
					Keychecks.Bad(c);
				}
			}
			catch (HttpException)
			{
				 Keychecks.Retries(c);
				 MakeRequest(c);
			}
			catch
			{
				Keychecks.Errors(c);
				MakeRequest(c);
			} 
		}
	}
}
