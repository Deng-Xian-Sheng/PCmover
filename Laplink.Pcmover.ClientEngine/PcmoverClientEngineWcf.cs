using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using Laplink.Pcmover.Proxies;
using Laplink.PcmoverService.Infrastructure;
using Laplink.Tools.Helpers;
using Laplink.Tools.Helpers.Wcf;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x0200000B RID: 11
	public class PcmoverClientEngineWcf : PcmoverClientEngine<PcmoverControlClient>
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00002DEC File Offset: 0x00000FEC
		protected virtual IEnumerable<BindingFactory> GetStandardBindingFactories()
		{
			return new ServiceBindingFactories_S20();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00002DF3 File Offset: 0x00000FF3
		public PcmoverClientEngineWcf(LlTraceSource ts) : base(ts)
		{
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00002DFC File Offset: 0x00000FFC
		protected virtual bool ConnectToPcmoverControl(EndpointAddress endpointAddress)
		{
			try
			{
				base.Ts.TraceInformation("Creating the proxy");
				this.PcmoverControlProxy = this.CreatePcmoverControlProxy(endpointAddress, new InstanceContext(this.PcmoverControlCallback), this.GetStandardBindingFactories());
				base.Ts.TraceInformation("Opening the proxy");
				this.PcmoverControlProxy.Open();
				base.Ts.TraceInformation("Connection succeeded");
			}
			catch (SystemException ex) when (ex is EndpointNotFoundException || ex is TimeoutException)
			{
				base.Ts.TraceException(ex, "ConnectToPcmoverControl");
				this.PcmoverControlProxy = null;
				return false;
			}
			return true;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002EBC File Offset: 0x000010BC
		protected PcmoverControlClient CreatePcmoverControlProxy(EndpointAddress endpointAddress, InstanceContext instanceContext, IEnumerable<BindingFactory> factories)
		{
			PcmoverControlClient pcmoverControlClient = null;
			if (endpointAddress != null)
			{
				PcmoverControlEndpoint pcmoverControlEndpoint = new PcmoverControlEndpoint(factories)
				{
					Uri = endpointAddress.Uri
				};
				if (pcmoverControlEndpoint.Binding != null && pcmoverControlEndpoint.IsValidContract)
				{
					pcmoverControlClient = new PcmoverControlClient(instanceContext, pcmoverControlEndpoint.Binding, endpointAddress);
					pcmoverControlClient.ClientCredentials.Windows.AllowedImpersonationLevel = TokenImpersonationLevel.Delegation;
				}
			}
			return pcmoverControlClient;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00002F18 File Offset: 0x00001118
		protected bool LoadServiceDirectly(EndpointAddress endpointAddress)
		{
			string host = endpointAddress.Uri.Host;
			if (string.Compare(host, "localhost", true) != 0 && string.Compare(host, NetworkHelper.LocalHostName, true) != 0)
			{
				base.Ts.TraceCaller("Not loading because the host name, " + host + ", is not localhost", "LoadServiceDirectly");
				return false;
			}
			string pcmoverHostPath = this.GetPcmoverHostPath();
			string str = Guid.NewGuid().ToString();
			string text = "PcmService.FromPcmover.Stop." + str;
			string text2 = "PcmServiceReady." + str;
			this._signalStopEvent = new EventWaitHandle(false, EventResetMode.ManualReset, text);
			EventWaitHandle eventWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset, text2);
			string arguments = text + " " + text2;
			try
			{
				Process process = Process.Start(pcmoverHostPath, arguments);
				if (process != null)
				{
					eventWaitHandle.WaitOne(60000);
					if (this.ConnectToPcmoverControl(endpointAddress))
					{
						return true;
					}
					if (process != null)
					{
						process.Kill();
					}
				}
			}
			catch (Exception ex)
			{
				base.Ts.TraceException(ex, "LoadServiceDirectly");
			}
			this._signalStopEvent.Dispose();
			this._signalStopEvent = null;
			return false;
		}

		// Token: 0x04000028 RID: 40
		protected EventWaitHandle _signalStopEvent;
	}
}
