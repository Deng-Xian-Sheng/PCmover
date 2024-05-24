using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using PCmover.Infrastructure;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000006 RID: 6
	public class GetSnapshotActivityClient : ActivityClient
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000022F0 File Offset: 0x000004F0
		protected PCmoverEngineLive Engine
		{
			get
			{
				return (PCmoverEngineLive)base.ClientEngine;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000022FD File Offset: 0x000004FD
		public GetSnapshotActivityClient(PCmoverEngineLive engine) : base(engine)
		{
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002306 File Offset: 0x00000506
		public virtual void Start(int transferMethodHandle)
		{
			if (base.IsResuming)
			{
				this.Resume(transferMethodHandle);
				return;
			}
			if (transferMethodHandle != 0)
			{
				this._transferMethodHandle = transferMethodHandle;
				this.Start(base.ControlInterface.CreateGetSnapshotActivity(transferMethodHandle));
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002334 File Offset: 0x00000534
		public void Resume(int transferMethodHandle)
		{
			this._transferMethodHandle = transferMethodHandle;
			base.Resume(ActivityType.GetSnapshot);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002344 File Offset: 0x00000544
		public bool ConfigureTransferMethod(ConnectableMachine targetMachine, bool bSecure)
		{
			return targetMachine == null || targetMachine.Method != TransferMethodType.Network || base.ControlInterface.SetNetworkTransferMethodInfo(targetMachine.TransferMethodHandle, new NetworkTransferMethodInfo
			{
				Target = targetMachine.NetName,
				bSecure = bSecure,
				CertificateName = targetMachine.CertificateName
			});
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002395 File Offset: 0x00000595
		public int GetFileAnyTransferMethodHandle(int tmh = 0)
		{
			if (tmh == 0)
			{
				tmh = base.ControlInterface.CreateTransferMethod(TransferMethodType.File);
			}
			return tmh;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000023AA File Offset: 0x000005AA
		public override void OnProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			this.Engine.EventAggregator.GetEvent<EngineEvents.SnapshotProgressChanged>().Publish(progressInfo);
			base.OnProgress(activityInfo, progressInfo);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000023CC File Offset: 0x000005CC
		public override void OnSucceeded(ActivityInfo info)
		{
			int otherMachineHandle;
			if (base.Handle == -1)
			{
				MachineData otherMachineData = this.Engine.ServiceData.OtherMachineData;
				if (otherMachineData == null)
				{
					base.Ts.TraceCaller("I don't know what the other machine is", "OnSucceeded");
					return;
				}
				otherMachineHandle = otherMachineData.Handle;
			}
			else
			{
				otherMachineHandle = base.ControlInterface.GetActivityMachineHandle(base.Handle);
			}
			this.OnOtherMachine(otherMachineHandle);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002430 File Offset: 0x00000630
		protected void OnOtherMachine(int otherMachineHandle)
		{
			this.Engine.CatchCommEx(delegate
			{
				this.Engine.OtherMachine = this.ControlInterface.GetMachineData(otherMachineHandle);
				this.Engine._otherMachineTransferMethodHandle = this._transferMethodHandle;
				if (this.Engine.OtherMachine != null && this.Engine.OtherMachine.Handle != 0)
				{
					this.OnGetSnapshotSuccess();
				}
			}, "OnOtherMachine");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002470 File Offset: 0x00000670
		protected virtual void OnGetSnapshotSuccess()
		{
			GetSnapshotActivityClient.<OnGetSnapshotSuccess>d__11 <OnGetSnapshotSuccess>d__;
			<OnGetSnapshotSuccess>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnGetSnapshotSuccess>d__.<>4__this = this;
			<OnGetSnapshotSuccess>d__.<>1__state = -1;
			<OnGetSnapshotSuccess>d__.<>t__builder.Start<GetSnapshotActivityClient.<OnGetSnapshotSuccess>d__11>(ref <OnGetSnapshotSuccess>d__);
		}

		// Token: 0x04000003 RID: 3
		protected int _transferMethodHandle;
	}
}
