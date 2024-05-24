using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000004 RID: 4
	public class BuildChangeListsActivity : PcmActivity, ITaskActivity
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13 RVA: 0x000026E4 File Offset: 0x000008E4
		public ServiceTask ActivityServiceTask { get; }

		// Token: 0x0600000E RID: 14 RVA: 0x000026EC File Offset: 0x000008EC
		public BuildChangeListsActivity(PcmoverManager manager, ServiceTask serviceTask) : base(ActivityType.BuildChangeLists, manager)
		{
			this.ActivityServiceTask = serviceTask;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(BuildChangeListsActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002714 File Offset: 0x00000914
		protected override void Run()
		{
			this.m_bSuccess = false;
			this.UpdatePhase(BuildChangeListsActivityPhase.Preparing);
			this.ActivityServiceTask.GetChangeLists();
			this.UpdatePhase(BuildChangeListsActivityPhase.Building);
			FillVanTask fillVanTask = this.ActivityServiceTask.Task as FillVanTask;
			if (fillVanTask != null)
			{
				this.m_bSuccess = fillVanTask.BuildChangeLists();
			}
			this.UpdatePhase(BuildChangeListsActivityPhase.SavingLog);
			fillVanTask.SaveBuildJournal();
		}
	}
}
