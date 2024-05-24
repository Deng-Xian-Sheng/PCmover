using System;
using System.ServiceModel;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;

namespace Laplink.Pcmover.ClientEngine
{
	// Token: 0x0200000D RID: 13
	[CallbackBehavior(IncludeExceptionDetailInFaults = true, UseSynchronizationContext = false, ValidateMustUnderstand = true, ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class PcmoverMonitorCallbackBase : IPcmoverMonitorCallback
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000097 RID: 151 RVA: 0x0000315D File Offset: 0x0000135D
		protected IPcmoverClientEngine Engine { get; }

		// Token: 0x06000098 RID: 152 RVA: 0x00003165 File Offset: 0x00001365
		public PcmoverMonitorCallbackBase(IPcmoverClientEngine engine)
		{
			this.Engine = engine;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00003174 File Offset: 0x00001374
		public virtual void ActivityChanged(ActivityInfo activityInfo, MonitorChangeType change)
		{
			Task.Run(delegate()
			{
				this.Engine.OnActivityChanged(activityInfo, change);
			});
		}

		// Token: 0x0600009A RID: 154 RVA: 0x000031A1 File Offset: 0x000013A1
		public virtual void MachineChanged(MachineData machineData, MonitorChangeType change)
		{
		}

		// Token: 0x0600009B RID: 155 RVA: 0x000031A3 File Offset: 0x000013A3
		public virtual void ActivityProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			Task.Run(delegate()
			{
				this.Engine.Progress(activityInfo, progressInfo);
			});
		}

		// Token: 0x0600009C RID: 156 RVA: 0x000031D0 File Offset: 0x000013D0
		public virtual void TaskChanged(PcmTaskData taskData, MonitorChangeType change)
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x000031D2 File Offset: 0x000013D2
		public virtual void TransferMethodChanged(TransferMethodData transferMethodData, MonitorChangeType change)
		{
		}

		// Token: 0x0600009E RID: 158 RVA: 0x000031D4 File Offset: 0x000013D4
		public virtual void PcmoverStatusChanged(PcmoverStatusInfo newStatusInfo)
		{
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000031D6 File Offset: 0x000013D6
		public virtual void PublicPropertyChanged(string key, string value)
		{
		}
	}
}
