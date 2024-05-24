using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceModel;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x0200000F RID: 15
	public class WmiScriptChannel : ScriptChannelBase
	{
		// Token: 0x0600006B RID: 107 RVA: 0x000030FF File Offset: 0x000012FF
		public WmiScriptChannel(ScriptClientBase clientBase, Uri uri) : base(clientBase, uri)
		{
			base.CanFireEvents = true;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003110 File Offset: 0x00001310
		protected override void EstablishConnection()
		{
			ConnectionOptions options = new ConnectionOptions();
			this._scope = new ManagementScope("\\\\" + base.HostName + "\\root\\Laplink\\Pcmover", options);
			try
			{
				this._scope.Connect();
				ObjectQuery query = new ObjectQuery("SELECT * FROM ScriptInstance");
				IEnumerable<ManagementObject> source = new ManagementObjectSearcher(this._scope, query).Get().Cast<ManagementObject>();
				this._scriptInstance = source.First<ManagementObject>();
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "EstablishConnection");
				base.ClientBase.State = CommunicationState.Faulted;
				throw new EndpointNotFoundException("Unable to open WMI connection for " + base.HostName, ex);
			}
			this.CreateInterpreter();
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000031CC File Offset: 0x000013CC
		private void CreateInterpreter()
		{
			ManagementBaseObject methodParameters = this._scriptInstance.GetMethodParameters(WmiScriptChannel._createInterpreterMethodName);
			methodParameters["timeout"] = 60;
			try
			{
				ManagementBaseObject managementBaseObject = this._scriptInstance.InvokeMethod(WmiScriptChannel._createInterpreterMethodName, methodParameters, null);
				this._eventId = (string)managementBaseObject["eventId"];
				this._interpreterId = (string)managementBaseObject["ReturnValue"];
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "CreateInterpreter");
				base.ClientBase.ThrowCommunicationException("Unable to open WMI connection for " + base.HostName, ex);
			}
			this._processScriptParameters = this._scriptInstance.GetMethodParameters(WmiScriptChannel._processScriptMethodName);
			this._processScriptParameters["interpreterId"] = this._interpreterId;
			this._deleteInterpreterParameters = this._scriptInstance.GetMethodParameters(WmiScriptChannel._deleteInterpreterMethodName);
			this._deleteInterpreterParameters["interpreterId"] = this._interpreterId;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000032D8 File Offset: 0x000014D8
		public override void CloseConnection()
		{
			if (this._scriptInstance == null)
			{
				return;
			}
			try
			{
				this.DeleteInterpreter();
				this._scriptInstance.Dispose();
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "CloseConnection");
			}
			this._scriptInstance = null;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00003330 File Offset: 0x00001530
		private void DeleteInterpreter()
		{
			this._scriptInstance.InvokeMethod(WmiScriptChannel._deleteInterpreterMethodName, this._deleteInterpreterParameters, null);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000334C File Offset: 0x0000154C
		protected override void SetupEvents()
		{
			WqlEventQuery query = new WqlEventQuery("Select * from ScriptEvent where EventId = '" + this._eventId + "'");
			this._eventWatcher = new ManagementEventWatcher(this._scope, query);
			this._eventWatcher.EventArrived += this.Watcher_EventArrived;
			this._eventWatcher.Start();
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000033A8 File Offset: 0x000015A8
		private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
		{
			ManagementBaseObject newEvent = e.NewEvent;
			string text = (string)newEvent["EventId"];
			string text2 = (string)newEvent["EventText"];
			string text3 = (string)newEvent["EventType"];
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000033E4 File Offset: 0x000015E4
		protected override string ProcessScript(string script)
		{
			ManagementBaseObject managementBaseObject = (ManagementBaseObject)this._processScriptParameters.Clone();
			managementBaseObject["script"] = script;
			ManagementBaseObject managementBaseObject2 = this._scriptInstance.InvokeMethod(WmiScriptChannel._processScriptMethodName, managementBaseObject, null);
			string text = (string)managementBaseObject2["text"];
			ScriptResult scriptResult = (ScriptResult)managementBaseObject2["ReturnValue"];
			if (scriptResult != ScriptResult.Success)
			{
				base.ClientBase.ThrowScriptException(scriptResult, script, text);
			}
			return text;
		}

		// Token: 0x04000022 RID: 34
		private ManagementObject _scriptInstance;

		// Token: 0x04000023 RID: 35
		private ManagementBaseObject _processScriptParameters;

		// Token: 0x04000024 RID: 36
		private ManagementBaseObject _deleteInterpreterParameters;

		// Token: 0x04000025 RID: 37
		private string _eventId;

		// Token: 0x04000026 RID: 38
		private string _interpreterId;

		// Token: 0x04000027 RID: 39
		private ManagementEventWatcher _eventWatcher;

		// Token: 0x04000028 RID: 40
		private ManagementScope _scope;

		// Token: 0x04000029 RID: 41
		private static string _processScriptMethodName = "ProcessScript";

		// Token: 0x0400002A RID: 42
		private static string _createInterpreterMethodName = "CreateInterpreter";

		// Token: 0x0400002B RID: 43
		private static string _deleteInterpreterMethodName = "DeleteInterpreter";
	}
}
