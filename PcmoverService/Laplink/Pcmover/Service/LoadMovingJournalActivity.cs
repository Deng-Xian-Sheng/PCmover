using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200000D RID: 13
	internal class LoadMovingJournalActivity : PcmActivity, ITaskActivity, ITransferMethodActivity
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003802 File Offset: 0x00001A02
		// (set) Token: 0x06000050 RID: 80 RVA: 0x0000380A File Offset: 0x00001A0A
		public ServiceTask ActivityServiceTask { get; private set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003813 File Offset: 0x00001A13
		public ServiceTransferMethod ActivityServiceTransferMethod { get; }

		// Token: 0x06000052 RID: 82 RVA: 0x0000381B File Offset: 0x00001A1B
		public LoadMovingJournalActivity(PcmoverManager manager, ServiceTransferMethod stm) : base(ActivityType.LoadMovingJournal, manager)
		{
			this.ActivityServiceTransferMethod = stm;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003830 File Offset: 0x00001A30
		protected override void Run()
		{
			PcmTask pcmTask = this.m_app.LoadMovingJournal(this.ActivityServiceTransferMethod.GetTransferMethod());
			if (pcmTask == null)
			{
				this.m_bSuccess = false;
				return;
			}
			this.m_bSuccess = true;
			this.ActivityServiceTask = base.Manager.AddServiceTask(pcmTask, null, null);
		}
	}
}
