using System;
using System.Windows;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;

namespace WizardModule.ViewModels
{
	// Token: 0x02000078 RID: 120
	public class ConnectionHelpPageViewModel : BindablePcmoverEngineBase, INavigationAware
	{
		// Token: 0x06000678 RID: 1656 RVA: 0x0000E948 File Offset: 0x0000CB48
		public ConnectionHelpPageViewModel(IUnityContainer container, IRegionManager regionManager, IEventAggregator eventAggregator, IPCmoverEngine pcmoverEngine) : base(container, eventAggregator, pcmoverEngine)
		{
			this.regionManager = regionManager;
			this.OnTryAgain = new DelegateCommand(new Action(this.OnTryAgainCommand), new Func<bool>(this.CanOnTryAgainCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0000E9AC File Offset: 0x0000CBAC
		// (set) Token: 0x0600067A RID: 1658 RVA: 0x0000E9B4 File Offset: 0x0000CBB4
		public string NetworkName
		{
			get
			{
				return this._NetworkName;
			}
			private set
			{
				this.SetProperty<string>(ref this._NetworkName, value, "NetworkName");
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x0000E9C9 File Offset: 0x0000CBC9
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x0000E9D1 File Offset: 0x0000CBD1
		public DelegateCommand OnTryAgain { get; private set; }

		// Token: 0x0600067D RID: 1661 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnTryAgainCommand()
		{
			return true;
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0000E9DA File Offset: 0x0000CBDA
		private void OnTryAgainCommand()
		{
			MessageBox.Show("Not implemented");
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x0600067F RID: 1663 RVA: 0x0000E9E7 File Offset: 0x0000CBE7
		// (set) Token: 0x06000680 RID: 1664 RVA: 0x0000E9EF File Offset: 0x0000CBEF
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000681 RID: 1665 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0000E9F8 File Offset: 0x0000CBF8
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate(RegionNames.WizardRegion, new Uri("LicensePage", UriKind.Relative));
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0000EA15 File Offset: 0x0000CC15
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			base.pcmoverEngine.CatchCommEx(delegate
			{
				this.NetworkName = base.pcmoverEngine.TargetMachine.NetName;
				this.eventAggregator.GetEvent<Events.SetQuickstepPage>().Publish(QuickstepPage.ConnectionHelp);
			}, "OnNavigatedTo");
		}

		// Token: 0x0400017E RID: 382
		private readonly IRegionManager regionManager;

		// Token: 0x0400017F RID: 383
		private string _NetworkName;
	}
}
