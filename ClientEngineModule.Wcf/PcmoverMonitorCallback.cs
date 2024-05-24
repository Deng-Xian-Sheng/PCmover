using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;

namespace ClientEngineModule.Wcf
{
	// Token: 0x0200000B RID: 11
	[CallbackBehavior(IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false, ValidateMustUnderstand = true, ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class PcmoverMonitorCallback : IPcmoverMonitorCallback
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000146 RID: 326 RVA: 0x00006DB2 File Offset: 0x00004FB2
		protected PCmoverEngineLive Engine { get; }

		// Token: 0x06000147 RID: 327 RVA: 0x00006DBA File Offset: 0x00004FBA
		public PcmoverMonitorCallback(PCmoverEngineLive engine)
		{
			this.Engine = engine;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00006DCC File Offset: 0x00004FCC
		public void ActivityProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			if (!this.Engine._shuttingDown)
			{
				Task.Run(delegate()
				{
					this.Engine.Progress(activityInfo, progressInfo);
				});
			}
		}

		// Token: 0x06000149 RID: 329 RVA: 0x00006E13 File Offset: 0x00005013
		public void PcmoverStatusChanged(PcmoverStatusInfo statusInfo)
		{
			this.Engine.Ts.TraceCaller(TraceEventType.Verbose, statusInfo.ToString(), "PcmoverStatusChanged");
			this.Engine.NewPcmoverState(statusInfo.State);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00006E44 File Offset: 0x00005044
		public void ActivityChanged(ActivityInfo info, MonitorChangeType change)
		{
			try
			{
				if (!this.Engine._shuttingDown)
				{
					Task.Run(delegate()
					{
						this.Engine.OnActivityChanged(info, change);
					});
				}
			}
			catch (Exception ex)
			{
				this.Engine.Ts.TraceException(ex, "ActivityChanged");
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00006EB8 File Offset: 0x000050B8
		public void MachineChanged(MachineData machineData, MonitorChangeType change)
		{
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00006EBA File Offset: 0x000050BA
		public void TaskChanged(PcmTaskData taskData, MonitorChangeType change)
		{
		}

		// Token: 0x0600014D RID: 333 RVA: 0x00006EBC File Offset: 0x000050BC
		public void TransferMethodChanged(TransferMethodData transferMethodData, MonitorChangeType change)
		{
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00006EBE File Offset: 0x000050BE
		public void PublicPropertyChanged(string key, string value)
		{
		}
	}
}
