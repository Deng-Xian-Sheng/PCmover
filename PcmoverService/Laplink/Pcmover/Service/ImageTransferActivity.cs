using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200000C RID: 12
	public class ImageTransferActivity : PcmActivity, ITaskActivity, ITransferMethodActivity, ITransferParametersActivity
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000035C0 File Offset: 0x000017C0
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000035C8 File Offset: 0x000017C8
		public ServiceTask ActivityServiceTask { get; private set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000035D1 File Offset: 0x000017D1
		public ServiceTransferMethod ActivityServiceTransferMethod { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000035D9 File Offset: 0x000017D9
		public ServiceTask ActivityFillServiceTask { get; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000035E1 File Offset: 0x000017E1
		public bool ActivityAllowUndo { get; }

		// Token: 0x0600004A RID: 74 RVA: 0x000035E9 File Offset: 0x000017E9
		public ImageTransferActivity(PcmoverManager manager, ServiceTask serviceTask, bool allowUndo, ServiceTransferMethod stm) : base(ActivityType.Transfer, manager)
		{
			this.ActivityAllowUndo = allowUndo;
			this.ActivityFillServiceTask = serviceTask;
			this._fillVanTask = (serviceTask.Task as FillVanTask);
			this.ActivityServiceTransferMethod = stm;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(TransferActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000031A4 File Offset: 0x000013A4
		private void SetFailure(TransferActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000361C File Offset: 0x0000181C
		private bool DoTransfer()
		{
			bool flag = false;
			try
			{
				this.UpdatePhase(TransferActivityPhase.AuthorizingTransfer);
				if (!new AuthorizeTaskHelper(this, this.ActivityFillServiceTask, null).IsAuthorized())
				{
					this.SetFailure(TransferActivityFailureReason.SerialNumberRequired);
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.Initializing);
				this._unloadVanTask = this.m_app.CreateUnloadVanTask();
				if (this._unloadVanTask == null)
				{
					this.SetFailure(TransferActivityFailureReason.CreateTask);
					return false;
				}
				this.ActivityServiceTask = base.Manager.AddServiceTask(this._unloadVanTask, this.ActivityFillServiceTask.SrcServiceMachine, this.ActivityFillServiceTask.DstServiceMachine);
				this.m_ts.TraceInformation(string.Format("ImageTransfer ShouldCreateUndoFile: {0}", this.ActivityAllowUndo));
				this._unloadVanTask.ShouldCreateUndoFile = this.ActivityAllowUndo;
				this.UpdatePhase(TransferActivityPhase.ReadingHeader);
				if (!this._unloadVanTask.PrepareLiveToLive(this._fillVanTask))
				{
					this.SetFailure(TransferActivityFailureReason.ReadHeader);
					return false;
				}
				base.Manager.NotifyTaskChanged(this.ActivityServiceTask, MonitorChangeType.Changed);
				this._unloadVanTask.bUsePolicy = true;
				if (this.m_bCancel)
				{
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.ProcessingHeader);
				UiCallbacksHandler pCallbacks = new UiCallbacksHandler(this);
				if (!this._unloadVanTask.ProcessLiveToLivePrep(pCallbacks))
				{
					this.SetFailure(TransferActivityFailureReason.ProcessHeader);
					return false;
				}
				if (this.m_bCancel)
				{
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.ProcessingData);
				flag = this._unloadVanTask.FinishLiveToLiveUnload();
				if (!flag)
				{
					this.SetFailure(TransferActivityFailureReason.ProcessData);
				}
				this.UpdatePhase(TransferActivityPhase.SavingLog);
				this._unloadVanTask.CreateTaskFiles((TASK_FILES)11 | (flag ? TASK_FILES.TF_FAILURES : ((TASK_FILES)0)));
				this.UpdatePhase(TransferActivityPhase.ApplicationAutoRun);
				if (flag)
				{
					this._unloadVanTask.LaunchApplicationAutoRun(false);
				}
			}
			catch (Exception ex)
			{
				flag = false;
				base.TerminateOnException(ex, "DoTransfer");
			}
			return flag;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000037F4 File Offset: 0x000019F4
		protected override void Run()
		{
			this.m_bSuccess = this.DoTransfer();
		}

		// Token: 0x0400001F RID: 31
		private FillVanTask _fillVanTask;

		// Token: 0x04000020 RID: 32
		private UnloadVanTask _unloadVanTask;
	}
}
