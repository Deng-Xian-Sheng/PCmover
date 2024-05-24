using System;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;

namespace ClientEngineModule.Wcf
{
	// Token: 0x0200000D RID: 13
	public class TransferActivityClient : ActivityClient
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000156 RID: 342 RVA: 0x0000714C File Offset: 0x0000534C
		private PCmoverEngineLive Engine
		{
			get
			{
				return (PCmoverEngineLive)base.ClientEngine;
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00007159 File Offset: 0x00005359
		public TransferActivityClient(PCmoverEngineLive engine) : base(engine)
		{
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00007178 File Offset: 0x00005378
		public override void OnProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			TransferProgressInfo transferProgressInfo = new TransferProgressInfo();
			transferProgressInfo.ProgressInfo = progressInfo;
			transferProgressInfo.CurrentCategory = progressInfo.Action;
			transferProgressInfo.CurrentItem = progressInfo.Item;
			transferProgressInfo.TotalItems = this.bogusTransferTotalItems;
			int itemsRemaining = this.bogusTransferItemsRemaining - 1;
			this.bogusTransferItemsRemaining = itemsRemaining;
			transferProgressInfo.ItemsRemaining = itemsRemaining;
			transferProgressInfo.ActivityInfo = activityInfo;
			TransferProgressInfo transferProgressInfo2 = transferProgressInfo;
			DateTime startTimeUtc = activityInfo.StartTimeUtc;
			DateTime timeStampUtc = progressInfo.TimeStampUtc;
			transferProgressInfo2.ElapsedTime = timeStampUtc - startTimeUtc;
			if (progressInfo.Percentage >= 2)
			{
				TimeSpan t = TimeSpan.FromTicks(transferProgressInfo2.ElapsedTime.Ticks / (long)((ulong)progressInfo.Percentage) * 100L);
				transferProgressInfo2.EstimatedTimeRemaining = t - transferProgressInfo2.ElapsedTime;
			}
			this.Engine.TransferInfo = transferProgressInfo2;
			this.Engine.EventAggregator.GetEvent<EngineEvents.TransferProgressChanged>().Publish(transferProgressInfo2);
			base.OnProgress(activityInfo, progressInfo);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00007258 File Offset: 0x00005458
		public override void OnDone(ActivityInfo info)
		{
			this.Engine.CatchCommEx(delegate
			{
				if (this.Handle == -1)
				{
					PcmTaskType type = PcmTaskType.Unload;
					if (this.Type == ActivityType.SaveMovingVan)
					{
						type = PcmTaskType.Fill;
					}
					PcmTaskData task = this.Engine.ServiceData.GetTask(type);
					if (task == null)
					{
						this.Ts.TraceCaller("Cannot find resulting task", "OnDone");
						return;
					}
					this.Engine._transferTaskHandle = task.Handle;
				}
				else
				{
					this.Engine._transferTaskHandle = this.ControlInterface.GetActivityTaskHandle(this.Handle);
				}
				TransferProcessResult taskTransferResult = this.ControlInterface.GetTaskTransferResult(this.Engine._transferTaskHandle);
				TransferCompleteInfo transferCompleteInfo = new TransferCompleteInfo
				{
					ActivityInfo = info,
					TransferResult = taskTransferResult,
					Stats = this.ControlInterface.TaskGetStats(this.Engine._transferTaskHandle, true)
				};
				if (transferCompleteInfo.TransferSucceeded)
				{
					this.Engine.GenerateTransferReports();
				}
				this.Engine.SendAlerts(TaskAlertData.AlertType.Done, this.Engine.InteractiveDoneAlert, taskTransferResult);
				this.Engine.EventAggregator.GetEvent<EngineEvents.TransferComplete>().Publish(transferCompleteInfo);
				this.<>n__0(info);
			}, "OnDone");
		}

		// Token: 0x04000054 RID: 84
		private int bogusTransferTotalItems = 2000;

		// Token: 0x04000055 RID: 85
		private int bogusTransferItemsRemaining = 2000;
	}
}
