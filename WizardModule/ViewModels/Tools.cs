using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Media;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClientEngineModule.Infrastructure.Properties;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Laplink.Tools.NativeMethods;
using Laplink.Tools.Ui.Converters;
using Microsoft.Win32;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Events;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x02000096 RID: 150
	public static class Tools
	{
		// Token: 0x06000C65 RID: 3173 RVA: 0x00020AFA File Offset: 0x0001ECFA
		public static string Truncate(this string value, int maxChars)
		{
			if (value.Length > maxChars)
			{
				return value.Substring(0, maxChars) + "...";
			}
			return value;
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x00020B1C File Offset: 0x0001ED1C
		public static bool StartsWithNumber(this string Input)
		{
			bool result;
			try
			{
				result = char.IsDigit(Input.ToCharArray()[0]);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x00020B50 File Offset: 0x0001ED50
		public static string GetDisplaySize(double bytes)
		{
			return FileSizeConverter.ToString(bytes);
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x00020B58 File Offset: 0x0001ED58
		public static string GetDisplayTime(TimeSpan span)
		{
			string text;
			if (span.Hours > 0 || span.Days > 0)
			{
				text = (span.Days * 24 + span.Hours).ToString() + " ";
				text += ((span.Hours == 1 && span.Days == 0) ? WizardModule.Properties.Resources.strHour : WizardModule.Properties.Resources.strHours);
			}
			else if (span.Minutes > 0)
			{
				text = span.Minutes.ToString() + " ";
				text += ((span.Minutes == 1) ? WizardModule.Properties.Resources.strMinute : WizardModule.Properties.Resources.strMinutes);
			}
			else
			{
				text = "1 " + WizardModule.Properties.Resources.strMinute;
			}
			return text;
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x00020C1C File Offset: 0x0001EE1C
		public static bool IsInternetConnected()
		{
			bool flag = false;
			int num;
			flag = Wininet.InternetGetConnectedState(out num, 0);
			if (!flag)
			{
				try
				{
					using (Tools.QuickTimeoutWebClient quickTimeoutWebClient = new Tools.QuickTimeoutWebClient(2000))
					{
						using (quickTimeoutWebClient.OpenRead("http://www.google.com"))
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

		// Token: 0x06000C6A RID: 3178 RVA: 0x00020C98 File Offset: 0x0001EE98
		internal static bool IsEthernetAvailable(IPCmoverEngine engine)
		{
			IEnumerable<NetworkInfo> networkInfos = null;
			if (!engine.CatchCommEx(delegate
			{
				networkInfos = engine.NetworkInfos;
			}, "IsEthernetAvailable"))
			{
				return false;
			}
			foreach (NetworkInfo networkInfo in networkInfos)
			{
				if (networkInfo.NetworkInterfaceType.ToString().ToLower() == "ethernet" && networkInfo.OperationalStatus == OperationalStatus.Up)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x00020D4C File Offset: 0x0001EF4C
		public static string GetEthernetName(IPCmoverEngine engine)
		{
			IEnumerable<NetworkInfo> networkInfos = null;
			if (!engine.CatchCommEx(delegate
			{
				networkInfos = engine.NetworkInfos;
			}, "GetEthernetName"))
			{
				return null;
			}
			foreach (NetworkInfo networkInfo in networkInfos)
			{
				if (networkInfo.NetworkInterfaceType.ToString().ToLower() == "ethernet")
				{
					return networkInfo.Name;
				}
			}
			return null;
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x00020DFC File Offset: 0x0001EFFC
		public static string GetWiFiName(IPCmoverEngine engine)
		{
			IEnumerable<NetworkInfo> networkInfos = null;
			if (!engine.CatchCommEx(delegate
			{
				networkInfos = engine.NetworkInfos;
			}, "GetWiFiName"))
			{
				return null;
			}
			foreach (NetworkInfo networkInfo in networkInfos)
			{
				if (networkInfo.NetworkInterfaceType.ToString().ToLower().Contains("wireless") && networkInfo.OperationalStatus == OperationalStatus.Up)
				{
					return networkInfo.Name;
				}
			}
			return null;
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x00020EB4 File Offset: 0x0001F0B4
		internal static bool IsValidEmailAddress(string address)
		{
			if (string.IsNullOrEmpty(address))
			{
				return false;
			}
			try
			{
				MailAddress mailAddress = new MailAddress(address);
				if (!mailAddress.Host.Contains(".") || mailAddress.Host.StartsWith(".") || mailAddress.Host.EndsWith("."))
				{
					return false;
				}
				return new Regex("^[a-zA-Z0-9\\-\\.]+$").IsMatch(mailAddress.Host);
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x00020F3C File Offset: 0x0001F13C
		public static string GetUsername()
		{
			string empty;
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Laplink\\Registration", false))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue("UserName");
						if (value != null)
						{
							return value.ToString();
						}
					}
				}
				empty = string.Empty;
			}
			catch
			{
				empty = string.Empty;
			}
			return empty;
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x00020FB0 File Offset: 0x0001F1B0
		internal static void SetUsername(string name)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Laplink\\Registration"))
				{
					if (registryKey != null)
					{
						registryKey.SetValue("UserName", name);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x0002100C File Offset: 0x0001F20C
		public static string GetEmailAddress()
		{
			string empty;
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Laplink\\Registration", false))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue("Email");
						if (value != null)
						{
							return value.ToString();
						}
					}
				}
				empty = string.Empty;
			}
			catch
			{
				empty = string.Empty;
			}
			return empty;
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00021080 File Offset: 0x0001F280
		internal static void SetEmailAddress(string email)
		{
			try
			{
				using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Laplink\\Registration"))
				{
					if (registryKey != null)
					{
						registryKey.SetValue("Email", email);
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x000210DC File Offset: 0x0001F2DC
		internal static bool IsEULAAccepted()
		{
			string a = string.Empty;
			try
			{
				using (RegistryKey localMachine = Registry.LocalMachine)
				{
					RegistryKey registryKey = localMachine.OpenSubKey("Software\\Wow6432Node\\Laplink\\PCmover\\Install", false);
					if (registryKey == null)
					{
						registryKey = localMachine.OpenSubKey("Software\\Laplink\\PCmover\\Install", false);
					}
					if (registryKey != null)
					{
						object value = registryKey.GetValue("AcceptEULA");
						a = ((value != null) ? value.ToString() : null);
						registryKey.Close();
					}
				}
			}
			catch
			{
			}
			if (a != "Yes")
			{
				try
				{
					using (RegistryKey currentUser = Registry.CurrentUser)
					{
						RegistryKey registryKey = currentUser.OpenSubKey("Software\\Laplink\\PCmover\\Install", false);
						if (registryKey != null)
						{
							object value2 = registryKey.GetValue("AcceptEULA");
							a = ((value2 != null) ? value2.ToString() : null);
							registryKey.Close();
						}
					}
				}
				catch
				{
				}
			}
			if (a != "Yes")
			{
				a = Tools.GetXmlSetting("AcceptEULA");
			}
			return a == "Yes";
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x000211F0 File Offset: 0x0001F3F0
		internal static void SetEULAAccepted(bool isAccepted)
		{
			try
			{
				string empty = string.Empty;
				using (RegistryKey currentUser = Registry.CurrentUser)
				{
					RegistryKey registryKey = currentUser.CreateSubKey("Software\\Laplink\\PCmover\\Install");
					if (registryKey != null)
					{
						if (isAccepted)
						{
							registryKey.SetValue("AcceptEULA", "Yes");
						}
						else
						{
							registryKey.SetValue("AcceptEULA", "No");
						}
					}
					registryKey.Close();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x00021270 File Offset: 0x0001F470
		internal static void RemovePCmoverPopupFromRunKey()
		{
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				if (registryKey.GetValue("PCmoverPopup") != null)
				{
					registryKey.DeleteValue("PCmoverPopup");
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x000212BC File Offset: 0x0001F4BC
		internal static bool IsValidPath(string path)
		{
			try
			{
				if (!char.IsLetter(path[0]))
				{
					return false;
				}
				if (!Path.IsPathRooted(path))
				{
					return false;
				}
				if (Path.GetFullPath(path).Length > 0)
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
			return false;
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x00021314 File Offset: 0x0001F514
		public static bool IsValidWindowsAccountName(string name)
		{
			return !string.IsNullOrWhiteSpace(name) && !name.Trim().EndsWith(".") && name.Split(new char[]
			{
				'\\'
			}).Length - 1 <= 1 && !name.StartsWith("\\") && !name.EndsWith("\\") && !"/[]:;|=,+*?<>@\"".Any((char x) => name.Contains(x)) && (!name.Contains("\\") || name.Substring(name.IndexOf("\\")).Length <= 20);
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x000213E8 File Offset: 0x0001F5E8
		internal static double GetEstimatedlUndoProgress(double DisplayedProgress, UiCallbackCode action)
		{
			try
			{
				if (action != UiCallbackCode.Action_UndoProgressDisk)
				{
					if (action != UiCallbackCode.Action_UndoProgressReg)
					{
						if (DisplayedProgress < 80.0)
						{
							DisplayedProgress += 5.0;
						}
						if (DisplayedProgress < 98.0)
						{
							DisplayedProgress += 1.0;
						}
					}
					else if (DisplayedProgress < 76.0)
					{
						DisplayedProgress += 2.0;
					}
					else if (DisplayedProgress < 95.0)
					{
						DisplayedProgress += 0.1;
					}
				}
				else if (DisplayedProgress < 40.0)
				{
					DisplayedProgress += 1.0;
				}
				else if (DisplayedProgress < 60.0)
				{
					DisplayedProgress += 0.5;
				}
				else
				{
					if (DisplayedProgress >= 76.0)
					{
						return DisplayedProgress;
					}
					DisplayedProgress += 0.1;
				}
			}
			catch
			{
			}
			if (DisplayedProgress == 0.0)
			{
				return 1.0;
			}
			if (DisplayedProgress > 100.0)
			{
				return 100.0;
			}
			return DisplayedProgress;
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x00021510 File Offset: 0x0001F710
		internal static double GetTotalUnloadProgress(double CurrentProgress, TransferProgressInfo ReportedProgress)
		{
			try
			{
				if (ReportedProgress.Progress < 100.0)
				{
					UiCallbackCode actionCode = ReportedProgress.ProgressInfo.ActionCode;
					if (actionCode == UiCallbackCode.Action_UnloadProgressDisk)
					{
						return 2.0 + ReportedProgress.Progress * 0.86;
					}
					if (actionCode == UiCallbackCode.Action_UnloadProgressReg)
					{
						return 88.0 + ReportedProgress.Progress * 0.1;
					}
					if (CurrentProgress > 50.0)
					{
						return 98.0 + ReportedProgress.Progress * 0.02;
					}
					return 2.0;
				}
			}
			catch
			{
			}
			if (CurrentProgress == 0.0)
			{
				return 1.0;
			}
			return CurrentProgress;
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x000215E8 File Offset: 0x0001F7E8
		internal static double GetTimeRemaining(double CurrentProgress, TransferProgressInfo ReportedProgress, IMigrationDefinition definition)
		{
			double result = 0.0;
			try
			{
				if (CurrentProgress > 3.0)
				{
					result = ReportedProgress.ElapsedTime.TotalSeconds / (CurrentProgress / 100.0) - ReportedProgress.ElapsedTime.TotalSeconds;
				}
				else
				{
					result = (ReportedProgress.EstimatedTimeRemaining + definition.EstimatedTransferTime).TotalSeconds;
				}
			}
			catch (Exception)
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x00021674 File Offset: 0x0001F874
		internal static string NormalizeSerialNumber(string serialNumber)
		{
			if (!string.IsNullOrWhiteSpace(serialNumber))
			{
				serialNumber = serialNumber.ToUpper().Replace("I", "1").Replace("O", "0").Replace("U", "V").Replace("Z", "2");
				serialNumber = Regex.Replace(serialNumber, "[^0-9A-Za-z]", string.Empty);
				if (serialNumber.Length >= 16)
				{
					serialNumber = string.Concat(new string[]
					{
						serialNumber.Substring(0, 7),
						"-",
						serialNumber.Substring(7, 6),
						"-",
						serialNumber.Substring(13, 3)
					});
				}
			}
			return serialNumber;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x0002172C File Offset: 0x0001F92C
		internal static bool IsUserAdministrator()
		{
			bool result;
			try
			{
				result = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x00021768 File Offset: 0x0001F968
		internal static void Init3rdPartyApps()
		{
			try
			{
				string text = AppDomain.CurrentDomain.BaseDirectory + "ThankYou.exe";
				if (File.Exists(text))
				{
					Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Run", "LaplinkOffers", text, RegistryValueKind.String);
					Registry.SetValue("HKEY_CURRENT_USER\\Software\\Laplink\\PCmover\\Install", "Oem", PcmBrandUI.Properties.Resources.OEM, RegistryValueKind.String);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x000217D0 File Offset: 0x0001F9D0
		internal static void Disable3rdPartyApps()
		{
			try
			{
				Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue("LaplinkOffers", false);
			}
			catch
			{
			}
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00021810 File Offset: 0x0001FA10
		internal static string TranslateUICallback(UiCallbackCode Code, string EnglishString = null)
		{
			ResourceManager resourceManager = ClientEngineModule.Infrastructure.Properties.Resources.ResourceManager;
			string text = resourceManager.GetString(Code.ToString());
			if (text == null)
			{
				return EnglishString;
			}
			if (text.Contains("%p"))
			{
				text = text.Replace("%p", PcmBrandUI.Properties.Resources.ProgramName);
			}
			if (text.Contains("{0}") && !string.IsNullOrEmpty(EnglishString))
			{
				try
				{
					string @string = resourceManager.GetString(Code.ToString(), CultureInfo.GetCultureInfo("en"));
					IEnumerable<string> first = EnglishString.Trim().Split(new char[]
					{
						' '
					}).Distinct<string>();
					IEnumerable<string> second = @string.Trim().Split(new char[]
					{
						' '
					}).Distinct<string>();
					object[] args = first.Except(second).ToArray<object>();
					text = string.Format(text, args);
				}
				catch
				{
				}
			}
			return text;
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x000218F4 File Offset: 0x0001FAF4
		public static string LookupEnumResource(TransferProcessResult tpr)
		{
			switch (tpr)
			{
			case TransferProcessResult.Success:
				return WizardModule.Properties.Resources.TEPP_Success;
			case TransferProcessResult.UserStop:
				return WizardModule.Properties.Resources.TEPP_UserCancelledTransfer;
			case TransferProcessResult.EofIntentional:
			case TransferProcessResult.InternalError:
			case TransferProcessResult.OtherError:
			case TransferProcessResult.InvalidTask:
			case TransferProcessResult.TransferFailed:
				return tpr.ToString();
			case TransferProcessResult.EofUnexpected:
				return WizardModule.Properties.Resources.TEPP_UnexpectedDisconnect;
			case TransferProcessResult.DiskFull:
				return WizardModule.Properties.Resources.TEPP_DiskFull;
			case TransferProcessResult.ConnectionError:
				return WizardModule.Properties.Resources.TEPP_ConnectionError;
			}
			return WizardModule.Properties.Resources.TEPP_UnknownError;
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x0002198C File Offset: 0x0001FB8C
		public static string LookupEnumResource(TaskAction action)
		{
			string result = "";
			switch (action)
			{
			case TaskAction.Unknown:
				result = WizardModule.Properties.Resources.Report_Enum_Action_Unknown;
				break;
			case TaskAction.Send:
				result = WizardModule.Properties.Resources.Report_Enum_Action_Send;
				break;
			case TaskAction.Receive:
				result = WizardModule.Properties.Resources.Report_Enum_Action_Receive;
				break;
			case TaskAction.Undo:
				result = WizardModule.Properties.Resources.Report_Enum_Action_Undo;
				break;
			}
			return result;
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x000219D8 File Offset: 0x0001FBD8
		public static string LookupEnumResource(TransferMethodType tm)
		{
			if (tm <= TransferMethodType.Image)
			{
				if (tm == TransferMethodType.File)
				{
					return WizardModule.Properties.Resources.FPP_File;
				}
				if (tm == TransferMethodType.Image)
				{
					return WizardModule.Properties.Resources.FPP_Image;
				}
			}
			else
			{
				if (tm == TransferMethodType.Network)
				{
					return WizardModule.Properties.Resources.Report_Enum_TransferMethod_Network;
				}
				if (tm == TransferMethodType.Usb)
				{
					return WizardModule.Properties.Resources.FPP_USB;
				}
			}
			return tm.ToString();
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00021A38 File Offset: 0x0001FC38
		internal static string GetXmlSetting(string Name)
		{
			string result = string.Empty;
			try
			{
				string text = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "Settings.xml");
				if (File.Exists(text))
				{
					result = XElement.Load(text).Elements().FirstOrDefault((XElement x) => x.Name == Name).Value;
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00021AB8 File Offset: 0x0001FCB8
		public static string ExpandEnvironmentPlusDateTime(string s, EnvLookup envLookup)
		{
			if (string.IsNullOrEmpty(s))
			{
				return s;
			}
			string text = envLookup.Expand(s);
			string text2 = text.ToLower();
			if (text2.Contains("%date%"))
			{
				text = text2.Replace("%date%", DateTime.Now.ToString("yyyy-MM-dd"));
				text2 = text;
			}
			if (text2.Contains("%time%"))
			{
				text = text2.Replace("%time%", DateTime.Now.ToString("HH.mm.ss"));
			}
			if (text2.Contains("%uuid%"))
			{
				text = text2.Replace("%uuid%", Tools.GetSystemUuid());
			}
			return text;
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00021B58 File Offset: 0x0001FD58
		private static string GetSystemUuid()
		{
			string result;
			try
			{
				ManagementScope managementScope = new ManagementScope("\\\\localhost\\root\\CIMV2", null);
				managementScope.Connect();
				result = (string)new ManagementObjectSearcher(managementScope, new ObjectQuery("SELECT UUID FROM Win32_ComputerSystemProduct")).Get().Cast<ManagementObject>().First<ManagementObject>()["UUID"];
			}
			catch (Exception)
			{
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00021BC0 File Offset: 0x0001FDC0
		internal static bool IsValidIPAddress(string ipAddress)
		{
			IPAddress ipaddress;
			long num;
			return !string.IsNullOrWhiteSpace(ipAddress) && IPAddress.TryParse(ipAddress, out ipaddress) && !long.TryParse(ipAddress, out num);
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x00021BF0 File Offset: 0x0001FDF0
		internal static bool IsIntelProcessor(IPCmoverEngine engine)
		{
			try
			{
				ManagementObject managementObject = new ManagementObjectSearcher("select * from Win32_Processor").Get().Cast<ManagementObject>().First<ManagementObject>();
				engine.Ts.TraceInformation("Processor Name: " + (string)managementObject["Name"]);
				engine.Ts.TraceInformation("Processor Manufacturer: " + (string)managementObject["Manufacturer"]);
				engine.Ts.TraceInformation("Processor Description: " + (string)managementObject["Description"]);
				engine.Ts.TraceInformation("Processor Caption: " + (string)managementObject["Caption"]);
				string a = (string)managementObject["Manufacturer"];
				managementObject.Dispose();
				return a == "GenuineIntel";
			}
			catch (Exception ex)
			{
				engine.Ts.TraceInformation("Exception getting processor information: " + ex.Message);
			}
			return true;
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00021D00 File Offset: 0x0001FF00
		internal static bool IsBiosNEC(IPCmoverEngine engine)
		{
			try
			{
				using (ManagementObject managementObject = new ManagementObjectSearcher("select * from Win32_BIOS").Get().Cast<ManagementObject>().First<ManagementObject>())
				{
					string text = (string)managementObject["Manufacturer"];
					engine.Ts.TraceInformation("BIOS Manufacturer: " + text);
					return text.Trim().ToLower() == "nec";
				}
			}
			catch (Exception ex)
			{
				engine.Ts.TraceInformation("Exception getting BIOS information: " + ex.Message);
			}
			return true;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x00021DB0 File Offset: 0x0001FFB0
		internal static bool IsLG(IPCmoverEngine engine)
		{
			try
			{
				ManagementObject managementObject = new ManagementObjectSearcher("select * from Win32_ComputerSystem").Get().Cast<ManagementObject>().First<ManagementObject>();
				string text = (string)managementObject["Manufacturer"];
				managementObject.Dispose();
				engine.Ts.TraceInformation("Performing LG check.  System Manufacturer is " + text);
				return text.Trim() == "LG Electronics";
			}
			catch (Exception ex)
			{
				engine.Ts.TraceInformation("An error occurred atempting to get System Manufacturer in LG check: " + ex.Message);
			}
			return false;
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00021E48 File Offset: 0x00020048
		internal static string GetResourceString(string Name)
		{
			string @string = PcmBrandUI.Properties.Resources.ResourceManager.GetString(Name);
			if (string.IsNullOrEmpty(@string))
			{
				@string = WizardModule.Properties.Resources.ResourceManager.GetString(Name);
			}
			if (string.IsNullOrEmpty(@string))
			{
				@string = ClientEngineModule.Infrastructure.Properties.Resources.ResourceManager.GetString(Name);
			}
			return @string;
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00021E8C File Offset: 0x0002008C
		internal static bool WillDownloadManagerRunAfterReboot()
		{
			bool result;
			try
			{
				using (RegistryKey localMachine = Registry.LocalMachine)
				{
					using (RegistryKey registryKey = localMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", false))
					{
						if (registryKey.GetValue("PCmoverConfigurationManager") != null)
						{
							return true;
						}
					}
				}
				using (RegistryKey currentUser = Registry.CurrentUser)
				{
					using (RegistryKey registryKey2 = currentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", false))
					{
						result = (registryKey2.GetValue("PCmoverConfigurationManager") != null);
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x00021F58 File Offset: 0x00020158
		internal static Task<bool> PromptForReconfigurator(IPCmoverEngine engine, IEventAggregator eventAggregator)
		{
			Tools.<PromptForReconfigurator>d__39 <PromptForReconfigurator>d__;
			<PromptForReconfigurator>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<PromptForReconfigurator>d__.engine = engine;
			<PromptForReconfigurator>d__.eventAggregator = eventAggregator;
			<PromptForReconfigurator>d__.<>1__state = -1;
			<PromptForReconfigurator>d__.<>t__builder.Start<Tools.<PromptForReconfigurator>d__39>(ref <PromptForReconfigurator>d__);
			return <PromptForReconfigurator>d__.<>t__builder.Task;
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x00021FA4 File Offset: 0x000201A4
		private static bool IsReconfiguratorNeeded(IPCmoverEngine engine)
		{
			bool isNeeded = false;
			engine.CatchCommEx(delegate
			{
				if (Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowReconfigurator) && !engine.IsRemoteUI && File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Reconfigurator.exe") && engine.ThisMachineDriveSpace.Count<DriveSpaceData>() > 1)
				{
					double otherDriveMaxSize = 256.0;
					try
					{
						using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
						{
							using (RegistryKey registryKey2 = registryKey.OpenSubKey("Software\\Laplink\\PCmover\\Install"))
							{
								if (registryKey2 != null && registryKey2.GetValueNames().Contains("ReconfiguratorDriveSize"))
								{
									otherDriveMaxSize = Convert.ToDouble(registryKey2.GetValue("ReconfiguratorDriveSize"));
								}
							}
						}
					}
					catch
					{
					}
					bool flag = DriveInfo.GetDrives().Any((DriveInfo drive) => drive.IsReady && !drive.Name.ToLower().StartsWith("c") && (double)drive.TotalSize / Math.Pow(1024.0, 3.0) > otherDriveMaxSize);
					if ((long)((double)new DriveInfo("C:\\").TotalSize / Math.Pow(1024.0, 3.0)) <= 256L && flag)
					{
						Environment.SpecialFolder[] array = new Environment.SpecialFolder[4];
						RuntimeHelpers.InitializeArray(array, fieldof(<PrivateImplementationDetails>.2D3581AB8E42A7356520383C588068573241FF15D875208E8179B5E23568CA1C).FieldHandle);
						Environment.SpecialFolder[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							if (Path.GetPathRoot(Environment.GetFolderPath(array2[i])).StartsWith("C"))
							{
								isNeeded = true;
								return;
							}
						}
					}
				}
			}, "IsReconfiguratorNeeded");
			return isNeeded;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x00021FE8 File Offset: 0x000201E8
		public static void OpenSupport(DefaultPolicy policy)
		{
			try
			{
				string fileName = string.Empty;
				if (!string.IsNullOrEmpty(PcmBrandUI.Properties.Resources.URL_supportLink))
				{
					fileName = PcmBrandUI.Properties.Resources.URL_supportLink;
				}
				else if (policy.SupportEmail.Contains("@"))
				{
					fileName = "mailto:" + policy.SupportEmail;
				}
				else if (policy.SupportEmail.StartsWith("http"))
				{
					fileName = policy.SupportEmail;
				}
				Process.Start(new ProcessStartInfo(fileName));
			}
			catch
			{
			}
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x00022070 File Offset: 0x00020270
		internal static void PlayAudio(Tools.Sounds Sound)
		{
			string text = Environment.GetEnvironmentVariable("SystemRoot");
			switch (Sound)
			{
			case Tools.Sounds.Notification:
				text += "\\media\\Windows Balloon.wav";
				break;
			case Tools.Sounds.Warning:
				text += "\\media\\Windows Exclamation.wav";
				break;
			case Tools.Sounds.Error:
				text += "\\media\\Windows Critical Stop.wav";
				break;
			}
			if (File.Exists(text))
			{
				try
				{
					new SoundPlayer(text).Play();
					return;
				}
				catch
				{
				}
			}
			switch (Sound)
			{
			case Tools.Sounds.Notification:
				SystemSounds.Asterisk.Play();
				return;
			case Tools.Sounds.Warning:
				SystemSounds.Hand.Play();
				return;
			case Tools.Sounds.Error:
				SystemSounds.Exclamation.Play();
				break;
			default:
				return;
			}
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x00022120 File Offset: 0x00020320
		internal static ObservableCollection<string> GetLogicalUsbDisks()
		{
			ObservableCollection<string> result;
			try
			{
				ObservableCollection<string> observableCollection = new ObservableCollection<string>();
				foreach (ManagementBaseObject managementBaseObject in new ManagementObjectSearcher("SELECT Caption, DeviceID FROM Win32_DiskDrive WHERE InterfaceType='USB'").Get())
				{
					ManagementObject managementObject = (ManagementObject)managementBaseObject;
					string str = "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='";
					object obj = managementObject["DeviceID"];
					foreach (ManagementBaseObject managementBaseObject2 in new ManagementObjectSearcher(str + ((obj != null) ? obj.ToString() : null) + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
					{
						ManagementObject managementObject2 = (ManagementObject)managementBaseObject2;
						string str2 = "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='";
						object obj2 = managementObject2["DeviceID"];
						foreach (ManagementBaseObject managementBaseObject3 in new ManagementObjectSearcher(str2 + ((obj2 != null) ? obj2.ToString() : null) + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
						{
							ManagementObject managementObject3 = (ManagementObject)managementBaseObject3;
							observableCollection.Add(managementObject3["CAPTION"].ToString());
						}
					}
				}
				result = observableCollection;
			}
			catch
			{
				result = new ObservableCollection<string>();
			}
			return result;
		}

		// Token: 0x02000182 RID: 386
		private class QuickTimeoutWebClient : WebClient
		{
			// Token: 0x060012CC RID: 4812 RVA: 0x0003ABD6 File Offset: 0x00038DD6
			public QuickTimeoutWebClient(int timeout)
			{
				this._Timeout = timeout;
			}

			// Token: 0x060012CD RID: 4813 RVA: 0x0003ABE5 File Offset: 0x00038DE5
			protected override WebRequest GetWebRequest(Uri uri)
			{
				WebRequest webRequest = base.GetWebRequest(uri);
				webRequest.Timeout = this._Timeout;
				return webRequest;
			}

			// Token: 0x0400083C RID: 2108
			private int _Timeout;
		}

		// Token: 0x02000183 RID: 387
		public enum Sounds
		{
			// Token: 0x0400083E RID: 2110
			Notification,
			// Token: 0x0400083F RID: 2111
			Warning,
			// Token: 0x04000840 RID: 2112
			Error
		}
	}
}
