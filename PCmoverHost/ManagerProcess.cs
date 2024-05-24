using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading;
using Laplink.Download.Service;
using Laplink.Pcmover.Service;
using Laplink.Service.Infrastructure;
using Laplink.Tools.Helpers;

namespace Laplink.Pcmover.Hosts.ExternalProcess
{
	// Token: 0x02000002 RID: 2
	internal class ManagerProcess
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static int Main(string[] args)
		{
			return new ManagerProcess().Run(args);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205D File Offset: 0x0000025D
		private ManagerProcess()
		{
			this.Ts.InitLoggingFromAppData("Laplink\\PCmover\\PcmoverHost.log");
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002094 File Offset: 0x00000294
		private int Run(string[] args)
		{
			this.Ts.TraceInformation("Starting host");
			EventWaitHandle eventWaitHandle = null;
			if (args.Length != 0)
			{
				try
				{
					string text = args[0];
					this.Ts.TraceVerbose("Stop Request event name: " + text);
					if (!string.IsNullOrWhiteSpace(text))
					{
						this._stopRequestEvent = EventWaitHandle.OpenExisting(text);
					}
				}
				catch (Exception ex)
				{
					this.Ts.TraceException(ex, "Run");
				}
				if (args.Length <= 1)
				{
					goto IL_B4;
				}
				try
				{
					string text2 = args[1];
					this.Ts.TraceVerbose("Notify Ready event name: " + text2);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						eventWaitHandle = EventWaitHandle.OpenExisting(text2);
					}
					goto IL_B4;
				}
				catch (Exception ex2)
				{
					this.Ts.TraceException(ex2, "Run");
					goto IL_B4;
				}
			}
			this.Ts.TraceVerbose("No command line parameters");
			IL_B4:
			try
			{
				if (!this.StartService())
				{
					return 1;
				}
			}
			catch (Exception ex3)
			{
				this.Ts.TraceException(ex3, "Run");
				this.Ts.TraceEvent(TraceEventType.Critical, "Exiting due to unexpected exception starting the service");
				return 1;
			}
			if (eventWaitHandle != null)
			{
				eventWaitHandle.Set();
				eventWaitHandle = null;
			}
			this.Ts.TraceInformation("Start waiting");
			if (this._stopRequestEvent == null)
			{
				this._exitEvent.WaitOne();
				this.Ts.TraceInformation("WaitOne completed");
			}
			else
			{
				int num = WaitHandle.WaitAny(new WaitHandle[]
				{
					this._exitEvent,
					this._stopRequestEvent
				});
				this.Ts.TraceInformation(string.Format("WaitAny returned {0}", num));
				if (num == 1)
				{
					this.StopService();
				}
			}
			this.Ts.TraceInformation("Exiting normally");
			return 0;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000225C File Offset: 0x0000045C
		private bool StartService()
		{
			this._pcmoverManager = new PcmoverManager().ServiceManager;
			this._pcmoverManager.EnabledSettingName = "ServiceLoggingEnabled";
			this._pcmoverManager.PreviousLogFileSettingName = "ServicePreviousLogFile";
			this._pcmoverManager.ExitEvent = this._exitEvent;
			this._pcmoverServiceHost = this._pcmoverManager.CreateServiceHost();
			if (this._pcmoverServiceHost == null)
			{
				this.Ts.TraceError("No PCmover Service Host");
				return false;
			}
			IServiceManager serviceManager = new DownloadManager().ServiceManager;
			serviceManager.EnabledSettingName = "DownloadLoggingEnabled";
			serviceManager.PreviousLogFileSettingName = "DownloadPreviousLogFile";
			this._downloadServiceHost = serviceManager.CreateServiceHost();
			if (this._downloadServiceHost == null)
			{
				this.Ts.TraceError("No PCmover Download Host");
				this.StopService();
				return false;
			}
			this.Ts.TraceVerbose("Service hosts created");
			return true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002334 File Offset: 0x00000534
		private void StopService()
		{
			IServiceManager pcmoverManager = this._pcmoverManager;
			if (pcmoverManager != null)
			{
				pcmoverManager.OnStop();
			}
			ServiceHost pcmoverServiceHost = this._pcmoverServiceHost;
			if (pcmoverServiceHost != null)
			{
				pcmoverServiceHost.Close();
			}
			this._pcmoverServiceHost = null;
			this._pcmoverManager = null;
			ServiceHost downloadServiceHost = this._downloadServiceHost;
			if (downloadServiceHost != null)
			{
				downloadServiceHost.Close();
			}
			this._downloadServiceHost = null;
		}

		// Token: 0x04000001 RID: 1
		private ServiceHost _pcmoverServiceHost;

		// Token: 0x04000002 RID: 2
		private ServiceHost _downloadServiceHost;

		// Token: 0x04000003 RID: 3
		private IServiceManager _pcmoverManager;

		// Token: 0x04000004 RID: 4
		private ManualResetEvent _exitEvent = new ManualResetEvent(false);

		// Token: 0x04000005 RID: 5
		private EventWaitHandle _stopRequestEvent;

		// Token: 0x04000006 RID: 6
		private readonly LlTraceSource Ts = new LlTraceSource("PcmoverHost");
	}
}
