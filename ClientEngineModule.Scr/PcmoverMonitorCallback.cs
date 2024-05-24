using System;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;

namespace ClientEngineModule.Scr
{
	// Token: 0x02000007 RID: 7
	[CallbackBehavior(IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false, ValidateMustUnderstand = true, ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class PcmoverMonitorCallback : IPcmoverMonitorCallback
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00005793 File Offset: 0x00003993
		protected PCmoverEngineScr Engine { get; }

		// Token: 0x06000112 RID: 274 RVA: 0x0000579B File Offset: 0x0000399B
		public PcmoverMonitorCallback(PCmoverEngineScr engine)
		{
			this.Engine = engine;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000057AC File Offset: 0x000039AC
		public void ActivityProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			if (!this.Engine._shuttingDown)
			{
				Task.Run(delegate()
				{
					this.Engine.Progress(activityInfo, progressInfo);
				});
				this.Engine.FireActivityProgressEvent(activityInfo, progressInfo);
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000580A File Offset: 0x00003A0A
		public void PcmoverStatusChanged(PcmoverStatusInfo statusInfo)
		{
			this.Engine.Ts.TraceCaller(TraceEventType.Verbose, statusInfo.ToString(), "PcmoverStatusChanged");
			this.Engine.NewPcmoverState(statusInfo.State);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000583C File Offset: 0x00003A3C
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

		// Token: 0x06000116 RID: 278 RVA: 0x000058B0 File Offset: 0x00003AB0
		public void MachineChanged(MachineData machineData, MonitorChangeType change)
		{
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000058B2 File Offset: 0x00003AB2
		public void TaskChanged(PcmTaskData taskData, MonitorChangeType change)
		{
		}

		// Token: 0x06000118 RID: 280 RVA: 0x000058B4 File Offset: 0x00003AB4
		public void TransferMethodChanged(TransferMethodData transferMethodData, MonitorChangeType change)
		{
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000058B6 File Offset: 0x00003AB6
		public void PublicPropertyChanged(string key, string value)
		{
		}
	}
}
