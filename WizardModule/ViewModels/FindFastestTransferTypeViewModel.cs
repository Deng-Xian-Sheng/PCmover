using System;
using System.Diagnostics;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x02000087 RID: 135
	public class FindFastestTransferTypeViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000951 RID: 2385 RVA: 0x00016500 File Offset: 0x00014700
		public FindFastestTransferTypeViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this._navigationHelper = navigationHelper;
			this.OnGetRecommendations = new DelegateCommand(new Action(this.OnGetRecommendationsCommand), new Func<bool>(this.CanOnGetRecommendationsTransfer));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnSetCableVisibility = new DelegateCommand(new Action(this.OnSetCableVisibilityCommand), new Func<bool>(this.CanOnSetCableVisibilityCommand));
			this.OnGetCable = new DelegateCommand(new Action(this.OnGetCableCommand), new Func<bool>(this.CanOnGetCableCommand));
			this.Questions = new ConnectionWizardQuestions();
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x000165BD File Offset: 0x000147BD
		// (set) Token: 0x06000953 RID: 2387 RVA: 0x000165C5 File Offset: 0x000147C5
		public ConnectionWizardQuestions Questions
		{
			get
			{
				return this._Questions;
			}
			set
			{
				this.SetProperty<ConnectionWizardQuestions>(ref this._Questions, value, "Questions");
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000954 RID: 2388 RVA: 0x000165DA File Offset: 0x000147DA
		// (set) Token: 0x06000955 RID: 2389 RVA: 0x000165E2 File Offset: 0x000147E2
		public bool EthernetCableVisible
		{
			get
			{
				return this._EthernetCableVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._EthernetCableVisible, value, "EthernetCableVisible");
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000956 RID: 2390 RVA: 0x000165F8 File Offset: 0x000147F8
		public bool ShowFileBased
		{
			get
			{
				bool result;
				try
				{
					result = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowAdvanced);
				}
				catch (FormatException)
				{
					result = true;
				}
				return result;
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000957 RID: 2391 RVA: 0x00016628 File Offset: 0x00014828
		// (set) Token: 0x06000958 RID: 2392 RVA: 0x00016630 File Offset: 0x00014830
		public DelegateCommand OnGetRecommendations { get; private set; }

		// Token: 0x06000959 RID: 2393 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnGetRecommendationsTransfer()
		{
			return true;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0001663C File Offset: 0x0001483C
		private void OnGetRecommendationsCommand()
		{
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("WizardQuestions", this.Questions);
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("RecommendedTransferMethodsPage", UriKind.Relative), navigationParameters);
		}

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x0600095B RID: 2395 RVA: 0x0001667C File Offset: 0x0001487C
		// (set) Token: 0x0600095C RID: 2396 RVA: 0x00016684 File Offset: 0x00014884
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x0600095D RID: 2397 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0001668D File Offset: 0x0001488D
		private void OnBackCommand()
		{
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x0600095F RID: 2399 RVA: 0x0001669B File Offset: 0x0001489B
		// (set) Token: 0x06000960 RID: 2400 RVA: 0x000166A3 File Offset: 0x000148A3
		public DelegateCommand OnGetCable { get; private set; }

		// Token: 0x06000961 RID: 2401 RVA: 0x000166AC File Offset: 0x000148AC
		private void OnGetCableCommand()
		{
			try
			{
				Process.Start(PcmBrandUI.Properties.Resources.URL_UsbCable);
			}
			catch
			{
			}
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnGetCableCommand()
		{
			return true;
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000963 RID: 2403 RVA: 0x000166DC File Offset: 0x000148DC
		// (set) Token: 0x06000964 RID: 2404 RVA: 0x000166E4 File Offset: 0x000148E4
		public DelegateCommand OnSetCableVisibility { get; private set; }

		// Token: 0x06000965 RID: 2405 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnSetCableVisibilityCommand()
		{
			return true;
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x000166ED File Offset: 0x000148ED
		private void OnSetCableVisibilityCommand()
		{
			this.EthernetCableVisible = (this.Questions.EthernetPortLocal || this.Questions.EthernetPortRemoteYes);
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00016710 File Offset: 0x00014910
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.RecommendedTransferMethod);
			this.Update();
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x0001672A File Offset: 0x0001492A
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00016748 File Offset: 0x00014948
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			if (activityInfo.Type == ActivityType.Listen && activityInfo.Phase == 2)
			{
				NavigationParameters parameters = new NavigationParameters();
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.pcmoverEngine.Ts.TraceInformation("FindFastestTransferTypeViewModel.OnActivityInfo: Set ThisMachineIsOld = true");
					this.pcmoverEngine.ThisMachineIsOld = true;
					parameters.Add("IsConnected", true);
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), parameters);
				}, "OnActivityInfo");
			}
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x0001679C File Offset: 0x0001499C
		private void Update()
		{
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_FindFastestTransferTypePage);
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnActivityInfo), ThreadOption.UIThread);
			this.Questions.EthernetPortLocal = Tools.IsEthernetAvailable(base.pcmoverEngine);
			this.Questions.WiFiLocal = (Tools.GetWiFiName(base.pcmoverEngine) != null);
			this.OnSetCableVisibilityCommand();
		}

		// Token: 0x040002BE RID: 702
		private readonly IRegionManager regionManager;

		// Token: 0x040002BF RID: 703
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040002C0 RID: 704
		private ConnectionWizardQuestions _Questions;

		// Token: 0x040002C1 RID: 705
		private bool _EthernetCableVisible;
	}
}
