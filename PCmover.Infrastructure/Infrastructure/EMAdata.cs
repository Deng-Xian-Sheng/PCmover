using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using IntelEMA;
using Microsoft.Win32;

namespace PCmover.Infrastructure
{
	// Token: 0x02000015 RID: 21
	public class EMAdata
	{
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00004DDD File Offset: 0x00002FDD
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00004DE4 File Offset: 0x00002FE4
		protected static AutoResetEvent ResetEvent { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00004DEC File Offset: 0x00002FEC
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00004DF3 File Offset: 0x00002FF3
		public static bool IsAuthenticated { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00004DFB File Offset: 0x00002FFB
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00004E02 File Offset: 0x00003002
		public static bool IsInitialized { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004E0A File Offset: 0x0000300A
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00004E11 File Offset: 0x00003011
		public static EMAAPI emapi { get; set; } = null;

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00004E19 File Offset: 0x00003019
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00004E20 File Offset: 0x00003020
		public static string server { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00004E28 File Offset: 0x00003028
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00004E2F File Offset: 0x0000302F
		protected static string minpage { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00004E37 File Offset: 0x00003037
		// (set) Token: 0x06000118 RID: 280 RVA: 0x00004E3E File Offset: 0x0000303E
		public static string username { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000119 RID: 281 RVA: 0x00004E46 File Offset: 0x00003046
		// (set) Token: 0x0600011A RID: 282 RVA: 0x00004E4D File Offset: 0x0000304D
		public static string password { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00004E55 File Offset: 0x00003055
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00004E5C File Offset: 0x0000305C
		public static bool loginFailed { get; set; } = false;

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00004E64 File Offset: 0x00003064
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00004E6B File Offset: 0x0000306B
		public static AjaxCookie ajaxCookie { get; set; } = null;

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00004E73 File Offset: 0x00003073
		// (set) Token: 0x06000120 RID: 288 RVA: 0x00004E7A File Offset: 0x0000307A
		private static DispatcherTimer timer { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000121 RID: 289 RVA: 0x00004E82 File Offset: 0x00003082
		// (set) Token: 0x06000122 RID: 290 RVA: 0x00004E89 File Offset: 0x00003089
		private static DispatcherTimer refreshTimer { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00004E91 File Offset: 0x00003091
		// (set) Token: 0x06000124 RID: 292 RVA: 0x00004E98 File Offset: 0x00003098
		protected static bool logging { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00004EA0 File Offset: 0x000030A0
		// (set) Token: 0x06000126 RID: 294 RVA: 0x00004EA8 File Offset: 0x000030A8
		public string instanceName { get; set; }

		// Token: 0x06000127 RID: 295 RVA: 0x00004EB4 File Offset: 0x000030B4
		static EMAdata()
		{
			EMAdata.IsInitialized = false;
			EMAdata.GetEMASettings();
			EMAdata._lock = new SemaphoreSlim(1, 1);
			if (EMAdata.server != null)
			{
				EMAdata.timer = new DispatcherTimer
				{
					Interval = TimeSpan.FromSeconds(1.0)
				};
				EMAdata.timer.Tick += delegate(object sender, EventArgs args)
				{
					EMAdata.<>c.<<-cctor>b__59_0>d <<-cctor>b__59_0>d;
					<<-cctor>b__59_0>d.<>t__builder = AsyncVoidMethodBuilder.Create();
					<<-cctor>b__59_0>d.<>1__state = -1;
					<<-cctor>b__59_0>d.<>t__builder.Start<EMAdata.<>c.<<-cctor>b__59_0>d>(ref <<-cctor>b__59_0>d);
				};
				EMAdata.timer.Start();
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00004F79 File Offset: 0x00003179
		public EMAdata(string instanceName)
		{
			this.instanceName = instanceName;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00004F88 File Offset: 0x00003188
		public static Task InitializeEma()
		{
			EMAdata.<InitializeEma>d__61 <InitializeEma>d__;
			<InitializeEma>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeEma>d__.<>1__state = -1;
			<InitializeEma>d__.<>t__builder.Start<EMAdata.<InitializeEma>d__61>(ref <InitializeEma>d__);
			return <InitializeEma>d__.<>t__builder.Task;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00004FC4 File Offset: 0x000031C4
		private static void GetEMASettings()
		{
			try
			{
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(EMAdata._emaSettingsKeyPath, false))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue(EMAdata._serverURLKey);
						if (value != null)
						{
							EMAdata.server = value.ToString();
						}
						value = registryKey.GetValue(EMAdata._usernameKey);
						if (value != null)
						{
							EMAdata.username = value.ToString();
						}
						value = registryKey.GetValue(EMAdata._passwordKey);
						if (value != null)
						{
							try
							{
								EMAdata.password = value.ToString().Decrypt();
							}
							catch
							{
								EMAdata.password = "";
							}
						}
						value = registryKey.GetValue(EMAdata._pageKey);
						if (value != null)
						{
							EMAdata.minpage = value.ToString();
						}
						value = registryKey.GetValue(EMAdata._jslogging);
						if (value != null)
						{
							EMAdata.logging = Convert.ToBoolean(value);
						}
						else
						{
							EMAdata.logging = false;
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw new EmaException(ex.Message);
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000050C8 File Offset: 0x000032C8
		public static void SetEMASettings()
		{
			try
			{
				using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(EMAdata._emaSettingsKeyPath, true))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue(EMAdata._serverURLKey);
						if (value == null || value.ToString() != EMAdata.server)
						{
							string text = EMAdata.server;
							if (!text.EndsWith("\\") && !text.EndsWith("/"))
							{
								text += "/";
							}
							text += "pcmover/min.html";
							EMAdata.minpage = text;
							registryKey.SetValue(EMAdata._pageKey, text);
						}
						registryKey.SetValue(EMAdata._serverURLKey, EMAdata.server);
						registryKey.SetValue(EMAdata._usernameKey, EMAdata.username);
						registryKey.SetValue(EMAdata._passwordKey, EMAdata.password.Encrypt());
					}
				}
			}
			catch (Exception ex)
			{
				throw new EmaException(ex.Message);
			}
		}

		// Token: 0x0600012C RID: 300 RVA: 0x000051C4 File Offset: 0x000033C4
		public static Task<List<EndpointGroup>> GetEndpointGroupListAsync()
		{
			EMAdata.<GetEndpointGroupListAsync>d__70 <GetEndpointGroupListAsync>d__;
			<GetEndpointGroupListAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<EndpointGroup>>.Create();
			<GetEndpointGroupListAsync>d__.<>1__state = -1;
			<GetEndpointGroupListAsync>d__.<>t__builder.Start<EMAdata.<GetEndpointGroupListAsync>d__70>(ref <GetEndpointGroupListAsync>d__);
			return <GetEndpointGroupListAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00005200 File Offset: 0x00003400
		public static Task<List<EndpointData>> GetEndpoints()
		{
			EMAdata.<GetEndpoints>d__71 <GetEndpoints>d__;
			<GetEndpoints>d__.<>t__builder = AsyncTaskMethodBuilder<List<EndpointData>>.Create();
			<GetEndpoints>d__.<>1__state = -1;
			<GetEndpoints>d__.<>t__builder.Start<EMAdata.<GetEndpoints>d__71>(ref <GetEndpoints>d__);
			return <GetEndpoints>d__.<>t__builder.Task;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x0000523C File Offset: 0x0000343C
		private static Task GetEndpointsData()
		{
			EMAdata.<GetEndpointsData>d__72 <GetEndpointsData>d__;
			<GetEndpointsData>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<GetEndpointsData>d__.<>1__state = -1;
			<GetEndpointsData>d__.<>t__builder.Start<EMAdata.<GetEndpointsData>d__72>(ref <GetEndpointsData>d__);
			return <GetEndpointsData>d__.<>t__builder.Task;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00005278 File Offset: 0x00003478
		public static Task<List<EndpointData>> GetEndpointsInGroupAsync(EndpointGroup endpointGroup)
		{
			EMAdata.<GetEndpointsInGroupAsync>d__73 <GetEndpointsInGroupAsync>d__;
			<GetEndpointsInGroupAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<EndpointData>>.Create();
			<GetEndpointsInGroupAsync>d__.endpointGroup = endpointGroup;
			<GetEndpointsInGroupAsync>d__.<>1__state = -1;
			<GetEndpointsInGroupAsync>d__.<>t__builder.Start<EMAdata.<GetEndpointsInGroupAsync>d__73>(ref <GetEndpointsInGroupAsync>d__);
			return <GetEndpointsInGroupAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000130 RID: 304 RVA: 0x000052BC File Offset: 0x000034BC
		public static Task<EndpointData> UpdateEndpoint(EndpointGroup group, string EndpointID)
		{
			EMAdata.<UpdateEndpoint>d__74 <UpdateEndpoint>d__;
			<UpdateEndpoint>d__.<>t__builder = AsyncTaskMethodBuilder<EndpointData>.Create();
			<UpdateEndpoint>d__.group = group;
			<UpdateEndpoint>d__.EndpointID = EndpointID;
			<UpdateEndpoint>d__.<>1__state = -1;
			<UpdateEndpoint>d__.<>t__builder.Start<EMAdata.<UpdateEndpoint>d__74>(ref <UpdateEndpoint>d__);
			return <UpdateEndpoint>d__.<>t__builder.Task;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00005308 File Offset: 0x00003508
		public static Task<List<string>> GetScriptComputers()
		{
			EMAdata.<GetScriptComputers>d__75 <GetScriptComputers>d__;
			<GetScriptComputers>d__.<>t__builder = AsyncTaskMethodBuilder<List<string>>.Create();
			<GetScriptComputers>d__.<>1__state = -1;
			<GetScriptComputers>d__.<>t__builder.Start<EMAdata.<GetScriptComputers>d__75>(ref <GetScriptComputers>d__);
			return <GetScriptComputers>d__.<>t__builder.Task;
		}

		// Token: 0x04000078 RID: 120
		private static List<EndpointGroup> GroupList;

		// Token: 0x04000079 RID: 121
		private static List<EndpointData> Endpoints = new List<EndpointData>();

		// Token: 0x0400007A RID: 122
		private static readonly SemaphoreSlim _lock;

		// Token: 0x0400007D RID: 125
		private static string _emaSettingsKeyPath = "Software\\Laplink\\TransferManager\\EMA";

		// Token: 0x0400007E RID: 126
		private static string _serverURLKey = "ServerURL";

		// Token: 0x0400007F RID: 127
		private static string _usernameKey = "Username";

		// Token: 0x04000080 RID: 128
		private static string _passwordKey = "Password";

		// Token: 0x04000081 RID: 129
		private static string _pageKey = "PageURL";

		// Token: 0x04000082 RID: 130
		private static string _jslogging = "JavascriptLogging";
	}
}
