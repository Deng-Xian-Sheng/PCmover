using System;
using System.ServiceModel;
using System.Threading;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ScriptApi
{
	// Token: 0x02000006 RID: 6
	public abstract class ScriptChannelBase : IScriptChannel
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000023EB File Offset: 0x000005EB
		public string HostName
		{
			get
			{
				return this.UriProperties.Host;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000023F8 File Offset: 0x000005F8
		public LlTraceSource Ts
		{
			get
			{
				return this.ClientBase.Ts;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x00002405 File Offset: 0x00000605
		// (set) Token: 0x06000019 RID: 25 RVA: 0x0000240D File Offset: 0x0000060D
		public bool CanFireEvents { get; protected set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00002416 File Offset: 0x00000616
		// (set) Token: 0x0600001B RID: 27 RVA: 0x0000241E File Offset: 0x0000061E
		public bool UseEvents
		{
			get
			{
				return this._useEvents;
			}
			set
			{
				if (value && !this.CanFireEvents)
				{
					throw new ArgumentException("UseEvents cannot be enabled if the channel cannot fire events");
				}
				this._useEvents = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000243D File Offset: 0x0000063D
		public TimeSpan PollTimeout { get; } = TimeSpan.FromSeconds(5.0);

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001D RID: 29 RVA: 0x00002445 File Offset: 0x00000645
		public LlUriProperties UriProperties { get; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001E RID: 30 RVA: 0x0000244D File Offset: 0x0000064D
		public ScriptClientBase ClientBase { get; }

		// Token: 0x0600001F RID: 31 RVA: 0x00002458 File Offset: 0x00000658
		public ScriptChannelBase(ScriptClientBase clientBase, Uri uri)
		{
			this.ClientBase = clientBase;
			this.UriProperties = new LlUriProperties(uri.Scheme);
			this.UriProperties.Uri = uri;
		}

		// Token: 0x06000020 RID: 32
		protected abstract void EstablishConnection();

		// Token: 0x06000021 RID: 33
		public abstract void CloseConnection();

		// Token: 0x06000022 RID: 34 RVA: 0x000024B7 File Offset: 0x000006B7
		protected virtual void SetupEvents()
		{
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000024B9 File Offset: 0x000006B9
		public void Open()
		{
			this.EstablishConnection();
			if (this.UseEvents)
			{
				this.SetupEvents();
			}
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000024CF File Offset: 0x000006CF
		public string InvokeScript(string script)
		{
			return this.DoInvokeScript(script, false);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000024DC File Offset: 0x000006DC
		private void CheckStateForInvoke(bool openingOk)
		{
			CommunicationState state = this.ClientBase.State;
			if (state == CommunicationState.Opened)
			{
				return;
			}
			if (openingOk && state == CommunicationState.Opening)
			{
				return;
			}
			if (state == CommunicationState.Faulted)
			{
				throw new CommunicationObjectFaultedException();
			}
			if (state == CommunicationState.Closed && this.ClientBase.IsAborted)
			{
				throw new CommunicationObjectAbortedException();
			}
			throw new CommunicationException(string.Format("Invalid state {0}", state));
		}

		// Token: 0x06000026 RID: 38
		protected abstract string ProcessScript(string script);

		// Token: 0x06000027 RID: 39 RVA: 0x00002538 File Offset: 0x00000738
		public string DoInvokeScript(string script, bool openingOk)
		{
			this.CheckStateForInvoke(openingOk);
			string result = this.ProcessScript(script);
			this.CheckStateForInvoke(openingOk);
			return result;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000254F File Offset: 0x0000074F
		public bool Poll(string script, Predicate<string> checkResult, out string result)
		{
			return this.Poll(script, checkResult, this.PollTimeout, out result);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002560 File Offset: 0x00000760
		public bool Poll(string script, Predicate<string> checkResult, TimeSpan timeout, out string result)
		{
			return this.DoPoll(script, checkResult, timeout, false, out result);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002570 File Offset: 0x00000770
		public bool DoPoll(string script, Predicate<string> checkResult, TimeSpan timeout, bool openingOk, out string result)
		{
			DateTime now = DateTime.Now;
			while (DateTime.Now - now < timeout)
			{
				result = this.DoInvokeScript(script, openingOk);
				if (checkResult(result))
				{
					return true;
				}
				Thread.Sleep(this._pollSleepTime);
			}
			this.Ts.TraceError("Timeout polling " + script);
			result = string.Empty;
			return false;
		}

		// Token: 0x04000007 RID: 7
		private bool _useEvents;

		// Token: 0x04000009 RID: 9
		protected TimeSpan _pollSleepTime = TimeSpan.FromMilliseconds(250.0);
	}
}
