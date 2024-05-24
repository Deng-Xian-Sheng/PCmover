using System;
using Laplink.Pcmover.ClientEngine;
using Laplink.Pcmover.Contracts;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x0200007C RID: 124
	public class CustomTransferPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x060006DC RID: 1756 RVA: 0x0000F738 File Offset: 0x0000D938
		public CustomTransferPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, LlTraceSource ts, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._navigationHelper = navigationHelper;
			this._ts = ts;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextTransfer));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			eventAggregator.GetEvent<Events.ChangedCustomSelection>().Subscribe(new Action<MigrationItemsOption>(this.OnPickCustomCommand));
			this.CustomizeCommand = new DelegateCommand(new Action(this.OnCustomize), new Func<bool>(this.CanOnCustomize));
			this.TransferSelection = MigrationItemsOption.All;
			this.IsTransferEverythingEnabled = true;
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x0000F805 File Offset: 0x0000DA05
		// (set) Token: 0x060006DE RID: 1758 RVA: 0x0000F80D File Offset: 0x0000DA0D
		public MigrationItemsOption TransferSelection
		{
			get
			{
				return this._TransferSelection;
			}
			private set
			{
				this.SetProperty<MigrationItemsOption>(ref this._TransferSelection, value, "TransferSelection");
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x060006DF RID: 1759 RVA: 0x0000F822 File Offset: 0x0000DA22
		// (set) Token: 0x060006E0 RID: 1760 RVA: 0x0000F82A File Offset: 0x0000DA2A
		public bool IsTransferEverythingEnabled
		{
			get
			{
				return this._IsTransferEverythingEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsTransferEverythingEnabled, value, "IsTransferEverythingEnabled");
			}
		}

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x060006E1 RID: 1761 RVA: 0x0000F83F File Offset: 0x0000DA3F
		// (set) Token: 0x060006E2 RID: 1762 RVA: 0x0000F847 File Offset: 0x0000DA47
		public bool IsFilesAndSettingsEnabled
		{
			get
			{
				return this._IsFilesAndSettingsEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsFilesAndSettingsEnabled, value, "IsFilesAndSettingsEnabled");
			}
		}

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x060006E3 RID: 1763 RVA: 0x0000F85C File Offset: 0x0000DA5C
		// (set) Token: 0x060006E4 RID: 1764 RVA: 0x0000F864 File Offset: 0x0000DA64
		public bool IsFilesOnlyEnabled
		{
			get
			{
				return this._IsFilesOnlyEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsFilesOnlyEnabled, value, "IsFilesOnlyEnabled");
			}
		}

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x060006E5 RID: 1765 RVA: 0x0000F879 File Offset: 0x0000DA79
		// (set) Token: 0x060006E6 RID: 1766 RVA: 0x0000F881 File Offset: 0x0000DA81
		public bool IsLetMeChooseEnabled
		{
			get
			{
				return this._isLetMeChooseEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._isLetMeChooseEnabled, value, "IsLetMeChooseEnabled");
			}
		}

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x060006E7 RID: 1767 RVA: 0x0000F896 File Offset: 0x0000DA96
		// (set) Token: 0x060006E8 RID: 1768 RVA: 0x0000F89E File Offset: 0x0000DA9E
		public DelegateCommand CustomizeCommand { get; private set; }

		// Token: 0x060006E9 RID: 1769 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCustomize()
		{
			return true;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0000F8A8 File Offset: 0x0000DAA8
		private void OnCustomize()
		{
			string uriString = (this.migrationDefinition.MigrationType == TransferMethodType.File) ? "FilesBasedCustomizePage" : "LetMeChoosePage";
			base.pcmoverEngine.MigrationItemsSelection = this.TransferSelection;
			this.policy.enginePolicy.MigItems.DefaultOption = new MigrationItemsOption?(this.TransferSelection);
			this.policy.customTransferPagePolicy.AutoCustomize = true;
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri(uriString, UriKind.Relative));
		}

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x0000F92A File Offset: 0x0000DB2A
		// (set) Token: 0x060006EC RID: 1772 RVA: 0x0000F932 File Offset: 0x0000DB32
		public DelegateCommand<string> OnPickCustom { get; private set; }

		// Token: 0x060006ED RID: 1773 RVA: 0x0000F93B File Offset: 0x0000DB3B
		private bool CanOnPickCustomCommand(string radioSelection)
		{
			return this.TransferSelection > MigrationItemsOption.All;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0000F948 File Offset: 0x0000DB48
		private void OnPickCustomCommand(MigrationItemsOption selection)
		{
			this.TransferSelection = selection;
			this.policy.enginePolicy.MigItems.DefaultOption = new MigrationItemsOption?(selection);
			if (this.migrationDefinition.MigrationType == TransferMethodType.File)
			{
				this.migrationDefinition.FilesBasedParameters.BuildChangelistsRequired = true;
			}
		}

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x0000F997 File Offset: 0x0000DB97
		// (set) Token: 0x060006F0 RID: 1776 RVA: 0x0000F99F File Offset: 0x0000DB9F
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x060006F1 RID: 1777 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x0000F9A8 File Offset: 0x0000DBA8
		private void OnBackCommand()
		{
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x060006F3 RID: 1779 RVA: 0x0000F9B6 File Offset: 0x0000DBB6
		// (set) Token: 0x060006F4 RID: 1780 RVA: 0x0000F9BE File Offset: 0x0000DBBE
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x060006F5 RID: 1781 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnNextTransfer()
		{
			return true;
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
		private void OnNextCommand()
		{
			string uriString = (this.migrationDefinition.MigrationType == TransferMethodType.File) ? "FilesBasedTransferProgressPage" : "TransferEverythingPage";
			base.pcmoverEngine.MigrationItemsSelection = this.TransferSelection;
			this.policy.enginePolicy.MigItems.DefaultOption = new MigrationItemsOption?(this.TransferSelection);
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri(uriString, UriKind.Relative));
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x0000FA3C File Offset: 0x0000DC3C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !this.policy.customTransferPagePolicy.IsPageDisplayed)
			{
				this.OnBack.Execute();
				return;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.CustomTransfer);
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_CustomTransferPage);
			string payload = this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName1 : this.migrationDefinition.PCName2;
			this.eventAggregator.GetEvent<Events.OtherPcChanged>().Publish(payload);
			string payload2 = this.migrationDefinition.IsPCName1Old ? this.migrationDefinition.PCName2 : this.migrationDefinition.PCName1;
			this.eventAggregator.GetEvent<Events.ThisPcChanged>().Publish(payload2);
			this.migrationDefinition.BuildChangelistsRequired = true;
			this.IsTransferEverythingEnabled = base.pcmoverEngine.Policy.MigrationItems.Enabled.HasFlag(MigrationItemsEnabled.All);
			this.IsFilesAndSettingsEnabled = base.pcmoverEngine.Policy.MigrationItems.Enabled.HasFlag(MigrationItemsEnabled.FilesAndSettings);
			this.IsFilesOnlyEnabled = base.pcmoverEngine.Policy.MigrationItems.Enabled.HasFlag(MigrationItemsEnabled.FilesOnly);
			this.IsLetMeChooseEnabled = !this.policy.customTransferPagePolicy.IsLetMeChooseDisabled;
			this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(base.pcmoverEngine.Policy.MigrationItems.DefaultOption);
			if (!this.policy.customTransferPagePolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy)
			{
				if (this.policy.customTransferPagePolicy.AutoCustomize)
				{
					this.CustomizeCommand.Execute();
				}
				else
				{
					this.OnNext.Execute();
				}
			}
			base.pcmoverEngine.CatchCommEx(delegate
			{
				if (!this.migrationDefinition.IsResuming)
				{
					base.pcmoverEngine.SetControllerProperty(ControllerProperties.CustomizationScreen, CustomizationScreen.CustomTransfer.ToString());
					return;
				}
				if (this.migrationDefinition.CustomizeScreen == CustomizationScreen.LetMeChoose || this.migrationDefinition.CustomizeScreen == CustomizationScreen.StartTransfer)
				{
					this.CustomizeCommand.Execute();
					return;
				}
				this.migrationDefinition.IsResuming = false;
			}, "OnNavigatedTo");
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0000FC40 File Offset: 0x0000DE40
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.policy.WriteProfile();
		}

		// Token: 0x040001B4 RID: 436
		private readonly IRegionManager regionManager;

		// Token: 0x040001B5 RID: 437
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040001B6 RID: 438
		private NavigationContext navigationContext;

		// Token: 0x040001B7 RID: 439
		private readonly DefaultPolicy policy;

		// Token: 0x040001B8 RID: 440
		private readonly LlTraceSource _ts;

		// Token: 0x040001B9 RID: 441
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040001BA RID: 442
		private MigrationItemsOption _TransferSelection;

		// Token: 0x040001BB RID: 443
		private bool _IsTransferEverythingEnabled;

		// Token: 0x040001BC RID: 444
		private bool _IsFilesAndSettingsEnabled;

		// Token: 0x040001BD RID: 445
		private bool _IsFilesOnlyEnabled;

		// Token: 0x040001BE RID: 446
		private bool _isLetMeChooseEnabled;
	}
}
