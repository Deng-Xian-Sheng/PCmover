using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000014 RID: 20
	internal class GetSnapshotActivity : PcmProtocolBase, IMachineActivity
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600006B RID: 107 RVA: 0x00003CA3 File Offset: 0x00001EA3
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00003CAB File Offset: 0x00001EAB
		public ServiceMachine ActivityServiceMachine { get; private set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00003CB4 File Offset: 0x00001EB4
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00003CBC File Offset: 0x00001EBC
		public int SleepTimeWaitingForSnapshot { get; set; } = 5000;

		// Token: 0x0600006F RID: 111 RVA: 0x00003CC5 File Offset: 0x00001EC5
		public GetSnapshotActivity(PcmoverManager manager, ServiceTransferMethod stm) : base(ActivityType.GetSnapshot, manager, stm)
		{
			this.m_protocol.IsNewComputer = true;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00003CE8 File Offset: 0x00001EE8
		public override bool Start()
		{
			bool result;
			lock (this)
			{
				if (this.m_protocol == null || this.m_task != null)
				{
					result = false;
				}
				else
				{
					this.m_app.CurMigrationStatus.state = MS_STATE.STATE_ADD;
					this.m_protocol.Cleanup();
					result = base.Start();
				}
			}
			return result;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00003D58 File Offset: 0x00001F58
		private void UpdatePhase(GetSnapshotActivityPhase newPhase)
		{
			if (this.Info.Phase != (int)newPhase)
			{
				this.Info.Phase = (int)newPhase;
				base.NotifyActivityInfoChanged();
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000031A4 File Offset: 0x000013A4
		private void SetFailure(GetSnapshotActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00003D7C File Offset: 0x00001F7C
		private bool GetSnapshot()
		{
			if (this.m_connectionMethod == null)
			{
				return false;
			}
			bool result;
			try
			{
				this.m_bKeepAlive = true;
				if (!this.m_connectionMethod.IsOpen())
				{
					this.UpdatePhase(GetSnapshotActivityPhase.Connecting);
					if (!this.m_connectionMethod.MakeConnection())
					{
						this.m_bKeepAlive = false;
						if (!this.m_bCancel)
						{
							this.SetFailure(GetSnapshotActivityFailureReason.FailedToConnect);
						}
						return false;
					}
				}
				this.m_bKeepAlive = false;
				if (this.m_bCancel)
				{
					result = false;
				}
				else
				{
					this.UpdatePhase(GetSnapshotActivityPhase.CheckingVersion);
					if (!base.ValidateRemoteVersion())
					{
						result = false;
					}
					else
					{
						string text = "<OptionalData>";
						string friendlyName = this.m_app.ThisMachine.FriendlyName;
						if (friendlyName != null && friendlyName.Length != 0)
						{
							text = text + "<fn>" + UserData.createCDATA(friendlyName) + "</fn>";
						}
						text += "</OptionalData>";
						byte[] bytes = UserData.encoding.GetBytes(text);
						if (bytes.Length != 0 && (!this.m_protocol.SendCommandWithData(CommandType.CMD_OPTIONALDATA, ref bytes[0], (uint)bytes.Length) || !this.m_protocol.GetAck()))
						{
							this.SetFailure(GetSnapshotActivityFailureReason.VersionVerificationFailed);
							result = false;
						}
						else if (this.m_bCancel)
						{
							result = false;
						}
						else
						{
							this.UpdatePhase(GetSnapshotActivityPhase.RequestingSnapshot);
							bool flag = true;
							while (flag)
							{
								if (!this.m_protocol.SendCommandPacket(this.m_protocol.CreateCommandPacket(CommandType.CMD_TAKESNAPSHOT)))
								{
									this.SetFailure(GetSnapshotActivityFailureReason.CommunicationError);
									return false;
								}
								if (this.m_bCancel)
								{
									return false;
								}
								if (this.m_protocol.GetAck())
								{
									flag = false;
								}
								else
								{
									if (this.m_bCancel)
									{
										return false;
									}
									this.UpdatePhase(GetSnapshotActivityPhase.WaitingForSnapshotReady);
									if (this.m_cancelEvent.WaitOne(this.SleepTimeWaitingForSnapshot))
									{
										return false;
									}
								}
							}
							if (this.m_bCancel)
							{
								result = false;
							}
							else
							{
								this.UpdatePhase(GetSnapshotActivityPhase.ReceivingSnapshot);
								this._remoteMachine = this.m_app.CreateMachine();
								if (!this._remoteMachine.Load((TransferMethod)this.m_connectionMethod))
								{
									this._remoteMachine.dispose();
									this._remoteMachine = null;
									this.SetFailure(GetSnapshotActivityFailureReason.GetSnapshotFailed);
									result = false;
								}
								else
								{
									this.ActivityServiceMachine = base.Manager.GetServiceMachine(this._remoteMachine);
									if (this.m_protocol.SendCommandPacket(this.m_protocol.CreateCommandPacket(CommandType.CMD_SYNC)) && this.m_protocol.GetAck())
									{
										this.m_bKeepAlive = true;
									}
									result = true;
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				base.TerminateOnException(ex, "GetSnapshot");
				result = false;
			}
			finally
			{
				if (!this.m_bKeepAlive)
				{
					try
					{
						if (this.m_connectionMethod.IsOpen())
						{
							this.m_connectionMethod.CloseConnection();
						}
					}
					catch
					{
					}
				}
			}
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00004064 File Offset: 0x00002264
		protected override void Run()
		{
			this.m_bSuccess = this.GetSnapshot();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004072 File Offset: 0x00002272
		protected override void OnCancel()
		{
			base.OnCancel();
			this.m_connectionMethod.CloseConnection();
		}

		// Token: 0x04000032 RID: 50
		private Machine _remoteMachine;
	}
}
