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
	// Token: 0x02000076 RID: 118
	public class ChooseTransferEverythingViewModel : BindableBase, INavigationAware
	{
		// Token: 0x0600064B RID: 1611 RVA: 0x0000E5A8 File Offset: 0x0000C7A8
		public ChooseTransferEverythingViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnTransferEverything = new DelegateCommand(new Action(this.OnTransferEverythingCommand), new Func<bool>(this.CanOnTransferEverythingCommand));
			this.OnInfo = new DelegateCommand(new Action(this.OnInfoCommand), new Func<bool>(this.CanOnInfoCommand));
			eventAggregator.GetEvent<Events.ChangedCustomSelection>().Subscribe(new Action<MigrationItemsOption>(this.OnPickCustomCommand));
			eventAggregator.GetEvent<Events.ThisPcChanged>().Subscribe(new Action<string>(this.OnThisPcChanged));
			eventAggregator.GetEvent<Events.OtherPcChanged>().Subscribe(new Action<string>(this.OnOtherPcChanged));
			this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x0000E662 File Offset: 0x0000C862
		// (set) Token: 0x0600064D RID: 1613 RVA: 0x0000E66A File Offset: 0x0000C86A
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

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x0000E67F File Offset: 0x0000C87F
		// (set) Token: 0x0600064F RID: 1615 RVA: 0x0000E687 File Offset: 0x0000C887
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

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06000650 RID: 1616 RVA: 0x0000E69C File Offset: 0x0000C89C
		// (set) Token: 0x06000651 RID: 1617 RVA: 0x0000E6A4 File Offset: 0x0000C8A4
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

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x0000E6BC File Offset: 0x0000C8BC
		public int HighlightBorderThickness
		{
			get
			{
				int result;
				try
				{
					result = (int)Convert.ToInt16(Resources.CTE_HighlightBorderThickness);
				}
				catch
				{
					result = 4;
				}
				return result;
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x0000E6EC File Offset: 0x0000C8EC
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x0000E6F4 File Offset: 0x0000C8F4
		public DelegateCommand OnTransferEverything { get; private set; }

		// Token: 0x06000655 RID: 1621 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnTransferEverythingCommand()
		{
			return true;
		}

		// Token: 0x06000656 RID: 1622 RVA: 0x0000E6FD File Offset: 0x0000C8FD
		private void OnTransferEverythingCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(MigrationItemsOption.All);
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000657 RID: 1623 RVA: 0x0000E710 File Offset: 0x0000C910
		// (set) Token: 0x06000658 RID: 1624 RVA: 0x0000E718 File Offset: 0x0000C918
		public DelegateCommand OnInfo { get; private set; }

		// Token: 0x06000659 RID: 1625 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnInfoCommand()
		{
			return true;
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0000E724 File Offset: 0x0000C924
		private void OnInfoCommand()
		{
			ChooseTransferEverythingViewModel.<OnInfoCommand>d__28 <OnInfoCommand>d__;
			<OnInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnInfoCommand>d__.<>4__this = this;
			<OnInfoCommand>d__.<>1__state = -1;
			<OnInfoCommand>d__.<>t__builder.Start<ChooseTransferEverythingViewModel.<OnInfoCommand>d__28>(ref <OnInfoCommand>d__);
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0000E75B File Offset: 0x0000C95B
		private void OnPickCustomCommand(MigrationItemsOption selection)
		{
			if (selection == MigrationItemsOption.All)
			{
				this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
				return;
			}
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0000E777 File Offset: 0x0000C977
		private void OnOtherPcChanged(string obj)
		{
			this.OtherPC = obj;
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0000E780 File Offset: 0x0000C980
		private void OnThisPcChanged(string obj)
		{
			this.ThisPC = obj;
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000170 RID: 368
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000171 RID: 369
		private readonly IUnityContainer container;

		// Token: 0x04000172 RID: 370
		private string _BoxUri;

		// Token: 0x04000173 RID: 371
		private string _OtherPC;

		// Token: 0x04000174 RID: 372
		private string _ThisPC;
	}
}
