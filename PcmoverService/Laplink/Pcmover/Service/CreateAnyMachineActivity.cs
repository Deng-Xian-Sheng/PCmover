using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000005 RID: 5
	public class CreateAnyMachineActivity : PcmActivity, IMachineActivity, ITransferMethodActivity
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000011 RID: 17 RVA: 0x0000276F File Offset: 0x0000096F
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002777 File Offset: 0x00000977
		public ServiceMachine ActivityServiceMachine { get; private set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002780 File Offset: 0x00000980
		public ServiceTransferMethod ActivityServiceTransferMethod
		{
			get
			{
				return this._ftm;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002788 File Offset: 0x00000988
		public CreateAnyMachineActivity(PcmoverManager manager, ServiceFileTransferMethod ftm) : base(ActivityType.GetSnapshot, manager)
		{
			this._ftm = ftm;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(GetSnapshotActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002799 File Offset: 0x00000999
		private void SetFailure(GetSnapshotActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
			this.m_bSuccess = false;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000027B0 File Offset: 0x000009B0
		protected override void Run()
		{
			try
			{
				this.m_bSuccess = true;
				this._anyMachine = this.m_app.CreateMachine();
				if (this._anyMachine == null)
				{
					this.SetFailure(GetSnapshotActivityFailureReason.CreateMachineFailed);
					return;
				}
				if (!this._anyMachine.InitNoSnapshotMachine(this._ftm.AnyMachineName))
				{
					this.SetFailure(GetSnapshotActivityFailureReason.InitMachineFailed);
				}
				this.ActivityServiceMachine = base.Manager.GetServiceMachine(this._anyMachine);
			}
			catch (Exception ex)
			{
				base.TerminateOnException(ex, "Run");
				this.m_bSuccess = false;
			}
			if (!this.m_bSuccess && this.ActivityServiceMachine != null)
			{
				try
				{
					Machine anyMachine = this._anyMachine;
					if (anyMachine != null)
					{
						anyMachine.dispose();
					}
					this._anyMachine = null;
					ServiceMachine activityServiceMachine = this.ActivityServiceMachine;
					this.ActivityServiceMachine = null;
					base.Manager.RemoveServiceMachine(activityServiceMachine);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x04000006 RID: 6
		private ServiceFileTransferMethod _ftm;

		// Token: 0x04000007 RID: 7
		private Machine _anyMachine;
	}
}
