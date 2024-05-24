using System;
using System.Diagnostics;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;

namespace ClientEngineModule.Wcf
{
	// Token: 0x02000002 RID: 2
	public class AppInvActivityClient : ActivityClient
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected PCmoverEngineLive Engine
		{
			get
			{
				return (PCmoverEngineLive)base.ClientEngine;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205D File Offset: 0x0000025D
		public AppInvActivityClient(PCmoverEngineLive engine) : base(engine)
		{
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002068 File Offset: 0x00000268
		public void ResumeOrStart(int machineHandle, ref AppInventoryStatus appInvStatus)
		{
			if (this.Engine.IsResuming)
			{
				base.Ts.TraceInformation("Resuming AppInvActivityClient");
				ActivityInfo appInvActivity = null;
				if (!this.Engine.CatchCommEx(delegate
				{
					appInvActivity = this.ServiceData.GetMachineActivity(ActivityType.AppInventory, machineHandle);
				}, "ResumeOrStart"))
				{
					return;
				}
				if (appInvActivity == null)
				{
					base.Ts.TraceCaller("No AppInventory activity", "ResumeOrStart");
					AppInventoryAmount? nullableAmount = null;
					if (!this.Engine.CatchCommEx(delegate
					{
						nullableAmount = this.ControlInterface.GetMachineAppInventoryAmount(machineHandle);
					}, "ResumeOrStart"))
					{
						return;
					}
					if (nullableAmount == null)
					{
						base.Ts.TraceCaller(TraceEventType.Error, string.Format("No AppInventoryAmount for {0}", machineHandle), "ResumeOrStart");
						return;
					}
					appInvStatus.Completed = nullableAmount.Value;
					if (!appInvStatus.IsCompleted)
					{
						base.Ts.TraceCaller("App Inventory activity does not exist, but it's not complete. We have to stop resuming and complete it.", "ResumeOrStart");
						this.Engine.IsResuming = false;
					}
				}
				else
				{
					AppInventoryStatus liveAppInvStatus = null;
					if (!this.Engine.CatchCommEx(delegate
					{
						liveAppInvStatus = this.ControlInterface.GetAppInventoryActivityStatus(appInvActivity.Handle);
					}, "ResumeOrStart"))
					{
						return;
					}
					appInvStatus = liveAppInvStatus;
				}
				if (appInvStatus == null)
				{
					base.Ts.TraceCaller("No appInvStatus", "ResumeOrStart");
				}
				else
				{
					base.Ts.TraceCaller(appInvStatus.ToString(), "ResumeOrStart");
				}
				if (this.Engine.IsResuming)
				{
					base.Resume(ActivityType.AppInventory, appInvActivity);
					return;
				}
			}
			this.Start(base.ControlInterface.CreateAppInventoryActivity(machineHandle, appInvStatus.Configuration));
		}
	}
}
