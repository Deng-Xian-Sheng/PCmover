using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200000A RID: 10
	public class FileTransferActivity : PcmActivity, ITaskActivity, ITransferMethodActivity, ITransferParametersActivity
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00003168 File Offset: 0x00001368
		// (set) Token: 0x06000037 RID: 55 RVA: 0x00003170 File Offset: 0x00001370
		public ServiceTask ActivityServiceTask { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00003179 File Offset: 0x00001379
		public ServiceTransferMethod ActivityServiceTransferMethod
		{
			get
			{
				return this._ftm;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003181 File Offset: 0x00001381
		public ServiceTask ActivityFillServiceTask
		{
			get
			{
				return null;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00003184 File Offset: 0x00001384
		public bool ActivityAllowUndo { get; }

		// Token: 0x0600003B RID: 59 RVA: 0x0000318C File Offset: 0x0000138C
		public FileTransferActivity(PcmoverManager manager, ServiceFileTransferMethod ftm, bool allowUndo) : base(ActivityType.Transfer, manager)
		{
			this.ActivityAllowUndo = allowUndo;
			this._ftm = ftm;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(TransferActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000031A4 File Offset: 0x000013A4
		private void SetFailure(TransferActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000031B4 File Offset: 0x000013B4
		private bool DoTransfer()
		{
			bool flag = false;
			try
			{
				this.UpdatePhase(TransferActivityPhase.Initializing);
				this._unloadVanTask = this.m_app.CreateUnloadVanTask();
				if (this._unloadVanTask == null)
				{
					this.SetFailure(TransferActivityFailureReason.CreateTask);
					return false;
				}
				this._unloadVanTask.bUsePolicy = true;
				this.m_ts.TraceInformation(string.Format("FileTransfer ShouldCreateUndoFile: {0}", this.ActivityAllowUndo));
				this._unloadVanTask.ShouldCreateUndoFile = this.ActivityAllowUndo;
				if (this.m_bCancel)
				{
					return false;
				}
				this.ActivityServiceTask = base.Manager.AddServiceTask(this._unloadVanTask, null, base.Manager.ThisServiceMachine);
				this.UpdatePhase(TransferActivityPhase.ReadingHeader);
				this._ftm.FileTransferMethod.Span = true;
				if (!this._unloadVanTask.LoadMovingVanHeader((TransferMethod)this._ftm.FileTransferMethod))
				{
					this.SetFailure(TransferActivityFailureReason.ReadHeader);
					return false;
				}
				base.Manager.NotifyTaskChanged(this.ActivityServiceTask, MonitorChangeType.Changed);
				this.UpdatePhase(TransferActivityPhase.AuthorizingTransfer);
				if (!new AuthorizeTaskHelper(this, this.ActivityServiceTask, null).IsAuthorized())
				{
					this.SetFailure(TransferActivityFailureReason.SerialNumberRequired);
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.ProcessingHeader);
				UiCallbacksHandler pCallbacks = new UiCallbacksHandler(this);
				if (!this._unloadVanTask.ProcessMovingVanHeader(pCallbacks))
				{
					this.SetFailure(TransferActivityFailureReason.ProcessHeader);
					return false;
				}
				if (this.m_bCancel)
				{
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.ProcessingData);
				flag = this._unloadVanTask.FinishMovingVanUnload();
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

		// Token: 0x0600003F RID: 63 RVA: 0x0000339C File Offset: 0x0000159C
		protected override void Run()
		{
			this.m_bSuccess = this.DoTransfer();
		}

		// Token: 0x04000018 RID: 24
		private ServiceFileTransferMethod _ftm;

		// Token: 0x04000019 RID: 25
		private UnloadVanTask _unloadVanTask;
	}
}
