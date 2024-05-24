using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace WizardModule.ViewModels
{
	// Token: 0x02000075 RID: 117
	public class ChooseLetMeChooseViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000636 RID: 1590 RVA: 0x0000E41C File Offset: 0x0000C61C
		public ChooseLetMeChooseViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnLetMeChoose = new DelegateCommand(new Action(this.OnLetMeChooseCommand), new Func<bool>(this.CanOnLetMeChooseCommand));
			this.OnInfo = new DelegateCommand(new Action(this.OnInfoCommand), new Func<bool>(this.CanOnInfoCommand));
			eventAggregator.GetEvent<Events.ChangedCustomSelection>().Subscribe(new Action<MigrationItemsOption>(this.OnPickCustomCommand));
			eventAggregator.GetEvent<Events.ThisPcChanged>().Subscribe(new Action<string>(this.OnThisPcChanged));
			eventAggregator.GetEvent<Events.OtherPcChanged>().Subscribe(new Action<string>(this.OnOtherPcChanged));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0000E4D6 File Offset: 0x0000C6D6
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x0000E4DE File Offset: 0x0000C6DE
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

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06000639 RID: 1593 RVA: 0x0000E4F3 File Offset: 0x0000C6F3
		// (set) Token: 0x0600063A RID: 1594 RVA: 0x0000E4FB File Offset: 0x0000C6FB
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

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x0600063B RID: 1595 RVA: 0x0000E510 File Offset: 0x0000C710
		// (set) Token: 0x0600063C RID: 1596 RVA: 0x0000E518 File Offset: 0x0000C718
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

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x0600063D RID: 1597 RVA: 0x0000E52D File Offset: 0x0000C72D
		// (set) Token: 0x0600063E RID: 1598 RVA: 0x0000E535 File Offset: 0x0000C735
		public DelegateCommand OnLetMeChoose { get; private set; }

		// Token: 0x0600063F RID: 1599 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnLetMeChooseCommand()
		{
			return true;
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0000E53E File Offset: 0x0000C73E
		private void OnLetMeChooseCommand()
		{
			throw new NotImplementedException("OnLetMeChooseCommand");
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x0000E54A File Offset: 0x0000C74A
		// (set) Token: 0x06000642 RID: 1602 RVA: 0x0000E552 File Offset: 0x0000C752
		public DelegateCommand OnInfo { get; private set; }

		// Token: 0x06000643 RID: 1603 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnInfoCommand()
		{
			return true;
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0000E55C File Offset: 0x0000C75C
		private void OnInfoCommand()
		{
			ChooseLetMeChooseViewModel.<OnInfoCommand>d__26 <OnInfoCommand>d__;
			<OnInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnInfoCommand>d__.<>4__this = this;
			<OnInfoCommand>d__.<>1__state = -1;
			<OnInfoCommand>d__.<>t__builder.Start<ChooseLetMeChooseViewModel.<OnInfoCommand>d__26>(ref <OnInfoCommand>d__);
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0000CE65 File Offset: 0x0000B065
		private void OnPickCustomCommand(MigrationItemsOption selection)
		{
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0000E593 File Offset: 0x0000C793
		private void OnOtherPcChanged(string obj)
		{
			this.OtherPC = obj;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0000E59C File Offset: 0x0000C79C
		private void OnThisPcChanged(string obj)
		{
			this.ThisPC = obj;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000169 RID: 361
		private readonly IEventAggregator eventAggregator;

		// Token: 0x0400016A RID: 362
		private readonly IUnityContainer container;

		// Token: 0x0400016B RID: 363
		private string _BoxUri;

		// Token: 0x0400016C RID: 364
		private string _OtherPC;

		// Token: 0x0400016D RID: 365
		private string _ThisPC;
	}
}
