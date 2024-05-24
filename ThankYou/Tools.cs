using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;
using Microsoft.Win32;
using ThankYou.UIData;

namespace ThankYou
{
	// Token: 0x02000005 RID: 5
	public class Tools
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002114 File Offset: 0x00000314
		private static Task<XElement> LoadXElementAsync(string uri)
		{
			Tools.<LoadXElementAsync>d__0 <LoadXElementAsync>d__;
			<LoadXElementAsync>d__.<>t__builder = AsyncTaskMethodBuilder<XElement>.Create();
			<LoadXElementAsync>d__.uri = uri;
			<LoadXElementAsync>d__.<>1__state = -1;
			<LoadXElementAsync>d__.<>t__builder.Start<Tools.<LoadXElementAsync>d__0>(ref <LoadXElementAsync>d__);
			return <LoadXElementAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002158 File Offset: 0x00000358
		internal static Task<ThankYouModel> DownloadXmlAsync(string URL)
		{
			Tools.<DownloadXmlAsync>d__1 <DownloadXmlAsync>d__;
			<DownloadXmlAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ThankYouModel>.Create();
			<DownloadXmlAsync>d__.URL = URL;
			<DownloadXmlAsync>d__.<>1__state = -1;
			<DownloadXmlAsync>d__.<>t__builder.Start<Tools.<DownloadXmlAsync>d__1>(ref <DownloadXmlAsync>d__);
			return <DownloadXmlAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000219C File Offset: 0x0000039C
		internal static void LaunchURL(string URL)
		{
			try
			{
				if (URL.Contains("!bitness!"))
				{
					string newValue = Environment.Is64BitOperatingSystem ? "64" : "32";
					URL = URL.Replace("!bitness!", newValue);
				}
				if (Tools.IsInternetConnected() || URL.ToLower().EndsWith("chm"))
				{
					Process.Start(URL);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002210 File Offset: 0x00000410
		internal static bool IsInternetConnected()
		{
			bool flag = false;
			int num;
			flag = Tools.InternetGetConnectedState(out num, 0);
			if (!flag)
			{
				try
				{
					using (Tools.QuickaTimeoutWebClient quickaTimeoutWebClient = new Tools.QuickaTimeoutWebClient(5000))
					{
						using (quickaTimeoutWebClient.OpenRead("http://www.google.com"))
						{
							flag = true;
						}
					}
				}
				catch
				{
				}
			}
			return flag;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000228C File Offset: 0x0000048C
		internal static bool IsValidEmailAddress(string address)
		{
			bool result;
			try
			{
				result = new Regex("^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase).IsMatch(address);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022C4 File Offset: 0x000004C4
		internal static string GetInstallInfo(string regValue)
		{
			string text = string.Empty;
			try
			{
				RegistryKey localMachine = Registry.LocalMachine;
				RegistryKey registryKey;
				if (Environment.Is64BitOperatingSystem)
				{
					registryKey = localMachine.OpenSubKey("Software\\Wow6432Node\\Laplink\\PCmover\\Install");
				}
				else
				{
					registryKey = localMachine.OpenSubKey("Software\\Laplink\\PCmover\\Install");
				}
				text = registryKey.GetValue(regValue).ToString();
				registryKey.Close();
				localMachine.Close();
			}
			catch
			{
				text = string.Empty;
			}
			if (string.IsNullOrEmpty(text))
			{
				try
				{
					RegistryKey currentUser = Registry.CurrentUser;
					RegistryKey registryKey2 = currentUser.OpenSubKey("Software\\Laplink\\PCmover\\Install");
					text = registryKey2.GetValue(regValue).ToString();
					registryKey2.Close();
					currentUser.Close();
				}
				catch
				{
					text = string.Empty;
				}
			}
			return text;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000237C File Offset: 0x0000057C
		internal static string GetRegistrationInfo(string valueName)
		{
			string result = string.Empty;
			try
			{
				RegistryKey currentUser = Registry.CurrentUser;
				RegistryKey registryKey = currentUser.OpenSubKey("Software\\Laplink\\Registration");
				if (registryKey.GetValueKind(valueName) == RegistryValueKind.Binary)
				{
					result = Tools.ReadEncryptedString(registryKey, valueName);
				}
				else
				{
					result = registryKey.GetValue(valueName).ToString();
				}
				registryKey.Close();
				currentUser.Close();
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000023E8 File Offset: 0x000005E8
		internal static bool SendFeedback(string Comments, string name, string email, int rating, bool Authorized, string FeedbackUri)
		{
			bool result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Encoding = Encoding.UTF8;
					Uri address = new Uri(FeedbackUri);
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
					ServicePointManager.FindServicePoint(address).Expect100Continue = false;
					webClient.UploadValues(address, "POST", new NameValueCollection
					{
						{
							"validation",
							Tools.GetSNValidationCode().Trim()
						},
						{
							"feedback",
							Comments.Trim()
						},
						{
							"name",
							name.Trim()
						},
						{
							"email",
							email.Trim()
						},
						{
							"rating",
							rating.ToString()
						},
						{
							"authorized",
							Authorized.ToString()
						}
					});
				}
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000024D8 File Offset: 0x000006D8
		private static string GetSNValidationCode()
		{
			string text = string.Empty;
			string result;
			try
			{
				RegistryKey localMachine = Registry.LocalMachine;
				RegistryKey registryKey;
				if (Environment.Is64BitOperatingSystem)
				{
					registryKey = localMachine.OpenSubKey("Software\\Wow6432Node\\Laplink\\PCmover\\Reg");
				}
				else
				{
					registryKey = localMachine.OpenSubKey("Software\\Laplink\\PCmover\\Reg");
				}
				if (registryKey.GetValueKind("SN_ValidationCode") == RegistryValueKind.Binary)
				{
					text = Tools.ReadEncryptedString(registryKey, "SN_ValidationCode");
				}
				else
				{
					text = registryKey.GetValue("SN_ValidationCode").ToString();
				}
				registryKey.Close();
				localMachine.Close();
				result = text;
			}
			catch
			{
				result = "unknown";
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000256C File Offset: 0x0000076C
		private static Task<BitmapImage> GetImageSourceAsync(string URL)
		{
			Tools.<GetImageSourceAsync>d__9 <GetImageSourceAsync>d__;
			<GetImageSourceAsync>d__.<>t__builder = AsyncTaskMethodBuilder<BitmapImage>.Create();
			<GetImageSourceAsync>d__.URL = URL;
			<GetImageSourceAsync>d__.<>1__state = -1;
			<GetImageSourceAsync>d__.<>t__builder.Start<Tools.<GetImageSourceAsync>d__9>(ref <GetImageSourceAsync>d__);
			return <GetImageSourceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000025B0 File Offset: 0x000007B0
		private static string ReadEncryptedString(RegistryKey key, string valueName)
		{
			string result = null;
			try
			{
				byte[] array = (byte[])key.GetValue(valueName);
				array = ProtectedData.Unprotect(array, null, DataProtectionScope.LocalMachine);
				result = Encoding.UTF8.GetString(array);
			}
			catch
			{
				return "unknown";
			}
			return result;
		}

		// Token: 0x06000015 RID: 21
		[DllImport("wininet.dll")]
		private static extern bool InternetGetConnectedState(out int Description, int ReservedValue);

		// Token: 0x0200001B RID: 27
		private class QuickaTimeoutWebClient : WebClient
		{
			// Token: 0x060000D0 RID: 208 RVA: 0x00003482 File Offset: 0x00001682
			public QuickaTimeoutWebClient(int timeout)
			{
				this._Timeout = timeout;
			}

			// Token: 0x060000D1 RID: 209 RVA: 0x00003491 File Offset: 0x00001691
			protected override WebRequest GetWebRequest(Uri uri)
			{
				WebRequest webRequest = base.GetWebRequest(uri);
				webRequest.Timeout = this._Timeout;
				return webRequest;
			}

			// Token: 0x04000050 RID: 80
			private int _Timeout;
		}
	}
}
