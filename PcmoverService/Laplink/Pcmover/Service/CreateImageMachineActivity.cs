using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000006 RID: 6
	public class CreateImageMachineActivity : PcmActivity, IMachineActivity, ITransferMethodActivity
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000028A0 File Offset: 0x00000AA0
		// (set) Token: 0x06000019 RID: 25 RVA: 0x000028A8 File Offset: 0x00000AA8
		public ServiceMachine ActivityServiceMachine { get; private set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000028B1 File Offset: 0x00000AB1
		public ServiceTransferMethod ActivityServiceTransferMethod
		{
			get
			{
				return this._sitm;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000028B9 File Offset: 0x00000AB9
		public CreateImageMachineActivity(PcmoverManager manager, ServiceImageTransferMethod sitm) : base(ActivityType.GetSnapshot, manager)
		{
			this._sitm = sitm;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(GetSnapshotActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002799 File Offset: 0x00000999
		private void SetFailure(GetSnapshotActivityFailureReason reason)
		{
			this.Info.FailureReason = (int)reason;
			this.m_bSuccess = false;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000028CC File Offset: 0x00000ACC
		protected override void Run()
		{
			try
			{
				this.m_bSuccess = true;
				this._imageMachine = this.m_app.CreateMachine();
				if (this._imageMachine == null)
				{
					this.SetFailure(GetSnapshotActivityFailureReason.CreateMachineFailed);
					return;
				}
				VirtualPhysicalMapping virtualPhysicalMapping = null;
				ServiceWinUpgradeTransferMethod serviceWinUpgradeTransferMethod = this._sitm as ServiceWinUpgradeTransferMethod;
				if (serviceWinUpgradeTransferMethod == null)
				{
					virtualPhysicalMapping = this.m_app.CreateVirtualPhysicalMapping();
				}
				else
				{
					virtualPhysicalMapping = this.m_app.CreateWinUpgradeVirtualPhysicalMapping(serviceWinUpgradeTransferMethod.WindowsOld);
				}
				foreach (ImageFolderMapping imageFolderMapping in this._sitm.ImageMap.Folders)
				{
					virtualPhysicalMapping.AppendPair(imageFolderMapping.VStr, imageFolderMapping.PStr);
				}
				if (!this._imageMachine.InitImageMachine(virtualPhysicalMapping, this._sitm.ImageMap.WinDir, this._sitm.ImageMap.ImageName))
				{
					this.SetFailure(GetSnapshotActivityFailureReason.InitMachineFailed);
				}
				this.ActivityServiceMachine = base.Manager.GetServiceMachine(this._imageMachine);
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
					Machine imageMachine = this._imageMachine;
					if (imageMachine != null)
					{
						imageMachine.dispose();
					}
					this._imageMachine = null;
					ServiceMachine activityServiceMachine = this.ActivityServiceMachine;
					this.ActivityServiceMachine = null;
					base.Manager.RemoveServiceMachine(activityServiceMachine);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x04000009 RID: 9
		private Machine _imageMachine;

		// Token: 0x0400000A RID: 10
		private readonly ServiceImageTransferMethod _sitm;
	}
}
