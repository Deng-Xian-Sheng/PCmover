using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;

namespace ClientEngineModule.Wcf
{
	// Token: 0x0200000C RID: 12
	public class ThisMachineAppInvActivityClient : AppInvActivityClient
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x0600014F RID: 335 RVA: 0x00006EC0 File Offset: 0x000050C0
		private IUnityContainer Container
		{
			get
			{
				return base.Engine.Container;
			}
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00006ECD File Offset: 0x000050CD
		public ThisMachineAppInvActivityClient(PCmoverEngineLive engine) : base(engine)
		{
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00006ED6 File Offset: 0x000050D6
		public override void OnProgress(ActivityInfo activityInfo, ProgressInfo progressInfo)
		{
			base.Engine.EventAggregator.GetEvent<EngineEvents.ThisMachineAppInventoryProgressChanged>().Publish(progressInfo);
			base.OnProgress(activityInfo, progressInfo);
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00006EF8 File Offset: 0x000050F8
		public override void OnActivityInfoChanged(ActivityInfo info)
		{
			base.Ts.TraceInformation(string.Format("ThisMachineAppInvActivityClient.ActivityInfoChanged: {0}", info));
			AppInventoryStatus status = null;
			if (base.IsResuming && base.Handle == -1)
			{
				status = base.Engine._thisAppInvStatus;
			}
			else if (!base.Engine.CatchCommEx(delegate
			{
				status = this.ControlInterface.GetAppInventoryActivityStatus(this.Handle);
			}, "OnActivityInfoChanged"))
			{
				return;
			}
			if (status != null)
			{
				base.Ts.TraceCaller(info.ToString(), "OnActivityInfoChanged");
				base.Ts.TraceCaller(status.ToString(), "OnActivityInfoChanged");
				if (base.Engine.AppInventoryAmountAtLeast(base.Engine._thisAppInvStatus.Completed, status.Completed))
				{
					base.Ts.TraceCaller("Changing engine's Completed amount", "OnActivityInfoChanged");
					base.Engine._thisAppInvStatus.Completed = status.Completed;
				}
				if (!base.Engine._thisAppInvHasCheckedForOffice && base.Engine.AppInventoryAmountAtLeast(AppInventoryAmount.Minimum, base.Engine._thisAppInvStatus.Completed))
				{
					base.Engine._thisAppInvHasCheckedForOffice = true;
					if (!base.Engine.CatchCommEx(delegate
					{
						if (!this.Engine.CheckControllerProperty(ControllerProperties.CheckForOffice))
						{
							this.CheckForOffice();
							this.Engine.SetControllerDateProperty(ControllerProperties.CheckForOffice);
						}
					}, "OnActivityInfoChanged"))
					{
						return;
					}
				}
			}
			else
			{
				base.Ts.TraceCaller("No AppInventoryStatus", "OnActivityInfoChanged");
			}
			base.OnActivityInfoChanged(info);
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00007078 File Offset: 0x00005278
		private void CheckForOffice()
		{
			if (Convert.ToBoolean(Resources.Feature_SuppressOfficeTrialWarning))
			{
				return;
			}
			if (this.Container.Resolve(Array.Empty<ResolverOverride>()).LaunchDownloadManager)
			{
				return;
			}
			if (this.Container.Resolve(Array.Empty<ResolverOverride>()).SuppressMessageBoxes)
			{
				return;
			}
			IEnumerable<ApplicationData> enumerable = base.ControlInterface.MachineGetMicrosoftOfficeTrialApps(base.Engine.ThisMachine.Handle, new GetApplicationsParameters());
			if (enumerable != null && enumerable.Any<ApplicationData>())
			{
				base.Engine.EventAggregator.GetEvent<EngineEvents.ShowOfficeTrialPopupEvent>().Publish(enumerable);
			}
		}

		// Token: 0x06000154 RID: 340 RVA: 0x00007104 File Offset: 0x00005304
		protected override void AfterDeleted(ActivityInfo info)
		{
			ThisMachineAppInvActivityClient.<AfterDeleted>d__6 <AfterDeleted>d__;
			<AfterDeleted>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<AfterDeleted>d__.<>4__this = this;
			<AfterDeleted>d__.info = info;
			<AfterDeleted>d__.<>1__state = -1;
			<AfterDeleted>d__.<>t__builder.Start<ThisMachineAppInvActivityClient.<AfterDeleted>d__6>(ref <AfterDeleted>d__);
		}
	}
}
