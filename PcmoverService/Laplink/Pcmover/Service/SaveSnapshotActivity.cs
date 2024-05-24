using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200001F RID: 31
	public class SaveSnapshotActivity : PcmActivity, IMachineActivity, ITransferMethodActivity
	{
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060001D7 RID: 471 RVA: 0x0000EFF6 File Offset: 0x0000D1F6
		public ServiceMachine ActivityServiceMachine { get; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000EFFE File Offset: 0x0000D1FE
		public ServiceTransferMethod ActivityServiceTransferMethod
		{
			get
			{
				return this._ftm;
			}
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x0000F006 File Offset: 0x0000D206
		public SaveSnapshotActivity(PcmoverManager manager, ServiceFileTransferMethod ftm, ServiceMachine serviceMachine) : base(ActivityType.SaveSnapshot, manager)
		{
			this._ftm = ftm;
			this.ActivityServiceMachine = serviceMachine;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000F01E File Offset: 0x0000D21E
		protected override void Run()
		{
			this.m_bSuccess = this.ActivityServiceMachine.PcmMachine.SaveSnapshot((TransferMethod)this._ftm.FileTransferMethod, EXPAND_CONDITIONS.EC_NON_OPERATINGSYSTEM);
		}

		// Token: 0x04000080 RID: 128
		private ServiceFileTransferMethod _ftm;
	}
}
