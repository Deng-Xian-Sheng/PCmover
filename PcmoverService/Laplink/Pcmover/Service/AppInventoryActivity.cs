using System;
using Laplink.Pcmover.Contracts;
using PcmComLib;

namespace Laplink.Pcmover.Service
{
	// Token: 0x0200002F RID: 47
	internal class AppInventoryActivity : PcmActivity, IMachineActivity
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000104D7 File Offset: 0x0000E6D7
		public ServiceMachine ActivityServiceMachine { get; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000239 RID: 569 RVA: 0x000104DF File Offset: 0x0000E6DF
		// (set) Token: 0x0600023A RID: 570 RVA: 0x000104E7 File Offset: 0x0000E6E7
		public AppInventoryAmount AmountCompleted { get; private set; }

		// Token: 0x0600023B RID: 571 RVA: 0x000104F0 File Offset: 0x0000E6F0
		public AppInventoryActivity(PcmoverManager manager, ServiceMachine serviceMachine, AppInventoryAmount amount) : base(ActivityType.AppInventory, manager)
		{
			this.ActivityServiceMachine = serviceMachine;
			this.AmountToDo = amount;
			this.AmountCompleted = AppInventoryAmount.None;
		}

		// Token: 0x0600023C RID: 572 RVA: 0x000026FD File Offset: 0x000008FD
		private void UpdatePhase(AppInventoryActivityPhase newPhase)
		{
			this.Info.Phase = (int)newPhase;
			base.NotifyActivityInfoChanged();
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00010518 File Offset: 0x0000E718
		protected override void Run()
		{
			this.m_bSuccess = true;
			if (this.AmountToDo == AppInventoryAmount.None)
			{
				return;
			}
			this.UpdatePhase(AppInventoryActivityPhase.Init);
			this.m_bSuccess = this.ActivityServiceMachine.PcmMachine.DoApplicationInventory(ENUM_APPSEL_STAGE.AS_INIT);
			if (!this.m_bSuccess || this.m_bCancel)
			{
				return;
			}
			this.AmountCompleted = AppInventoryAmount.Minimum;
			if (this.AmountToDo == AppInventoryAmount.Minimum)
			{
				return;
			}
			this.UpdatePhase(AppInventoryActivityPhase.GetInfo);
			this.m_bSuccess = this.ActivityServiceMachine.PcmMachine.DoApplicationInventory(ENUM_APPSEL_STAGE.AS_GETINFO);
			if (!this.m_bSuccess || this.m_bCancel)
			{
				return;
			}
			this.UpdatePhase(AppInventoryActivityPhase.ScanShortcuts);
			this.m_bSuccess = this.ActivityServiceMachine.PcmMachine.DoApplicationInventory(ENUM_APPSEL_STAGE.AS_SCANSHORTCUTS);
			if (!this.m_bSuccess || this.m_bCancel)
			{
				return;
			}
			this.AmountCompleted = AppInventoryAmount.NewComputer;
			if (this.AmountToDo == AppInventoryAmount.NewComputer)
			{
				return;
			}
			this.UpdatePhase(AppInventoryActivityPhase.ScanOthers);
			this.m_bSuccess = this.ActivityServiceMachine.PcmMachine.DoApplicationInventory(ENUM_APPSEL_STAGE.AS_SCANOTHERS);
			if (!this.m_bSuccess || this.m_bCancel)
			{
				return;
			}
			this.AmountCompleted = AppInventoryAmount.OldComputer;
		}

		// Token: 0x040000B6 RID: 182
		public AppInventoryAmount AmountToDo = AppInventoryAmount.OldComputer;
	}
}
