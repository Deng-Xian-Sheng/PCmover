using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.ClientEngine;
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
	// Token: 0x0200008B RID: 139
	public class LetMeChoosePageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000A59 RID: 2649 RVA: 0x00019548 File Offset: 0x00017748
		public LetMeChoosePageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._navigationHelper = navigationHelper;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextTransfer));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnCustomizePPM = new DelegateCommand(new Action(this.OnCustomizePPMCommand), new Func<bool>(this.CanOnCustomizePPMTransfer));
			this.OnCompactSaveUserMapping = new DelegateCommand(new Action(this.OnCompactSaveUserMappingCommand), new Func<bool>(this.CanOnCompactSaveUserMappingCommand));
			this.OnCompactCancelUserMapping = new DelegateCommand(new Action(this.OnCompactCancelUserMappingCommand), new Func<bool>(this.CanOnCompactCancelUserMappingCommand));
			eventAggregator.GetEvent<Events.InSectionPage>().Subscribe(new Action<bool>(this.OnInSection));
			this.ButtonString = WizardModule.Properties.Resources.NEXT;
			this._wizardParameters = container.Resolve(Array.Empty<ResolverOverride>());
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06000A5A RID: 2650 RVA: 0x00019661 File Offset: 0x00017861
		// (set) Token: 0x06000A5B RID: 2651 RVA: 0x00019669 File Offset: 0x00017869
		public string ButtonString
		{
			get
			{
				return this._ButtonString;
			}
			private set
			{
				this.SetProperty<string>(ref this._ButtonString, value, "ButtonString");
			}
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x0001967E File Offset: 0x0001787E
		// (set) Token: 0x06000A5D RID: 2653 RVA: 0x00019686 File Offset: 0x00017886
		public bool IsBackButtonVisible
		{
			get
			{
				return this._IsBackButtonVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsBackButtonVisible, value, "IsBackButtonVisible");
			}
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06000A5E RID: 2654 RVA: 0x0001969B File Offset: 0x0001789B
		// (set) Token: 0x06000A5F RID: 2655 RVA: 0x000196A3 File Offset: 0x000178A3
		public bool IsCustomizeVisible
		{
			get
			{
				return this._IsCustomizeVisible;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsCustomizeVisible, value, "IsCustomizeVisible");
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06000A60 RID: 2656 RVA: 0x000196B8 File Offset: 0x000178B8
		// (set) Token: 0x06000A61 RID: 2657 RVA: 0x000196C0 File Offset: 0x000178C0
		public bool IsCompactEditUserMapping
		{
			get
			{
				return this._IsCompactEditUserMapping;
			}
			private set
			{
				this.SetProperty<bool>(ref this._IsCompactEditUserMapping, value, "IsCompactEditUserMapping");
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06000A62 RID: 2658 RVA: 0x000196D5 File Offset: 0x000178D5
		// (set) Token: 0x06000A63 RID: 2659 RVA: 0x000196DD File Offset: 0x000178DD
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000A64 RID: 2660 RVA: 0x000196E8 File Offset: 0x000178E8
		private bool CanOnBackCommand()
		{
			if (!this.migrationDefinition.IsSelfTransfer)
			{
				return true;
			}
			IEnumerable<UserMapping> mappings = null;
			if (!base.pcmoverEngine.CatchCommEx(delegate
			{
				UserMappings users = this.pcmoverEngine.Users;
				mappings = ((users != null) ? users.Mappings : null);
			}, "CanOnBackCommand"))
			{
				return false;
			}
			IEnumerable<UserMapping> mappings2 = mappings;
			bool result;
			if (mappings2 == null)
			{
				result = false;
			}
			else
			{
				result = ((from x in mappings2
				where x.New != null
				select x).Count<UserMapping>() > 0);
			}
			return result;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00019778 File Offset: 0x00017978
		private void OnBackCommand()
		{
			LetMeChoosePageViewModel.<OnBackCommand>d__31 <OnBackCommand>d__;
			<OnBackCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnBackCommand>d__.<>4__this = this;
			<OnBackCommand>d__.<>1__state = -1;
			<OnBackCommand>d__.<>t__builder.Start<LetMeChoosePageViewModel.<OnBackCommand>d__31>(ref <OnBackCommand>d__);
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06000A66 RID: 2662 RVA: 0x000197AF File Offset: 0x000179AF
		// (set) Token: 0x06000A67 RID: 2663 RVA: 0x000197B7 File Offset: 0x000179B7
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000A68 RID: 2664 RVA: 0x000197C0 File Offset: 0x000179C0
		private bool CanOnNextTransfer()
		{
			return this.CanOnBackCommand();
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x000197C8 File Offset: 0x000179C8
		private void OnNextCommand()
		{
			LetMeChoosePageViewModel.<OnNextCommand>d__37 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<LetMeChoosePageViewModel.<OnNextCommand>d__37>(ref <OnNextCommand>d__);
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06000A6A RID: 2666 RVA: 0x000197FF File Offset: 0x000179FF
		// (set) Token: 0x06000A6B RID: 2667 RVA: 0x00019807 File Offset: 0x00017A07
		public DelegateCommand OnCustomizePPM { get; private set; }

		// Token: 0x06000A6C RID: 2668 RVA: 0x000197C0 File Offset: 0x000179C0
		private bool CanOnCustomizePPMTransfer()
		{
			return this.CanOnBackCommand();
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x00019810 File Offset: 0x00017A10
		private void OnCustomizePPMCommand()
		{
			if (!this.migrationDefinition.IsResuming)
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.SetControllerProperty(ControllerProperties.CustomizationScreen, CustomizationScreen.PPMCustomize.ToString());
				}, "OnCustomizePPMCommand");
			}
			this._PPMCustomizationMode = true;
			this.IsCustomizeVisible = false;
			NavigationParameters navigationParameters = new NavigationParameters();
			navigationParameters.Add("PPMCustomizationMode", true);
			this.regionManager.RequestNavigate(RegionNames.RegionDetailButtons, new Uri("DetailButtonList", UriKind.Relative), navigationParameters);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_LetMeChoosePage);
			this.selectedIndex = 0;
			this.policy.detailButtonListPolicy.DblSelectedButton = DefaultPolicy.SelectedButtonEnum.None;
			this.policy.WriteProfile();
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06000A6E RID: 2670 RVA: 0x000198C0 File Offset: 0x00017AC0
		// (set) Token: 0x06000A6F RID: 2671 RVA: 0x000198C8 File Offset: 0x00017AC8
		public DelegateCommand OnCompactSaveUserMapping { get; set; }

		// Token: 0x06000A70 RID: 2672 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCompactSaveUserMappingCommand()
		{
			return true;
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x000198D1 File Offset: 0x00017AD1
		private void OnCompactSaveUserMappingCommand()
		{
			this.IsCompactEditUserMapping = false;
			this.eventAggregator.GetEvent<Events.CompactUserMappingComplete>().Publish(true);
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06000A72 RID: 2674 RVA: 0x000198EB File Offset: 0x00017AEB
		// (set) Token: 0x06000A73 RID: 2675 RVA: 0x000198F3 File Offset: 0x00017AF3
		public DelegateCommand OnCompactCancelUserMapping { get; set; }

		// Token: 0x06000A74 RID: 2676 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnCompactCancelUserMappingCommand()
		{
			return true;
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x000198FC File Offset: 0x00017AFC
		private void OnCompactCancelUserMappingCommand()
		{
			this.IsCompactEditUserMapping = false;
			this.eventAggregator.GetEvent<Events.CompactUserMappingComplete>().Publish(false);
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x00019918 File Offset: 0x00017B18
		private void OnInSection(bool inSection)
		{
			if (inSection)
			{
				if (this.migrationDefinition.IsSelfTransfer && !this._PPMCustomizationMode)
				{
					this.IsCustomizeVisible = true;
				}
				else
				{
					this.ButtonString = WizardModule.Properties.Resources.DONE;
					this.IsCustomizeVisible = false;
				}
				this.IsBackButtonVisible = false;
				return;
			}
			this.ButtonString = ((this.migrationDefinition.IsSelfTransfer && !this._PPMCustomizationMode) ? WizardModule.Properties.Resources.TEP_Transfer : WizardModule.Properties.Resources.NEXT);
			this.IsBackButtonVisible = true;
			this.IsCustomizeVisible = false;
			this.policy.detailButtonListPolicy.DblSelectedButton = DefaultPolicy.SelectedButtonEnum.None;
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x000199A6 File Offset: 0x00017BA6
		private void OnSettingChanged()
		{
			this.OnBack.RaiseCanExecuteChanged();
			this.OnNext.RaiseCanExecuteChanged();
			this.OnCustomizePPM.RaiseCanExecuteChanged();
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x000199CC File Offset: 0x00017BCC
		private void OnSelectionChanged(NavigationParameters parameters)
		{
			if (parameters["AutoNext"] != null)
			{
				this.OnNextCommand();
				return;
			}
			this.selectedIndex = (int)parameters["Index"];
			this.regionManager.RequestNavigate(RegionNames.RegionDetailButtons, new Uri((string)parameters["Region"], UriKind.Relative), parameters);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish((string)parameters["Title"]);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x00019A4C File Offset: 0x00017C4C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !this.policy.detailButtonListPolicy.IsPageDisplayed && this.CanOnBackCommand())
			{
				this.OnBack.Execute();
				return;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.LetMeChoose);
			this.navigationContext = navigationContext;
			if (this._wizardParameters.CompactUI)
			{
				this.eventAggregator.GetEvent<Events.CompactUserSelected>().Subscribe(new Action(this.OnCompactUserSelected), ThreadOption.UIThread);
			}
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.Title_LetMeChoosePage);
			this.subscriptionToken = this.eventAggregator.GetEvent<SelectionChanged>().Subscribe(new Action<NavigationParameters>(this.OnSelectionChanged), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<Events.CustomizationSettingChanged>().Subscribe(new Action(this.OnSettingChanged), ThreadOption.UIThread);
			this.selectedIndex = 0;
			this.migrationDefinition.IsUserMappingSaved = true;
			this.migrationDefinition.IsRedirectionSaved = true;
			this.OnInSection(false);
			this.migrationDefinition.BuildChangelistsRequired = true;
			this.IsCustomizeVisible = (this.migrationDefinition.IsSelfTransfer && !this._PPMCustomizationMode);
			this.regionManager.RequestNavigate(RegionNames.RegionDetailButtons, new Uri("DetailButtonList", UriKind.Relative));
			this.IsBackButtonVisible = (PcmBrandUI.Properties.Resources.Edition != "ProfileMigrator");
			this.ButtonString = ((this.migrationDefinition.IsSelfTransfer && !this._PPMCustomizationMode) ? WizardModule.Properties.Resources.TEP_Transfer : WizardModule.Properties.Resources.NEXT);
			if ((!this.policy.detailButtonListPolicy.IsPageDisplayed || this._navigationHelper.IsPlayingBackRecordedPolicy) && !this.migrationDefinition.IsSelfTransfer)
			{
				this.OnNextCommand();
			}
			if (this.migrationDefinition.IsResuming)
			{
				if (this.migrationDefinition.CustomizeScreen == CustomizationScreen.StartTransfer)
				{
					if (this.migrationDefinition.IsSelfTransfer && this.migrationDefinition.ServiceData.Step != PcmoverTransferState.TransferStep.Customizing)
					{
						this.OnNext.Execute();
						return;
					}
				}
				else
				{
					if (this.migrationDefinition.CustomizeScreen == CustomizationScreen.PPMCustomize)
					{
						this.OnCustomizePPM.Execute();
						this.OnInSection(false);
						return;
					}
					if (!this.migrationDefinition.IsSelfTransfer)
					{
						this.migrationDefinition.IsResuming = false;
						return;
					}
				}
			}
			else
			{
				base.pcmoverEngine.CatchCommEx(delegate
				{
					base.pcmoverEngine.SetControllerProperty(ControllerProperties.CustomizationScreen, CustomizationScreen.LetMeChoose.ToString());
				}, "OnNavigatedTo");
			}
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x00019C9F File Offset: 0x00017E9F
		private void OnCompactUserSelected()
		{
			this.IsCompactEditUserMapping = true;
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x00019CA8 File Offset: 0x00017EA8
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<SelectionChanged>().Unsubscribe(this.subscriptionToken);
			this.eventAggregator.GetEvent<Events.CustomizationSettingChanged>().Unsubscribe(new Action(this.OnSettingChanged));
			this.eventAggregator.GetEvent<Events.CompactUserSelected>().Unsubscribe(new Action(this.OnCompactUserSelected));
			this.policy.WriteProfile();
		}

		// Token: 0x04000322 RID: 802
		private readonly IRegionManager regionManager;

		// Token: 0x04000323 RID: 803
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000324 RID: 804
		private NavigationContext navigationContext;

		// Token: 0x04000325 RID: 805
		private readonly DefaultPolicy policy;

		// Token: 0x04000326 RID: 806
		private readonly IWizardParameters _wizardParameters;

		// Token: 0x04000327 RID: 807
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000328 RID: 808
		private SubscriptionToken subscriptionToken;

		// Token: 0x04000329 RID: 809
		private int selectedIndex;

		// Token: 0x0400032A RID: 810
		private bool _PPMCustomizationMode;

		// Token: 0x0400032B RID: 811
		private string _ButtonString;

		// Token: 0x0400032C RID: 812
		private bool _IsBackButtonVisible;

		// Token: 0x0400032D RID: 813
		private bool _IsCustomizeVisible;

		// Token: 0x0400032E RID: 814
		private bool _IsCompactEditUserMapping;
	}
}
