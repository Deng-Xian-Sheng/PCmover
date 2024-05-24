using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace WizardModule.ViewModels
{
	// Token: 0x02000077 RID: 119
	public class ChooseTransferOnlyViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000661 RID: 1633 RVA: 0x0000E78C File Offset: 0x0000C98C
		public ChooseTransferOnlyViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnTransferOnly = new DelegateCommand(new Action(this.OnTransferOnlyCommand), new Func<bool>(this.CanOnTransferOnlyCommand));
			this.OnInfo = new DelegateCommand(new Action(this.OnInfoCommand), new Func<bool>(this.CanOnInfoCommand));
			eventAggregator.GetEvent<Events.ChangedCustomSelection>().Subscribe(new Action<MigrationItemsOption>(this.OnPickCustomCommand));
			eventAggregator.GetEvent<Events.ThisPcChanged>().Subscribe(new Action<string>(this.OnThisPcChanged));
			eventAggregator.GetEvent<Events.OtherPcChanged>().Subscribe(new Action<string>(this.OnOtherPcChanged));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000662 RID: 1634 RVA: 0x0000E846 File Offset: 0x0000CA46
		// (set) Token: 0x06000663 RID: 1635 RVA: 0x0000E84E File Offset: 0x0000CA4E
		public string BoxUri
		{
			get
			{
				return this._BoxUri;
			}
			set
			{
				this.SetProperty<string>(ref this._BoxUri, value, "BoxUri");
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000664 RID: 1636 RVA: 0x0000E863 File Offset: 0x0000CA63
		// (set) Token: 0x06000665 RID: 1637 RVA: 0x0000E86B File Offset: 0x0000CA6B
		public string OtherPC
		{
			get
			{
				return this._OtherPC;
			}
			private set
			{
				this.SetProperty<string>(ref this._OtherPC, value, "OtherPC");
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000666 RID: 1638 RVA: 0x0000E880 File Offset: 0x0000CA80
		// (set) Token: 0x06000667 RID: 1639 RVA: 0x0000E888 File Offset: 0x0000CA88
		public string ThisPC
		{
			get
			{
				return this._ThisPC;
			}
			private set
			{
				this.SetProperty<string>(ref this._ThisPC, value, "ThisPC");
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000668 RID: 1640 RVA: 0x0000E89D File Offset: 0x0000CA9D
		public string CTO_Title
		{
			get
			{
				return Resources.CTO_Title;
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x0000E8A4 File Offset: 0x0000CAA4
		public string CTO_Desc
		{
			get
			{
				return Resources.CTO_Desc;
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x0000E8AB File Offset: 0x0000CAAB
		// (set) Token: 0x0600066B RID: 1643 RVA: 0x0000E8B3 File Offset: 0x0000CAB3
		public DelegateCommand OnTransferOnly { get; private set; }

		// Token: 0x0600066C RID: 1644 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnTransferOnlyCommand()
		{
			return true;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0000E8BC File Offset: 0x0000CABC
		private void OnTransferOnlyCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(MigrationItemsOption.FilesAndSettings);
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x0600066E RID: 1646 RVA: 0x0000E8CF File Offset: 0x0000CACF
		// (set) Token: 0x0600066F RID: 1647 RVA: 0x0000E8D7 File Offset: 0x0000CAD7
		public DelegateCommand OnInfo { get; private set; }

		// Token: 0x06000670 RID: 1648 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnInfoCommand()
		{
			return true;
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0000E8E0 File Offset: 0x0000CAE0
		private void OnInfoCommand()
		{
			ChooseTransferOnlyViewModel.<OnInfoCommand>d__30 <OnInfoCommand>d__;
			<OnInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnInfoCommand>d__.<>4__this = this;
			<OnInfoCommand>d__.<>1__state = -1;
			<OnInfoCommand>d__.<>t__builder.Start<ChooseTransferOnlyViewModel.<OnInfoCommand>d__30>(ref <OnInfoCommand>d__);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0000E917 File Offset: 0x0000CB17
		private void OnPickCustomCommand(MigrationItemsOption selection)
		{
			if (selection == MigrationItemsOption.FilesAndSettings)
			{
				this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
				return;
			}
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0000E934 File Offset: 0x0000CB34
		private void OnOtherPcChanged(string obj)
		{
			this.OtherPC = obj;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0000E93D File Offset: 0x0000CB3D
		private void OnThisPcChanged(string obj)
		{
			this.ThisPC = obj;
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000177 RID: 375
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000178 RID: 376
		private readonly IUnityContainer container;

		// Token: 0x04000179 RID: 377
		private string _BoxUri;

		// Token: 0x0400017A RID: 378
		private string _OtherPC;

		// Token: 0x0400017B RID: 379
		private string _ThisPC;
	}
}
