using System;
using System.Runtime.CompilerServices;
using Laplink.Tools.Helpers;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using WizardModule.Migration;

namespace WizardModule.ViewModels
{
	// Token: 0x02000079 RID: 121
	public class CopyInstallerPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06000687 RID: 1671 RVA: 0x0000EA5D File Offset: 0x0000CC5D
		private LlTraceSource Ts { get; }

		// Token: 0x06000688 RID: 1672 RVA: 0x0000EA68 File Offset: 0x0000CC68
		public CopyInstallerPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine, IMigrationDefinition migration, IWizardModuleModule wizardModuleModule, DefaultPolicy policy, LlTraceSource ts, NavigationHelper navigationHelper) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.migrationDefinition = migration;
			this.policy = policy;
			this._wizardModuleModule = wizardModuleModule;
			this._navigationHelper = navigationHelper;
			this.Ts = ts;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OpenCopyInstallerPopup = new DelegateCommand(new Action(this.OnOpenCopyInstallerPopup), new Func<bool>(this.CanOnOpenCopyInstallerPopup));
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x0000EB17 File Offset: 0x0000CD17
		// (set) Token: 0x0600068A RID: 1674 RVA: 0x0000EB1F File Offset: 0x0000CD1F
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
				this.OnBack.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x0600068B RID: 1675 RVA: 0x0000EB4A File Offset: 0x0000CD4A
		// (set) Token: 0x0600068C RID: 1676 RVA: 0x0000EB52 File Offset: 0x0000CD52
		public bool IsCopyPopupOpen
		{
			get
			{
				return this._IsCopyPopupOpen;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsCopyPopupOpen, value, "IsCopyPopupOpen");
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0000EB67 File Offset: 0x0000CD67
		// (set) Token: 0x0600068E RID: 1678 RVA: 0x0000EB6F File Offset: 0x0000CD6F
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x0600068F RID: 1679 RVA: 0x0000EB78 File Offset: 0x0000CD78
		private bool CanOnNextCommand()
		{
			return !this.IsBusy;
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0000EB84 File Offset: 0x0000CD84
		private void OnNextCommand()
		{
			CopyInstallerPageViewModel.<OnNextCommand>d__23 <OnNextCommand>d__;
			<OnNextCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnNextCommand>d__.<>4__this = this;
			<OnNextCommand>d__.<>1__state = -1;
			<OnNextCommand>d__.<>t__builder.Start<CopyInstallerPageViewModel.<OnNextCommand>d__23>(ref <OnNextCommand>d__);
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0000EBBB File Offset: 0x0000CDBB
		// (set) Token: 0x06000692 RID: 1682 RVA: 0x0000EBC3 File Offset: 0x0000CDC3
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000693 RID: 1683 RVA: 0x0000EB78 File Offset: 0x0000CD78
		private bool CanOnBackCommand()
		{
			return !this.IsBusy;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0000EBCC File Offset: 0x0000CDCC
		private void OnBackCommand()
		{
			this._navigationHelper.GoBack(null);
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0000EBDA File Offset: 0x0000CDDA
		// (set) Token: 0x06000696 RID: 1686 RVA: 0x0000EBE2 File Offset: 0x0000CDE2
		public DelegateCommand OpenCopyInstallerPopup { get; private set; }

		// Token: 0x06000697 RID: 1687 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnOpenCopyInstallerPopup()
		{
			return true;
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0000EBEC File Offset: 0x0000CDEC
		private void OnOpenCopyInstallerPopup()
		{
			CopyInstallerPageViewModel.<OnOpenCopyInstallerPopup>d__35 <OnOpenCopyInstallerPopup>d__;
			<OnOpenCopyInstallerPopup>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnOpenCopyInstallerPopup>d__.<>4__this = this;
			<OnOpenCopyInstallerPopup>d__.<>1__state = -1;
			<OnOpenCopyInstallerPopup>d__.<>t__builder.Start<CopyInstallerPageViewModel.<OnOpenCopyInstallerPopup>d__35>(ref <OnOpenCopyInstallerPopup>d__);
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0000EC23 File Offset: 0x0000CE23
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.navigationContext = navigationContext;
			this.eventAggregator.GetEvent<Events.UpdateTitle>().Publish(Resources.Title_WelcomePage);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000182 RID: 386
		private readonly IRegionManager regionManager;

		// Token: 0x04000183 RID: 387
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000184 RID: 388
		private readonly DefaultPolicy policy;

		// Token: 0x04000185 RID: 389
		private readonly IWizardModuleModule _wizardModuleModule;

		// Token: 0x04000186 RID: 390
		private NavigationContext navigationContext;

		// Token: 0x04000187 RID: 391
		private readonly NavigationHelper _navigationHelper;

		// Token: 0x04000189 RID: 393
		private bool _IsBusy;

		// Token: 0x0400018A RID: 394
		private bool _IsCopyPopupOpen;
	}
}
