using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000031 RID: 49
	public class UndoActivity : PcmActivity, ITaskActivity
	{
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000249 RID: 585 RVA: 0x000109C1 File Offset: 0x0000EBC1
		// (set) Token: 0x0600024A RID: 586 RVA: 0x000109C9 File Offset: 0x0000EBC9
		public ServiceTask ActivityServiceTask { get; private set; }

		// Token: 0x0600024B RID: 587 RVA: 0x000109D2 File Offset: 0x0000EBD2
		public UndoActivity(PcmoverManager manager) : base(ActivityType.Undo, manager)
		{
		}

		// Token: 0x0600024C RID: 588 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(UndoActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00002799 File Offset: 0x00000999
		private void SetFailure(UndoActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
			this.m_bSuccess = false;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x000109E0 File Offset: 0x0000EBE0
		protected override void Run()
		{
			this.m_bSuccess = false;
			try
			{
				this.UpdatePhase(UndoActivityPhase.Initializing);
				this._unloadVanTask = this.m_app.CreateUnloadVanTask();
				if (this._unloadVanTask == null)
				{
					this.SetFailure(UndoActivityFailureReason.CreateTask);
				}
				else
				{
					this.ActivityServiceTask = base.Manager.AddServiceTask(this._unloadVanTask, null, null);
					if (!this.m_bCancel)
					{
						this._unloadVanTask.bUsePolicy = true;
						this.UpdatePhase(UndoActivityPhase.ReadingHeader);
						if (!this._unloadVanTask.LoadUndoHeader())
						{
							this.SetFailure(UndoActivityFailureReason.ReadHeader);
						}
						else if (!this.m_bCancel)
						{
							base.Manager.NotifyTaskChanged(this.ActivityServiceTask, MonitorChangeType.Changed);
							this.UpdatePhase(UndoActivityPhase.ProcessingHeader);
							UiCallbacksHandler pCallbacks = new UiCallbacksHandler(this);
							if (!this._unloadVanTask.ProcessMovingVanHeader(pCallbacks))
							{
								this.SetFailure(UndoActivityFailureReason.ProcessHeader);
							}
							else if (!this.m_bCancel)
							{
								this.UpdatePhase(UndoActivityPhase.ProcessingData);
								this.m_bSuccess = this._unloadVanTask.FinishUndo();
								if (!this.m_bSuccess)
								{
									this.SetFailure(UndoActivityFailureReason.ProcessData);
								}
								this.UpdatePhase(UndoActivityPhase.SavingLog);
								this._unloadVanTask.CreateTaskFiles((TASK_FILES)3 | (this.m_bSuccess ? TASK_FILES.TF_FAILURES : ((TASK_FILES)0)));
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.m_bSuccess = false;
				base.TerminateOnException(ex, "Run");
			}
		}

		// Token: 0x040000BA RID: 186
		private UnloadVanTask _unloadVanTask;
	}
}
