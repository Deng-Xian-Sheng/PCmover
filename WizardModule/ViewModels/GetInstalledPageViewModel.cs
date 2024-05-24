using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;

namespace WizardModule.ViewModels
{
	// Token: 0x0200008A RID: 138
	public class GetInstalledPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06000A2B RID: 2603 RVA: 0x00018EA0 File Offset: 0x000170A0
		private LlTraceSource Ts { get; }

		// Token: 0x06000A2C RID: 2604 RVA: 0x00018EA8 File Offset: 0x000170A8
		public GetInstalledPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, LlTraceSource ts, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardModuleModule = wizardModuleModule;
			this._navigationHelper = navigationHelper;
			this.Ts = ts;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnAccept = new DelegateCommand(new Action(this.OnAcceptCommand), new Func<bool>(this.CanOnAcceptCommand));
			this.OnDecline = new DelegateCommand(new Action(this.OnDeclineCommand), new Func<bool>(this.CanOnDeclineCommand));
			this.IsEULAAccepted = Tools.IsEULAAccepted();
			this.OnChangeSerialNumber = new DelegateCommand(new Action(this.OnChangeSerialNumberCommand), new Func<bool>(this.CanOnChangeSerialNumberCommand));
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00018FA8 File Offset: 0x000171A8
		private void OnFoundTargetComputer(ConnectableMachine newConnectableMachine)
		{
			this.migrationDefinition.UIConnectableMachines.AddOrUpdateMachine(newConnectableMachine);
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00018FBC File Offset: 0x000171BC
		private void OnLostTargetComputer(ConnectableMachine lostConnectableMachine)
		{
			this.migrationDefinition.UIConnectableMachines.RemoveMachine(lostConnectableMachine);
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x00018FD0 File Offset: 0x000171D0
		private void OnMachineStatus(ConnectableMachine machine)
		{
			if (machine != null && machine.Status == DiscoveredMachineStatus.MachineFound)
			{
				this.migrationDefinition.UIConnectableMachines.AddOrUpdateMachine(machine);
				return;
			}
			if (machine != null && machine.Status == DiscoveredMachineStatus.MachineLost)
			{
				this.migrationDefinition.UIConnectableMachines.RemoveMachine(machine);
				return;
			}
			if (machine != null && machine.Status == DiscoveredMachineStatus.RemoteManualConnection)
			{
				this._RemoteMachine = machine;
			}
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00019030 File Offset: 0x00017230
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (activityInfo.Type == ActivityType.Listen && activityInfo.Phase == 2)
				{
					NavigationParameters navigationParameters = new NavigationParameters();
					this.Ts.TraceInformation("GetInstalledPageViewModel.OnActivityInfo: Set ThisMachineIsOld = true");
					this.pcmoverEngine.ThisMachineIsOld = true;
					navigationParameters.Add("IsConnected", true);
					if (this._RemoteMachine != null)
					{
						navigationParameters.Add("RemoteMachine", this._RemoteMachine);
					}
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), navigationParameters);
				}
				this.OnNext.RaiseCanExecuteChanged();
			}, "OnActivityInfo");
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x00019070 File Offset: 0x00017270
		private void OnSetDirection(ConnectableMachine machine)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				NavigationParameters navigationParameters = new NavigationParameters();
				navigationParameters.Add("RemoteMachine", machine);
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), navigationParameters);
			}, "OnSetDirection");
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06000A32 RID: 2610 RVA: 0x000190AE File Offset: 0x000172AE
		// (set) Token: 0x06000A33 RID: 2611 RVA: 0x000190B6 File Offset: 0x000172B6
		public bool IsEULAOpen
		{
			get
			{
				return this._IsEULAOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsEULAOpen, value, "IsEULAOpen");
				this.eventAggregator.GetEvent<Events.BlackoutWindow>().Publish(value);
			}
		}

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06000A34 RID: 2612 RVA: 0x000190DC File Offset: 0x000172DC
		// (set) Token: 0x06000A35 RID: 2613 RVA: 0x000190E4 File Offset: 0x000172E4
		public bool IsEULAAccepted
		{
			get
			{
				return this._IsEULAAccepted;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsEULAAccepted, value, "IsEULAAccepted");
			}
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06000A36 RID: 2614 RVA: 0x000190F9 File Offset: 0x000172F9
		// (set) Token: 0x06000A37 RID: 2615 RVA: 0x00019101 File Offset: 0x00017301
		public string SerialNumber
		{
			get
			{
				return this._SerialNumber;
			}
			set
			{
				this.SetProperty<string>(ref this._SerialNumber, value, "SerialNumber");
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06000A38 RID: 2616 RVA: 0x00019116 File Offset: 0x00017316
		// (set) Token: 0x06000A39 RID: 2617 RVA: 0x0001911E File Offset: 0x0001731E
		public bool IsSerialNumberVisible
		{
			get
			{
				return this._IsSerialNumberVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsSerialNumberVisible, value, "IsSerialNumberVisible");
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06000A3A RID: 2618 RVA: 0x00019133 File Offset: 0x00017333
		// (set) Token: 0x06000A3B RID: 2619 RVA: 0x0001913B File Offset: 0x0001733B
		public bool IsDownloadVisible
		{
			get
			{
				return this._IsDownloadVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsDownloadVisible, value, "IsDownloadVisible");
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06000A3C RID: 2620 RVA: 0x00019150 File Offset: 0x00017350
		// (set) Token: 0x06000A3D RID: 2621 RVA: 0x00019158 File Offset: 0x00017358
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000A3E RID: 2622 RVA: 0x00019161 File Offset: 0x00017361
		private bool CanOnNextCommand()
		{
			return !this.container.Resolve(Array.Empty<ResolverOverride>()).IsOld;
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x0001917C File Offset: 0x0001737C
		private void OnNextCommand()
		{
			this.policy.getInstalledPagePolicy.GiIsEULAAccepted = (this.IsEULAAccepted ? DefaultPolicy.Tristate.True : DefaultPolicy.Tristate.False);
			this.policy.WriteProfile();
			if (this.IsEULAAccepted)
			{
				NavigationParameters navigationParameters = new NavigationParameters();
				navigationParameters.Add("IsConnected", false);
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), navigationParameters);
				return;
			}
			this.IsEULAOpen = true;
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x000191F3 File Offset: 0x000173F3
		// (set) Token: 0x06000A41 RID: 2625 RVA: 0x000191FB File Offset: 0x000173FB
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000A42 RID: 2626 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00019204 File Offset: 0x00017404
		private void OnBackCommand()
		{
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x00019212 File Offset: 0x00017412
		// (set) Token: 0x06000A45 RID: 2629 RVA: 0x0001921A File Offset: 0x0001741A
		public DelegateCommand OnAccept { get; private set; }

		// Token: 0x06000A46 RID: 2630 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnAcceptCommand()
		{
			return true;
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x00019224 File Offset: 0x00017424
		private void OnAcceptCommand()
		{
			GetInstalledPageViewModel.<OnAcceptCommand>d__52 <OnAcceptCommand>d__;
			<OnAcceptCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnAcceptCommand>d__.<>4__this = this;
			<OnAcceptCommand>d__.<>1__state = -1;
			<OnAcceptCommand>d__.<>t__builder.Start<GetInstalledPageViewModel.<OnAcceptCommand>d__52>(ref <OnAcceptCommand>d__);
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06000A48 RID: 2632 RVA: 0x0001925B File Offset: 0x0001745B
		// (set) Token: 0x06000A49 RID: 2633 RVA: 0x00019263 File Offset: 0x00017463
		public DelegateCommand OnDecline { get; private set; }

		// Token: 0x06000A4A RID: 2634 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDeclineCommand()
		{
			return true;
		}

		// Token: 0x06000A4B RID: 2635 RVA: 0x0001926C File Offset: 0x0001746C
		private void OnDeclineCommand()
		{
			GetInstalledPageViewModel.<OnDeclineCommand>d__58 <OnDeclineCommand>d__;
			<OnDeclineCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnDeclineCommand>d__.<>4__this = this;
			<OnDeclineCommand>d__.<>1__state = -1;
			<OnDeclineCommand>d__.<>t__builder.Start<GetInstalledPageViewModel.<OnDeclineCommand>d__58>(ref <OnDeclineCommand>d__);
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06000A4C RID: 2636 RVA: 0x000192A3 File Offset: 0x000174A3
		// (set) Token: 0x06000A4D RID: 2637 RVA: 0x000192AB File Offset: 0x000174AB
		public DelegateCommand OnChangeSerialNumber { get; private set; }

		// Token: 0x06000A4E RID: 2638 RVA: 0x000192B4 File Offset: 0x000174B4
		private bool CanOnChangeSerialNumberCommand()
		{
			return !base.pcmoverEngine.License.IsSerialNumberFromPolicy || (base.pcmoverEngine.License.IsSerialNumberFromPolicy && this.policy.licensePagePolicy.AllowReentryOnError);
		}

		// Token: 0x06000A4F RID: 2639 RVA: 0x000192F0 File Offset: 0x000174F0
		private void OnChangeSerialNumberCommand()
		{
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("NextPage", "GetInstalledPage");
			navigationParameters.Add("AutoNavigate", false);
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LicensePage", UriKind.Relative), navigationParameters);
		}

		// Token: 0x06000A50 RID: 2640 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000A51 RID: 2641 RVA: 0x00019340 File Offset: 0x00017540
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
			this.eventAggregator.GetEvent<EngineEvents.ConnectableMachineStatusEvent>().Unsubscribe(new Action<ConnectableMachine>(this.OnMachineStatus));
			this.eventAggregator.GetEvent<EngineEvents.SetDirectionEvent>().Unsubscribe(new Action<ConnectableMachine>(this.OnSetDirection));
		}

		// Token: 0x06000A52 RID: 2642 RVA: 0x000193A4 File Offset: 0x000175A4
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			GetInstalledPageViewModel.<OnNavigatedTo>d__67 <OnNavigatedTo>d__;
			<OnNavigatedTo>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNavigatedTo>d__.<>4__this = this;
			<OnNavigatedTo>d__.<>1__state = -1;
			<OnNavigatedTo>d__.<>t__builder.Start<GetInstalledPageViewModel.<OnNavigatedTo>d__67>(ref <OnNavigatedTo>d__);
		}

		// Token: 0x06000A53 RID: 2643 RVA: 0x000193DC File Offset: 0x000175DC
		private Task Update()
		{
			GetInstalledPageViewModel.<Update>d__68 <Update>d__;
			<Update>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<Update>d__.<>4__this = this;
			<Update>d__.<>1__state = -1;
			<Update>d__.<>t__builder.Start<GetInstalledPageViewModel.<Update>d__68>(ref <Update>d__);
			return <Update>d__.<>t__builder.Task;
		}

		// Token: 0x04000311 RID: 785
		private readonly IRegionManager regionManager;

		// Token: 0x04000312 RID: 786
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000313 RID: 787
		private readonly DefaultPolicy policy;

		// Token: 0x04000314 RID: 788
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x04000315 RID: 789
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000316 RID: 790
		private ConnectableMachine _RemoteMachine;

		// Token: 0x04000318 RID: 792
		private bool _IsEULAOpen;

		// Token: 0x04000319 RID: 793
		private bool _IsEULAAccepted;

		// Token: 0x0400031A RID: 794
		private string _SerialNumber;

		// Token: 0x0400031B RID: 795
		private bool _IsSerialNumberVisible;

		// Token: 0x0400031C RID: 796
		private bool _IsDownloadVisible;
	}
}
