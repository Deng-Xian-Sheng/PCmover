using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Discovery;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ClientEngineModule.Infrastructure.Properties;
using Laplink.Download.Contracts;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Pcmover.ScriptApi;
using Laplink.Pcmover.ScriptApi.Pcmover;
using Laplink.Service.Contracts;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Events;

namespace ClientEngineModule.Scr
{
	// Token: 0x02000006 RID: 6
	public class PCmoverEngineScr : PcmoverClientEngine<PcmoverControlScriptClient>, IPCmoverEngine
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000033 RID: 51 RVA: 0x0000260F File Offset: 0x0000080F
		// (set) Token: 0x06000034 RID: 52 RVA: 0x0000262A File Offset: 0x0000082A
		public LicenseInfo License
		{
			get
			{
				if (this._license == null)
				{
					this._license = new LicenseInfo();
				}
				return this._license;
			}
			set
			{
				this._license = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002633 File Offset: 0x00000833
		public IEventAggregator EventAggregator { get; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000036 RID: 54 RVA: 0x0000263B File Offset: 0x0000083B
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00002643 File Offset: 0x00000843
		public bool GodMode { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000038 RID: 56 RVA: 0x0000264C File Offset: 0x0000084C
		// (set) Token: 0x06000039 RID: 57 RVA: 0x00002654 File Offset: 0x00000854
		public bool IsLive { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600003A RID: 58 RVA: 0x0000265D File Offset: 0x0000085D
		// (set) Token: 0x0600003B RID: 59 RVA: 0x00002665 File Offset: 0x00000865
		public bool IsScript { get; set; } = true;

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600003C RID: 60 RVA: 0x0000266E File Offset: 0x0000086E
		public bool IsRemoteUI { get; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002676 File Offset: 0x00000876
		// (set) Token: 0x0600003E RID: 62 RVA: 0x0000267E File Offset: 0x0000087E
		public bool UseSSL { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00002687 File Offset: 0x00000887
		// (set) Token: 0x06000040 RID: 64 RVA: 0x0000268F File Offset: 0x0000088F
		public string CertificateName { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00002698 File Offset: 0x00000898
		public IEnumerable<ApplicationInfo> ApplicationList
		{
			get
			{
				return this._applicationList;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000026A0 File Offset: 0x000008A0
		// (set) Token: 0x06000043 RID: 67 RVA: 0x000026BB File Offset: 0x000008BB
		public Settings Settings
		{
			get
			{
				if (this._settings == null)
				{
					this._settings = new Settings();
				}
				return this._settings;
			}
			set
			{
				this._settings = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000026C4 File Offset: 0x000008C4
		// (set) Token: 0x06000045 RID: 69 RVA: 0x000026CC File Offset: 0x000008CC
		public List<FileFilter> FileFilters { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000046 RID: 70 RVA: 0x000026D5 File Offset: 0x000008D5
		// (set) Token: 0x06000047 RID: 71 RVA: 0x000026E0 File Offset: 0x000008E0
		public bool ThisMachineIsOld
		{
			get
			{
				return this._thisMachineIsOld;
			}
			set
			{
				if (this._thisMachineIsOld == value)
				{
					base.Ts.TraceInformation(string.Format("Keeping ThisMachineIsOld as {0}", value));
					return;
				}
				base.Ts.TraceInformation(string.Format("Changing ThisMachineIsOld to {0}", value));
				this._thisMachineIsOld = value;
				if (value)
				{
					this.ThisMachineAppInventoryRequirement = AppInventoryAmount.OldComputer;
					return;
				}
				if (this.OtherMachine != null && base.ThisMachine != null && this.OtherMachine.Handle == base.ThisMachine.Handle)
				{
					this.ThisMachineAppInventoryRequirement = AppInventoryAmount.OldComputer;
					return;
				}
				this.ThisMachineAppInventoryRequirement = AppInventoryAmount.NewComputer;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00002776 File Offset: 0x00000976
		// (set) Token: 0x06000049 RID: 73 RVA: 0x0000277E File Offset: 0x0000097E
		public bool IsRebooting { get; private set; }

		// Token: 0x0600004A RID: 74 RVA: 0x00002788 File Offset: 0x00000988
		public Task<bool> ConnectToPcmoverServiceAsync()
		{
			PCmoverEngineScr.<ConnectToPcmoverServiceAsync>d__49 <ConnectToPcmoverServiceAsync>d__;
			<ConnectToPcmoverServiceAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<ConnectToPcmoverServiceAsync>d__.<>4__this = this;
			<ConnectToPcmoverServiceAsync>d__.<>1__state = -1;
			<ConnectToPcmoverServiceAsync>d__.<>t__builder.Start<PCmoverEngineScr.<ConnectToPcmoverServiceAsync>d__49>(ref <ConnectToPcmoverServiceAsync>d__);
			return <ConnectToPcmoverServiceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000027CB File Offset: 0x000009CB
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000027D3 File Offset: 0x000009D3
		public VersionInfo Version { get; private set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000027DC File Offset: 0x000009DC
		// (set) Token: 0x0600004E RID: 78 RVA: 0x000027E4 File Offset: 0x000009E4
		public DateTime UndoTime { get; private set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000027ED File Offset: 0x000009ED
		public RebootPendingReasons RebootPending
		{
			get
			{
				if (this.HasControlInterface)
				{
					return this.ControlInterface.CheckRebootPending();
				}
				return RebootPendingReasons.None;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000050 RID: 80 RVA: 0x00002804 File Offset: 0x00000A04
		// (set) Token: 0x06000051 RID: 81 RVA: 0x0000280C File Offset: 0x00000A0C
		public MachineData OtherMachine { get; internal set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00002815 File Offset: 0x00000A15
		// (set) Token: 0x06000053 RID: 83 RVA: 0x0000281D File Offset: 0x00000A1D
		public ConnectableMachine TargetMachine { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002826 File Offset: 0x00000A26
		// (set) Token: 0x06000055 RID: 85 RVA: 0x0000282E File Offset: 0x00000A2E
		public TimeSpan TotalTransferTime { get; private set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002837 File Offset: 0x00000A37
		// (set) Token: 0x06000057 RID: 87 RVA: 0x0000283F File Offset: 0x00000A3F
		public double TotalTransferSize { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002848 File Offset: 0x00000A48
		public GroupInfo DocumentsGroup
		{
			get
			{
				Dictionary<PCmoverEngineScr.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineScr.GroupType.Documents];
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000059 RID: 89 RVA: 0x0000285C File Offset: 0x00000A5C
		public GroupInfo PicturesGroup
		{
			get
			{
				Dictionary<PCmoverEngineScr.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineScr.GroupType.Pictures];
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002870 File Offset: 0x00000A70
		public GroupInfo MusicGroup
		{
			get
			{
				Dictionary<PCmoverEngineScr.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineScr.GroupType.Music];
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00002884 File Offset: 0x00000A84
		public GroupInfo VideoGroup
		{
			get
			{
				Dictionary<PCmoverEngineScr.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineScr.GroupType.Video];
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002898 File Offset: 0x00000A98
		public GroupInfo OtherGroup
		{
			get
			{
				Dictionary<PCmoverEngineScr.GroupType, GroupInfo> groups = this._groups;
				if (groups == null)
				{
					return null;
				}
				return groups[PCmoverEngineScr.GroupType.Other];
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600005D RID: 93 RVA: 0x000028AC File Offset: 0x00000AAC
		// (set) Token: 0x0600005E RID: 94 RVA: 0x000028B4 File Offset: 0x00000AB4
		public MigrationItemsOption MigrationItemsSelection
		{
			get
			{
				return this.MigrationItems;
			}
			set
			{
				this.ChangeMigrationItems(value);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600005F RID: 95 RVA: 0x000028BE File Offset: 0x00000ABE
		// (set) Token: 0x06000060 RID: 96 RVA: 0x000028C6 File Offset: 0x00000AC6
		public MigrationItemsOption MigrationItems { get; private set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000061 RID: 97 RVA: 0x000028CF File Offset: 0x00000ACF
		// (set) Token: 0x06000062 RID: 98 RVA: 0x000028D7 File Offset: 0x00000AD7
		public UserMappings Users { get; private set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000028E0 File Offset: 0x00000AE0
		// (set) Token: 0x06000064 RID: 100 RVA: 0x000028E8 File Offset: 0x00000AE8
		public IEnumerable<CategoryDefinition> CloudCategories { get; private set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000065 RID: 101 RVA: 0x000028F1 File Offset: 0x00000AF1
		// (set) Token: 0x06000066 RID: 102 RVA: 0x000028F9 File Offset: 0x00000AF9
		public TaskAlertData InteractiveDoneAlert { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00002902 File Offset: 0x00000B02
		// (set) Token: 0x06000068 RID: 104 RVA: 0x0000290A File Offset: 0x00000B0A
		public PolicyData Policy { get; private set; } = new PolicyData();

		// Token: 0x06000069 RID: 105 RVA: 0x00002914 File Offset: 0x00000B14
		public CustomizationData ChangeMigrationItems(MigrationItemsOption migItems)
		{
			CustomizationData customizationData = this.ControlInterface.TaskChangeMigrationItems(this._customizeTaskHandle, migItems);
			if (customizationData != null && customizationData.Result == CustomizationResult.Success)
			{
				this.MigrationItems = migItems;
			}
			return customizationData;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00002947 File Offset: 0x00000B47
		private string Quote(string val)
		{
			return ScriptClientBase.CreateScriptString(val);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00002950 File Offset: 0x00000B50
		public CustomizationData ChangeUserMapping(UserMapping userMapping)
		{
			if (this._customizeTaskHandle == 0)
			{
				return null;
			}
			CustomizationData result = null;
			string val = (userMapping.Old == null) ? string.Empty : userMapping.Old.AccountName;
			string val2 = (userMapping.New == null) ? string.Empty : userMapping.New.AccountName;
			try
			{
				string[] data = this._scriptConnection.InvokeScript(string.Format("TaskChangeUserMapping({0}, {1}, {2});", this._customizeTaskHandle, this.Quote(val), this.Quote(val2))).Split(new string[]
				{
					";"
				}, StringSplitOptions.None);
				CustomizationResult result2;
				Enum.TryParse<CustomizationResult>(this.ParseValue(data, "Result"), out result2);
				result = new CustomizationData
				{
					Affects = CustomizationAffects.Users,
					Result = result2
				};
			}
			catch (UnexpectedScriptException ex)
			{
				base.Ts.TraceException(ex, "ChangeUserMapping");
				result = new CustomizationData
				{
					Result = CustomizationResult.OtherFailure
				};
			}
			return result;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00002A44 File Offset: 0x00000C44
		public Task<SerialNumberInfo> GetSerialNumberInfoAsync(string serialNumber)
		{
			SerialNumberInfo serialNumberInfo = new SerialNumberInfo();
			if (string.IsNullOrEmpty(serialNumber))
			{
				return Task.FromResult<SerialNumberInfo>(serialNumberInfo);
			}
			try
			{
				string[] data = this._scriptConnection.InvokeScript("GetSerialNumberInfo(" + this.Quote(serialNumber) + ");").Split(new string[]
				{
					";"
				}, StringSplitOptions.None);
				SerialNumberInfoResult result;
				Enum.TryParse<SerialNumberInfoResult>(this.ParseValue(data, "Result"), out result);
				serialNumberInfo.Result = result;
				serialNumberInfo.NumLicenses = Convert.ToInt32(this.ParseValue(data, "NumLicenses"));
				serialNumberInfo.NumUsed = Convert.ToInt32(this.ParseValue(data, "NumUsed"));
				serialNumberInfo.MatchedType = Convert.ToInt32(this.ParseValue(data, "MatchedType"));
				serialNumberInfo.Expired = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "Expired")));
			}
			catch (UnexpectedScriptException ex)
			{
				base.Ts.TraceException(ex, "GetSerialNumberInfo");
			}
			return Task.FromResult<SerialNumberInfo>(serialNumberInfo);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00002B48 File Offset: 0x00000D48
		public void RetrieveUsers()
		{
			this.Users = this.TaskGetUserMappings(this._customizeTaskHandle, true);
			if (this.Users != null)
			{
				if (this._srcMachineHandle == 0 || this._dstMachineHandle == 0)
				{
					PcmTaskData taskData = this.GetTaskData(this._customizeTaskHandle);
					if (taskData != null)
					{
						this._srcMachineHandle = taskData.SourceMachineHandle;
						this._dstMachineHandle = taskData.DestMachineHandle;
					}
				}
				if (this.Users.Mappings != null)
				{
					base.Ts.TraceVerbose(string.Format("{0} user mappings:", this.Users.Mappings.Count<UserMapping>()));
					foreach (UserMapping userMapping in this.Users.Mappings)
					{
						if (userMapping.Old != null)
						{
							base.Ts.TraceVerbose(this.NameForLogging(userMapping.Old) + " => " + this.NameForLogging(userMapping.New));
						}
					}
				}
				if (this.Users.UnusedOnNew != null)
				{
					int num = this.Users.UnusedOnNew.Count<UserDetail>();
					if (num > 0)
					{
						base.Ts.TraceVerbose(string.Format("{0} unused on new", num));
						foreach (UserDetail user in this.Users.UnusedOnNew)
						{
							base.Ts.TraceVerbose(this.NameForLogging(user));
						}
					}
				}
			}
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00002CE8 File Offset: 0x00000EE8
		private IEnumerable<UserDetail> GetMachineUsers(int machineHandle)
		{
			IEnumerable<UserDetail> result;
			try
			{
				this._scriptConnection.InvokeScript(string.Format("GetMachineUsers({0});", machineHandle));
				List<UserDetail> list = new List<UserDetail>();
				string[] array = this._scriptConnection.InvokeScript("strMachineUsers;").Split(new string[]
				{
					"\n"
				}, StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						string[] data = array[i].Split(new string[]
						{
							";"
						}, StringSplitOptions.None);
						UserType userType;
						Enum.TryParse<UserType>(this.ParseValue(data, "UserType"), out userType);
						UserDetail item = new UserDetail
						{
							AccountName = this.ParseValue(data, "AccountName"),
							FriendlyName = this.ParseValue(data, "FriendlyName"),
							UserType = userType,
							IsCurrentUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsCurrentUser"))),
							IsAzureAdUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsAzureAdUser"))),
							IsRegularUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsRegularUser")))
						};
						list.Add(item);
					}
				}
				result = list;
			}
			catch (UnexpectedScriptException ex)
			{
				base.Ts.TraceException(ex, "GetMachineUsers");
				result = null;
			}
			return result;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00002E54 File Offset: 0x00001054
		private PcmTaskData GetTaskData(int taskHandle)
		{
			PcmTaskData result;
			try
			{
				this._scriptConnection.InvokeScript(string.Format("GetPcmTaskData({0});", taskHandle));
				string[] data = this._scriptConnection.InvokeScript("strPcmTaskData;").Split(new string[]
				{
					"\n"
				}, StringSplitOptions.None);
				result = new PcmTaskData
				{
					Handle = (int)Convert.ToInt16(this.ParseValue(data, "Handle")),
					SourceMachineHandle = (int)Convert.ToInt16(this.ParseValue(data, "SourceMachineHandle")),
					DestMachineHandle = (int)Convert.ToInt16(this.ParseValue(data, "DestMachineHandle")),
					IsReady = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsReady")))
				};
			}
			catch (UnexpectedScriptException ex)
			{
				base.Ts.TraceException(ex, "GetTaskData");
				result = null;
			}
			return result;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00002F34 File Offset: 0x00001134
		public UserMappings TaskGetUserMappings(int taskHandle, bool regularUsersOnly)
		{
			List<UserMapping> list = new List<UserMapping>();
			UserMappings result = new UserMappings(list);
			try
			{
				this._scriptConnection.InvokeScript(string.Format("TaskGetUserMappings({0}, {1});", taskHandle, regularUsersOnly));
				string[] array = this._scriptConnection.InvokeScript("strMappings;").Split(new string[]
				{
					"\n"
				}, StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == "Mapping")
					{
						UserDetail old = null;
						UserDetail @new = null;
						i++;
						if (array[i].StartsWith("Old="))
						{
							string[] data = array[i].Substring(4).Split(new string[]
							{
								";"
							}, StringSplitOptions.None);
							UserType userType;
							Enum.TryParse<UserType>(this.ParseValue(data, "UserType"), out userType);
							old = new UserDetail
							{
								AccountName = this.ParseValue(data, "AccountName"),
								FriendlyName = this.ParseValue(data, "FriendlyName"),
								UserType = userType,
								IsCurrentUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsCurrentUser"))),
								IsAzureAdUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsAzureAdUser"))),
								IsRegularUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsRegularUser")))
							};
						}
						i++;
						if (array[i].StartsWith("New="))
						{
							string text = array[i].Substring(4);
							if (text == "null")
							{
								goto IL_253;
							}
							string[] data2 = text.Split(new string[]
							{
								";"
							}, StringSplitOptions.None);
							UserType userType2;
							Enum.TryParse<UserType>(this.ParseValue(data2, "UserType"), out userType2);
							@new = new UserDetail
							{
								AccountName = this.ParseValue(data2, "AccountName"),
								FriendlyName = this.ParseValue(data2, "FriendlyName"),
								UserType = userType2,
								IsCurrentUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data2, "IsCurrentUser"))),
								IsAzureAdUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data2, "IsAzureAdUser"))),
								IsRegularUser = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data2, "IsRegularUser")))
							};
						}
						UserMapping item = new UserMapping
						{
							Old = old,
							New = @new
						};
						list.Add(item);
					}
					IL_253:;
				}
			}
			catch (UnexpectedScriptException ex)
			{
				base.Ts.TraceException(ex, "TaskGetUserMappings");
			}
			return result;
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000031D8 File Offset: 0x000013D8
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000031F3 File Offset: 0x000013F3
		public TransferProgressInfo TransferInfo
		{
			get
			{
				if (this._TransferInfo == null)
				{
					this._TransferInfo = new TransferProgressInfo();
				}
				return this._TransferInfo;
			}
			set
			{
				this._TransferInfo = value;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000073 RID: 115 RVA: 0x000031FC File Offset: 0x000013FC
		// (set) Token: 0x06000074 RID: 116 RVA: 0x00003204 File Offset: 0x00001404
		public AppInventoryAmount ThisMachineAppInventoryRequirement
		{
			get
			{
				return this._thisAppInvAmountRequirement;
			}
			set
			{
				if (this._thisAppInvAmountRequirement != value)
				{
					base.Ts.TraceInformation(string.Format("Changing ThisMachineAppInventoryRequirement from {0} to {1}", this._thisAppInvAmountRequirement, value));
					this._thisAppInvAmountRequirement = value;
					this.RunThisMachineAppInventory();
					return;
				}
				base.Ts.TraceInformation(string.Format("Keeping ThisMachineAppInventoryRequirement as {0}", value));
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000326C File Offset: 0x0000146C
		public bool AddSelf()
		{
			this._transferType = PcmoverTransferState.TransferTypeEnum.Profile;
			if (this._selfTransferMethodHandle == 0)
			{
				this._selfTransferMethodHandle = Convert.ToInt32(this._scriptConnection.InvokeScript("CreateTransferMethod('Image');"));
				this.OtherMachine = base.ThisMachine;
				this._otherMachineTransferMethodHandle = this._selfTransferMethodHandle;
				this._otherMachineReady = true;
				this.ThisMachineAppInventoryRequirement = AppInventoryAmount.Minimum;
			}
			Task.Run(() => this.SetupFillTask());
			return true;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000032DC File Offset: 0x000014DC
		public ActivityClient StartBuildChangeLists()
		{
			try
			{
				switch (this._transferType)
				{
				case PcmoverTransferState.TransferTypeEnum.PcToPc:
					this._scriptConnection.InvokeScript(string.Format("StartBuildChangeLists({0}, {1}, {2});", this.TargetMachine.TransferMethodHandle, this.OtherMachine.Handle, base.ThisMachine.Handle));
					break;
				case PcmoverTransferState.TransferTypeEnum.Profile:
					this._scriptConnection.InvokeScript("fillTaskHandle=0;");
					this._scriptConnection.InvokeScript(string.Format("StartBuildChangeLists({0}, {1}, {2});", this._selfTransferMethodHandle, this.OtherMachine.Handle, base.ThisMachine.Handle));
					break;
				case PcmoverTransferState.TransferTypeEnum.File:
					this._scriptConnection.InvokeScript(string.Format("StartBuildChangeLists(_TransferMethodHandle, {0}, otherMachineHandle);", base.ThisMachine.Handle));
					break;
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "StartBuildChangeLists");
			}
			return null;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00003400 File Offset: 0x00001600
		private bool HasThisMachineAppInvMetRequirement
		{
			get
			{
				return this.AppInventoryAmountAtLeast(this.ThisMachineAppInventoryRequirement, this._thisAppInvStatus.Completed);
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00003419 File Offset: 0x00001619
		internal bool AppInventoryAmountAtLeast(AppInventoryAmount target, AppInventoryAmount candidate)
		{
			return target <= candidate;
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00003424 File Offset: 0x00001624
		private void RunThisMachineAppInventory()
		{
			base.Ts.TraceCaller(this.ThisMachineAppInventoryRequirement.ToString(), "RunThisMachineAppInventory");
			object thisAppInvLock = this._thisAppInvLock;
			lock (thisAppInvLock)
			{
				string value = this._scriptConnection.InvokeScript("StartAppInventory(" + this.Quote(this._thisAppInvAmountRequirement.ToString()) + ");");
				new ActivityClient(this).Attach(ActivityType.AppInventory, Convert.ToInt32(value));
			}
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000034C8 File Offset: 0x000016C8
		internal Task SetupFillTask()
		{
			PCmoverEngineScr.<SetupFillTask>d__135 <SetupFillTask>d__;
			<SetupFillTask>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<SetupFillTask>d__.<>4__this = this;
			<SetupFillTask>d__.<>1__state = -1;
			<SetupFillTask>d__.<>t__builder.Start<PCmoverEngineScr.<SetupFillTask>d__135>(ref <SetupFillTask>d__);
			return <SetupFillTask>d__.<>t__builder.Task;
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0000350C File Offset: 0x0000170C
		private bool CreateFolderList()
		{
			bool result;
			try
			{
				this._groups = new Dictionary<PCmoverEngineScr.GroupType, GroupInfo>
				{
					{
						PCmoverEngineScr.GroupType.Documents,
						new GroupInfo("Documents", this, false)
					},
					{
						PCmoverEngineScr.GroupType.Pictures,
						new GroupInfo("Pictures", this, false)
					},
					{
						PCmoverEngineScr.GroupType.Music,
						new GroupInfo("Music", this, false)
					},
					{
						PCmoverEngineScr.GroupType.Video,
						new GroupInfo("Video", this, false)
					},
					{
						PCmoverEngineScr.GroupType.Other,
						new GroupInfo("Other", this, false)
					},
					{
						PCmoverEngineScr.GroupType.None,
						new GroupInfo("None", this, false)
					}
				};
				result = true;
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "CreateFolderList");
				result = false;
			}
			return result;
		}

		// Token: 0x0600007C RID: 124 RVA: 0x000035C4 File Offset: 0x000017C4
		public Task<int> CreateFillTask(int srcMachine, int dstMachine)
		{
			PCmoverEngineScr.<CreateFillTask>d__137 <CreateFillTask>d__;
			<CreateFillTask>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<CreateFillTask>d__.<>4__this = this;
			<CreateFillTask>d__.srcMachine = srcMachine;
			<CreateFillTask>d__.dstMachine = dstMachine;
			<CreateFillTask>d__.<>1__state = -1;
			<CreateFillTask>d__.<>t__builder.Start<PCmoverEngineScr.<CreateFillTask>d__137>(ref <CreateFillTask>d__);
			return <CreateFillTask>d__.<>t__builder.Task;
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00003617 File Offset: 0x00001817
		public string WindowsOldFolder
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600007E RID: 126 RVA: 0x0000361E File Offset: 0x0000181E
		// (set) Token: 0x0600007F RID: 127 RVA: 0x00003626 File Offset: 0x00001826
		public IEnumerable<DriveSpaceData> ThisMachineDriveSpace { get; private set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000080 RID: 128 RVA: 0x0000362F File Offset: 0x0000182F
		public SecurityProductsData SecurityProducts
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00003636 File Offset: 0x00001836
		public ConnectionPolicyMethods ConnectionMethods
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000082 RID: 130 RVA: 0x0000363D File Offset: 0x0000183D
		public IEnumerable<NetworkInfo> NetworkInfos
		{
			get
			{
				if (this._networkInfos == null && this.HasControlInterface)
				{
					this._networkInfos = this.ControlInterface.GetNetworkInfos();
				}
				return this._networkInfos;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00003666 File Offset: 0x00001866
		public bool IsConnected
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0000366D File Offset: 0x0000186D
		// (set) Token: 0x06000085 RID: 133 RVA: 0x00003674 File Offset: 0x00001874
		public string CloudToken
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000086 RID: 134 RVA: 0x0000367B File Offset: 0x0000187B
		// (set) Token: 0x06000087 RID: 135 RVA: 0x00003683 File Offset: 0x00001883
		public bool IsThisMachineAppInventoryComplete { get; private set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000088 RID: 136 RVA: 0x0000368C File Offset: 0x0000188C
		public string DefaultCertificateName
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003693 File Offset: 0x00001893
		public NetworkStatsData NetworkStats
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600008A RID: 138 RVA: 0x0000369A File Offset: 0x0000189A
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000036A1 File Offset: 0x000018A1
		public bool AllowUndo
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000036A8 File Offset: 0x000018A8
		public CommunicationState ControlProxyState
		{
			get
			{
				PcmoverControlScriptClient pcmoverControlProxy = this.PcmoverControlProxy;
				if (pcmoverControlProxy != null)
				{
					return pcmoverControlProxy.State;
				}
				if (!this.HasControlInterface)
				{
					return CommunicationState.Faulted;
				}
				return CommunicationState.Opened;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x0600008D RID: 141 RVA: 0x000036D1 File Offset: 0x000018D1
		public DriveData Drives
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000036D8 File Offset: 0x000018D8
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000036E0 File Offset: 0x000018E0
		public MiscSettingsData MiscSettingsData { get; private set; }

		// Token: 0x06000090 RID: 144 RVA: 0x000036EC File Offset: 0x000018EC
		public CustomizationData AddFileFilter(FileFilter filter)
		{
			CustomizationData result;
			try
			{
				if (this._customizeTaskHandle == 0)
				{
					result = null;
				}
				else
				{
					this._customizeTaskHandle = this._fillTaskHandle;
					this._scriptConnection.InvokeScript(string.Format("AddFileFilter({0}, {1}, {2}, {3} );", new object[]
					{
						this._customizeTaskHandle,
						this.Quote(filter.filter),
						this.Quote(filter.target),
						filter.transfer
					}));
					result = new CustomizationData();
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "AddFileFilter");
				result = null;
			}
			return result;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000379C File Offset: 0x0000199C
		public bool AddRemoteMachine(ConnectableMachine machine, string discoveryId, bool bSecure)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000037A3 File Offset: 0x000019A3
		public bool ApplyDataUpdate()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000037AA File Offset: 0x000019AA
		public Task CancelPrepareCustomizationAsync()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x000037B1 File Offset: 0x000019B1
		public CustomizationData ChangeApplicationInfo(ApplicationInfo appInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000095 RID: 149 RVA: 0x000037B8 File Offset: 0x000019B8
		public CustomizationData ChangeApplicationSelection(ApplicationInfo appInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000037BF File Offset: 0x000019BF
		public CustomizationData ChangeDiskData(string path, string fileName, bool isFolder, bool? isFiltered, string target)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000037C6 File Offset: 0x000019C6
		public CustomizationData ChangeDriveMapping(DrivePair drivePair)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x000037CD File Offset: 0x000019CD
		public CustomizationData ChangeFileFilter(int index, FileFilter filter)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000099 RID: 153 RVA: 0x000037D4 File Offset: 0x000019D4
		public CustomizationData ChangeMiscSetting(MiscSettingData miscSetting)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000037DB File Offset: 0x000019DB
		public Task<bool> CleanupAsync(uint timeout = 9000U)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000037E2 File Offset: 0x000019E2
		public int CreateNetworkTransferMethod(string networkTarget)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000037E9 File Offset: 0x000019E9
		public int CreateTransferMethod(TransferMethodType tm, string networkTarget)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000037F0 File Offset: 0x000019F0
		public int CreateTransferMethod(TransferMethodType tm)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000037F7 File Offset: 0x000019F7
		public CustomizationData DeleteFileFilter(int index)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000037FE File Offset: 0x000019FE
		public bool DeleteTransferMethod(int transferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00003808 File Offset: 0x00001A08
		public IEnumerable<DriveSpaceAndNeeded> DetermineInsufficientDiskSpace(IEnumerable<DriveSpaceRequired> requiredList)
		{
			if (this.ThisMachineDriveSpace == null)
			{
				this.ThisMachineDriveSpace = this.ControlInterface.MachineGetDriveSpace(base.ThisMachine.Handle);
			}
			List<DriveSpaceAndNeeded> list = new List<DriveSpaceAndNeeded>();
			ulong num = (ulong)Math.Pow(1024.0, 3.0) * 10UL;
			using (IEnumerator<DriveSpaceRequired> enumerator = requiredList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					DriveSpaceRequired required = enumerator.Current;
					IEnumerable<DriveSpaceData> thisMachineDriveSpace = this.ThisMachineDriveSpace;
					DriveSpaceData driveSpaceData = (thisMachineDriveSpace != null) ? thisMachineDriveSpace.FirstOrDefault((DriveSpaceData d) => string.Compare(d.Drive, required.Drive, true) == 0) : null;
					if (driveSpaceData != null)
					{
						ulong num2 = required.Required + num;
						if (required.Required > 0UL && num2 > driveSpaceData.FreeBytes)
						{
							list.Add(new DriveSpaceAndNeeded
							{
								Drive = required.Drive,
								Required = required.Required,
								Available = driveSpaceData.FreeBytes
							});
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000392C File Offset: 0x00001B2C
		public void DisconnectFromPcmoverService()
		{
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000392E File Offset: 0x00001B2E
		public FindResponse FindServiceHosts()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00003935 File Offset: 0x00001B35
		public Task<FindResponse> FindServiceHostsAsync()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000393C File Offset: 0x00001B3C
		public ActivityClient GetActivityClient(ActivityType type)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00003943 File Offset: 0x00001B43
		public ActivityClient GetActivityClient(int handle)
		{
			return null;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x00003946 File Offset: 0x00001B46
		public List<ApplicationData> GetApplications(int taskHandle, GetApplicationsParameters parameters)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003950 File Offset: 0x00001B50
		public IEnumerable<ConnectableMachine> GetConnectableMachines()
		{
			List<ConnectableMachine> list = new List<ConnectableMachine>();
			try
			{
				string text = this._scriptConnection.InvokeScript(string.Format("GetConnectableMachines({0});", this.DiscoveryActivityClient.Handle));
				foreach (string text2 in text.Split(new string[]
				{
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries))
				{
					string[] data = text.Split(new string[]
					{
						";"
					}, StringSplitOptions.None);
					TransferMethodType method;
					Enum.TryParse<TransferMethodType>(this.ParseValue(data, "ConnectionName"), out method);
					ConnectableMachine item = new ConnectableMachine
					{
						FriendlyName = this.ParseValue(data, "FriendlyName"),
						NetName = this.ParseValue(data, "NetName"),
						ConnectionName = this.ParseValue(data, "ConnectionName"),
						Method = method,
						IsOld = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsOld"))),
						SerialNumber = this.ParseValue(data, "SerialNumber"),
						TransferMethodHandle = Convert.ToInt32(this.ParseValue(data, "TransferMethodHandle"))
					};
					list.Add(item);
				}
				foreach (ConnectableMachine payload in list)
				{
					this.EventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Publish(payload);
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetConnectableMachines");
			}
			return list;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00003B08 File Offset: 0x00001D08
		public string GetControllerProperty(string property)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00003B0F File Offset: 0x00001D0F
		public IDownloadControl GetDownloadManager()
		{
			return null;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00003B12 File Offset: 0x00001D12
		public EngineLogData GetEngineLogData()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00003B1C File Offset: 0x00001D1C
		private int GetFileTransferMethodHandle(string fileName, ulong? spanSize = null, bool? canSpan = null, bool? notifySpan = null)
		{
			int result;
			try
			{
				result = Convert.ToInt32(this._scriptConnection.InvokeScript("iPcmover.CreateTransferMethod('File');"));
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetFileTransferMethodHandle");
				result = 0;
			}
			return result;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003B68 File Offset: 0x00001D68
		public FileTransferMethodInfo GetFileTransferMethodInfo()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00003B6F File Offset: 0x00001D6F
		public TransferrableContainerData GetFolderData(string path, bool withinBranch, bool onlyRoot)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003B76 File Offset: 0x00001D76
		public ImageMapData GetImageTransferMethodInfo()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003B7D File Offset: 0x00001D7D
		public SslInfo GetLocalSslInfo()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003B84 File Offset: 0x00001D84
		public MachineDriveInfo GetMachineDriveInfo()
		{
			MachineDriveInfo result;
			try
			{
				string[] data = this._scriptConnection.InvokeScript(string.Format("GetMachineDriveInfo({0});", base.ThisMachine.Handle)).Split(new string[]
				{
					";"
				}, StringSplitOptions.RemoveEmptyEntries);
				result = new MachineDriveInfo
				{
					HardDrives = this.ParseValue(data, "HardDrives"),
					UsbDrives = this.ParseValue(data, "UsbDrives"),
					VirtualDrives = this.ParseValue(data, "VirtualDrives")
				};
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetMachineDriveInfo");
				result = null;
			}
			return result;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003C30 File Offset: 0x00001E30
		public string GetPublicProperty(string property)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003C37 File Offset: 0x00001E37
		public IEnumerable<string> GetRedistributables()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003C3E File Offset: 0x00001E3E
		public SslInfo GetSslInfo()
		{
			if (this.TargetMachine == null || (this.TargetMachine.Method != TransferMethodType.Network && this.TargetMachine.Method != TransferMethodType.Usb))
			{
				return null;
			}
			return this.ControlInterface.GetSslInfo(this.TargetMachine.TransferMethodHandle);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003C7E File Offset: 0x00001E7E
		public TaskSummaryData GetTaskSummaryData(int taskHandle, bool regularUsersOnly)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00003C85 File Offset: 0x00001E85
		public TransferMethodData GetTransferMethodData(int transferMethodHandle)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003C8C File Offset: 0x00001E8C
		public TransferSpeeds GetTransferSpeeds(ActivityClient transferClient)
		{
			return new TransferSpeeds();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003C93 File Offset: 0x00001E93
		public uint GetValidNetworkAdapterCount()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003C9A File Offset: 0x00001E9A
		public bool MarkUserDeferredComplete(string userName, string userSid)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003CA1 File Offset: 0x00001EA1
		public FinishTransferData PerformPostTransferActions(bool dlmgrReboot)
		{
			FinishTransferData result = new FinishTransferData();
			if (!this.ThisMachineIsOld)
			{
				this._scriptConnection.InvokeScript("PerformPostTransferActions();");
			}
			this.StopConnectionMonitor();
			return result;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public bool Reboot(uint delay)
		{
			this._scriptConnection.InvokeScript("pcmover.CloseOrAbort();");
			this.EventAggregator.GetEvent<Events.ShutdownEvent>().Publish();
			try
			{
				Process.Start("shutdown.exe", string.Format("/r /t {0}", delay));
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "Reboot");
				return false;
			}
			return true;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003D3C File Offset: 0x00001F3C
		public bool RefreshNetworkAdapters()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00003D44 File Offset: 0x00001F44
		public Task RetrieveApplicationListAsync()
		{
			PCmoverEngineScr.<RetrieveApplicationListAsync>d__220 <RetrieveApplicationListAsync>d__;
			<RetrieveApplicationListAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RetrieveApplicationListAsync>d__.<>1__state = -1;
			<RetrieveApplicationListAsync>d__.<>t__builder.Start<PCmoverEngineScr.<RetrieveApplicationListAsync>d__220>(ref <RetrieveApplicationListAsync>d__);
			return <RetrieveApplicationListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00003D7F File Offset: 0x00001F7F
		public bool RetrieveDiskData()
		{
			return this.CreateFolderList();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00003D87 File Offset: 0x00001F87
		public void RetrieveDrives()
		{
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00003D89 File Offset: 0x00001F89
		public void RetrieveFileFilters()
		{
			this.FileFilters = new List<FileFilter>();
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00003D96 File Offset: 0x00001F96
		public void RetrieveMigrationItems()
		{
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003D98 File Offset: 0x00001F98
		public void RetrieveMiscSettings()
		{
			this.MiscSettingsData = this.ControlInterface.TaskGetMiscSettings(this._customizeTaskHandle, CultureInfo.CurrentUICulture.Name);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003DBB File Offset: 0x00001FBB
		public bool SendAlerts(TaskAlertData.AlertType alertType, TaskAlertData interactiveAlert, TransferProcessResult status)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003DC2 File Offset: 0x00001FC2
		public void SendCallbackReply(int replyHandle, int reply)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00003DCC File Offset: 0x00001FCC
		public void SetControllerProperty(string property, string value)
		{
			try
			{
				this._scriptConnection.InvokeScript(string.Concat(new string[]
				{
					"iPcmover.SetControllerProperty(",
					this.Quote(property),
					", ",
					this.Quote(value),
					");"
				}));
			}
			catch (UnexpectedScriptException ex)
			{
				base.Ts.TraceException(ex, "SetControllerProperty");
			}
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00003E44 File Offset: 0x00002044
		public bool SetDirection(ConnectableMachine remoteMachine)
		{
			base.Ts.TraceCaller((remoteMachine != null) ? remoteMachine.NetName : null, "SetDirection");
			try
			{
				if (!this.UseSSL && remoteMachine != null)
				{
					remoteMachine.CertificateName = string.Empty;
				}
				this.EventAggregator.GetEvent<EngineEvents.SetDirectionEvent>().Publish(remoteMachine);
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "SetDirection");
				return false;
			}
			return true;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00003EC0 File Offset: 0x000020C0
		public void SetEngineLogData(EngineLogData data)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003EC7 File Offset: 0x000020C7
		public bool SetFileTransferMethodInfo(int fileTransferMethodHandle, FileTransferMethodInfo info)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003ECE File Offset: 0x000020CE
		public bool SetImageTransferMethodInfo(int imageTransferMethodHandle, ImageMapData imageMapData)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00003ED5 File Offset: 0x000020D5
		public bool SetNetworkTransferMethodInfo(int networkTransferMethodHandle, NetworkTransferMethodInfo info)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00003EDC File Offset: 0x000020DC
		public void SetProductCulture(string language, string country)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00003EE3 File Offset: 0x000020E3
		public bool SetProxyAuth(string proxy, string username, string password)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x00003EEA File Offset: 0x000020EA
		public void SetPublicProperty(string property, string value)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00003EF1 File Offset: 0x000020F1
		public CustomizationData SetUserPassword(string accountName, string password)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00003EF8 File Offset: 0x000020F8
		public bool SetVanPassword(string password)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00003EFF File Offset: 0x000020FF
		public Task ShutdownAndRestartPcmoverAsync()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x00003F08 File Offset: 0x00002108
		public Task ShutdownPcmoverAppAsync(bool terminateService)
		{
			PCmoverEngineScr.<ShutdownPcmoverAppAsync>d__240 <ShutdownPcmoverAppAsync>d__;
			<ShutdownPcmoverAppAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<ShutdownPcmoverAppAsync>d__.<>4__this = this;
			<ShutdownPcmoverAppAsync>d__.terminateService = terminateService;
			<ShutdownPcmoverAppAsync>d__.<>1__state = -1;
			<ShutdownPcmoverAppAsync>d__.<>t__builder.Start<PCmoverEngineScr.<ShutdownPcmoverAppAsync>d__240>(ref <ShutdownPcmoverAppAsync>d__);
			return <ShutdownPcmoverAppAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00003F54 File Offset: 0x00002154
		public ActivityClient StartCreateAnyMachine()
		{
			try
			{
				this._transferType = PcmoverTransferState.TransferTypeEnum.File;
				this._scriptConnection.InvokeScript("StartCreateAnyMachine();");
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "StartCreateAnyMachine");
			}
			this._CallbackPoller.PollItems[PollItemName.ReadSnapshot].Enabled = true;
			return new ActivityClient(this);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00003FBC File Offset: 0x000021BC
		public ActivityClient StartCreateImageMachine(ImageMapData imageMachineData)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00003FC3 File Offset: 0x000021C3
		public ActivityClient StartCreateWinUpgradeMachine(string windowsOld)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00003FCC File Offset: 0x000021CC
		public Task<ActivityClient> StartFindComputerAsync()
		{
			PCmoverEngineScr.<StartFindComputerAsync>d__244 <StartFindComputerAsync>d__;
			<StartFindComputerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ActivityClient>.Create();
			<StartFindComputerAsync>d__.<>4__this = this;
			<StartFindComputerAsync>d__.<>1__state = -1;
			<StartFindComputerAsync>d__.<>t__builder.Start<PCmoverEngineScr.<StartFindComputerAsync>d__244>(ref <StartFindComputerAsync>d__);
			return <StartFindComputerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x0000400F File Offset: 0x0000220F
		private void StopFindComputer()
		{
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00004014 File Offset: 0x00002214
		public ActivityClient StartListenActivity(string discoveryId = null, string password = "")
		{
			if (string.IsNullOrEmpty(discoveryId))
			{
				discoveryId = this.License.SerialNumber;
			}
			try
			{
				this._scriptConnection.InvokeScript(string.Concat(new string[]
				{
					"StartListenActivity(",
					this.Quote(discoveryId),
					", ",
					this.Quote(password),
					");"
				}));
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "StartListenActivity");
			}
			return new ActivityClient(this);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x000040A8 File Offset: 0x000022A8
		public ActivityClient StartLoadMovingJournal(string fileName)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x000040B0 File Offset: 0x000022B0
		public ActivityClient StartReadSnapshot()
		{
			try
			{
				this._scriptConnection.InvokeScript(string.Format("StartReadSnapshot({0}, {1}, {2});", this.TargetMachine.TransferMethodHandle, this.Quote(this.TargetMachine.FriendlyName), this.Quote(this.TargetMachine.CertificateName)));
				string value;
				if (this._scriptConnection.Poll("otherMachineHandle;", (string t) => t != "0", TimeSpan.FromMinutes(20.0), out value))
				{
					int num = Convert.ToInt32(value);
					if (num != 0)
					{
						this.OtherMachine = this.ControlInterface.GetMachineData(num);
					}
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "StartReadSnapshot");
			}
			return new ActivityClient(this);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004190 File Offset: 0x00002390
		public ActivityClient StartReadSnapshot(ConnectableMachine targetMachine)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004198 File Offset: 0x00002398
		public ActivityClient StartSaveMovingVan(string fileName, ulong? spanSize, bool? canSpan, bool? notifySpan)
		{
			try
			{
				this._scriptConnection.InvokeScript("SetFileTransferMethodInfo(" + this.Quote(fileName) + ");");
				this._scriptConnection.InvokeScript("StartSaveMovingVan();");
				return new ActivityClient(this);
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "StartSaveMovingVan");
			}
			return null;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00004208 File Offset: 0x00002408
		public ActivityClient StartTransfer()
		{
			if (this._fillTaskHandle == 0)
			{
				return null;
			}
			if (this._otherMachineTransferMethodHandle == 0 && this.TargetMachine != null)
			{
				this._otherMachineTransferMethodHandle = this.TargetMachine.TransferMethodHandle;
			}
			return this.StartTransfer(this._otherMachineTransferMethodHandle);
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00004244 File Offset: 0x00002444
		private ActivityClient StartTransfer(int transferMethodHandle)
		{
			ActivityClient result;
			try
			{
				this._scriptConnection.InvokeScript(string.Format("StartTransfer({0}, {1});", transferMethodHandle, this._fillTaskHandle));
				result = new ActivityClient(this);
			}
			catch (UnexpectedScriptException ex)
			{
				base.Ts.TraceException(ex, "StartTransfer");
				result = null;
			}
			return result;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000042A8 File Offset: 0x000024A8
		internal void DeleteTask(ref int taskHandle)
		{
			try
			{
				if (taskHandle != 0 && this.HasControlInterface)
				{
					this.ControlInterface.DeleteTask(taskHandle);
				}
				if (taskHandle == this._customizeTaskHandle)
				{
					this._customizeTaskHandle = 0;
				}
				taskHandle = 0;
			}
			catch (SystemException ex) when (ex is CommunicationException || ex is TimeoutException)
			{
				base.Ts.TraceException(ex, "DeleteTask");
				throw;
			}
			catch (Exception ex2)
			{
				base.Ts.TraceException(ex2, "DeleteTask");
				this.HandleException(ex2, "DeleteTask");
			}
		}

		// Token: 0x060000DE RID: 222 RVA: 0x0000435C File Offset: 0x0000255C
		private void HandleException(Exception e, [CallerMemberName] string caller = "")
		{
			PCmoverEngineScr.<HandleException>d__254 <HandleException>d__;
			<HandleException>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<HandleException>d__.<>4__this = this;
			<HandleException>d__.e = e;
			<HandleException>d__.caller = caller;
			<HandleException>d__.<>1__state = -1;
			<HandleException>d__.<>t__builder.Start<PCmoverEngineScr.<HandleException>d__254>(ref <HandleException>d__);
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000043A4 File Offset: 0x000025A4
		public ActivityClient StartTransferMovingVan(string fileName)
		{
			if (this.FileTransferMethodHandle == 0)
			{
				this.FileTransferMethodHandle = this.GetFileTransferMethodHandle(fileName, null, null, null);
				if (this.FileTransferMethodHandle == 0)
				{
					return null;
				}
			}
			try
			{
				this._scriptConnection.InvokeScript(string.Format("fileBasedStartTransfer({0}, {1});", this.Quote(fileName), this.FileTransferMethodHandle));
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "StartTransferMovingVan");
				return null;
			}
			return new ActivityClient(this);
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00004444 File Offset: 0x00002644
		public ActivityClient StartUndoActivity()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000444C File Offset: 0x0000264C
		public Task StopActivityAsync(ActivityClient activityClient, bool waitUntilDone = true)
		{
			PCmoverEngineScr.<StopActivityAsync>d__258 <StopActivityAsync>d__;
			<StopActivityAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StopActivityAsync>d__.<>1__state = -1;
			<StopActivityAsync>d__.<>t__builder.Start<PCmoverEngineScr.<StopActivityAsync>d__258>(ref <StopActivityAsync>d__);
			return <StopActivityAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00004488 File Offset: 0x00002688
		public Task StopActivityAsync(ActivityType type, bool waitUntilDone = true)
		{
			PCmoverEngineScr.<StopActivityAsync>d__259 <StopActivityAsync>d__;
			<StopActivityAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<StopActivityAsync>d__.<>4__this = this;
			<StopActivityAsync>d__.type = type;
			<StopActivityAsync>d__.<>1__state = -1;
			<StopActivityAsync>d__.<>t__builder.Start<PCmoverEngineScr.<StopActivityAsync>d__259>(ref <StopActivityAsync>d__);
			return <StopActivityAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000044D3 File Offset: 0x000026D3
		public Task StopReadSnapshotAsync(bool waitUntilDone = true)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x000044DA File Offset: 0x000026DA
		public bool SuspendSleep(bool suspend)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x000044E1 File Offset: 0x000026E1
		public CustomizationData SwapFileFilters(int index1, int index2)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000044E8 File Offset: 0x000026E8
		public AuthorizationInfo TaskGetAuthorizationInfo()
		{
			if (this._customizeTaskHandle != 0)
			{
				try
				{
					this._scriptConnection.InvokeScript(string.Format("TaskGetAuthorizationInfo({0});", this._customizeTaskHandle));
					string[] data = this._scriptConnection.InvokeScript("strAuthorizationInfo;").Split(new string[]
					{
						";"
					}, StringSplitOptions.None);
					return new AuthorizationInfo
					{
						IsAuthorized = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsAuthorized"))),
						IsPreValidated = Convert.ToBoolean(Convert.ToInt16(this.ParseValue(data, "IsPreValidated"))),
						SerialNumber = this.ParseValue(data, "SerialNumber"),
						SessionCode = this.ParseValue(data, "SessionCode")
					};
				}
				catch (UnexpectedScriptException ex)
				{
					base.Ts.TraceException(ex, "TaskGetAuthorizationInfo");
				}
			}
			return new AuthorizationInfo();
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000045D8 File Offset: 0x000027D8
		public TaskStats TaskGetStats(int taskHandle, bool includeDriveSpace)
		{
			try
			{
				this._scriptConnection.InvokeScript(string.Format("TaskGetStats({0}, {1});", taskHandle, includeDriveSpace));
				string[] array = this._scriptConnection.InvokeScript("strStats;").Split(new string[]
				{
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				string[] data = array[0].Split(new string[]
				{
					";"
				}, StringSplitOptions.RemoveEmptyEntries);
				List<DriveSpaceRequired> list = new List<DriveSpaceRequired>();
				for (int i = 1; i < array.Length; i++)
				{
					string[] data2 = array[i].Split(new string[]
					{
						";"
					}, StringSplitOptions.RemoveEmptyEntries);
					DriveSpaceRequired item = new DriveSpaceRequired
					{
						Drive = this.ParseValue(data2, "Drive"),
						Required = Convert.ToUInt64(this.ParseValue(data2, "RequiredSpace"))
					};
					list.Add(item);
				}
				return new TaskStats
				{
					Disk = new ContainerStats
					{
						NumContainers = Convert.ToUInt64(this.ParseValue(data, "NumContainers")),
						NumItems = Convert.ToUInt64(this.ParseValue(data, "NumItems")),
						TotalSize = Convert.ToUInt64(this.ParseValue(data, "TotalSize"))
					},
					DriveSpaceRequired = list
				};
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "TaskGetStats");
			}
			return null;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00004744 File Offset: 0x00002944
		public bool TaskPrepareAuthorization(LicenseInfo license)
		{
			if (this._customizeTaskHandle == 0)
			{
				try
				{
					string value = this._scriptConnection.InvokeScript("fillTaskHandle;");
					this._fillTaskHandle = Convert.ToInt32(value);
					this._customizeTaskHandle = this._fillTaskHandle;
				}
				catch (Exception ex)
				{
					base.Ts.TraceException(ex, "TaskPrepareAuthorization");
				}
			}
			return this._scriptConnection.InvokeScript(string.Format("TaskPrepareAuthorization({0}, {1}, {2}, {3});", new object[]
			{
				this._customizeTaskHandle,
				this.Quote(license.User),
				this.Quote(license.Email),
				this.Quote(license.SerialNumber)
			})) == "1";
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004808 File Offset: 0x00002A08
		public AuthorizationRequestData GetAuthorizationRequestData(LicenseInfo license)
		{
			return new AuthorizationRequestData(license);
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004810 File Offset: 0x00002A10
		public bool UploadApplicationReport()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00004817 File Offset: 0x00002A17
		internal IUnityContainer Container { get; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00004820 File Offset: 0x00002A20
		private PcmoverEdition Edition
		{
			get
			{
				PcmoverEdition result;
				if (!Enum.TryParse<PcmoverEdition>(PcmBrandUI.Properties.Resources.Edition, out result))
				{
					result = PcmoverEdition.Pro;
				}
				return result;
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00004840 File Offset: 0x00002A40
		public PCmoverEngineScr(IUnityContainer container, IEventAggregator eventAggregator, IEngineParameters engineParameters, LlTraceSource ts) : base(ts)
		{
			this.Container = container;
			this._engineParameters = engineParameters;
			this.EventAggregator = eventAggregator;
			this.GodMode = false;
			this.IsLive = true;
			if (this._engineParameters.PcmoverServiceAddress == null)
			{
				this.IsRemoteUI = 0;
			}
			else
			{
				this.IsRemoteUI = (this._engineParameters.PcmoverServiceAddress.Uri.Scheme != Uri.UriSchemeNetPipe);
			}
			this.UseSSL = ConfigHelper.GetBoolSetting("UseSSL", true);
			this.CertificateName = ConfigHelper.GetStringSetting("CertificateName", string.Empty);
			this._applicationList = new List<ApplicationInfo>();
			this.Settings["IsFilesBasedEnabled"] = true;
			this.Settings["IsIAEnabled"] = true;
			this.Settings["IsUAEnabled"] = false;
			this.FileFilters = new List<FileFilter>();
			this._networkStatsLock = new object();
			eventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Subscribe(new Action<Exception>(this.OnCommunicationExceptionEvent));
			this.EventAggregator.GetEvent<Events.ProcessShutdownRequest>().Subscribe(new Action<Events.ShutdownEventArgs>(this.ProcessShutdown), ThreadOption.UIThread);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000049C4 File Offset: 0x00002BC4
		private string NameForLogging(UserDetail user)
		{
			if (user == null)
			{
				return "null";
			}
			return user.AccountName + " (" + user.FriendlyName + ")";
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000049EC File Offset: 0x00002BEC
		private Task<int> DisplayMessageAsync(string v)
		{
			PCmoverEngineScr.<DisplayMessageAsync>d__301 <DisplayMessageAsync>d__;
			<DisplayMessageAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<DisplayMessageAsync>d__.<>4__this = this;
			<DisplayMessageAsync>d__.v = v;
			<DisplayMessageAsync>d__.<>1__state = -1;
			<DisplayMessageAsync>d__.<>t__builder.Start<PCmoverEngineScr.<DisplayMessageAsync>d__301>(ref <DisplayMessageAsync>d__);
			return <DisplayMessageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00004A38 File Offset: 0x00002C38
		private void ProcessShutdown(Events.ShutdownEventArgs obj)
		{
			PCmoverEngineScr.<ProcessShutdown>d__302 <ProcessShutdown>d__;
			<ProcessShutdown>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ProcessShutdown>d__.<>4__this = this;
			<ProcessShutdown>d__.obj = obj;
			<ProcessShutdown>d__.<>1__state = -1;
			<ProcessShutdown>d__.<>t__builder.Start<PCmoverEngineScr.<ProcessShutdown>d__302>(ref <ProcessShutdown>d__);
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00004A77 File Offset: 0x00002C77
		public override void OnCommunicationException(Exception ex)
		{
			this.EventAggregator.GetEvent<EngineEvents.CommunicationExceptionEvent>().Publish(ex);
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00004A8C File Offset: 0x00002C8C
		private void OnCommunicationExceptionEvent(Exception ex)
		{
			PCmoverEngineScr.<OnCommunicationExceptionEvent>d__304 <OnCommunicationExceptionEvent>d__;
			<OnCommunicationExceptionEvent>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnCommunicationExceptionEvent>d__.<>4__this = this;
			<OnCommunicationExceptionEvent>d__.<>1__state = -1;
			<OnCommunicationExceptionEvent>d__.<>t__builder.Start<PCmoverEngineScr.<OnCommunicationExceptionEvent>d__304>(ref <OnCommunicationExceptionEvent>d__);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00004AC3 File Offset: 0x00002CC3
		private void RunConnectionMonitor()
		{
			this._stopMonitorEvent = new AutoResetEvent(false);
			this._monitorConnection = true;
			this._connectionMonitorThread = new Thread(new ThreadStart(this.ConnectionMonitorThread));
			this._connectionMonitorThread.Start();
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00004AFA File Offset: 0x00002CFA
		private void StopConnectionMonitor()
		{
			this._monitorConnection = false;
			AutoResetEvent stopMonitorEvent = this._stopMonitorEvent;
			if (stopMonitorEvent == null)
			{
				return;
			}
			stopMonitorEvent.Set();
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00004B14 File Offset: 0x00002D14
		private List<CategoryDefinition> FindCloudCategories(MachineData machine)
		{
			return null;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00004B18 File Offset: 0x00002D18
		public Task PrepareCustomizationAsync()
		{
			PCmoverEngineScr.<PrepareCustomizationAsync>d__310 <PrepareCustomizationAsync>d__;
			<PrepareCustomizationAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<PrepareCustomizationAsync>d__.<>4__this = this;
			<PrepareCustomizationAsync>d__.<>1__state = -1;
			<PrepareCustomizationAsync>d__.<>t__builder.Start<PCmoverEngineScr.<PrepareCustomizationAsync>d__310>(ref <PrepareCustomizationAsync>d__);
			return <PrepareCustomizationAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00004B5C File Offset: 0x00002D5C
		private Task RunCustomizationTask()
		{
			PCmoverEngineScr.<RunCustomizationTask>d__311 <RunCustomizationTask>d__;
			<RunCustomizationTask>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<RunCustomizationTask>d__.<>4__this = this;
			<RunCustomizationTask>d__.<>1__state = -1;
			<RunCustomizationTask>d__.<>t__builder.Start<PCmoverEngineScr.<RunCustomizationTask>d__311>(ref <RunCustomizationTask>d__);
			return <RunCustomizationTask>d__.<>t__builder.Task;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00004BA0 File Offset: 0x00002DA0
		private void ExpandSnapshotAsync()
		{
			base.Ts.TraceCaller("Expand Snapshot Activity", "ExpandSnapshotAsync");
			if (base.IsResuming)
			{
				if (base.ServiceData.Step != PcmoverTransferState.TransferStep.Customizing)
				{
					base.Ts.TraceCaller("No need to expand the snapshot while resuming", "ExpandSnapshotAsync");
					return;
				}
				base.Ts.TraceCaller("Turning off IsResuming so we can expand the snapshot for Customizing", "ExpandSnapshotAsync");
				base.IsResuming = false;
			}
			PcmTaskData taskData = this.ControlInterface.GetTaskData(this._fillTaskHandle);
			if (taskData == null)
			{
				return;
			}
			if (this.ControlInterface.GetMachineData(taskData.SourceMachineHandle) == null)
			{
				return;
			}
			new ActivityClient(this);
			ExpandSnapshotActivityParameters expandSnapshotActivityParameters = new ExpandSnapshotActivityParameters
			{
				MachineHandle = taskData.SourceMachineHandle,
				ItemType = ItemType.Disk,
				RegularUsersOnly = true,
				ExpandGlobalCategories = (taskData.SourceMachineHandle != taskData.DestMachineHandle)
			};
			try
			{
				this._scriptConnection.InvokeScript(string.Format("CreateExpandSnapshotActivity({0}, '{1}', {2}, {3});", new object[]
				{
					expandSnapshotActivityParameters.MachineHandle,
					expandSnapshotActivityParameters.ItemType,
					expandSnapshotActivityParameters.RegularUsersOnly,
					expandSnapshotActivityParameters.ExpandGlobalCategories
				}));
				string text;
				if (this._scriptConnection.Poll("ExpandSnapshotComplete;", (string t) => t == "1", TimeSpan.FromMinutes(20.0), out text))
				{
					base.Ts.TraceInformation("Expand snapshot complete.");
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "ExpandSnapshotAsync");
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00004D40 File Offset: 0x00002F40
		internal Task<MessageBoxResult> DisplayEarlierVersionMessageAsync(string formatString, WindowsVersionData srcWindowsVersion, WindowsVersionData destWindowsVersion)
		{
			PCmoverEngineScr.<DisplayEarlierVersionMessageAsync>d__313 <DisplayEarlierVersionMessageAsync>d__;
			<DisplayEarlierVersionMessageAsync>d__.<>t__builder = AsyncTaskMethodBuilder<MessageBoxResult>.Create();
			<DisplayEarlierVersionMessageAsync>d__.<>4__this = this;
			<DisplayEarlierVersionMessageAsync>d__.formatString = formatString;
			<DisplayEarlierVersionMessageAsync>d__.srcWindowsVersion = srcWindowsVersion;
			<DisplayEarlierVersionMessageAsync>d__.destWindowsVersion = destWindowsVersion;
			<DisplayEarlierVersionMessageAsync>d__.<>1__state = -1;
			<DisplayEarlierVersionMessageAsync>d__.<>t__builder.Start<PCmoverEngineScr.<DisplayEarlierVersionMessageAsync>d__313>(ref <DisplayEarlierVersionMessageAsync>d__);
			return <DisplayEarlierVersionMessageAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00004D9C File Offset: 0x00002F9C
		internal string LookupMessage(UiCallbackCode code, string param, string defaultMsg)
		{
			string resourceString = this.GetResourceString(code.ToString());
			if (!string.IsNullOrEmpty(resourceString))
			{
				return string.Format(resourceString, param);
			}
			return defaultMsg;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00004DD0 File Offset: 0x00002FD0
		internal string GetResourceString(string Id)
		{
			string @string = PcmBrandUI.Properties.Resources.ResourceManager.GetString(Id);
			if (string.IsNullOrEmpty(@string))
			{
				@string = ClientEngineModule.Infrastructure.Properties.Resources.ResourceManager.GetString(Id);
			}
			return @string;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00004E00 File Offset: 0x00003000
		internal void NewPcmoverState(PcmoverState newState)
		{
			if (newState == this._lastState)
			{
				return;
			}
			base.Ts.TraceCaller(newState.ToString(), "NewPcmoverState");
			if (this._shuttingDown && newState == PcmoverState.idle)
			{
				bool flag = false;
				object shutdownLock = this._shutdownLock;
				lock (shutdownLock)
				{
					if (this._shuttingDown)
					{
						flag = true;
						this._shuttingDown = false;
					}
				}
				if (flag)
				{
					Task.Run(new Action(this.FinishShutdown));
				}
			}
			this.EventAggregator.GetEvent<EngineEvents.ServiceStateChanged>().Publish(newState);
			if (this._lastState == PcmoverState.initInProgress)
			{
				TaskCompletionSource<PcmoverState> initComplete = this._initComplete;
				if (initComplete != null)
				{
					initComplete.TrySetResult(newState);
				}
			}
			this._lastState = newState;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00004EC8 File Offset: 0x000030C8
		private void FinishShutdown()
		{
			try
			{
				if (this._restarting)
				{
					this._restarting = false;
					base.Ts.TraceCaller("Connect to PCmover service for restart", "FinishShutdown");
					Task.Run<bool>(() => this.ConnectToPcmoverServiceAsync());
				}
				else
				{
					this.DisconnectFromPcmoverService();
				}
			}
			catch (Exception e)
			{
				this.HandleException(e, "FinishShutdown");
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00004F34 File Offset: 0x00003134
		private void ConnectionMonitorThread()
		{
			base.Ts.TraceCaller("Started", "ConnectionMonitorThread");
			while (this._monitorConnection && !this._stopMonitorEvent.WaitOne(10000))
			{
			}
			base.Ts.TraceCaller("Ended", "ConnectionMonitorThread");
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004F87 File Offset: 0x00003187
		private void CreatePcmoverControlCallback()
		{
			this._CallbackPoller = new PcmoverControlCallback(this, this.EventAggregator, base.Ts);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00004FA4 File Offset: 0x000031A4
		private string GetConnectionType()
		{
			string result = "WMI";
			try
			{
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(PCmoverEngineScr._emaSettingsKeyPath, false))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue(PCmoverEngineScr._connectionTypeKey);
						if (value != null)
						{
							result = value.ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetConnectionType");
				return null;
			}
			return result;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00005028 File Offset: 0x00003228
		private Task<bool> MakeConnectionAsync()
		{
			PCmoverEngineScr.<MakeConnectionAsync>d__324 <MakeConnectionAsync>d__;
			<MakeConnectionAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<MakeConnectionAsync>d__.<>4__this = this;
			<MakeConnectionAsync>d__.<>1__state = -1;
			<MakeConnectionAsync>d__.<>t__builder.Start<PCmoverEngineScr.<MakeConnectionAsync>d__324>(ref <MakeConnectionAsync>d__);
			return <MakeConnectionAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000506C File Offset: 0x0000326C
		private Task DisconnectServiceAsync(string message = null)
		{
			PCmoverEngineScr.<DisconnectServiceAsync>d__325 <DisconnectServiceAsync>d__;
			<DisconnectServiceAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<DisconnectServiceAsync>d__.<>4__this = this;
			<DisconnectServiceAsync>d__.message = message;
			<DisconnectServiceAsync>d__.<>1__state = -1;
			<DisconnectServiceAsync>d__.<>t__builder.Start<PCmoverEngineScr.<DisconnectServiceAsync>d__325>(ref <DisconnectServiceAsync>d__);
			return <DisconnectServiceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000050B8 File Offset: 0x000032B8
		private bool DoInitialize()
		{
			base.Ts.TraceCaller(null, "DoInitialize");
			this._initErrorMessage = "";
			bool flag = false;
			try
			{
				base.ServiceData = new PcmoverServiceData(base.Ts);
				if (base.ServiceData == null)
				{
					return false;
				}
				this._scriptConnection.InvokeScript("include(\"pcmover.cscs\");");
				this._scriptConnection.InvokeScript(PcmoverScripts.BecomeControllerAndInit);
				string a;
				if (!this._scriptConnection.Poll(PcmoverScripts.CurrentStatus, (string t) => t != "initInProgress", TimeSpan.FromMinutes(2.0), out a))
				{
					return false;
				}
				if (a == PcmoverState.initialized.ToString())
				{
					this.RetrieveInitialData();
					flag = true;
				}
			}
			catch (EndpointNotFoundException)
			{
				this._initErrorMessage = ClientEngineModule.Infrastructure.Properties.Resources.ERROR_NoService + Environment.NewLine + Environment.NewLine;
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "DoInitialize");
				this._initErrorMessage = ex.Message;
			}
			base.Ts.TraceCaller("Complete", "DoInitialize");
			if (flag)
			{
				this.RunConnectionMonitor();
				this._CallbackPoller.StartPolling();
			}
			return flag;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00005218 File Offset: 0x00003418
		private void RetrieveInitialData()
		{
			base.Ts.TraceCaller("Starting", "RetrieveInitialData");
			base.ThisMachine = this.GetThisMachine();
			this.Container.Resolve(Array.Empty<ResolverOverride>()).InitializeReports(this.Policy.ClientReports);
			this.CloudCategories = (this.FindCloudCategories(base.ThisMachine) ?? new List<CategoryDefinition>());
			base.Ts.TraceCaller(string.Format("Cloud categories: {0}", this.CloudCategories.Count<CategoryDefinition>()), "RetrieveInitialData");
			base.Ts.TraceCaller(string.Format("{0} drives", (this.ThisMachineDriveSpace == null) ? 0 : this.ThisMachineDriveSpace.Count<DriveSpaceData>()), "RetrieveInitialData");
			base.Ts.TraceCaller("Complete", "RetrieveInitialData");
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000052F8 File Offset: 0x000034F8
		private MachineData GetThisMachine()
		{
			string[] data = this._scriptConnection.InvokeScript("ipcmover.GetThisMachine();").Split(new string[]
			{
				"\n"
			}, StringSplitOptions.None);
			ProductType productType;
			Enum.TryParse<ProductType>(this.ParseValue(data, "ProductType"), out productType);
			WindowsVersionData windowsVersion = new WindowsVersionData
			{
				Platform = Convert.ToInt32(this.ParseValue(data, "Platform")),
				ServicePack = this.ParseValue(data, "ServicePack"),
				Version = new Version(this.ParseValue(data, "Version")),
				VersionString = this.ParseValue(data, "VersionString"),
				Is64Bit = Convert.ToBoolean(this.ParseValue(data, "Is64Bit")),
				ProductType = productType,
				EnablePreviewBuilds = Convert.ToUInt32(this.ParseValue(data, "EnablePreviewBuilds")),
				WindowsEdition = Convert.ToUInt32(this.ParseValue(data, "WindowsEdition"))
			};
			return new MachineData
			{
				Handle = (int)Convert.ToInt16(this.ParseValue(data, "Handle")),
				NetName = this.ParseValue(data, "NetName"),
				FriendlyName = this.ParseValue(data, "FriendlyName"),
				MachineId = this.ParseValue(data, "MachineId"),
				Manufacturer = this.ParseValue(data, "Manufacturer"),
				JoinedDomain = this.ParseValue(data, "JoinedDomain"),
				IsJoinedToAzureAd = Convert.ToBoolean(this.ParseValue(data, "IsJoinedToAzureAd")),
				IsEngineRunningAsAdmin = Convert.ToBoolean(this.ParseValue(data, "IsEngineRunningAsAdmin")),
				Age = Convert.ToDateTime(this.ParseValue(data, "Age")),
				OemId = Convert.ToUInt32(this.ParseValue(data, "$OemId")),
				WindowsVersion = windowsVersion
			};
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000054BC File Offset: 0x000036BC
		public string ParseValue(string[] data, string Property)
		{
			try
			{
				string text = data.FirstOrDefault((string x) => x.StartsWith(Property));
				if (text != null)
				{
					string text2 = string.Empty;
					if (text.Contains("="))
					{
						text2 = text.Substring(text.IndexOf("=") + 1);
					}
					else if (text.Contains(":"))
					{
						text2 = text.Substring(text.IndexOf(":") + 1);
					}
					return text2.Trim();
				}
			}
			catch (Exception)
			{
			}
			return string.Empty;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000555C File Offset: 0x0000375C
		public void FireActivityProgressEvent(ActivityInfo info, ProgressInfo progress)
		{
			switch (info.Type)
			{
			case ActivityType.AppInventory:
				this.EventAggregator.GetEvent<EngineEvents.ThisMachineAppInventoryProgressChanged>().Publish(progress);
				return;
			case ActivityType.Discovery:
			case ActivityType.SaveSnapshot:
			case ActivityType.Listen:
			case ActivityType.Undo:
			case ActivityType.ExpandSnapshot:
			case ActivityType.GenerateReports:
			case ActivityType.LoadMovingJournal:
				break;
			case ActivityType.GetSnapshot:
				this.EventAggregator.GetEvent<EngineEvents.SnapshotProgressChanged>().Publish(progress);
				return;
			case ActivityType.BuildChangeLists:
				this.EventAggregator.GetEvent<EngineEvents.AnalysisProgressChanged>().Publish(progress);
				return;
			case ActivityType.SaveMovingVan:
			case ActivityType.Transfer:
			{
				TransferProgressInfo payload = new TransferProgressInfo
				{
					ProgressInfo = progress,
					ActivityInfo = info
				};
				this.EventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Publish(payload);
				break;
			}
			default:
				return;
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005604 File Offset: 0x00003804
		public void FireMachineFoundEvent(ConnectableMachine machine)
		{
			this.EventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Publish(machine);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005618 File Offset: 0x00003818
		public bool SetAuthorizationData(AuthorizationRequestData authRequest)
		{
			bool result;
			try
			{
				this._scriptConnection.InvokeScript(string.Concat(new string[]
				{
					"SetAuthorizationData(",
					this.Quote(authRequest.User),
					", ",
					this.Quote(authRequest.Email),
					", ",
					this.Quote(authRequest.SerialNumber),
					");"
				}));
				result = true;
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "SetAuthorizationData");
				result = false;
			}
			return result;
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000056B4 File Offset: 0x000038B4
		public override void FireActivityInfoEvent(ActivityInfo info)
		{
			base.Ts.TraceInformation(string.Format("Firing ActivityInfoEvent: Succeeded:{0}, IsDone:{1}", info.IsSucceeded, info.IsDone));
			if (info.IsDone)
			{
				this.IsThisMachineAppInventoryComplete = info.IsDone;
			}
			this.EventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Publish(info);
			base.FireActivityInfoEvent(info);
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0000572E File Offset: 0x0000392E
		MachineData IPCmoverEngine.get_ThisMachine()
		{
			return base.ThisMachine;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x00005736 File Offset: 0x00003936
		Task<bool> IPCmoverEngine.CatchCommExAsync(Func<Task> func, string caller)
		{
			return base.CatchCommExAsync(func, caller);
		}

		// Token: 0x04000013 RID: 19
		private LicenseInfo _license;

		// Token: 0x0400001B RID: 27
		private List<ApplicationInfo> _applicationList;

		// Token: 0x0400001C RID: 28
		private Settings _settings;

		// Token: 0x0400001E RID: 30
		private bool _thisMachineIsOld = true;

		// Token: 0x04000022 RID: 34
		private AppInventoryAmount _thisAppInvAmountRequirement;

		// Token: 0x04000027 RID: 39
		private Dictionary<PCmoverEngineScr.GroupType, GroupInfo> _groups;

		// Token: 0x0400002D RID: 45
		private TransferProgressInfo _TransferInfo;

		// Token: 0x0400002E RID: 46
		internal AppInventoryStatus _thisAppInvStatus = new AppInventoryStatus();

		// Token: 0x0400002F RID: 47
		private readonly object _thisAppInvLock = new object();

		// Token: 0x04000031 RID: 49
		private IEnumerable<NetworkInfo> _networkInfos;

		// Token: 0x04000034 RID: 52
		private ActivityClient DiscoveryActivityClient;

		// Token: 0x04000035 RID: 53
		private int FileTransferMethodHandle;

		// Token: 0x04000036 RID: 54
		internal int _selfTransferMethodHandle;

		// Token: 0x04000038 RID: 56
		private IEngineParameters _engineParameters;

		// Token: 0x04000039 RID: 57
		private readonly object _networkStatsLock;

		// Token: 0x0400003A RID: 58
		private bool _handledCommEx;

		// Token: 0x0400003B RID: 59
		private bool _receivedShutdownRequest;

		// Token: 0x0400003C RID: 60
		private object _shutdownRequestLock = new object();

		// Token: 0x0400003D RID: 61
		private bool _monitorConnection;

		// Token: 0x0400003E RID: 62
		private Thread _connectionMonitorThread;

		// Token: 0x0400003F RID: 63
		private AutoResetEvent _stopMonitorEvent;

		// Token: 0x04000040 RID: 64
		private bool _retryInitialization;

		// Token: 0x04000041 RID: 65
		private string _initErrorMessage;

		// Token: 0x04000042 RID: 66
		private bool _firstConnection = true;

		// Token: 0x04000043 RID: 67
		public int _customizeTaskHandle;

		// Token: 0x04000044 RID: 68
		private int _fillTaskHandle;

		// Token: 0x04000045 RID: 69
		internal int _transferTaskHandle;

		// Token: 0x04000046 RID: 70
		internal int _otherMachineTransferMethodHandle;

		// Token: 0x04000047 RID: 71
		private int _srcMachineHandle;

		// Token: 0x04000048 RID: 72
		private int _dstMachineHandle;

		// Token: 0x04000049 RID: 73
		private bool _otherMachineReady;

		// Token: 0x0400004A RID: 74
		private object _shutdownLock = new object();

		// Token: 0x0400004B RID: 75
		public bool _shuttingDown;

		// Token: 0x0400004C RID: 76
		private bool _restarting;

		// Token: 0x0400004D RID: 77
		private TaskCompletionSource<PcmoverState> _initComplete;

		// Token: 0x0400004E RID: 78
		private PcmoverState _lastState;

		// Token: 0x0400004F RID: 79
		private IScriptChannel _scriptConnection;

		// Token: 0x04000050 RID: 80
		private PcmoverTransferState.TransferTypeEnum _transferType;

		// Token: 0x04000051 RID: 81
		private Task _customizationTask;

		// Token: 0x04000052 RID: 82
		private CancellationTokenSource _customizationTokenSource;

		// Token: 0x04000053 RID: 83
		private PcmoverControlCallback _CallbackPoller;

		// Token: 0x04000054 RID: 84
		private static string _emaSettingsKeyPath = "Software\\Laplink\\TransferManager\\EMA";

		// Token: 0x04000055 RID: 85
		private static string _connectionTypeKey = "ConnectionType";

		// Token: 0x02000008 RID: 8
		private enum GroupType
		{
			// Token: 0x04000058 RID: 88
			Documents,
			// Token: 0x04000059 RID: 89
			Pictures,
			// Token: 0x0400005A RID: 90
			Music,
			// Token: 0x0400005B RID: 91
			Video,
			// Token: 0x0400005C RID: 92
			Other,
			// Token: 0x0400005D RID: 93
			None
		}
	}
}
