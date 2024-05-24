using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.OffScreen;

namespace IntelEMA
{
	// Token: 0x02000014 RID: 20
	public class EMAAPI : IDisposable
	{
		// Token: 0x060000AC RID: 172 RVA: 0x000026B8 File Offset: 0x000008B8
		public EMAAPI(string emaServer, string javascriptServerPage, bool logging = false)
		{
			if (EMAAPI._client == null)
			{
				this.Init(emaServer, javascriptServerPage, logging);
				try
				{
					CefRuntime.SubscribeAnyCpuAssemblyResolver(null);
				}
				catch (Exception)
				{
					return;
				}
				Task task = Task.Run(delegate()
				{
					EMAAPI.<>c.<<-ctor>b__8_0>d <<-ctor>b__8_0>d;
					<<-ctor>b__8_0>d.<>t__builder = AsyncTaskMethodBuilder.Create();
					<<-ctor>b__8_0>d.<>1__state = -1;
					<<-ctor>b__8_0>d.<>t__builder.Start<EMAAPI.<>c.<<-ctor>b__8_0>d>(ref <<-ctor>b__8_0>d);
					return <<-ctor>b__8_0>d.<>t__builder.Task;
				});
				TimeSpan timeout = TimeSpan.FromSeconds(30.0);
				if (!task.Wait(timeout))
				{
					throw new CEFException("Unable to initialize CEF");
				}
			}
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000273C File Offset: 0x0000093C
		public void Init(string emaServer, string javascriptServerPage, bool logging)
		{
			this._emaServer = emaServer;
			EMAAPI._javascriptServerPage = javascriptServerPage;
			this._logging = logging;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00002754 File Offset: 0x00000954
		public static Task InitializeAsync(int consoleLogging)
		{
			EMAAPI.<InitializeAsync>d__10 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<InitializeAsync>d__.consoleLogging = consoleLogging;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<EMAAPI.<InitializeAsync>d__10>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00002798 File Offset: 0x00000998
		public static Task<ChromiumWebBrowser> CreateClientInstanceAsync(int consoleLogging)
		{
			EMAAPI.<CreateClientInstanceAsync>d__11 <CreateClientInstanceAsync>d__;
			<CreateClientInstanceAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ChromiumWebBrowser>.Create();
			<CreateClientInstanceAsync>d__.consoleLogging = consoleLogging;
			<CreateClientInstanceAsync>d__.<>1__state = -1;
			<CreateClientInstanceAsync>d__.<>t__builder.Start<EMAAPI.<CreateClientInstanceAsync>d__11>(ref <CreateClientInstanceAsync>d__);
			return <CreateClientInstanceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x000027DB File Offset: 0x000009DB
		public bool IsClientValid()
		{
			return EMAAPI._client != null;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000027E8 File Offset: 0x000009E8
		private Task<AuthResult> GetAuthToken()
		{
			EMAAPI.<GetAuthToken>d__13 <GetAuthToken>d__;
			<GetAuthToken>d__.<>t__builder = AsyncTaskMethodBuilder<AuthResult>.Create();
			<GetAuthToken>d__.<>4__this = this;
			<GetAuthToken>d__.<>1__state = -1;
			<GetAuthToken>d__.<>t__builder.Start<EMAAPI.<GetAuthToken>d__13>(ref <GetAuthToken>d__);
			return <GetAuthToken>d__.<>t__builder.Task;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000282C File Offset: 0x00000A2C
		public Task<HttpStatusCode> AuthenticateAsync(string user, string pass)
		{
			EMAAPI.<AuthenticateAsync>d__14 <AuthenticateAsync>d__;
			<AuthenticateAsync>d__.<>t__builder = AsyncTaskMethodBuilder<HttpStatusCode>.Create();
			<AuthenticateAsync>d__.<>4__this = this;
			<AuthenticateAsync>d__.user = user;
			<AuthenticateAsync>d__.pass = pass;
			<AuthenticateAsync>d__.<>1__state = -1;
			<AuthenticateAsync>d__.<>t__builder.Start<EMAAPI.<AuthenticateAsync>d__14>(ref <AuthenticateAsync>d__);
			return <AuthenticateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00002880 File Offset: 0x00000A80
		public Task<AjaxCookie> GetAjaxCookieAsync()
		{
			EMAAPI.<GetAjaxCookieAsync>d__15 <GetAjaxCookieAsync>d__;
			<GetAjaxCookieAsync>d__.<>t__builder = AsyncTaskMethodBuilder<AjaxCookie>.Create();
			<GetAjaxCookieAsync>d__.<>4__this = this;
			<GetAjaxCookieAsync>d__.<>1__state = -1;
			<GetAjaxCookieAsync>d__.<>t__builder.Start<EMAAPI.<GetAjaxCookieAsync>d__15>(ref <GetAjaxCookieAsync>d__);
			return <GetAjaxCookieAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000028C4 File Offset: 0x00000AC4
		public Task<List<EndpointGroup>> GetEndpointGroupsAsync()
		{
			EMAAPI.<GetEndpointGroupsAsync>d__16 <GetEndpointGroupsAsync>d__;
			<GetEndpointGroupsAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<EndpointGroup>>.Create();
			<GetEndpointGroupsAsync>d__.<>4__this = this;
			<GetEndpointGroupsAsync>d__.<>1__state = -1;
			<GetEndpointGroupsAsync>d__.<>t__builder.Start<EMAAPI.<GetEndpointGroupsAsync>d__16>(ref <GetEndpointGroupsAsync>d__);
			return <GetEndpointGroupsAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00002908 File Offset: 0x00000B08
		public Task<List<EndpointData>> EndpointsInGroupAsync(EndpointGroup group)
		{
			EMAAPI.<EndpointsInGroupAsync>d__17 <EndpointsInGroupAsync>d__;
			<EndpointsInGroupAsync>d__.<>t__builder = AsyncTaskMethodBuilder<List<EndpointData>>.Create();
			<EndpointsInGroupAsync>d__.<>4__this = this;
			<EndpointsInGroupAsync>d__.group = group;
			<EndpointsInGroupAsync>d__.<>1__state = -1;
			<EndpointsInGroupAsync>d__.<>t__builder.Start<EMAAPI.<EndpointsInGroupAsync>d__17>(ref <EndpointsInGroupAsync>d__);
			return <EndpointsInGroupAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00002954 File Offset: 0x00000B54
		public Task<EndpointDataEx> GetEndpointDataExAsync(EndpointData endpoint)
		{
			EMAAPI.<GetEndpointDataExAsync>d__18 <GetEndpointDataExAsync>d__;
			<GetEndpointDataExAsync>d__.<>t__builder = AsyncTaskMethodBuilder<EndpointDataEx>.Create();
			<GetEndpointDataExAsync>d__.<>4__this = this;
			<GetEndpointDataExAsync>d__.endpoint = endpoint;
			<GetEndpointDataExAsync>d__.<>1__state = -1;
			<GetEndpointDataExAsync>d__.<>t__builder.Start<EMAAPI.<GetEndpointDataExAsync>d__18>(ref <GetEndpointDataExAsync>d__);
			return <GetEndpointDataExAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x000029A0 File Offset: 0x00000BA0
		public Task<InstallState> GetInstallStateAsync(EndpointData endpoint)
		{
			EMAAPI.<GetInstallStateAsync>d__19 <GetInstallStateAsync>d__;
			<GetInstallStateAsync>d__.<>t__builder = AsyncTaskMethodBuilder<InstallState>.Create();
			<GetInstallStateAsync>d__.<>4__this = this;
			<GetInstallStateAsync>d__.endpoint = endpoint;
			<GetInstallStateAsync>d__.<>1__state = -1;
			<GetInstallStateAsync>d__.<>t__builder.Start<EMAAPI.<GetInstallStateAsync>d__19>(ref <GetInstallStateAsync>d__);
			return <GetInstallStateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x000029EC File Offset: 0x00000BEC
		public Task<InstallState> InstallPCmoverAsync(EndpointData endpoint)
		{
			EMAAPI.<InstallPCmoverAsync>d__20 <InstallPCmoverAsync>d__;
			<InstallPCmoverAsync>d__.<>t__builder = AsyncTaskMethodBuilder<InstallState>.Create();
			<InstallPCmoverAsync>d__.<>4__this = this;
			<InstallPCmoverAsync>d__.endpoint = endpoint;
			<InstallPCmoverAsync>d__.<>1__state = -1;
			<InstallPCmoverAsync>d__.<>t__builder.Start<EMAAPI.<InstallPCmoverAsync>d__20>(ref <InstallPCmoverAsync>d__);
			return <InstallPCmoverAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00002A38 File Offset: 0x00000C38
		public Task<int> DoPowerAsync(EndpointData endpoint, PowerOptionsEnum powerOption)
		{
			EMAAPI.<DoPowerAsync>d__21 <DoPowerAsync>d__;
			<DoPowerAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<DoPowerAsync>d__.<>4__this = this;
			<DoPowerAsync>d__.endpoint = endpoint;
			<DoPowerAsync>d__.powerOption = powerOption;
			<DoPowerAsync>d__.<>1__state = -1;
			<DoPowerAsync>d__.<>t__builder.Start<EMAAPI.<DoPowerAsync>d__21>(ref <DoPowerAsync>d__);
			return <DoPowerAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00002A8C File Offset: 0x00000C8C
		public Task<int> DoGetScriptInstanceAsync(EndpointData endpoint)
		{
			EMAAPI.<DoGetScriptInstanceAsync>d__22 <DoGetScriptInstanceAsync>d__;
			<DoGetScriptInstanceAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<DoGetScriptInstanceAsync>d__.<>4__this = this;
			<DoGetScriptInstanceAsync>d__.endpoint = endpoint;
			<DoGetScriptInstanceAsync>d__.<>1__state = -1;
			<DoGetScriptInstanceAsync>d__.<>t__builder.Start<EMAAPI.<DoGetScriptInstanceAsync>d__22>(ref <DoGetScriptInstanceAsync>d__);
			return <DoGetScriptInstanceAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00002AD8 File Offset: 0x00000CD8
		public Task<ScriptInterpreter> doScriptCreateInterpreterAsync(EndpointData endpoint, int scriptID)
		{
			EMAAPI.<doScriptCreateInterpreterAsync>d__23 <doScriptCreateInterpreterAsync>d__;
			<doScriptCreateInterpreterAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ScriptInterpreter>.Create();
			<doScriptCreateInterpreterAsync>d__.<>4__this = this;
			<doScriptCreateInterpreterAsync>d__.endpoint = endpoint;
			<doScriptCreateInterpreterAsync>d__.scriptID = scriptID;
			<doScriptCreateInterpreterAsync>d__.<>1__state = -1;
			<doScriptCreateInterpreterAsync>d__.<>t__builder.Start<EMAAPI.<doScriptCreateInterpreterAsync>d__23>(ref <doScriptCreateInterpreterAsync>d__);
			return <doScriptCreateInterpreterAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00002B2C File Offset: 0x00000D2C
		public Task<bool> doScriptDeleteInterpreterAsync(EndpointData endpoint, int scriptID, string interpreterID)
		{
			EMAAPI.<doScriptDeleteInterpreterAsync>d__24 <doScriptDeleteInterpreterAsync>d__;
			<doScriptDeleteInterpreterAsync>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
			<doScriptDeleteInterpreterAsync>d__.<>4__this = this;
			<doScriptDeleteInterpreterAsync>d__.endpoint = endpoint;
			<doScriptDeleteInterpreterAsync>d__.scriptID = scriptID;
			<doScriptDeleteInterpreterAsync>d__.interpreterID = interpreterID;
			<doScriptDeleteInterpreterAsync>d__.<>1__state = -1;
			<doScriptDeleteInterpreterAsync>d__.<>t__builder.Start<EMAAPI.<doScriptDeleteInterpreterAsync>d__24>(ref <doScriptDeleteInterpreterAsync>d__);
			return <doScriptDeleteInterpreterAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00002B88 File Offset: 0x00000D88
		public Task<ScriptReturnedData> DoSendScriptAsync(EndpointData endpoint, string scriptCommand, int scriptInstance, string interpreterID)
		{
			EMAAPI.<DoSendScriptAsync>d__25 <DoSendScriptAsync>d__;
			<DoSendScriptAsync>d__.<>t__builder = AsyncTaskMethodBuilder<ScriptReturnedData>.Create();
			<DoSendScriptAsync>d__.<>4__this = this;
			<DoSendScriptAsync>d__.endpoint = endpoint;
			<DoSendScriptAsync>d__.scriptCommand = scriptCommand;
			<DoSendScriptAsync>d__.scriptInstance = scriptInstance;
			<DoSendScriptAsync>d__.interpreterID = interpreterID;
			<DoSendScriptAsync>d__.<>1__state = -1;
			<DoSendScriptAsync>d__.<>t__builder.Start<EMAAPI.<DoSendScriptAsync>d__25>(ref <DoSendScriptAsync>d__);
			return <DoSendScriptAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00002BEC File Offset: 0x00000DEC
		public Task<int> DoGetLastErrorCodeAsync(EndpointData endpoint)
		{
			EMAAPI.<DoGetLastErrorCodeAsync>d__26 <DoGetLastErrorCodeAsync>d__;
			<DoGetLastErrorCodeAsync>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<DoGetLastErrorCodeAsync>d__.<>4__this = this;
			<DoGetLastErrorCodeAsync>d__.<>1__state = -1;
			<DoGetLastErrorCodeAsync>d__.<>t__builder.Start<EMAAPI.<DoGetLastErrorCodeAsync>d__26>(ref <DoGetLastErrorCodeAsync>d__);
			return <DoGetLastErrorCodeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00002C30 File Offset: 0x00000E30
		private Task TellEMAToGenerateData(string jscript)
		{
			EMAAPI.<TellEMAToGenerateData>d__27 <TellEMAToGenerateData>d__;
			<TellEMAToGenerateData>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<TellEMAToGenerateData>d__.jscript = jscript;
			<TellEMAToGenerateData>d__.<>1__state = -1;
			<TellEMAToGenerateData>d__.<>t__builder.Start<EMAAPI.<TellEMAToGenerateData>d__27>(ref <TellEMAToGenerateData>d__);
			return <TellEMAToGenerateData>d__.<>t__builder.Task;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002C74 File Offset: 0x00000E74
		private Task<string> TellEMAToGetData(string jscript, bool waitOnNull = false)
		{
			EMAAPI.<TellEMAToGetData>d__28 <TellEMAToGetData>d__;
			<TellEMAToGetData>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<TellEMAToGetData>d__.jscript = jscript;
			<TellEMAToGetData>d__.waitOnNull = waitOnNull;
			<TellEMAToGetData>d__.<>1__state = -1;
			<TellEMAToGetData>d__.<>t__builder.Start<EMAAPI.<TellEMAToGetData>d__28>(ref <TellEMAToGetData>d__);
			return <TellEMAToGetData>d__.<>t__builder.Task;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00002CC0 File Offset: 0x00000EC0
		private Task<int> TellEMAToGetIntData(string jscript, int timeout = 50)
		{
			EMAAPI.<TellEMAToGetIntData>d__29 <TellEMAToGetIntData>d__;
			<TellEMAToGetIntData>d__.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
			<TellEMAToGetIntData>d__.jscript = jscript;
			<TellEMAToGetIntData>d__.timeout = timeout;
			<TellEMAToGetIntData>d__.<>1__state = -1;
			<TellEMAToGetIntData>d__.<>t__builder.Start<EMAAPI.<TellEMAToGetIntData>d__29>(ref <TellEMAToGetIntData>d__);
			return <TellEMAToGetIntData>d__.<>t__builder.Task;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00002D0B File Offset: 0x00000F0B
		private void ThrowIfDisposed()
		{
			if (this.disposedValue)
			{
				throw new ObjectDisposedException("EMAAPI");
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002D20 File Offset: 0x00000F20
		protected virtual void Dispose(bool disposing)
		{
			EMAAPI._lock.Wait();
			try
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						Timer refreshTokenTimer = this._refreshTokenTimer;
						if (refreshTokenTimer != null)
						{
							refreshTokenTimer.Dispose();
						}
						this._refreshTokenTimer = null;
					}
					this.disposedValue = true;
				}
			}
			finally
			{
				EMAAPI._lock.Release();
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002D80 File Offset: 0x00000F80
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x04000072 RID: 114
		private static ChromiumWebBrowser _client = null;

		// Token: 0x04000073 RID: 115
		private Timer _refreshTokenTimer;

		// Token: 0x04000074 RID: 116
		private bool disposedValue;

		// Token: 0x04000075 RID: 117
		private static readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

		// Token: 0x04000076 RID: 118
		private static string _javascriptServerPage;

		// Token: 0x04000077 RID: 119
		private string _emaServer;

		// Token: 0x04000078 RID: 120
		private bool _logging;

		// Token: 0x04000079 RID: 121
		private static readonly CancellationTokenSource s_cts = new CancellationTokenSource();
	}
}
