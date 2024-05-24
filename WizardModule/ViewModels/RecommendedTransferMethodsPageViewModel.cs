using System;
using System.Diagnostics;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200008D RID: 141
	public class RecommendedTransferMethodsPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000AC7 RID: 2759 RVA: 0x0001A820 File Offset: 0x00018A20
		public RecommendedTransferMethodsPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnCableInfo = new DelegateCommand(new Action(this.OnOnCableInfoCommand), new Func<bool>(this.CanOnCableInfoCommand));
			this.ShowEstimateTime = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowEstimatedTime);
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x0001A8BF File Offset: 0x00018ABF
		// (set) Token: 0x06000AC9 RID: 2761 RVA: 0x0001A8C7 File Offset: 0x00018AC7
		public bool IsExternalHdVisible
		{
			get
			{
				return this._IsExternalHdVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsExternalHdVisible, value, "IsExternalHdVisible");
			}
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06000ACA RID: 2762 RVA: 0x0001A8DC File Offset: 0x00018ADC
		// (set) Token: 0x06000ACB RID: 2763 RVA: 0x0001A8E4 File Offset: 0x00018AE4
		public string ExternalHdTime
		{
			get
			{
				return this._ExternalHdTime;
			}
			set
			{
				this.SetProperty<string>(ref this._ExternalHdTime, value, "ExternalHdTime");
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06000ACC RID: 2764 RVA: 0x0001A8F9 File Offset: 0x00018AF9
		// (set) Token: 0x06000ACD RID: 2765 RVA: 0x0001A901 File Offset: 0x00018B01
		public bool IsExternalHdSelected
		{
			get
			{
				return this._IsExternalHdSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsExternalHdSelected, value, "IsExternalHdSelected");
			}
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0001A916 File Offset: 0x00018B16
		// (set) Token: 0x06000ACF RID: 2767 RVA: 0x0001A91E File Offset: 0x00018B1E
		public string ExternalHDConnectionTitle
		{
			get
			{
				return this._ExternalHDConnectionTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._ExternalHDConnectionTitle, value, "ExternalHDConnectionTitle");
			}
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0001A933 File Offset: 0x00018B33
		// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x0001A93B File Offset: 0x00018B3B
		public bool IsEthernetVisible
		{
			get
			{
				return this._IsEthernetVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsEthernetVisible, value, "IsEthernetVisible");
			}
		}

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06000AD2 RID: 2770 RVA: 0x0001A950 File Offset: 0x00018B50
		// (set) Token: 0x06000AD3 RID: 2771 RVA: 0x0001A958 File Offset: 0x00018B58
		public string EthernetTime
		{
			get
			{
				return this._EthernetTime;
			}
			set
			{
				this.SetProperty<string>(ref this._EthernetTime, value, "EthernetTime");
			}
		}

		// Token: 0x1700055B RID: 1371
		// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0001A96D File Offset: 0x00018B6D
		// (set) Token: 0x06000AD5 RID: 2773 RVA: 0x0001A975 File Offset: 0x00018B75
		public bool IsEthernetSelected
		{
			get
			{
				return this._IsEthernetSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsEthernetSelected, value, "IsEthernetSelected");
			}
		}

		// Token: 0x1700055C RID: 1372
		// (get) Token: 0x06000AD6 RID: 2774 RVA: 0x0001A98A File Offset: 0x00018B8A
		// (set) Token: 0x06000AD7 RID: 2775 RVA: 0x0001A992 File Offset: 0x00018B92
		public string EthernetConnectionTitle
		{
			get
			{
				return this._EthernetConnectionTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._EthernetConnectionTitle, value, "EthernetConnectionTitle");
			}
		}

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x0001A9A7 File Offset: 0x00018BA7
		// (set) Token: 0x06000AD9 RID: 2777 RVA: 0x0001A9AF File Offset: 0x00018BAF
		public bool IsHybridVisible
		{
			get
			{
				return this._IsHybridVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsHybridVisible, value, "IsHybridVisible");
			}
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06000ADA RID: 2778 RVA: 0x0001A9C4 File Offset: 0x00018BC4
		// (set) Token: 0x06000ADB RID: 2779 RVA: 0x0001A9CC File Offset: 0x00018BCC
		public string HybridTime
		{
			get
			{
				return this._HybridTime;
			}
			set
			{
				this.SetProperty<string>(ref this._HybridTime, value, "HybridTime");
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06000ADC RID: 2780 RVA: 0x0001A9E1 File Offset: 0x00018BE1
		// (set) Token: 0x06000ADD RID: 2781 RVA: 0x0001A9E9 File Offset: 0x00018BE9
		public bool IsHybridSelected
		{
			get
			{
				return this._IsHybridSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsHybridSelected, value, "IsHybridSelected");
			}
		}

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06000ADE RID: 2782 RVA: 0x0001A9FE File Offset: 0x00018BFE
		// (set) Token: 0x06000ADF RID: 2783 RVA: 0x0001AA06 File Offset: 0x00018C06
		public string HybridConnectionTitle
		{
			get
			{
				return this._HybridConnectionTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._HybridConnectionTitle, value, "HybridConnectionTitle");
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06000AE0 RID: 2784 RVA: 0x0001AA1B File Offset: 0x00018C1B
		// (set) Token: 0x06000AE1 RID: 2785 RVA: 0x0001AA23 File Offset: 0x00018C23
		public bool IsUsbVisible
		{
			get
			{
				return this._IsUsbVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsUsbVisible, value, "IsUsbVisible");
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06000AE2 RID: 2786 RVA: 0x0001AA38 File Offset: 0x00018C38
		// (set) Token: 0x06000AE3 RID: 2787 RVA: 0x0001AA40 File Offset: 0x00018C40
		public string UsbTime
		{
			get
			{
				return this._UsbTime;
			}
			set
			{
				this.SetProperty<string>(ref this._UsbTime, value, "UsbTime");
			}
		}

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x0001AA55 File Offset: 0x00018C55
		// (set) Token: 0x06000AE5 RID: 2789 RVA: 0x0001AA5D File Offset: 0x00018C5D
		public bool IsUsbSelected
		{
			get
			{
				return this._IsUsbSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsUsbSelected, value, "IsUsbSelected");
			}
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x0001AA72 File Offset: 0x00018C72
		// (set) Token: 0x06000AE7 RID: 2791 RVA: 0x0001AA7A File Offset: 0x00018C7A
		public string USBConnectionTitle
		{
			get
			{
				return this._USBConnectionTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._USBConnectionTitle, value, "USBConnectionTitle");
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06000AE8 RID: 2792 RVA: 0x0001AA8F File Offset: 0x00018C8F
		// (set) Token: 0x06000AE9 RID: 2793 RVA: 0x0001AA97 File Offset: 0x00018C97
		public bool IsNoUSBSelected
		{
			get
			{
				return this._IsNoUSBSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsNoUSBSelected, false, "IsNoUSBSelected");
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06000AEA RID: 2794 RVA: 0x0001AAAC File Offset: 0x00018CAC
		// (set) Token: 0x06000AEB RID: 2795 RVA: 0x0001AAB4 File Offset: 0x00018CB4
		public bool IsWifiVisible
		{
			get
			{
				return this._IsWifiVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsWifiVisible, value, "IsWifiVisible");
			}
		}

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06000AEC RID: 2796 RVA: 0x0001AAC9 File Offset: 0x00018CC9
		// (set) Token: 0x06000AED RID: 2797 RVA: 0x0001AAD1 File Offset: 0x00018CD1
		public string WifiTime
		{
			get
			{
				return this._WifiTime;
			}
			set
			{
				this.SetProperty<string>(ref this._WifiTime, value, "WifiTime");
			}
		}

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06000AEE RID: 2798 RVA: 0x0001AAE6 File Offset: 0x00018CE6
		// (set) Token: 0x06000AEF RID: 2799 RVA: 0x0001AAEE File Offset: 0x00018CEE
		public bool IsWifiSelected
		{
			get
			{
				return this._IsWifiSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsWifiSelected, value, "IsWifiSelected");
			}
		}

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x0001AB03 File Offset: 0x00018D03
		// (set) Token: 0x06000AF1 RID: 2801 RVA: 0x0001AB0B File Offset: 0x00018D0B
		public string WirelessConnectionTitle
		{
			get
			{
				return this._WirelessConnectionTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._WirelessConnectionTitle, value, "WirelessConnectionTitle");
			}
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x06000AF2 RID: 2802 RVA: 0x0001AB20 File Offset: 0x00018D20
		// (set) Token: 0x06000AF3 RID: 2803 RVA: 0x0001AB28 File Offset: 0x00018D28
		public bool IsCrossoverVisible
		{
			get
			{
				return this._IsCrossoverVisible;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCrossoverVisible, value, "IsCrossoverVisible");
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0001AB3D File Offset: 0x00018D3D
		// (set) Token: 0x06000AF5 RID: 2805 RVA: 0x0001AB45 File Offset: 0x00018D45
		public bool IsCrossoverSelected
		{
			get
			{
				return this._IsCrossoverSelected;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCrossoverSelected, value, "IsCrossoverSelected");
			}
		}

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06000AF6 RID: 2806 RVA: 0x0001AB5A File Offset: 0x00018D5A
		// (set) Token: 0x06000AF7 RID: 2807 RVA: 0x0001AB62 File Offset: 0x00018D62
		public string CrossoverTime
		{
			get
			{
				return this._CrossoverTime;
			}
			set
			{
				this.SetProperty<string>(ref this._CrossoverTime, value, "CrossoverTime");
			}
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x0001AB77 File Offset: 0x00018D77
		// (set) Token: 0x06000AF9 RID: 2809 RVA: 0x0001AB7F File Offset: 0x00018D7F
		public string CrossoverConnectionTitle
		{
			get
			{
				return this._CrossoverConnectionTitle;
			}
			set
			{
				this.SetProperty<string>(ref this._CrossoverConnectionTitle, value, "CrossoverConnectionTitle");
			}
		}

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06000AFA RID: 2810 RVA: 0x0001AB94 File Offset: 0x00018D94
		// (set) Token: 0x06000AFB RID: 2811 RVA: 0x0001AB9C File Offset: 0x00018D9C
		public bool ShowEstimateTime
		{
			get
			{
				return this._ShowEstimateTime;
			}
			private set
			{
				this.SetProperty<bool>(ref this._ShowEstimateTime, value, "ShowEstimateTime");
			}
		}

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06000AFC RID: 2812 RVA: 0x0001ABB1 File Offset: 0x00018DB1
		// (set) Token: 0x06000AFD RID: 2813 RVA: 0x0001ABB9 File Offset: 0x00018DB9
		public ConnectionWizardQuestions Questions { get; set; }

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06000AFE RID: 2814 RVA: 0x0001ABC2 File Offset: 0x00018DC2
		// (set) Token: 0x06000AFF RID: 2815 RVA: 0x0001ABCA File Offset: 0x00018DCA
		public bool NoOptionsAvailable
		{
			get
			{
				return this._NoOptionsAvailable;
			}
			set
			{
				this.SetProperty<bool>(ref this._NoOptionsAvailable, value, "NoOptionsAvailable");
			}
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06000B00 RID: 2816 RVA: 0x0001ABDF File Offset: 0x00018DDF
		// (set) Token: 0x06000B01 RID: 2817 RVA: 0x0001ABE7 File Offset: 0x00018DE7
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000B02 RID: 2818 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextCommand()
		{
			return true;
		}

		// Token: 0x06000B03 RID: 2819 RVA: 0x0001ABF0 File Offset: 0x00018DF0
		private void OnNextCommand()
		{
			if (this.IsUsbSelected)
			{
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("UsbInfoPage", UriKind.Relative));
				return;
			}
			if (this.IsCrossoverSelected)
			{
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("CrossoverInfoPage", UriKind.Relative));
				return;
			}
			if (this.IsExternalHdSelected)
			{
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FilesBasedTransferPage", UriKind.Relative));
				return;
			}
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative));
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06000B04 RID: 2820 RVA: 0x0001AC84 File Offset: 0x00018E84
		// (set) Token: 0x06000B05 RID: 2821 RVA: 0x0001AC8C File Offset: 0x00018E8C
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000B06 RID: 2822 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0001AC95 File Offset: 0x00018E95
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindFastestTransferType", UriKind.Relative));
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x0001ACB2 File Offset: 0x00018EB2
		// (set) Token: 0x06000B09 RID: 2825 RVA: 0x0001ACBA File Offset: 0x00018EBA
		public DelegateCommand OnCableInfo { get; private set; }

		// Token: 0x06000B0A RID: 2826 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCableInfoCommand()
		{
			return true;
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0001ACC4 File Offset: 0x00018EC4
		private void OnOnCableInfoCommand()
		{
			try
			{
				Process.Start(Tools.GetResourceString("RTMP_WhatsCable_URL"));
			}
			catch
			{
			}
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0001ACF8 File Offset: 0x00018EF8
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Unsubscribe(new Action<ActivityInfo>(this.OnActivityInfo));
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0001AD18 File Offset: 0x00018F18
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.RecommendedTransferMethod);
			this.Questions = (ConnectionWizardQuestions)navigationContext.Parameters["WizardQuestions"];
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_RecommendedTransferMethods);
			this.eventAggregator.GetEvent<EngineEvents.ActivityInfoChanged>().Subscribe(new Action<ActivityInfo>(this.OnActivityInfo), ThreadOption.UIThread);
			this.Update();
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0001AD8C File Offset: 0x00018F8C
		private void OnActivityInfo(ActivityInfo activityInfo)
		{
			if (activityInfo.Type == ActivityType.Listen && activityInfo.Phase == 2)
			{
				NavigationParameters parameters = new NavigationParameters();
				base.pcmoverEngine.CatchCommEx(delegate
				{
					this.pcmoverEngine.Ts.TraceInformation("RecommendedTransferMethodsPageViewModel.OnActivityInfo: Set ThisMachineIsOld = true");
					this.pcmoverEngine.ThisMachineIsOld = true;
					parameters.Add("IsConnected", true);
					this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FindPCPage", UriKind.Relative), parameters);
				}, "OnActivityInfo");
			}
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0001ADE0 File Offset: 0x00018FE0
		private void Update()
		{
			this.IsUsbVisible = this.Questions.UsbCableYes;
			this.IsUsbSelected = this.IsUsbVisible;
			this.IsEthernetVisible = (this.Questions.EthernetPortLocal && this.Questions.EthernetPortRemoteYes && this.Questions.EthernetCableYes);
			this.IsEthernetSelected = (this.IsEthernetVisible && !this.IsUsbSelected);
			this.IsCrossoverVisible = this.IsEthernetVisible;
			this.IsCrossoverSelected = false;
			this.IsHybridVisible = (this.Questions.EthernetCableYes && (this.Questions.WiFiLocal || this.Questions.WiFiRemoteYes) && (this.Questions.EthernetPortLocal || this.Questions.EthernetPortRemoteYes) && (!this.Questions.EthernetPortRemoteNo || !this.Questions.WiFiRemoteNo) && (this.Questions.EthernetPortLocal || this.Questions.WiFiLocal));
			this.IsHybridSelected = (this.IsHybridVisible && !this.IsUsbSelected && !this.IsEthernetSelected && !this.IsCrossoverSelected);
			this.IsWifiVisible = (this.Questions.WiFiLocal && this.Questions.WiFiRemoteYes);
			this.IsWifiSelected = (this.IsWifiVisible && !this.IsUsbSelected && !this.IsEthernetSelected && !this.IsCrossoverSelected && !this.IsHybridSelected);
			this.IsExternalHdVisible = this.Questions.ExternalUsbDriveYes;
			this.IsExternalHdSelected = (this.IsExternalHdVisible && !this.IsUsbSelected && !this.IsEthernetSelected && !this.IsCrossoverSelected && !this.IsHybridSelected && !this.IsWifiSelected);
			this.NoOptionsAvailable = (!this.IsUsbVisible && !this.IsEthernetVisible && !this.IsCrossoverVisible && !this.IsWifiVisible && !this.IsExternalHdVisible && !this.IsHybridVisible);
			this.SetConnectionTitles();
			this.UsbTime = string.Format(WizardModule.Properties.Resources.RTMP_Timespan, "3", "4");
			this.EthernetTime = string.Format(WizardModule.Properties.Resources.RTMP_Timespan, "4", "5");
			this.CrossoverTime = string.Format(WizardModule.Properties.Resources.RTMP_Timespan, "4", "5");
			this.HybridTime = string.Format(WizardModule.Properties.Resources.RTMP_Timespan, "8", "9");
			this.WifiTime = string.Format(WizardModule.Properties.Resources.RTMP_Timespan, "10", "14");
			this.ExternalHdTime = string.Format(WizardModule.Properties.Resources.RTMP_Timespan, "3", "4");
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0001B088 File Offset: 0x00019288
		private void SetConnectionTitles()
		{
			this.USBConnectionTitle = WizardModule.Properties.Resources.RTMP_USBConnection;
			this.EthernetConnectionTitle = WizardModule.Properties.Resources.RTMP_EthernetConnection;
			this.CrossoverConnectionTitle = WizardModule.Properties.Resources.RTMP_CrossoverConnection;
			this.HybridConnectionTitle = WizardModule.Properties.Resources.RTMP_HybridConnection;
			this.WirelessConnectionTitle = WizardModule.Properties.Resources.RTMP_WirelessConnection;
			this.ExternalHDConnectionTitle = WizardModule.Properties.Resources.RTMP_ExternalHDConnection;
			if (this.IsUsbVisible)
			{
				this.USBConnectionTitle = "(" + WizardModule.Properties.Resources.RTMP_BestOption + ") " + this.USBConnectionTitle;
				return;
			}
			if (this.IsEthernetVisible)
			{
				this.EthernetConnectionTitle = "(" + WizardModule.Properties.Resources.RTMP_BestOption + ") " + this.EthernetConnectionTitle;
				return;
			}
			if (this.IsCrossoverVisible)
			{
				this.CrossoverConnectionTitle = "(" + WizardModule.Properties.Resources.RTMP_BestOption + ") " + this.CrossoverConnectionTitle;
				return;
			}
			if (this.IsHybridVisible)
			{
				this.HybridConnectionTitle = "(" + WizardModule.Properties.Resources.RTMP_BestOption + ") " + this.HybridConnectionTitle;
				return;
			}
			if (this.IsWifiVisible)
			{
				this.WirelessConnectionTitle = "(" + WizardModule.Properties.Resources.RTMP_BestOption + ") " + this.WirelessConnectionTitle;
				return;
			}
			if (this._IsExternalHdVisible)
			{
				this.ExternalHDConnectionTitle = "(" + WizardModule.Properties.Resources.RTMP_BestOption + ") " + this.ExternalHDConnectionTitle;
			}
		}

		// Token: 0x04000357 RID: 855
		private readonly IRegionManager regionManager;

		// Token: 0x04000358 RID: 856
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000359 RID: 857
		private bool _IsExternalHdVisible;

		// Token: 0x0400035A RID: 858
		private string _ExternalHdTime;

		// Token: 0x0400035B RID: 859
		private bool _IsExternalHdSelected;

		// Token: 0x0400035C RID: 860
		private string _ExternalHDConnectionTitle;

		// Token: 0x0400035D RID: 861
		private bool _IsEthernetVisible;

		// Token: 0x0400035E RID: 862
		private string _EthernetTime;

		// Token: 0x0400035F RID: 863
		private bool _IsEthernetSelected;

		// Token: 0x04000360 RID: 864
		private string _EthernetConnectionTitle;

		// Token: 0x04000361 RID: 865
		private bool _IsHybridVisible;

		// Token: 0x04000362 RID: 866
		private string _HybridTime;

		// Token: 0x04000363 RID: 867
		private bool _IsHybridSelected;

		// Token: 0x04000364 RID: 868
		private string _HybridConnectionTitle;

		// Token: 0x04000365 RID: 869
		private bool _IsUsbVisible;

		// Token: 0x04000366 RID: 870
		private string _UsbTime;

		// Token: 0x04000367 RID: 871
		private bool _IsUsbSelected;

		// Token: 0x04000368 RID: 872
		private string _USBConnectionTitle;

		// Token: 0x04000369 RID: 873
		private bool _IsNoUSBSelected;

		// Token: 0x0400036A RID: 874
		private bool _IsWifiVisible;

		// Token: 0x0400036B RID: 875
		private string _WifiTime;

		// Token: 0x0400036C RID: 876
		private bool _IsWifiSelected;

		// Token: 0x0400036D RID: 877
		private string _WirelessConnectionTitle;

		// Token: 0x0400036E RID: 878
		private bool _IsCrossoverVisible;

		// Token: 0x0400036F RID: 879
		private bool _IsCrossoverSelected;

		// Token: 0x04000370 RID: 880
		private string _CrossoverTime;

		// Token: 0x04000371 RID: 881
		private string _CrossoverConnectionTitle;

		// Token: 0x04000372 RID: 882
		private bool _ShowEstimateTime;

		// Token: 0x04000374 RID: 884
		private bool _NoOptionsAvailable;
	}
}
