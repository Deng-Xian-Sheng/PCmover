using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Popups;
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
	// Token: 0x0200008E RID: 142
	public class SectionAdvancedViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000B12 RID: 2834 RVA: 0x0001B1CC File Offset: 0x000193CC
		public SectionAdvancedViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this.OnDriveMappingChanged = new DelegateCommand<string>(new Action<string>(this.OnDriveMappingChangedCommand), new Func<string, bool>(this.CanOnDriveMappingChangedCommand));
			this.OnDriveMappingChanging = new DelegateCommand<string>(new Action<string>(this.OnDriveMappingChangingCommand), new Func<string, bool>(this.CanOnDriveMappingChangingCommand));
			this.OnDriveMappingCanceled = new DelegateCommand<string>(new Action<string>(this.OnDriveMappingCanceledCommand), new Func<string, bool>(this.CanOnDriveMappingCanceledCommand));
			this.OnChangeMiscSettings = new DelegateCommand<MiscSettingData>(new Action<MiscSettingData>(this.OnChangeMiscSettingsCommand), new Func<MiscSettingData, bool>(this.CanOnChangeMiscSettingsCommand));
			this.OnFilesBasedDriveSelectionChanged = new DelegateCommand<string>(new Action<string>(this.OnFilesBasedDriveSelectionChangedCommand), new Func<string, bool>(this.CanOnFilesBasedDriveSelectionChangedCommand));
			this.OnFileFilter = new DelegateCommand(new Action(this.OnFileFilterCommand), new Func<bool>(this.CanOnFileFilterCommand));
			this._MiscSettingsGroups = new ObservableCollection<MiscSettingsGroupData>();
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x0001B2D7 File Offset: 0x000194D7
		// (set) Token: 0x06000B14 RID: 2836 RVA: 0x0001B2DF File Offset: 0x000194DF
		public bool IsReadOnly
		{
			get
			{
				return this._IsReadOnly;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsReadOnly, value, "IsReadOnly");
			}
		}

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x0001B2F4 File Offset: 0x000194F4
		// (set) Token: 0x06000B16 RID: 2838 RVA: 0x0001B2FC File Offset: 0x000194FC
		public bool DriveCountMismatch
		{
			get
			{
				return this._DriveCountMismatch;
			}
			private set
			{
				this.SetProperty<bool>(ref this._DriveCountMismatch, value, "DriveCountMismatch");
			}
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x0001B311 File Offset: 0x00019511
		// (set) Token: 0x06000B18 RID: 2840 RVA: 0x0001B319 File Offset: 0x00019519
		public bool IsDrivePopupOpen
		{
			get
			{
				return this._IsDrivePopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsDrivePopupOpen, value, "IsDrivePopupOpen");
				this.OnDriveMappingChanged.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06000B19 RID: 2841 RVA: 0x0001B339 File Offset: 0x00019539
		// (set) Token: 0x06000B1A RID: 2842 RVA: 0x0001B341 File Offset: 0x00019541
		public string OldDriveLocation
		{
			get
			{
				return this._OldDriveLocation;
			}
			private set
			{
				this.SetProperty<string>(ref this._OldDriveLocation, value, "OldDriveLocation");
			}
		}

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x0001B356 File Offset: 0x00019556
		// (set) Token: 0x06000B1C RID: 2844 RVA: 0x0001B35E File Offset: 0x0001955E
		public string NewDriveLocation
		{
			get
			{
				return this._NewDriveLocation;
			}
			set
			{
				this.SetProperty<string>(ref this._NewDriveLocation, value, "NewDriveLocation");
				if (!string.IsNullOrEmpty(this._NewDriveLocation))
				{
					this.IsNewPathValid = Tools.IsValidPath(this._NewDriveLocation);
				}
			}
		}

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x0001B391 File Offset: 0x00019591
		// (set) Token: 0x06000B1E RID: 2846 RVA: 0x0001B399 File Offset: 0x00019599
		public ObservableCollection<UIDrivePair> DriveMapping
		{
			get
			{
				return this._DriveMapping;
			}
			private set
			{
				this.SetProperty<ObservableCollection<UIDrivePair>>(ref this._DriveMapping, value, "DriveMapping");
			}
		}

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x06000B1F RID: 2847 RVA: 0x0001B3AE File Offset: 0x000195AE
		// (set) Token: 0x06000B20 RID: 2848 RVA: 0x0001B3B6 File Offset: 0x000195B6
		public MiscSettingsData MiscellaneousSettings
		{
			get
			{
				return this._MiscellaneousSettings;
			}
			private set
			{
				this.SetProperty<MiscSettingsData>(ref this._MiscellaneousSettings, value, "MiscellaneousSettings");
			}
		}

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06000B21 RID: 2849 RVA: 0x0001B3CB File Offset: 0x000195CB
		// (set) Token: 0x06000B22 RID: 2850 RVA: 0x0001B3D3 File Offset: 0x000195D3
		public ObservableCollection<MiscSettingsGroupData> MiscSettingsGroups
		{
			get
			{
				return this._MiscSettingsGroups;
			}
			private set
			{
				this.SetProperty<ObservableCollection<MiscSettingsGroupData>>(ref this._MiscSettingsGroups, value, "MiscSettingsGroups");
			}
		}

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06000B23 RID: 2851 RVA: 0x0001B3E8 File Offset: 0x000195E8
		// (set) Token: 0x06000B24 RID: 2852 RVA: 0x0001B3F0 File Offset: 0x000195F0
		public bool IsNewPathValid
		{
			get
			{
				return this._IsNewPathValid;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsNewPathValid, value, "IsNewPathValid");
			}
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06000B25 RID: 2853 RVA: 0x0001B405 File Offset: 0x00019605
		// (set) Token: 0x06000B26 RID: 2854 RVA: 0x0001B40D File Offset: 0x0001960D
		public bool HideSettings
		{
			get
			{
				return this._HideSettings;
			}
			private set
			{
				this.SetProperty<bool>(ref this._HideSettings, value, "HideSettings");
			}
		}

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06000B27 RID: 2855 RVA: 0x0001B422 File Offset: 0x00019622
		// (set) Token: 0x06000B28 RID: 2856 RVA: 0x0001B42A File Offset: 0x0001962A
		public bool IsDriveMappingIncludeExclude
		{
			get
			{
				return this._IsDriveMappingIncludeExclude;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsDriveMappingIncludeExclude, value, "IsDriveMappingIncludeExclude");
			}
		}

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06000B29 RID: 2857 RVA: 0x0001B43F File Offset: 0x0001963F
		// (set) Token: 0x06000B2A RID: 2858 RVA: 0x0001B447 File Offset: 0x00019647
		public bool IsDriveExcluded
		{
			get
			{
				return this._IsDriveExcluded;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsDriveExcluded, value, "IsDriveExcluded");
				if (this._IsDriveExcluded)
				{
					this.IsNewPathValid = true;
				}
			}
		}

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06000B2B RID: 2859 RVA: 0x0001B46B File Offset: 0x0001966B
		// (set) Token: 0x06000B2C RID: 2860 RVA: 0x0001B473 File Offset: 0x00019673
		public ObservableCollection<FileFilter> FileFilters
		{
			get
			{
				return this._FileFilters;
			}
			private set
			{
				this.SetProperty<ObservableCollection<FileFilter>>(ref this._FileFilters, value, "FileFilters");
			}
		}

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x06000B2D RID: 2861 RVA: 0x0001B488 File Offset: 0x00019688
		// (set) Token: 0x06000B2E RID: 2862 RVA: 0x0001B490 File Offset: 0x00019690
		public bool IsDriveMappingEnabled
		{
			get
			{
				return this._IsDriveMappingEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsDriveMappingEnabled, value, "IsDriveMappingEnabled");
			}
		}

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x06000B2F RID: 2863 RVA: 0x0001B4A5 File Offset: 0x000196A5
		// (set) Token: 0x06000B30 RID: 2864 RVA: 0x0001B4AD File Offset: 0x000196AD
		public bool IsMigModEnabled
		{
			get
			{
				return this._IsMigModEnabled;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsMigModEnabled, value, "IsMigModEnabled");
			}
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x06000B31 RID: 2865 RVA: 0x0001B4C2 File Offset: 0x000196C2
		// (set) Token: 0x06000B32 RID: 2866 RVA: 0x0001B4CA File Offset: 0x000196CA
		public DelegateCommand<string> OnDriveMappingChanged { get; private set; }

		// Token: 0x06000B33 RID: 2867 RVA: 0x0001B4D3 File Offset: 0x000196D3
		private bool CanOnDriveMappingChangedCommand(string arg)
		{
			return this.IsDriveMappingEnabled;
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0001B4DC File Offset: 0x000196DC
		private void OnDriveMappingChangedCommand(string arg)
		{
			if (!this.IsNewPathValid)
			{
				return;
			}
			this.IsDrivePopupOpen = false;
			if (this.IsDriveExcluded)
			{
				this.NewDriveLocation = string.Empty;
			}
			UIDrivePair uidrivePair = this.DriveMapping.First((UIDrivePair x) => x.OldDrive == this.OldDriveLocation);
			uidrivePair.ShowChange = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowChange);
			uidrivePair.NewDrive = this.NewDriveLocation;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				DrivePair drivePair = base.pcmoverEngine.Drives.Matches.First((DrivePair x) => x.OldDrive == this.OldDriveLocation);
				if (string.IsNullOrEmpty(this.NewDriveLocation))
				{
					drivePair.NewDrive = null;
				}
				else
				{
					drivePair.NewDrive = this.NewDriveLocation;
				}
				CustomizationData customizationData = base.pcmoverEngine.ChangeDriveMapping(drivePair);
				if (customizationData.Result != CustomizationResult.Success)
				{
					if (!string.IsNullOrEmpty(customizationData.Message))
					{
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, customizationData.Message, WizardModule.Properties.Resources.strError + " " + customizationData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					}
					else
					{
						WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, WizardModule.Properties.Resources.SU_Error, WizardModule.Properties.Resources.strError + " " + customizationData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
					}
				}
				else if (!string.IsNullOrEmpty(customizationData.Message))
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, customizationData.Message, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				}
				if (customizationData.Result == CustomizationResult.Success)
				{
					this.policy.enginePolicy.DriveMap.Drives.Add(new EnginePolicy.DriveMapItem(this.OldDriveLocation, this.NewDriveLocation));
				}
				this.migrationDefinition.DirtyCustomizationItems |= customizationData.Affects;
				base.pcmoverEngine.RetrieveDiskData();
				this.Update();
			}, "OnDriveMappingChangedCommand");
		}

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06000B35 RID: 2869 RVA: 0x0001B55B File Offset: 0x0001975B
		// (set) Token: 0x06000B36 RID: 2870 RVA: 0x0001B563 File Offset: 0x00019763
		public DelegateCommand<string> OnDriveMappingCanceled { get; private set; }

		// Token: 0x06000B37 RID: 2871 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnDriveMappingCanceledCommand(string arg)
		{
			return true;
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0001B56C File Offset: 0x0001976C
		private void OnDriveMappingCanceledCommand(string arg)
		{
			this.IsDrivePopupOpen = false;
		}

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06000B39 RID: 2873 RVA: 0x0001B575 File Offset: 0x00019775
		// (set) Token: 0x06000B3A RID: 2874 RVA: 0x0001B57D File Offset: 0x0001977D
		public DelegateCommand<string> OnDriveMappingChanging { get; private set; }

		// Token: 0x06000B3B RID: 2875 RVA: 0x0001B586 File Offset: 0x00019786
		private bool CanOnDriveMappingChangingCommand(string arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0001B591 File Offset: 0x00019791
		private void OnDriveMappingChangingCommand(string arg)
		{
			this.OldDriveLocation = arg;
			base.pcmoverEngine.CatchCommEx(delegate
			{
				DrivePair drivePair = base.pcmoverEngine.Drives.Matches.First((DrivePair x) => x.OldDrive == this.OldDriveLocation);
				this.NewDriveLocation = drivePair.NewDrive;
				this.IsDriveExcluded = string.IsNullOrEmpty(this.NewDriveLocation);
				this.IsDrivePopupOpen = true;
			}, "OnDriveMappingChangingCommand");
		}

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0001B5B7 File Offset: 0x000197B7
		// (set) Token: 0x06000B3E RID: 2878 RVA: 0x0001B5BF File Offset: 0x000197BF
		public DelegateCommand<MiscSettingData> OnChangeMiscSettings { get; private set; }

		// Token: 0x06000B3F RID: 2879 RVA: 0x0001B586 File Offset: 0x00019786
		private bool CanOnChangeMiscSettingsCommand(MiscSettingData arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0001B5C8 File Offset: 0x000197C8
		private void OnChangeMiscSettingsCommand(MiscSettingData arg)
		{
			base.pcmoverEngine.Ts.TraceInformation(string.Format("Changing misc setting for {0} to {1}", arg.Name, arg.Selected));
			CustomizationData cData = null;
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				cData = this.pcmoverEngine.ChangeMiscSetting(arg);
			}, "OnChangeMiscSettingsCommand"))
			{
				base.pcmoverEngine.Ts.TraceInformation("ComException when calling ChangeMiscSetting");
				return;
			}
			if (cData.Result != CustomizationResult.Success)
			{
				if (!string.IsNullOrEmpty(cData.Message))
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, cData.Message, WizardModule.Properties.Resources.strError + " " + cData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				}
				else
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, WizardModule.Properties.Resources.SU_Error, WizardModule.Properties.Resources.strError + " " + cData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				}
			}
			else if (!string.IsNullOrEmpty(cData.Message))
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, cData.Message, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
			}
			this.migrationDefinition.DirtyCustomizationItems |= cData.Affects;
			try
			{
				if (cData.Result == CustomizationResult.Success)
				{
					EnginePolicy.MigModItem migModItem = this.policy.enginePolicy.MigMod.Items.FirstOrDefault((EnginePolicy.MigModItem i) => i.Name == arg.Name);
					if (migModItem == null)
					{
						this.policy.enginePolicy.MigMod.Items.Add(new EnginePolicy.MigModItem(arg.Name, new bool?(arg.Selected)));
					}
					else
					{
						migModItem.Selected = new bool?(arg.Selected);
					}
				}
				this.policy.WriteProfile();
			}
			catch (Exception ex)
			{
				base.pcmoverEngine.Ts.TraceException(ex, "OnChangeMiscSettingsCommand");
			}
		}

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06000B41 RID: 2881 RVA: 0x0001B834 File Offset: 0x00019A34
		// (set) Token: 0x06000B42 RID: 2882 RVA: 0x0001B83C File Offset: 0x00019A3C
		public DelegateCommand<string> OnFilesBasedDriveSelectionChanged { get; private set; }

		// Token: 0x06000B43 RID: 2883 RVA: 0x0001B586 File Offset: 0x00019786
		private bool CanOnFilesBasedDriveSelectionChangedCommand(string arg)
		{
			return !this.IsReadOnly;
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0001B848 File Offset: 0x00019A48
		private void OnFilesBasedDriveSelectionChangedCommand(string drive)
		{
			UIDrivePair uidrivePair = this.DriveMapping.First((UIDrivePair x) => x.OldDrive == drive);
			uidrivePair.ShowChange = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowChange);
			DrivePair match = base.pcmoverEngine.Drives.Matches.First((DrivePair x) => x.OldDrive == drive);
			match.NewDrive = (uidrivePair.Selected ? match.OldDrive : null);
			CustomizationData cData = null;
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				cData = this.pcmoverEngine.ChangeDriveMapping(match);
			}, "OnFilesBasedDriveSelectionChangedCommand"))
			{
				return;
			}
			if (cData.Result != CustomizationResult.Success)
			{
				if (!string.IsNullOrEmpty(cData.Message))
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, cData.Message, WizardModule.Properties.Resources.strError + " " + cData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				}
				else
				{
					WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, WizardModule.Properties.Resources.SU_Error, WizardModule.Properties.Resources.strError + " " + cData.Result.ToString(), PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				}
			}
			else if (!string.IsNullOrEmpty(cData.Message))
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, cData.Message, "", PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
			}
			if (cData.Result == CustomizationResult.Success)
			{
				EnginePolicy.DriveMapItem driveMapItem = this.policy.enginePolicy.DriveMap.Drives.FirstOrDefault((EnginePolicy.DriveMapItem x) => x.Source.ToUpper() == match.OldDrive.ToUpper());
				if (driveMapItem != null)
				{
					driveMapItem.Target = (uidrivePair.Selected ? match.OldDrive : string.Empty);
					if (string.IsNullOrWhiteSpace(driveMapItem.Target))
					{
						driveMapItem.Migrate = new bool?(false);
					}
					else
					{
						driveMapItem.Migrate = null;
					}
				}
				else
				{
					this.policy.enginePolicy.DriveMap.Drives.Add(new EnginePolicy.DriveMapItem(match.OldDrive, match.NewDrive));
				}
			}
			this.migrationDefinition.DirtyCustomizationItems |= cData.Affects;
			this.Update();
		}

		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06000B45 RID: 2885 RVA: 0x0001BADA File Offset: 0x00019CDA
		// (set) Token: 0x06000B46 RID: 2886 RVA: 0x0001BAE2 File Offset: 0x00019CE2
		public DelegateCommand OnFileFilter { get; private set; }

		// Token: 0x06000B47 RID: 2887 RVA: 0x0001BAEC File Offset: 0x00019CEC
		private bool CanOnFileFilterCommand()
		{
			if (!this.IsReadOnly)
			{
				bool? interactive = this.policy.enginePolicy.FileFilter.Interactive;
				bool flag = false;
				return !(interactive.GetValueOrDefault() == flag & interactive != null);
			}
			return false;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0001BB30 File Offset: 0x00019D30
		private void OnFileFilterCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("FileFilterPage", UriKind.Relative));
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0001BB50 File Offset: 0x00019D50
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.SecAdvanced);
			this.IsReadOnly = (navigationContext.NavigationService.Region.Name == RegionNames.TransferCompleteDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.SummaryDetailButtons || navigationContext.NavigationService.Region.Name == RegionNames.FilesBasedSummaryDetailButtons);
			this.Update();
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(true);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x0001BBE1 File Offset: 0x00019DE1
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<Events.InSectionPage>().Publish(false);
			this.policy.WriteProfile();
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0001BBFF File Offset: 0x00019DFF
		private void Update()
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (this.migrationDefinition.DirtyCustomizationItems.HasFlag(CustomizationAffects.Drives))
				{
					base.pcmoverEngine.RetrieveDrives();
					this.migrationDefinition.DirtyCustomizationItems &= ~CustomizationAffects.Drives;
				}
				this.DriveMapping = new ObservableCollection<UIDrivePair>();
				if (base.pcmoverEngine.Drives != null)
				{
					using (IEnumerator<string> enumerator = base.pcmoverEngine.Drives.OldDrives.GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							string oldDrive = enumerator.Current;
							UIDrivePair uidrivePair = new UIDrivePair
							{
								OldDrive = oldDrive
							};
							uidrivePair.ShowChange = Convert.ToBoolean(PcmBrandUI.Properties.Resources.Feature_ShowChange);
							if (base.pcmoverEngine.Drives.Matches.Any((DrivePair x) => x.OldDrive == oldDrive))
							{
								uidrivePair.NewDrive = base.pcmoverEngine.Drives.Matches.First((DrivePair x) => x.OldDrive == oldDrive).NewDrive;
								uidrivePair.Selected = !string.IsNullOrEmpty(uidrivePair.NewDrive);
							}
							else
							{
								uidrivePair.NewDrive = string.Empty;
								uidrivePair.Selected = false;
								base.pcmoverEngine.Drives.Matches.Add(new DrivePair
								{
									OldDrive = oldDrive,
									NewDrive = string.Empty
								});
							}
							this.DriveMapping.Add(uidrivePair);
						}
					}
				}
				this.HideSettings = (this.migrationDefinition.MigrationType == TransferMethodType.File && !base.pcmoverEngine.ThisMachineIsOld);
				this.IsDriveMappingIncludeExclude = (this.migrationDefinition.MigrationType == TransferMethodType.File && base.pcmoverEngine.ThisMachineIsOld);
				bool? interactive;
				bool flag;
				bool isDriveMappingEnabled;
				if (base.pcmoverEngine.ThisMachine.IsEngineRunningAsAdmin)
				{
					interactive = this.policy.enginePolicy.DriveMap.Interactive;
					flag = false;
					isDriveMappingEnabled = !(interactive.GetValueOrDefault() == flag & interactive != null);
				}
				else
				{
					isDriveMappingEnabled = false;
				}
				this.IsDriveMappingEnabled = isDriveMappingEnabled;
				interactive = this.policy.enginePolicy.MigMod.Interactive;
				flag = false;
				this.IsMigModEnabled = !(interactive.GetValueOrDefault() == flag & interactive != null);
				this.migrationDefinition.IsRedirectionSaved = true;
				this.migrationDefinition.IsUserMappingSaved = true;
				if (!this.HideSettings)
				{
					base.pcmoverEngine.RetrieveMiscSettings();
					this.MiscSettingsGroups = new ObservableCollection<MiscSettingsGroupData>();
					this.MiscellaneousSettings = base.pcmoverEngine.MiscSettingsData;
					foreach (MiscSettingsGroupData item in this.MiscellaneousSettings.Groups)
					{
						this.MiscSettingsGroups.Add(item);
					}
				}
				if (this.migrationDefinition.MigrationType != TransferMethodType.File && this.migrationDefinition.MigrationType != TransferMethodType.Image && this.migrationDefinition.MigrationType != TransferMethodType.WinUpgrade)
				{
					this.DriveCountMismatch = (base.pcmoverEngine.Drives.OldDrives.Count<string>() > base.pcmoverEngine.Drives.NewDrives.Count<string>());
				}
				base.pcmoverEngine.RetrieveFileFilters();
				this.FileFilters = new ObservableCollection<FileFilter>(base.pcmoverEngine.FileFilters);
			}, "Update");
		}

		// Token: 0x04000378 RID: 888
		private readonly IRegionManager regionManager;

		// Token: 0x04000379 RID: 889
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x0400037A RID: 890
		private readonly DefaultPolicy policy;

		// Token: 0x0400037B RID: 891
		private bool _IsReadOnly;

		// Token: 0x0400037C RID: 892
		private bool _DriveCountMismatch;

		// Token: 0x0400037D RID: 893
		private bool _IsDrivePopupOpen;

		// Token: 0x0400037E RID: 894
		private string _OldDriveLocation;

		// Token: 0x0400037F RID: 895
		private string _NewDriveLocation;

		// Token: 0x04000380 RID: 896
		private ObservableCollection<UIDrivePair> _DriveMapping;

		// Token: 0x04000381 RID: 897
		private MiscSettingsData _MiscellaneousSettings;

		// Token: 0x04000382 RID: 898
		private ObservableCollection<MiscSettingsGroupData> _MiscSettingsGroups;

		// Token: 0x04000383 RID: 899
		private bool _IsNewPathValid;

		// Token: 0x04000384 RID: 900
		private bool _HideSettings;

		// Token: 0x04000385 RID: 901
		private bool _IsDriveMappingIncludeExclude;

		// Token: 0x04000386 RID: 902
		private bool _IsDriveExcluded;

		// Token: 0x04000387 RID: 903
		private ObservableCollection<FileFilter> _FileFilters;

		// Token: 0x04000388 RID: 904
		private bool _IsDriveMappingEnabled;

		// Token: 0x04000389 RID: 905
		private bool _IsMigModEnabled;
	}
}
