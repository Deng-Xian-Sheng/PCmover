using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Laplink.Pcmover.ClientEngine;
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
	// Token: 0x02000094 RID: 148
	public class SelfTransferPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000C3E RID: 3134 RVA: 0x000201A8 File Offset: 0x0001E3A8
		public SelfTransferPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardModuleModule = wizardModuleModule;
			this._navigationHelper = navigationHelper;
			this._IsBusy = true;
			this._DisplayButtons = true;
			this.OnCustomTransfer = new DelegateCommand(new Action(this.OnCustomTransferCommand), new Func<bool>(this.CanOnCustomTransferCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x06000C3F RID: 3135 RVA: 0x0002025D File Offset: 0x0001E45D
		// (set) Token: 0x06000C40 RID: 3136 RVA: 0x00020265 File Offset: 0x0001E465
		public bool IsBusy
		{
			get
			{
				return this._IsBusy;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsBusy, value, "IsBusy");
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x06000C41 RID: 3137 RVA: 0x00020285 File Offset: 0x0001E485
		// (set) Token: 0x06000C42 RID: 3138 RVA: 0x0002028D File Offset: 0x0001E48D
		public bool DisplayButtons
		{
			get
			{
				return this._DisplayButtons;
			}
			set
			{
				this.SetProperty<bool>(ref this._DisplayButtons, value, "DisplayButtons");
			}
		}

		// Token: 0x170005CE RID: 1486
		// (get) Token: 0x06000C43 RID: 3139 RVA: 0x000202A2 File Offset: 0x0001E4A2
		// (set) Token: 0x06000C44 RID: 3140 RVA: 0x000202AA File Offset: 0x0001E4AA
		public string ScanCompleteMessage
		{
			get
			{
				return this._ScanCompleteMessage;
			}
			set
			{
				this.SetProperty<string>(ref this._ScanCompleteMessage, value, "ScanCompleteMessage");
			}
		}

		// Token: 0x170005CF RID: 1487
		// (get) Token: 0x06000C45 RID: 3141 RVA: 0x000202BF File Offset: 0x0001E4BF
		// (set) Token: 0x06000C46 RID: 3142 RVA: 0x000202C7 File Offset: 0x0001E4C7
		public DelegateCommand OnCustomTransfer { get; private set; }

		// Token: 0x06000C47 RID: 3143 RVA: 0x000202D0 File Offset: 0x0001E4D0
		private bool CanOnCustomTransferCommand()
		{
			if (this.IsBusy)
			{
				return false;
			}
			UserMappings users = base.pcmoverEngine.Users;
			if (users == null)
			{
				return false;
			}
			IEnumerable<UserMapping> mappings = users.Mappings;
			int? num;
			if (mappings == null)
			{
				num = null;
			}
			else
			{
				IEnumerable<UserMapping> enumerable = from x in mappings
				where x.Old != null
				select x;
				num = ((enumerable != null) ? new int?(enumerable.Count<UserMapping>()) : null);
			}
			int? num2 = num;
			int num3 = 1;
			return num2.GetValueOrDefault() > num3 & num2 != null;
		}

		// Token: 0x06000C48 RID: 3144 RVA: 0x0002035E File Offset: 0x0001E55E
		private void OnCustomTransferCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("CustomTransferPage", UriKind.Relative));
		}

		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x06000C49 RID: 3145 RVA: 0x0002037B File Offset: 0x0001E57B
		// (set) Token: 0x06000C4A RID: 3146 RVA: 0x00020383 File Offset: 0x0001E583
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000C4B RID: 3147 RVA: 0x0002038C File Offset: 0x0001E58C
		private bool CanOnBackCommand()
		{
			return !this._backSelected;
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x00020398 File Offset: 0x0001E598
		private void OnBackCommand()
		{
			SelfTransferPageViewModel.<OnBackCommand>d__32 <OnBackCommand>d__;
			<OnBackCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnBackCommand>d__.<>4__this = this;
			<OnBackCommand>d__.<>1__state = -1;
			<OnBackCommand>d__.<>t__builder.Start<SelfTransferPageViewModel.<OnBackCommand>d__32>(ref <OnBackCommand>d__);
		}

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x06000C4D RID: 3149 RVA: 0x000203CF File Offset: 0x0001E5CF
		// (set) Token: 0x06000C4E RID: 3150 RVA: 0x000203D7 File Offset: 0x0001E5D7
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000C4F RID: 3151 RVA: 0x000203E0 File Offset: 0x0001E5E0
		private bool CanOnNextCommand()
		{
			if (this.IsBusy)
			{
				return false;
			}
			UserMappings users = base.pcmoverEngine.Users;
			if (users == null)
			{
				return false;
			}
			IEnumerable<UserMapping> mappings = users.Mappings;
			int? num;
			if (mappings == null)
			{
				num = null;
			}
			else
			{
				IEnumerable<UserMapping> enumerable = from x in mappings
				where x.Old != null
				select x;
				num = ((enumerable != null) ? new int?(enumerable.Count<UserMapping>()) : null);
			}
			int? num2 = num;
			int num3 = 1;
			return num2.GetValueOrDefault() > num3 & num2 != null;
		}

		// Token: 0x06000C50 RID: 3152 RVA: 0x0002046E File Offset: 0x0001E66E
		private void OnNextCommand()
		{
			this.migrationDefinition.BuildChangelistsRequired = true;
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LetMeChoosePage", UriKind.Relative));
		}

		// Token: 0x06000C51 RID: 3153 RVA: 0x00020498 File Offset: 0x0001E698
		private void FillTaskCompleted(FillTaskData obj)
		{
			base.pcmoverEngine.Ts.TraceInformation(string.Format("FillTaskCompleted fired ({0})", obj.Result));
			this._fillTaskResult = obj.Result;
			if (obj.Result == FillTaskResult.DomainsDoNotMatch)
			{
				WPFMessageBox.ShowDialogAsync(this.container, this.eventAggregator, string.Format(WizardModule.Properties.Resources.ERROR_DomainsDoNotMatch, this.policy.SupportEmail), WizardModule.Properties.Resources.ERROR, PopupEvents.MBType.MB_OK, MessageBoxImage.None, MessageBoxResult.None).ConfigureAwait(false);
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, this._wizardModuleModule.WelcomeUri);
			}
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x00020530 File Offset: 0x0001E730
		private void OnReadSnapshot()
		{
			if (this._fillTaskResult != FillTaskResult.Success)
			{
				return;
			}
			base.pcmoverEngine.RetrieveUsers();
			UserMappings users = base.pcmoverEngine.Users;
			bool flag;
			if (users == null)
			{
				flag = false;
			}
			else
			{
				IEnumerable<UserMapping> mappings = users.Mappings;
				int? num;
				if (mappings == null)
				{
					num = null;
				}
				else
				{
					IEnumerable<UserMapping> enumerable = from x in mappings
					where x.Old != null
					select x;
					num = ((enumerable != null) ? new int?(enumerable.Count<UserMapping>()) : null);
				}
				int? num2 = num;
				int num3 = 1;
				flag = (num2.GetValueOrDefault() > num3 & num2 != null);
			}
			if (flag)
			{
				this.ScanCompleteMessage = WizardModule.Properties.Resources.STP_ScanComplete;
			}
			else
			{
				this.ScanCompleteMessage = WizardModule.Properties.Resources.STP_ScanCompleteError;
			}
			this.IsBusy = false;
			this.OnCustomTransfer.RaiseCanExecuteChanged();
			this.OnNext.RaiseCanExecuteChanged();
			if (this.migrationDefinition.IsResuming)
			{
				this.Resume();
				return;
			}
			if (this.CanOnNextCommand())
			{
				this.OnNext.Execute();
			}
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x00020628 File Offset: 0x0001E828
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.eventAggregator.GetEvent<EngineEvents.CreateFillTaskEvent>().Unsubscribe(new Action<FillTaskData>(this.FillTaskCompleted));
			this.eventAggregator.GetEvent<EngineEvents.ReadyForCustomizationEvent>().Unsubscribe(new Action(this.OnReadSnapshot));
			this.policy.WriteProfile();
		}

		// Token: 0x06000C55 RID: 3157 RVA: 0x00020678 File Offset: 0x0001E878
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (this._navigationHelper.IsNavigatingBack && !this.policy.profileMigratorPagePolicy.IsPageDisplayed && this.CanOnBackCommand())
			{
				this.OnBack.Execute();
				return;
			}
			this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.SelfTransfer);
			this.migrationDefinition.IsSelfTransfer = true;
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.CloseConfirmationRequiredChanged>().Publish(true);
			this.eventAggregator.GetEvent<EngineEvents.CreateFillTaskEvent>().Subscribe(new Action<FillTaskData>(this.FillTaskCompleted), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<EngineEvents.ReadyForCustomizationEvent>().Subscribe(new Action(this.OnReadSnapshot), ThreadOption.UIThread);
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(WizardModule.Properties.Resources.STP_Title);
			base.pcmoverEngine.CatchCommEx(delegate
			{
				base.pcmoverEngine.Ts.TraceInformation("SelfTransferPageViewModel.OnActivityInfo: Set ThisMachineIsOld = false");
				base.pcmoverEngine.ThisMachineIsOld = false;
				this._backSelected = false;
				this.OnBack.RaiseCanExecuteChanged();
				if (PcmBrandUI.Properties.Resources.Edition == "ProfileMigrator")
				{
					this.DisplayButtons = false;
				}
				base.pcmoverEngine.AddSelf();
				this.IsBusy = true;
			}, "OnNavigatedTo");
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x0002075C File Offset: 0x0001E95C
		private void Resume()
		{
			switch (this.migrationDefinition.ServiceData.Step)
			{
			case PcmoverTransferState.TransferStep.Customizing:
			case PcmoverTransferState.TransferStep.Transferring:
			case PcmoverTransferState.TransferStep.Done:
				base.pcmoverEngine.CatchCommEx(delegate
				{
					CustomizationScreen customizeScreen;
					Enum.TryParse<CustomizationScreen>(base.pcmoverEngine.GetControllerProperty(ControllerProperties.CustomizationScreen), out customizeScreen);
					this.migrationDefinition.CustomizeScreen = customizeScreen;
				}, "Resume");
				this.OnNext.Execute();
				return;
			case PcmoverTransferState.TransferStep.Downloading:
				this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("DownloadManagerPage", UriKind.Relative));
				return;
			default:
				return;
			}
		}

		// Token: 0x040003EA RID: 1002
		private readonly IRegionManager regionManager;

		// Token: 0x040003EB RID: 1003
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x040003EC RID: 1004
		private NavigationContext navigationContext;

		// Token: 0x040003ED RID: 1005
		private readonly DefaultPolicy policy;

		// Token: 0x040003EE RID: 1006
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x040003EF RID: 1007
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x040003F0 RID: 1008
		private bool _backSelected;

		// Token: 0x040003F1 RID: 1009
		private FillTaskResult _fillTaskResult;

		// Token: 0x040003F2 RID: 1010
		private bool _IsBusy;

		// Token: 0x040003F3 RID: 1011
		private bool _DisplayButtons;

		// Token: 0x040003F4 RID: 1012
		private string _ScanCompleteMessage;
	}
}
