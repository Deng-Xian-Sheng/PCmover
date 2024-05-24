using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000007 RID: 7
	public class GetImageSnapshotActivityClient : GetSnapshotActivityClient
	{
		// Token: 0x06000019 RID: 25 RVA: 0x000024A7 File Offset: 0x000006A7
		public GetImageSnapshotActivityClient(PCmoverEngineLive engine) : base(engine)
		{
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000024B0 File Offset: 0x000006B0
		public override void OnSucceeded(ActivityInfo info)
		{
			if (!base.IsResuming)
			{
				base.OnSucceeded(info);
				return;
			}
			MachineData machineData = base.ServiceData.Machines.FirstOrDefault((MachineData m) => !m.IsThisMachine);
			if (machineData == null)
			{
				base.ClientEngine.Ts.TraceCaller("Cannot find image machine", "OnSucceeded");
				base.OnOtherMachine(0);
				return;
			}
			base.OnOtherMachine(machineData.Handle);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002530 File Offset: 0x00000730
		public int GetImageTransferMethodHandle(ImageMapData imageMapData, int tmh = 0)
		{
			if (base.IsResuming)
			{
				TransferMethodData transferMethodData = base.ServiceData.GetTransferMethodData(TransferMethodType.Image);
				if (transferMethodData != null)
				{
					return transferMethodData.Handle;
				}
				base.ClientEngine.Ts.TraceCaller("Unable to find Image transfer method while resuming", "GetImageTransferMethodHandle");
			}
			if (tmh == 0)
			{
				tmh = base.ControlInterface.CreateTransferMethod(TransferMethodType.Image);
			}
			if (tmh != 0 && !base.ControlInterface.SetImageTransferMethodInfo(tmh, imageMapData))
			{
				tmh = 0;
			}
			return tmh;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000025A0 File Offset: 0x000007A0
		public int GetWinUpgradeTransferMethodHandle(string windowsOld, int tmh = 0)
		{
			PCmoverEngineLive engine = base.Engine;
			if (engine != null)
			{
				engine.CatchCommEx(delegate
				{
					if (tmh == 0)
					{
						tmh = this.ControlInterface.CreateTransferMethod(TransferMethodType.WinUpgrade);
					}
					if (tmh != 0 && !this.ControlInterface.SetWinUpgradeTransferMethodInfo(tmh, new WinUpgradeTransferMethodInfo
					{
						WindowsOld = windowsOld
					}))
					{
						tmh = 0;
					}
				}, "GetWinUpgradeTransferMethodHandle");
			}
			return tmh;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025F4 File Offset: 0x000007F4
		protected override void OnGetSnapshotSuccess()
		{
			GetImageSnapshotActivityClient.<OnGetSnapshotSuccess>d__4 <OnGetSnapshotSuccess>d__;
			<OnGetSnapshotSuccess>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnGetSnapshotSuccess>d__.<>4__this = this;
			<OnGetSnapshotSuccess>d__.<>1__state = -1;
			<OnGetSnapshotSuccess>d__.<>t__builder.Start<GetImageSnapshotActivityClient.<OnGetSnapshotSuccess>d__4>(ref <OnGetSnapshotSuccess>d__);
		}
	}
}
