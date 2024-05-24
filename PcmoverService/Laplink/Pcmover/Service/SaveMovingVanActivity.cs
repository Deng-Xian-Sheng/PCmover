using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200001E RID: 30
	public class SaveMovingVanActivity : PcmActivity, ITaskActivity, ITransferMethodActivity
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000EF4C File Offset: 0x0000D14C
		public ServiceTask ActivityServiceTask { get; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x0000EF54 File Offset: 0x0000D154
		public ServiceTransferMethod ActivityServiceTransferMethod
		{
			get
			{
				return this._ftm;
			}
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x0000EF5C File Offset: 0x0000D15C
		public SaveMovingVanActivity(PcmoverManager manager, ServiceFileTransferMethod ftm, ServiceTask serviceTask) : base(ActivityType.SaveMovingVan, manager)
		{
			this._ftm = ftm;
			this.ActivityServiceTask = serviceTask;
			this._fillTask = (serviceTask.Task as FillVanTask);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(SaveMovingVanActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x0000EF88 File Offset: 0x0000D188
		protected override void Run()
		{
			this.UpdatePhase(SaveMovingVanActivityPhase.StartingTransfer);
			this.m_bSuccess = this._fillTask.FillMovingVan((TransferMethod)this._ftm.FileTransferMethod, MACHINE_DETAIL.MD_SNAPSHOT);
			if (this.m_bSuccess)
			{
				this.UpdatePhase(SaveMovingVanActivityPhase.FinishedTransfer);
			}
			else
			{
				this.UpdatePhase(SaveMovingVanActivityPhase.FinishedTransferWithError);
			}
			this.UpdatePhase(SaveMovingVanActivityPhase.SavingLog);
			this._fillTask.CreateTaskFiles((TASK_FILES)3 | (this.m_bSuccess ? TASK_FILES.TF_FAILURES : ((TASK_FILES)0)));
		}

		// Token: 0x0400007D RID: 125
		private readonly ServiceFileTransferMethod _ftm;

		// Token: 0x0400007E RID: 126
		private readonly FillVanTask _fillTask;
	}
}
