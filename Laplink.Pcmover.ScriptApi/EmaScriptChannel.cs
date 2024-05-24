using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using IntelEMA;
using Microsoft.Win32;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x02000004 RID: 4
	public class EmaScriptChannel : ScriptChannelBase
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002090 File Offset: 0x00000290
		public EmaScriptChannel(ScriptClientBase clientBase, Uri uri) : base(clientBase, uri)
		{
			base.CanFireEvents = false;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020A4 File Offset: 0x000002A4
		private string GetEndpointID()
		{
			string result = "";
			try
			{
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(EmaScriptChannel._emaSettingsKeyPath, false))
				{
					if (registryKey != null)
					{
						object value = registryKey.GetValue(EmaScriptChannel._endpointIDKey);
						if (value != null)
						{
							result = value.ToString();
						}
					}
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "GetEndpointID");
				return null;
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002128 File Offset: 0x00000328
		private Task<EndpointData> GetEndpointDataAsync()
		{
			EmaScriptChannel.<GetEndpointDataAsync>d__7 <GetEndpointDataAsync>d__;
			<GetEndpointDataAsync>d__.<>t__builder = AsyncTaskMethodBuilder<EndpointData>.Create();
			<GetEndpointDataAsync>d__.<>4__this = this;
			<GetEndpointDataAsync>d__.<>1__state = -1;
			<GetEndpointDataAsync>d__.<>t__builder.Start<EmaScriptChannel.<GetEndpointDataAsync>d__7>(ref <GetEndpointDataAsync>d__);
			return <GetEndpointDataAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000216C File Offset: 0x0000036C
		protected override void EstablishConnection()
		{
			Task<EndpointData> task = Task.Run<EndpointData>(delegate()
			{
				EmaScriptChannel.<<EstablishConnection>b__8_0>d <<EstablishConnection>b__8_0>d;
				<<EstablishConnection>b__8_0>d.<>t__builder = AsyncTaskMethodBuilder<EndpointData>.Create();
				<<EstablishConnection>b__8_0>d.<>4__this = this;
				<<EstablishConnection>b__8_0>d.<>1__state = -1;
				<<EstablishConnection>b__8_0>d.<>t__builder.Start<EmaScriptChannel.<<EstablishConnection>b__8_0>d>(ref <<EstablishConnection>b__8_0>d);
				return <<EstablishConnection>b__8_0>d.<>t__builder.Task;
			});
			this._endPointData = task.Result;
			if (this._endPointData == null)
			{
				return;
			}
			Task<int> task2 = Task.Run<int>(delegate()
			{
				EmaScriptChannel.<<EstablishConnection>b__8_1>d <<EstablishConnection>b__8_1>d;
				<<EstablishConnection>b__8_1>d.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
				<<EstablishConnection>b__8_1>d.<>4__this = this;
				<<EstablishConnection>b__8_1>d.<>1__state = -1;
				<<EstablishConnection>b__8_1>d.<>t__builder.Start<EmaScriptChannel.<<EstablishConnection>b__8_1>d>(ref <<EstablishConnection>b__8_1>d);
				return <<EstablishConnection>b__8_1>d.<>t__builder.Task;
			});
			this._scriptID = task2.Result;
			if (this._scriptID != -1)
			{
				this.CreateInterpreter();
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000021D0 File Offset: 0x000003D0
		private void CreateInterpreter()
		{
			ScriptInterpreter result = Task.Run<ScriptInterpreter>(delegate()
			{
				EmaScriptChannel.<<CreateInterpreter>b__9_0>d <<CreateInterpreter>b__9_0>d;
				<<CreateInterpreter>b__9_0>d.<>t__builder = AsyncTaskMethodBuilder<ScriptInterpreter>.Create();
				<<CreateInterpreter>b__9_0>d.<>4__this = this;
				<<CreateInterpreter>b__9_0>d.<>1__state = -1;
				<<CreateInterpreter>b__9_0>d.<>t__builder.Start<EmaScriptChannel.<<CreateInterpreter>b__9_0>d>(ref <<CreateInterpreter>b__9_0>d);
				return <<CreateInterpreter>b__9_0>d.<>t__builder.Task;
			}).Result;
			this._interpreterId = result.InterpreterID;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002200 File Offset: 0x00000400
		public override void CloseConnection()
		{
			if (string.IsNullOrEmpty(this._interpreterId))
			{
				return;
			}
			try
			{
				this.DeleteInterpreter();
				this._interpreterId = string.Empty;
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "CloseConnection");
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002254 File Offset: 0x00000454
		private void DeleteInterpreter()
		{
			Task.Run<bool>(delegate()
			{
				EmaScriptChannel.<<DeleteInterpreter>b__11_0>d <<DeleteInterpreter>b__11_0>d;
				<<DeleteInterpreter>b__11_0>d.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
				<<DeleteInterpreter>b__11_0>d.<>4__this = this;
				<<DeleteInterpreter>b__11_0>d.<>1__state = -1;
				<<DeleteInterpreter>b__11_0>d.<>t__builder.Start<EmaScriptChannel.<<DeleteInterpreter>b__11_0>d>(ref <<DeleteInterpreter>b__11_0>d);
				return <<DeleteInterpreter>b__11_0>d.<>t__builder.Task;
			});
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002268 File Offset: 0x00000468
		protected override string ProcessScript(string script)
		{
			EmaScriptChannel.<>c__DisplayClass12_0 CS$<>8__locals1 = new EmaScriptChannel.<>c__DisplayClass12_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.script = script;
			ScriptReturnedData result = Task.Run<ScriptReturnedData>(delegate()
			{
				EmaScriptChannel.<>c__DisplayClass12_0.<<ProcessScript>b__0>d <<ProcessScript>b__0>d;
				<<ProcessScript>b__0>d.<>t__builder = AsyncTaskMethodBuilder<ScriptReturnedData>.Create();
				<<ProcessScript>b__0>d.<>4__this = CS$<>8__locals1;
				<<ProcessScript>b__0>d.<>1__state = -1;
				<<ProcessScript>b__0>d.<>t__builder.Start<EmaScriptChannel.<>c__DisplayClass12_0.<<ProcessScript>b__0>d>(ref <<ProcessScript>b__0>d);
				return <<ProcessScript>b__0>d.<>t__builder.Task;
			}).Result;
			string text = result.text;
			ScriptResult returnValue = (ScriptResult)result.ReturnValue;
			if (returnValue != ScriptResult.Success)
			{
				base.ClientBase.ThrowScriptException(returnValue, CS$<>8__locals1.script, text);
			}
			return text;
		}

		// Token: 0x04000001 RID: 1
		private string _interpreterId;

		// Token: 0x04000002 RID: 2
		private EndpointData _endPointData;

		// Token: 0x04000003 RID: 3
		private int _scriptID;

		// Token: 0x04000004 RID: 4
		private static string _emaSettingsKeyPath = "Software\\Laplink\\TransferManager\\EMA";

		// Token: 0x04000005 RID: 5
		private static string _endpointIDKey = "EndpointIDKey";
	}
}
