using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000009 RID: 9
	public class ExpandSnapshotActivity : PcmActivity, IMachineActivity
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00003014 File Offset: 0x00001214
		internal bool ExpandGlobalCategories { get; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000030 RID: 48 RVA: 0x0000301C File Offset: 0x0000121C
		public ServiceMachine ActivityServiceMachine { get; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00003024 File Offset: 0x00001224
		internal ItemType ItemType { get; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000032 RID: 50 RVA: 0x0000302C File Offset: 0x0000122C
		internal bool RegularUsersOnly { get; }

		// Token: 0x06000033 RID: 51 RVA: 0x00003034 File Offset: 0x00001234
		public ExpandSnapshotActivity(PcmoverManager manager, ItemType itemType, bool regularUsersOnly, bool expandGlobalCategories, ServiceMachine serviceMachine) : base(ActivityType.ExpandSnapshot, manager)
		{
			this.RegularUsersOnly = regularUsersOnly;
			this.ExpandGlobalCategories = expandGlobalCategories;
			this.ActivityServiceMachine = serviceMachine;
			this.ItemType = itemType;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003060 File Offset: 0x00001260
		private void UpdatePhase(ExpandSnapshotActivityPhase newPhase, string message = null)
		{
			ActivityInfo info = this.Info;
			lock (info)
			{
				this.Info.Phase = (int)newPhase;
				this.Info.Message = message;
			}
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000030B8 File Offset: 0x000012B8
		protected override void Run()
		{
			this.m_bSuccess = true;
			if (this.ActivityServiceMachine.Data.IsLive)
			{
				using (PcmoverObjectWrapper<TreeRoot> treeRootWrapper = base.Manager.GetTreeRootWrapper(this.ActivityServiceMachine, this.ItemType))
				{
					if (((treeRootWrapper != null) ? treeRootWrapper.Value : null) == null)
					{
						this.m_bSuccess = false;
						return;
					}
					this.UpdatePhase(ExpandSnapshotActivityPhase.Expanding, null);
					treeRootWrapper.Value.ExpandBranches(this.RegularUsersOnly, this.ExpandGlobalCategories);
				}
			}
			this.UpdatePhase(ExpandSnapshotActivityPhase.ApplicationDiskSpace, null);
			this.ActivityServiceMachine.PcmMachine.DetermineApplicationDiskSpace(this.RegularUsersOnly);
		}
	}
}
