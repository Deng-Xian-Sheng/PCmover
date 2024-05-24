using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;
using Laplink.Discovery.Infrastructure;
using Laplink.Download.Contracts;
using Laplink.Service.Contracts;
using Laplink.Service.Infrastructure;
using Laplink.Tools.Helpers;
using Microsoft.Win32;

namespace Laplink.Download.Service
{
	// Token: 0x02000003 RID: 3
	[ServiceBehavior(Namespace = "http://laplink.com/services/downloadcontracts/v2.0056", InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults = true)]
	public class DownloadManager : IDownloadControl, IDownloadMonitor, IDownloadQuery, IServiceManager, ILlTraceSource
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x0000206D File Offset: 0x0000026D
		public DownloadControlCallbackStateData DownloadCcs { get; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x00002075 File Offset: 0x00000275
		public ControlCallbackManager<IDownloadControlCallback> DownloadCcm { get; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x0000207D File Offset: 0x0000027D
		public IServiceManager ServiceManager
		{
			get
			{
				return this;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002080 File Offset: 0x00000280
		// (set) Token: 0x06000007 RID: 7 RVA: 0x00002088 File Offset: 0x00000288
		private DownloadState State
		{
			get
			{
				return this._state;
			}
			set
			{
				if (this._state != value)
				{
					this._state = value;
					this.Ts.TraceInformation(string.Format("DownloadState: {0}", value));
					this.NotifyStatusInfoChanged();
				}
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020BB File Offset: 0x000002BB
		public DownloadStatusInfo StatusInfo
		{
			get
			{
				return new DownloadStatusInfo(this.State, this.DownloadCcs.HasController);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020D3 File Offset: 0x000002D3
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000020DB File Offset: 0x000002DB
		public WindowsIdentity InvokerIdentity { private get; set; }

		// Token: 0x17000007 RID: 7
		// (set) Token: 0x0600000B RID: 11 RVA: 0x000020E4 File Offset: 0x000002E4
		public string InvokerScheme
		{
			set
			{
			}
		}

		// Token: 0x17000008 RID: 8
		// (set) Token: 0x0600000C RID: 12 RVA: 0x000020E4 File Offset: 0x000002E4
		public ManualResetEvent ExitEvent
		{
			set
			{
			}
		}

		// Token: 0x17000009 RID: 9
		// (set) Token: 0x0600000D RID: 13 RVA: 0x000020E4 File Offset: 0x000002E4
		public IDictionary InvokerEnvironment
		{
			set
			{
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000020E6 File Offset: 0x000002E6
		private MonitorCallbackManager<IDownloadMonitorCallback> MonitorCallbackManager
		{
			get
			{
				if (this._monitorCallbackManager == null)
				{
					this._monitorCallbackManager = new MonitorCallbackManager<IDownloadMonitorCallback>(this.Ts);
				}
				return this._monitorCallbackManager;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600000F RID: 15 RVA: 0x00002107 File Offset: 0x00000307
		// (set) Token: 0x06000010 RID: 16 RVA: 0x0000210F File Offset: 0x0000030F
		public string EnabledSettingName { get; set; } = "LoggingEnabled";

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002118 File Offset: 0x00000318
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002120 File Offset: 0x00000320
		public string PreviousLogFileSettingName { get; set; } = "PreviousLogFile";

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000013 RID: 19 RVA: 0x0000212C File Offset: 0x0000032C
		public LlTraceSource Ts
		{
			get
			{
				if (this._ts == null)
				{
					this._ts = new LlTraceSource("DownloadService")
					{
						EnabledSettingName = this.EnabledSettingName,
						PreviousLogFileSettingName = this.PreviousLogFileSettingName
					};
					this._ts.InitLoggingFromAppData("Laplink\\PCmover\\DownloadService.log");
				}
				return this._ts;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002180 File Offset: 0x00000380
		public DownloadManager()
		{
			this._rebootAfterAllInstalls = ConfigHelper.GetBoolSetting("RebootAfterDownloadInstall", false);
			this.DownloadCcs = new DownloadControlCallbackStateData(this);
			this.DownloadCcm = new ControlCallbackManager<IDownloadControlCallback>(this.DownloadCcs);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000021D7 File Offset: 0x000003D7
		public void OnStart()
		{
			this.Ts.TraceInformation("Download Manager contracts namespace = http://laplink.com/services/downloadcontracts/v2.0056");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000020E4 File Offset: 0x000002E4
		public void OnStop()
		{
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000021E9 File Offset: 0x000003E9
		public ServiceHost CreateServiceHost()
		{
			this.OnStart();
			return LlServiceHostWithDiscovery.CreateDiscoveryHost<DownloadServiceHost>(() => new DownloadServiceHost(this, this.Ts), true);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002203 File Offset: 0x00000403
		public Version GetDownloadVersion()
		{
			return new Version(0, 1);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000220C File Offset: 0x0000040C
		public DownloadStatusInfo GetDownloadStatus()
		{
			return this.StatusInfo;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002214 File Offset: 0x00000414
		public void ConfigureMonitorCallbacks(CallbackState monitorCallbackState)
		{
			this.MonitorCallbackManager.Configure(monitorCallbackState, OperationContext.Current.SessionId, OperationContext.Current.GetCallbackChannel<IDownloadMonitorCallback>());
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002238 File Offset: 0x00000438
		public bool BecomeController(CallbackState controlCallbackState)
		{
			ControlCallbackManager<IDownloadControlCallback> downloadCcm = this.DownloadCcm;
			IDownloadControlCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IDownloadControlCallback>();
			ServiceSecurityContext serviceSecurityContext = ServiceSecurityContext.Current;
			IIdentity identity = (serviceSecurityContext != null) ? serviceSecurityContext.PrimaryIdentity : null;
			ServiceSecurityContext serviceSecurityContext2 = ServiceSecurityContext.Current;
			WindowsIdentity windowsIdentity = (serviceSecurityContext2 != null) ? serviceSecurityContext2.WindowsIdentity : null;
			OperationContext operationContext = OperationContext.Current;
			return downloadCcm.SetController(callbackChannel, identity, windowsIdentity, (operationContext != null) ? operationContext.Channel.LocalAddress.Uri.Scheme : null, controlCallbackState);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000229D File Offset: 0x0000049D
		public void StopBeingController()
		{
			this.DownloadCcm.StopBeingController();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000022AA File Offset: 0x000004AA
		public void ConfigureControlCallbacks(CallbackState controlCallbackState)
		{
			this.DownloadCcm.ConfigureControlCallbacks(controlCallbackState);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000022B8 File Offset: 0x000004B8
		public void VerifyControl([CallerMemberName] string caller = "")
		{
			this.DownloadCcm.VerifyControl(caller);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022C8 File Offset: 0x000004C8
		public void PerformPendingReboot()
		{
			this.VerifyControl("PerformPendingReboot");
			try
			{
				Process.Start("shutdown.exe", "/r /t 3");
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "PerformPendingReboot");
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002318 File Offset: 0x00000518
		public ObservableCollection<DownloadPackage> GetDownloadPackages()
		{
			this.VerifyControl("GetDownloadPackages");
			this.Packages = new ObservableCollection<DownloadPackage>();
			try
			{
				if (!File.Exists(this._DataFile))
				{
					FileInfo fileInfo = (from x in new DirectoryInfo("C:\\ProgramData\\Laplink\\PCmover").GetFiles()
					where x.Extension == ".xml" && x.Name.StartsWith("DlMgr")
					select x into f
					orderby f.LastWriteTime descending
					select f).First<FileInfo>();
					this._DataFile = fileInfo.FullName;
					if (!IdentityHelper.IsAdministrator && !this._DataFile.ToLower().Contains("limited"))
					{
						string text = fileInfo.FullName.Substring(0, fileInfo.FullName.Length - 4) + "_Limited.xml";
						new XDocument(XDocument.Load(this._DataFile)).Save(text);
						this._DataFile = text;
					}
				}
				XElement xelement = XElement.Load(this._DataFile);
				foreach (XElement xelement2 in xelement.Elements())
				{
					if (!(xelement2.Name == "Settings") && xelement2.Name == "Package")
					{
						DownloadPackage downloadPackage = new DownloadPackage();
						downloadPackage.Id = Guid.NewGuid().ToString();
						XAttribute xattribute = xelement2.Attribute("Name");
						downloadPackage.Name = ((xattribute != null) ? xattribute.Value : null);
						XElement xelement3 = xelement2.Element("Download");
						string url;
						if (xelement3 == null)
						{
							url = null;
						}
						else
						{
							XAttribute xattribute2 = xelement3.Attribute("Url");
							url = ((xattribute2 != null) ? xattribute2.Value : null);
						}
						downloadPackage.URL = url;
						XElement xelement4 = xelement2.Element("Launch");
						string launchParameters;
						if (xelement4 == null)
						{
							launchParameters = null;
						}
						else
						{
							XAttribute xattribute3 = xelement4.Attribute("Param");
							launchParameters = ((xattribute3 != null) ? xattribute3.Value : null);
						}
						downloadPackage.LaunchParameters = launchParameters;
						XElement xelement5 = xelement2.Element("Launch");
						string file;
						if (xelement5 == null)
						{
							file = null;
						}
						else
						{
							XAttribute xattribute4 = xelement5.Attribute("File");
							file = ((xattribute4 != null) ? xattribute4.Value : null);
						}
						downloadPackage.File = file;
						downloadPackage.State = PackageState.Ready;
						XElement xelement6 = xelement2.Element("Delete");
						string a;
						if (xelement6 == null)
						{
							a = null;
						}
						else
						{
							XAttribute xattribute5 = xelement6.Attribute("RebootBefore");
							a = ((xattribute5 != null) ? xattribute5.Value.ToLower() : null);
						}
						downloadPackage.RebootAfterInstall = (a == "yes");
						XElement xelement7 = xelement2.Element("Launch");
						bool flag;
						if (xelement7 == null)
						{
							flag = (null != null);
						}
						else
						{
							XAttribute xattribute6 = xelement7.Attribute("Timeout");
							flag = (((xattribute6 != null) ? xattribute6.Value : null) != null);
						}
						downloadPackage.Timeout = ((!flag) ? 600000 : (Convert.ToInt32(xelement2.Element("Launch").Attribute("Timeout").Value) * 1000));
						XElement xelement8 = xelement2.Element("Download");
						string value;
						if (xelement8 == null)
						{
							value = null;
						}
						else
						{
							XAttribute xattribute7 = xelement8.Attribute("Retries");
							value = ((xattribute7 != null) ? xattribute7.Value : null);
						}
						downloadPackage.DownloadRetries = Convert.ToInt32(value);
						XElement xelement9 = xelement2.Element("Launch");
						string value2;
						if (xelement9 == null)
						{
							value2 = null;
						}
						else
						{
							XAttribute xattribute8 = xelement9.Attribute("Retries");
							value2 = ((xattribute8 != null) ? xattribute8.Value : null);
						}
						downloadPackage.InstallRetries = Convert.ToInt32(value2);
						DownloadPackage downloadPackage2 = downloadPackage;
						if (this._rebootAfterAllInstalls)
						{
							downloadPackage2.RebootAfterInstall = true;
						}
						XAttribute xattribute9 = xelement2.Attribute("Status");
						if (((xattribute9 != null) ? xattribute9.Value : null) == "Complete")
						{
							downloadPackage2.State = PackageState.Complete;
							this.Packages.Add(downloadPackage2);
						}
						else
						{
							XAttribute xattribute10 = xelement2.Attribute("Status");
							if (((xattribute10 != null) ? xattribute10.Value : null) == "Fail")
							{
								downloadPackage2.State = PackageState.Fail;
								this.Packages.Add(downloadPackage2);
							}
							else
							{
								if (xelement2.Element("Download") == null)
								{
									downloadPackage2.State = PackageState.WaitingToInstall;
								}
								else
								{
									XElement xelement10 = xelement2.Element("Launch");
									string a2;
									if (xelement10 == null)
									{
										a2 = null;
									}
									else
									{
										XAttribute xattribute11 = xelement10.Attribute("Status");
										a2 = ((xattribute11 != null) ? xattribute11.Value : null);
									}
									if (a2 == "Error" && File.Exists(downloadPackage2.File))
									{
										downloadPackage2.State = PackageState.WaitingToInstall;
									}
									else
									{
										XElement xelement11 = xelement2.Element("Download");
										string a3;
										if (xelement11 == null)
										{
											a3 = null;
										}
										else
										{
											XAttribute xattribute12 = xelement11.Attribute("Status");
											a3 = ((xattribute12 != null) ? xattribute12.Value : null);
										}
										if (a3 == "Success" && File.Exists(downloadPackage2.File))
										{
											downloadPackage2.State = PackageState.WaitingToInstall;
										}
									}
								}
								if (!File.Exists(downloadPackage2.File) && downloadPackage2.URL != null)
								{
									downloadPackage2.File = Path.GetFileName(downloadPackage2.URL);
									if (!downloadPackage2.File.ToLower().EndsWith(".exe") && !downloadPackage2.File.ToLower().EndsWith(".msi"))
									{
										string fileName = Path.GetFileName(Path.GetTempFileName());
										downloadPackage2.File = this.GetTempFolder() + fileName + ".exe";
									}
									else
									{
										downloadPackage2.File = this.GetTempFolder() + downloadPackage2.File;
									}
									XElement xelement12 = xelement2.Element("Launch");
									if (xelement12 != null)
									{
										xelement12.SetAttributeValue("File", downloadPackage2.File);
									}
								}
								this.Packages.Add(downloadPackage2);
							}
						}
					}
				}
				xelement.Save(this._DataFile);
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "GetDownloadPackages");
			}
			return this.Packages;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000294C File Offset: 0x00000B4C
		public void CancelPackage(string Id)
		{
			this.VerifyControl("CancelPackage");
			try
			{
				Func<DownloadPackage, bool> <>9__1;
				Task.Run(delegate()
				{
					IEnumerable<DownloadPackage> packages = this.Packages;
					Func<DownloadPackage, bool> predicate;
					if ((predicate = <>9__1) == null)
					{
						predicate = (<>9__1 = ((DownloadPackage x) => x.Id == Id));
					}
					DownloadPackage downloadPackage = packages.FirstOrDefault(predicate);
					this.SetStatus(downloadPackage, PackageState.Cancelled);
					this.Ts.TraceInformation("User cancelled package: " + downloadPackage.Name);
				});
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "CancelPackage");
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000029B0 File Offset: 0x00000BB0
		public void ProcessAll()
		{
			this.VerifyControl("ProcessAll");
			try
			{
				this.State = DownloadState.Active;
				if (this.Packages == null)
				{
					this.GetDownloadPackages();
				}
				if (!File.Exists(this._DataFile))
				{
					throw new FileNotFoundException(this._DataFile + " not found.");
				}
				this.DownloadQueue = new Queue<DownloadPackage>();
				this.InstallQueue = new Queue<DownloadPackage>();
				this.QueueTimer = new System.Timers.Timer(1000.0);
				this.QueueTimer.Elapsed += new ElapsedEventHandler(this.QueueTimer_Tick);
				this.QueueTimer.Start();
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "ProcessAll");
				try
				{
					this.State = DownloadState.Complete;
					this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
					{
						cb.DownloadCompleted(this._IsRestartRequired);
					});
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002AA4 File Offset: 0x00000CA4
		public void SetDataFile(string DataFile)
		{
			this.VerifyControl("SetDataFile");
			this._DataFile = DataFile;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public void UpdateRunKey(string ValueName, string Value, bool Remove)
		{
			this.VerifyControl("UpdateRunKey");
			try
			{
				if (IdentityHelper.IsAdministrator)
				{
					using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
					{
						using (RegistryKey registryKey2 = registryKey.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run"))
						{
							if (Remove)
							{
								registryKey2.DeleteValue(ValueName, false);
							}
							else
							{
								registryKey2.SetValue(ValueName, Value, RegistryValueKind.String);
							}
						}
						goto IL_9C;
					}
				}
				using (RegistryKey currentUser = Registry.CurrentUser)
				{
					using (RegistryKey registryKey3 = currentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run"))
					{
						if (Remove)
						{
							registryKey3.DeleteValue(ValueName, false);
						}
						else
						{
							registryKey3.SetValue(ValueName, Value, RegistryValueKind.String);
						}
					}
				}
				IL_9C:;
			}
			catch (Exception ex)
			{
				this.Ts.TraceException(ex, "UpdateRunKey");
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00002BBC File Offset: 0x00000DBC
		private void StartDownload(DownloadPackage package)
		{
			DownloadManager.<>c__DisplayClass62_0 CS$<>8__locals1 = new DownloadManager.<>c__DisplayClass62_0();
			CS$<>8__locals1.package = package;
			CS$<>8__locals1.<>4__this = this;
			if (CS$<>8__locals1.package.State == PackageState.Cancelled)
			{
				return;
			}
			CS$<>8__locals1.package.DownloadProgress = 0.0;
			this.SetStatus(CS$<>8__locals1.package, PackageState.Downloading);
			if (!string.IsNullOrWhiteSpace(CS$<>8__locals1.package.URL) && !string.IsNullOrWhiteSpace(CS$<>8__locals1.package.File))
			{
				try
				{
					using (WebClient webClient = new WebClient())
					{
						webClient.Headers.Add("Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
						webClient.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.154 Safari/537.36");
						webClient.DownloadProgressChanged += delegate(object o, DownloadProgressChangedEventArgs args)
						{
							if (CS$<>8__locals1.package.State == PackageState.Cancelled)
							{
								try
								{
									webClient.CancelAsync();
								}
								catch
								{
								}
								return;
							}
							CS$<>8__locals1.package.DownloadProgress = (double)args.ProgressPercentage;
							ControlCallbackStateData<IDownloadControlCallback> downloadCcs = CS$<>8__locals1.<>4__this.DownloadCcs;
							Action<IDownloadControlCallback> func;
							if ((func = CS$<>8__locals1.<>9__2) == null)
							{
								func = (CS$<>8__locals1.<>9__2 = delegate(IDownloadControlCallback cb)
								{
									cb.PackageUpdated(CS$<>8__locals1.package);
								});
							}
							downloadCcs.CallControlCallback(func);
						};
						webClient.DownloadFileCompleted += delegate(object o, AsyncCompletedEventArgs args)
						{
							DownloadManager.<>c__DisplayClass62_0.<<StartDownload>b__1>d <<StartDownload>b__1>d;
							<<StartDownload>b__1>d.<>t__builder = AsyncVoidMethodBuilder.Create();
							<<StartDownload>b__1>d.<>4__this = CS$<>8__locals1;
							<<StartDownload>b__1>d.args = args;
							<<StartDownload>b__1>d.<>1__state = -1;
							<<StartDownload>b__1>d.<>t__builder.Start<DownloadManager.<>c__DisplayClass62_0.<<StartDownload>b__1>d>(ref <<StartDownload>b__1>d);
						};
						webClient.DownloadFileAsync(new Uri(CS$<>8__locals1.package.URL), CS$<>8__locals1.package.File);
					}
				}
				catch (Exception ex)
				{
					this.Ts.TraceCaller("(" + CS$<>8__locals1.package.Name + ") " + ex.Message, "StartDownload");
					DownloadPackage package2 = CS$<>8__locals1.package;
					int downloadRetries = package2.DownloadRetries;
					package2.DownloadRetries = downloadRetries + 1;
					if (CS$<>8__locals1.package.DownloadRetries > 2)
					{
						this.SetStatus(CS$<>8__locals1.package, PackageState.Fail);
						CS$<>8__locals1.package.ErrorCode = DownloadManagerError.Download;
					}
					else
					{
						this.SetStatus(CS$<>8__locals1.package, PackageState.Error);
						CS$<>8__locals1.package.ErrorCode = DownloadManagerError.WillRetry;
					}
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002DA0 File Offset: 0x00000FA0
		private void InstallPackage(DownloadPackage package)
		{
			if (package.State == PackageState.Cancelled)
			{
				return;
			}
			this.SetStatus(package, PackageState.Installing);
			if (!File.Exists(package.File))
			{
				if (this.InvokerIdentity == null)
				{
					this.Ts.TraceCaller("File not found (unable to use impersonation) - " + package.File, "InstallPackage");
				}
				else
				{
					using (this.InvokerIdentity.Impersonate())
					{
						if (File.Exists(package.File))
						{
							try
							{
								string fileName = Path.GetFileName(Path.GetTempFileName());
								string text = this.GetTempFolder() + fileName + ".exe";
								this.Ts.TraceCaller(string.Concat(new string[]
								{
									"Found file using impersonation (",
									this.InvokerIdentity.Name,
									")",
									Environment.NewLine,
									"Copying ",
									package.File,
									" to ",
									text
								}), "InstallPackage");
								File.Copy(package.File, text);
								package.File = text;
								goto IL_153;
							}
							catch (Exception ex)
							{
								this.Ts.TraceException(ex, "InstallPackage");
								this.SetStatus(package, PackageState.Fail);
								return;
							}
						}
						this.Ts.TraceCaller("Redistributable package does not exist: " + package.File, "InstallPackage");
						this.SetStatus(package, PackageState.Fail);
						return;
					}
				}
			}
			IL_153:
			ProcessStartInfo startInfo;
			if (IdentityHelper.IsAdministrator)
			{
				startInfo = new ProcessStartInfo(package.File)
				{
					Arguments = package.LaunchParameters,
					UseShellExecute = false,
					CreateNoWindow = true,
					ErrorDialog = false,
					WindowStyle = ProcessWindowStyle.Hidden
				};
			}
			else
			{
				startInfo = new ProcessStartInfo(package.File)
				{
					Arguments = package.LaunchParameters,
					UseShellExecute = true,
					Verb = "runas",
					CreateNoWindow = false,
					ErrorDialog = true,
					WindowStyle = ProcessWindowStyle.Normal
				};
			}
			try
			{
				this.Ts.TraceInformation("Installing " + package.File);
				package.ExitCode = this.RunProcess(startInfo, package.Timeout);
				if (package.ExitCode == 0)
				{
					this.Ts.TraceInformation("Install complete.");
					try
					{
						if (!string.IsNullOrEmpty(package.URL) || package.File.StartsWith(this.GetTempFolder()))
						{
							File.Delete(package.File);
						}
					}
					catch
					{
					}
					if (!this._IsRestartRequired)
					{
						this._IsRestartRequired = (package.RebootAfterInstall || this.IsRebootRequired());
					}
					this.SetStatus(package, PackageState.Complete);
				}
				else
				{
					this.Ts.TraceInformation(string.Format("An error occurred during install.  Exit code: {0}", package.ExitCode));
					int installRetries = package.InstallRetries;
					package.InstallRetries = installRetries + 1;
					if (package.InstallRetries > 2)
					{
						this.SetStatus(package, PackageState.Fail);
						package.ErrorCode = DownloadManagerError.Install;
					}
					else
					{
						this.SetStatus(package, PackageState.Error);
						package.ErrorCode = DownloadManagerError.WillRetry;
						this._IsRestartRequired = true;
					}
				}
			}
			catch (Exception ex2)
			{
				this.Ts.TraceException(ex2, "InstallPackage");
				int installRetries = package.InstallRetries;
				package.InstallRetries = installRetries + 1;
				if (package.InstallRetries > 2)
				{
					this.SetStatus(package, PackageState.Fail);
					package.ErrorCode = DownloadManagerError.Install;
				}
				else
				{
					this.SetStatus(package, PackageState.Error);
					package.ErrorCode = DownloadManagerError.WillRetry;
				}
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003138 File Offset: 0x00001338
		private void QueueTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (this.Packages.Count == 0)
				{
					this.Ts.TraceInformation("No packages loaded");
					this.QueueTimer.Stop();
					this.QueueTimer.Elapsed -= new ElapsedEventHandler(this.QueueTimer_Tick);
					try
					{
						this.State = DownloadState.Complete;
						this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
						{
							cb.DownloadCompleted(this._IsRestartRequired);
						});
					}
					catch (CommunicationObjectAbortedException ex)
					{
						this.Ts.TraceException(ex, "QueueTimer_Tick");
					}
				}
				else
				{
					using (IEnumerator<DownloadPackage> enumerator = this.Packages.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							DownloadPackage p = enumerator.Current;
							switch (p.State)
							{
							case PackageState.Ready:
								if (!this.DownloadQueue.Contains(p))
								{
									this.DownloadQueue.Enqueue(p);
								}
								break;
							case PackageState.Downloading:
							case PackageState.Cancelled:
								continue;
							case PackageState.DownloadComplete:
								p.State = PackageState.WaitingToInstall;
								this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
								{
									cb.PackageUpdated(p);
								});
								continue;
							case PackageState.Installing:
								this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
								{
									cb.PackageUpdated(p);
								});
								continue;
							case PackageState.Complete:
								this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
								{
									cb.PackageUpdated(p);
								});
								continue;
							case PackageState.Error:
								this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
								{
									cb.PackageUpdated(p);
								});
								continue;
							case PackageState.WaitingToInstall:
								if (!this.InstallQueue.Contains(p) && !this._IsRestartRequired)
								{
									this.InstallQueue.Enqueue(p);
								}
								break;
							}
							if (this.DownloadQueue.Count > 0)
							{
								if ((from x in this.Packages
								where x.State == PackageState.Downloading
								select x).Count<DownloadPackage>() < 3)
								{
									Task.Run(delegate()
									{
										this.StartDownload(this.DownloadQueue.Dequeue());
									});
									return;
								}
							}
							if (this.InstallQueue.Count > 0)
							{
								if ((from x in this.Packages
								where x.State == PackageState.Installing
								select x).Count<DownloadPackage>() == 0 && !this._IsRestartRequired)
								{
									Task.Run(delegate()
									{
										this.InstallPackage(this.InstallQueue.Dequeue());
									});
									return;
								}
							}
						}
					}
					ObservableCollection<DownloadPackage> packages = this.Packages;
					int? num;
					if (packages == null)
					{
						num = null;
					}
					else
					{
						num = new int?((from x in packages
						where x.State == PackageState.Complete
						select x).Count<DownloadPackage>());
					}
					int? num2 = num;
					ObservableCollection<DownloadPackage> packages2 = this.Packages;
					int? num3;
					if (packages2 == null)
					{
						num3 = null;
					}
					else
					{
						num3 = new int?((from x in packages2
						where x.State == PackageState.Error
						select x).Count<DownloadPackage>());
					}
					int? num4 = num2 + num3;
					ObservableCollection<DownloadPackage> packages3 = this.Packages;
					int? num5;
					if (packages3 == null)
					{
						num5 = null;
					}
					else
					{
						num5 = new int?((from x in packages3
						where x.State == PackageState.Cancelled
						select x).Count<DownloadPackage>());
					}
					int? num6 = num4 + num5;
					ObservableCollection<DownloadPackage> packages4 = this.Packages;
					int? num7;
					if (packages4 == null)
					{
						num7 = null;
					}
					else
					{
						num7 = new int?((from x in packages4
						where x.State == PackageState.Fail
						select x).Count<DownloadPackage>());
					}
					int? num8 = num6 + num7;
					int count = this.Packages.Count;
					if (num8.GetValueOrDefault() == count & num8 != null)
					{
						this.QueueTimer.Stop();
						this.QueueTimer.Elapsed -= new ElapsedEventHandler(this.QueueTimer_Tick);
						this.State = DownloadState.Complete;
						if ((from x in this.Packages
						where x.State == PackageState.Fail
						select x).Count<DownloadPackage>() > 0)
						{
							IEnumerable<string> failedPackages = from x in this.Packages
							where x.State == PackageState.Fail
							select x into p
							select p.Name;
							this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
							{
								cb.DisplayDownloadError(failedPackages);
							});
						}
						try
						{
							this.Ts.TraceInformation("Finished processing packages.");
							this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
							{
								cb.DownloadCompleted(this._IsRestartRequired);
							});
						}
						catch (CommunicationObjectAbortedException ex2)
						{
							this.Ts.TraceException(ex2, "QueueTimer_Tick");
						}
					}
					else if (this._IsRestartRequired)
					{
						if ((from x in this.Packages
						where x.State == PackageState.Downloading
						select x).Count<DownloadPackage>() == 0)
						{
							if ((from x in this.Packages
							where x.State == PackageState.Installing
							select x).Count<DownloadPackage>() == 0)
							{
								if ((from x in this.Packages
								where x.State == PackageState.WaitingToInstall
								select x).Count<DownloadPackage>() > 0)
								{
									this.QueueTimer.Stop();
									this.QueueTimer.Elapsed -= new ElapsedEventHandler(this.QueueTimer_Tick);
									this.State = DownloadState.WaitingForReboot;
									this.DownloadCcs.CallControlCallback(delegate(IDownloadControlCallback cb)
									{
										cb.TimeToReboot();
									});
								}
							}
						}
					}
				}
			}
			catch (Exception ex3)
			{
				this.Ts.TraceInformation("Queue - " + ex3.Message);
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003824 File Offset: 0x00001A24
		private void SetStatus(DownloadPackage Package, PackageState State)
		{
			if (Package == null)
			{
				return;
			}
			if (Package.State == State)
			{
				return;
			}
			PackageState previousState = Package.State;
			Package.State = State;
			this.Ts.TraceInformation(string.Format("Package state for {0} changed from {1} to {2}", Package.Name, previousState, State));
			Func<XElement, bool> <>9__2;
			Action<IDownloadControlCallback> <>9__1;
			Task.Run(delegate()
			{
				try
				{
					XElement xelement = XElement.Load(this._DataFile);
					IEnumerable<XElement> source = xelement.Descendants("Package");
					Func<XElement, bool> predicate;
					if ((predicate = <>9__2) == null)
					{
						predicate = (<>9__2 = ((XElement nodes) => nodes.Attribute("Name").Value == Package.Name));
					}
					XElement xelement2 = source.Where(predicate).FirstOrDefault<XElement>();
					if (xelement2 != null)
					{
						xelement2.SetAttributeValue("Status", State.ToString());
					}
					switch (State)
					{
					case PackageState.DownloadComplete:
						if (xelement2 != null)
						{
							XElement xelement3 = xelement2.Element("Download");
							if (xelement3 != null)
							{
								xelement3.SetAttributeValue("Status", "Success");
							}
						}
						break;
					case PackageState.Complete:
						if (xelement2 != null)
						{
							XElement xelement4 = xelement2.Element("Launch");
							if (xelement4 != null)
							{
								xelement4.SetAttributeValue("Status", "Success");
							}
						}
						break;
					case PackageState.Error:
						if (previousState == PackageState.Downloading)
						{
							if (xelement2 != null)
							{
								XElement xelement5 = xelement2.Element("Download");
								if (xelement5 != null)
								{
									xelement5.SetAttributeValue("Retries", Package.DownloadRetries);
								}
							}
							if (xelement2 != null)
							{
								XElement xelement6 = xelement2.Element("Download");
								if (xelement6 != null)
								{
									xelement6.SetAttributeValue("Status", "Error");
								}
							}
							if (xelement2 != null)
							{
								XElement xelement7 = xelement2.Element("Launch");
								if (xelement7 != null)
								{
									xelement7.SetAttributeValue("File", null);
								}
							}
						}
						else if (previousState == PackageState.Installing)
						{
							if (xelement2 != null)
							{
								XElement xelement8 = xelement2.Element("Launch");
								if (xelement8 != null)
								{
									xelement8.SetAttributeValue("Retries", Package.InstallRetries);
								}
							}
							if (xelement2 != null)
							{
								XElement xelement9 = xelement2.Element("Launch");
								if (xelement9 != null)
								{
									xelement9.SetAttributeValue("Status", "Error");
								}
							}
							if (xelement2 != null)
							{
								XElement xelement10 = xelement2.Element("Launch");
								if (xelement10 != null)
								{
									xelement10.SetAttributeValue("ExitCode", Package.ExitCode);
								}
							}
						}
						break;
					}
					xelement.Save(this._DataFile);
				}
				catch (Exception ex)
				{
					this.Ts.TraceException(ex, "SetStatus");
				}
				ControlCallbackStateData<IDownloadControlCallback> downloadCcs = this.DownloadCcs;
				Action<IDownloadControlCallback> func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = delegate(IDownloadControlCallback cb)
					{
						cb.PackageUpdated(Package);
					});
				}
				downloadCcs.CallControlCallback(func);
			});
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000038D3 File Offset: 0x00001AD3
		private bool IsRebootRequired()
		{
			return (CheckRebootHelper.GetRebootPendingReasons(this.Ts) & RebootPendingReasons.RebootAfterRedistInstall) > RebootPendingReasons.None;
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000038E8 File Offset: 0x00001AE8
		private int RunProcess(ProcessStartInfo startInfo, int timeout)
		{
			Process process = new Process
			{
				StartInfo = startInfo,
				EnableRaisingEvents = true
			};
			process.Start();
			if (!process.WaitForExit(timeout))
			{
				process.Kill();
				throw new TimeoutException("Process timed out - " + startInfo.FileName);
			}
			return process.ExitCode;
		}

		// Token: 0x0600002B RID: 43 RVA: 0x0000393C File Offset: 0x00001B3C
		private string GetTempFolder()
		{
			string text = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Laplink\\Temp\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x0000396B File Offset: 0x00001B6B
		private void CallMonitorCallbacks(Action<IDownloadMonitorCallback> func, bool isProgress = false)
		{
			this.MonitorCallbackManager.Call(func, isProgress);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x0000397C File Offset: 0x00001B7C
		public void NotifyStatusInfoChanged()
		{
			DownloadStatusInfo statusInfo = this.StatusInfo;
			this.Ts.TraceCaller(TraceEventType.Verbose, statusInfo.ToString(), "NotifyStatusInfoChanged");
			this.CallMonitorCallbacks(delegate(IDownloadMonitorCallback cb)
			{
				cb.DownloadStatusChanged(statusInfo);
			}, false);
		}

		// Token: 0x04000004 RID: 4
		private bool _IsRestartRequired;

		// Token: 0x04000005 RID: 5
		private ObservableCollection<DownloadPackage> Packages;

		// Token: 0x04000006 RID: 6
		private Queue<DownloadPackage> DownloadQueue;

		// Token: 0x04000007 RID: 7
		private Queue<DownloadPackage> InstallQueue;

		// Token: 0x04000008 RID: 8
		private System.Timers.Timer QueueTimer;

		// Token: 0x04000009 RID: 9
		private string _DataFile;

		// Token: 0x0400000A RID: 10
		private bool _rebootAfterAllInstalls;

		// Token: 0x0400000B RID: 11
		private DownloadState _state;

		// Token: 0x0400000D RID: 13
		private MonitorCallbackManager<IDownloadMonitorCallback> _monitorCallbackManager;

		// Token: 0x04000010 RID: 16
		private LlTraceSource _ts;
	}
}
