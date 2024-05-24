using System;
using System.Threading;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200002D RID: 45
	internal class TransferActivity : PcmProtocolBase, ITaskActivity, ITransferParametersActivity
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600021F RID: 543 RVA: 0x0000FC89 File Offset: 0x0000DE89
		// (set) Token: 0x06000220 RID: 544 RVA: 0x0000FC91 File Offset: 0x0000DE91
		public ServiceTask ActivityServiceTask { get; private set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000221 RID: 545 RVA: 0x0000FC9A File Offset: 0x0000DE9A
		public ServiceTask ActivityFillServiceTask { get; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000222 RID: 546 RVA: 0x0000FCA2 File Offset: 0x0000DEA2
		public bool ActivityAllowUndo { get; }

		// Token: 0x06000223 RID: 547 RVA: 0x0000FCAA File Offset: 0x0000DEAA
		public TransferActivity(PcmoverManager manager, ServiceTransferMethod stm, ServiceTask fillServiceTask, bool allowUndo) : base(ActivityType.Transfer, manager, stm)
		{
			this.ActivityAllowUndo = allowUndo;
			this.ActivityFillServiceTask = fillServiceTask;
			this._fillVanTask = (fillServiceTask.Task as FillVanTask);
			this.m_protocol.IsNewComputer = true;
		}

		// Token: 0x06000224 RID: 548 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(TransferActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x06000225 RID: 549 RVA: 0x000031A4 File Offset: 0x000013A4
		private void SetFailure(TransferActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000FCE4 File Offset: 0x0000DEE4
		private bool SendJournal()
		{
			if (!this.m_protocol.SendCommandPacket(this.m_protocol.CreateCommandPacket(CommandType.CMD_ACCEPTJOURNAL)))
			{
				this.SetFailure(TransferActivityFailureReason.CommunicationError);
				return false;
			}
			if (this.m_bCancel)
			{
				return false;
			}
			if (!this.m_protocol.GetAck() || !this._fillVanTask.Save((TransferMethod)this.m_connectionMethod, MACHINE_DETAIL.MD_ID, MACHINE_DETAIL.MD_FULL))
			{
				this.SetFailure(TransferActivityFailureReason.SendJournalFailed);
				return false;
			}
			this.m_protocol.GetAck();
			return true;
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000FD5C File Offset: 0x0000DF5C
		private bool MakeConnection()
		{
			if (!this.m_connectionMethod.IsOpen())
			{
				int num = 0;
				while (!this.m_bCancel && num < 5)
				{
					this.m_connectionMethod.CloseConnection();
					if (this.m_bCancel)
					{
						break;
					}
					Thread.Sleep(1000);
					if (this.m_bCancel)
					{
						break;
					}
					this.UpdatePhase(TransferActivityPhase.Connecting);
					if (this.m_connectionMethod.MakeConnection())
					{
						break;
					}
					num++;
				}
				if (!this.m_connectionMethod.IsOpen())
				{
					if (!this.m_bCancel)
					{
						this.SetFailure(TransferActivityFailureReason.FailedToConnect);
					}
					return false;
				}
			}
			this.UpdatePhase(TransferActivityPhase.CheckingVersion);
			return base.ValidateRemoteVersion();
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000FDF0 File Offset: 0x0000DFF0
		private bool DoTransfer()
		{
			bool flag = false;
			try
			{
				this.m_bKeepAlive = true;
				if (!this.MakeConnection())
				{
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.AuthorizingTransfer);
				if (!new AuthorizeTaskHelper(this, this.ActivityFillServiceTask, this.m_protocol).IsAuthorized())
				{
					this.SetFailure(TransferActivityFailureReason.SerialNumberRequired);
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.SendingJournal);
				if (!this.SendJournal())
				{
					return false;
				}
				while (!this.m_bCancel)
				{
					this.UpdatePhase(TransferActivityPhase.ReceivingVan);
					if (this.m_protocol.SendFillCommand())
					{
						break;
					}
					if (!this.MakeConnection())
					{
						return false;
					}
				}
				if (this.m_bCancel)
				{
					return false;
				}
				this.UpdatePhase(TransferActivityPhase.Initializing);
				this._unloadVanTask = this.m_app.CreateUnloadVanTask();
				if (this._unloadVanTask == null)
				{
					this.SetFailure(TransferActivityFailureReason.CreateTask);
					return false;
				}
				this._unloadVanTask.SetSrcMachine(this.ActivityFillServiceTask.SrcServiceMachine.PcmMachine);
				this.ActivityServiceTask = base.Manager.AddServiceTask(this._unloadVanTask, this.ActivityFillServiceTask.SrcServiceMachine, base.Manager.ThisServiceMachine);
				this.m_ts.TraceInformation(string.Format("Transfer ShouldCreateUndoFile: {0}", this.ActivityAllowUndo));
				this._unloadVanTask.ShouldCreateUndoFile = this.ActivityAllowUndo;
				if (this.m_bCancel)
				{
					return false;
				}
				this._unloadVanTask.bUsePolicy = true;
				this.UpdatePhase(TransferActivityPhase.ReadingHeader);
				if (!this._unloadVanTask.LoadMovingVanHeader((TransferMethod)this.m_connectionMethod))
				{
					this.SetFailure(TransferActivityFailureReason.ReadHeader);
					return false;
				}
				if (this.m_bCancel)
				{
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
				if (this._unloadVanTask.TransferResult != CHANGE_PROCESS_ERROR.CPE_CONNECTION)
				{
					this.SendEnd();
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
			finally
			{
				if (this.m_bCancel && this.Info.FailureReason == 0)
				{
					flag = false;
					this.SetFailure(TransferActivityFailureReason.Cancelled);
				}
			}
			return flag;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000100A0 File Offset: 0x0000E2A0
		protected override void Run()
		{
			this.m_bSuccess = this.DoTransfer();
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000100B0 File Offset: 0x0000E2B0
		private void SendEnd()
		{
			try
			{
				if (this.m_connectionMethod.IsOpen() || this.MakeConnection())
				{
					if (!this.m_bCancel)
					{
						this.UpdatePhase(TransferActivityPhase.SendingEnd);
						if (this.m_protocol.SendCommandPacket(this.m_protocol.CreateCommandPacket(CommandType.CMD_END)))
						{
							this.m_protocol.GetAck();
						}
					}
					this.m_connectionMethod.CloseConnection();
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x040000A2 RID: 162
		private readonly FillVanTask _fillVanTask;

		// Token: 0x040000A3 RID: 163
		private UnloadVanTask _unloadVanTask;
	}
}
