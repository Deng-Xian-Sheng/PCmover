using System;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;
using Microsoft.Win32;
using WUApiLib;

namespace Laplink.Service.Infrastructure
{
	// Token: 0x0200000A RID: 10
	public static class CheckRebootHelper
	{
		// Token: 0x06000057 RID: 87 RVA: 0x000030A0 File Offset: 0x000012A0
		public static RebootPendingReasons GetRebootPendingReasons(LlTraceSource ts = null)
		{
			RebootPendingReasons reasons = RebootPendingReasons.None;
			try
			{
				using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
				{
					using (RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Component Based Servicing\\RebootPending", false))
					{
						if (registryKey2 != null)
						{
							LlTraceSource ts2 = ts;
							if (ts2 != null)
							{
								ts2.TraceCaller("ComponentBasedServicing", "GetRebootPendingReasons");
							}
							reasons |= RebootPendingReasons.ComponentBasedServicing;
						}
					}
					using (RegistryKey registryKey3 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\WindowsUpdate\\Auto Update\\RebootRequired", false))
					{
						if (registryKey3 != null)
						{
							LlTraceSource ts3 = ts;
							if (ts3 != null)
							{
								ts3.TraceCaller("WindowsUpdateAutoUpdate", "GetRebootPendingReasons");
							}
							reasons |= RebootPendingReasons.WindowsUpdateAutoUpdate;
						}
					}
					using (RegistryKey registryKey4 = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Netlogon", false))
					{
						if (registryKey4 != null)
						{
							string[] subKeyNames = registryKey4.GetSubKeyNames();
							if (subKeyNames != null && (subKeyNames.Contains("JoinDomain") || subKeyNames.Contains("AvoidSpnSet")))
							{
								LlTraceSource ts4 = ts;
								if (ts4 != null)
								{
									ts4.TraceCaller("PendingDomainJoin", "GetRebootPendingReasons");
								}
								reasons |= RebootPendingReasons.PendingDomainJoin;
							}
						}
					}
					CodeHelper.trycatch(delegate()
					{
						string str = "HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\ComputerName\\";
						string text = Registry.GetValue(str + "ComputerName", "ComputerName", null) as string;
						if (text != null)
						{
							string text2 = Registry.GetValue(str + "ActiveComputerName", "ComputerName", null) as string;
							if (text2 != null && text != text2)
							{
								LlTraceSource ts7 = ts;
								if (ts7 != null)
								{
									ts7.TraceCaller("PendingComputerRename", "GetRebootPendingReasons");
								}
								reasons |= RebootPendingReasons.PendingComputerRename;
							}
						}
					});
					using (RegistryKey key = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager", false))
					{
						if (key != null)
						{
							CodeHelper.trycatch(delegate()
							{
								string[] array = key.GetValue("PendingFileRenameOperations", null) as string[];
								if (array != null)
								{
									int num = array.Count<string>();
									for (int i = 1; i < num; i += 2)
									{
										if (string.IsNullOrWhiteSpace(array[i]))
										{
											reasons |= RebootPendingReasons.PendingFileDelete;
										}
										else
										{
											LlTraceSource ts7 = ts;
											if (ts7 != null)
											{
												ts7.TraceInformation("GetRebootPendingReasons: Rename {0} to {1}", new object[]
												{
													array[i - 1],
													array[i]
												});
											}
											reasons |= RebootPendingReasons.PendingFileRename;
										}
									}
								}
							});
						}
					}
				}
				try
				{
					ConnectionOptions options = new ConnectionOptions();
					using (ManagementClass managementClass = new ManagementClass(new ManagementScope("\\\\.\\ROOT\\ccm\\ClientSDK", options).Path.Path, "CCM_ClientUtilities", null))
					{
						ManagementBaseObject managementBaseObject = managementClass.InvokeMethod("DetermineIfRebootPending", null, null);
						if ((bool)managementBaseObject["RebootPending"] || (bool)managementBaseObject["IsHardRebootPending"])
						{
							LlTraceSource ts5 = ts;
							if (ts5 != null)
							{
								ts5.TraceCaller("SCCM", "GetRebootPendingReasons");
							}
							reasons |= RebootPendingReasons.SCCM;
						}
					}
				}
				catch
				{
				}
				Task<RebootPendingReasons> task = Task.Run<RebootPendingReasons>(() => CheckRebootHelper.GetUpdateReasons(ts));
				if (task.Wait(TimeSpan.FromSeconds(2.0)))
				{
					reasons |= task.Result;
					CheckRebootHelper.loggedTimeout = false;
				}
				else if (!CheckRebootHelper.loggedTimeout)
				{
					LlTraceSource ts6 = ts;
					if (ts6 != null)
					{
						ts6.TraceCaller("Timeout waiting for GetUpdateReasons", "GetRebootPendingReasons");
					}
					CheckRebootHelper.loggedTimeout = true;
				}
			}
			catch
			{
			}
			return reasons;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000341C File Offset: 0x0000161C
		private static RebootPendingReasons GetUpdateReasons(LlTraceSource ts)
		{
			try
			{
				UpdateInstaller updateInstaller = (UpdateInstaller)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("D2E0FE7F-D23E-48E1-93C0-6FA8CC346474")));
				if (updateInstaller.IsBusy)
				{
					if (ts != null)
					{
						ts.TraceCaller("Windows Update Installer is busy", "GetUpdateReasons");
					}
					return RebootPendingReasons.UpdateInProgress;
				}
				if (updateInstaller.RebootRequiredBeforeInstallation)
				{
					if (ts != null)
					{
						ts.TraceCaller("Windows Update requires reboot before installation", "GetUpdateReasons");
					}
					return RebootPendingReasons.UpdateRebootRequired;
				}
				CheckRebootHelper.loggedUpdateException = false;
			}
			catch (Exception ex)
			{
				if (!CheckRebootHelper.loggedUpdateException)
				{
					if (ts != null)
					{
						ts.TraceException(ex, "GetUpdateReasons");
					}
					CheckRebootHelper.loggedUpdateException = true;
				}
			}
			return RebootPendingReasons.None;
		}

		// Token: 0x0400001E RID: 30
		private static bool loggedTimeout;

		// Token: 0x0400001F RID: 31
		private static bool loggedUpdateException;
	}
}
