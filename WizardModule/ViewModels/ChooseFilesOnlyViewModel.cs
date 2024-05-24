using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using WizardModule.Migration;

namespace WizardModule.ViewModels
{
	// Token: 0x02000074 RID: 116
	public class ChooseFilesOnlyViewModel : BindableBase, INavigationAware
	{
		// Token: 0x06000621 RID: 1569 RVA: 0x0000E264 File Offset: 0x0000C464
		public ChooseFilesOnlyViewModel(IUnityContainer container, IEventAggregator eventAggregator, IMigrationDefinition migration)
		{
			this.eventAggregator = eventAggregator;
			this.migrationDefinition = migration;
			this.container = container;
			this.OnTransferOnly = new DelegateCommand(new Action(this.OnTransferOnlyCommand), new Func<bool>(this.CanOnTransferOnlyCommand));
			this.OnInfo = new DelegateCommand(new Action(this.OnInfoCommand), new Func<bool>(this.CanOnInfoCommand));
			eventAggregator.GetEvent<Events.ChangedCustomSelection>().Subscribe(new Action<MigrationItemsOption>(this.OnPickCustomCommand));
			eventAggregator.GetEvent<Events.ThisPcChanged>().Subscribe(new Action<string>(this.OnThisPcChanged));
			eventAggregator.GetEvent<Events.OtherPcChanged>().Subscribe(new Action<string>(this.OnOtherPcChanged));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06000622 RID: 1570 RVA: 0x0000E325 File Offset: 0x0000C525
		// (set) Token: 0x06000623 RID: 1571 RVA: 0x0000E32D File Offset: 0x0000C52D
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

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06000624 RID: 1572 RVA: 0x0000E342 File Offset: 0x0000C542
		// (set) Token: 0x06000625 RID: 1573 RVA: 0x0000E34A File Offset: 0x0000C54A
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

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06000626 RID: 1574 RVA: 0x0000E35F File Offset: 0x0000C55F
		// (set) Token: 0x06000627 RID: 1575 RVA: 0x0000E367 File Offset: 0x0000C567
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

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x0000E37C File Offset: 0x0000C57C
		// (set) Token: 0x06000629 RID: 1577 RVA: 0x0000E384 File Offset: 0x0000C584
		public DelegateCommand OnTransferOnly { get; private set; }

		// Token: 0x0600062A RID: 1578 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnTransferOnlyCommand()
		{
			return true;
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0000E38D File Offset: 0x0000C58D
		private void OnTransferOnlyCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(MigrationItemsOption.FilesOnly);
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x0600062C RID: 1580 RVA: 0x0000E3A0 File Offset: 0x0000C5A0
		// (set) Token: 0x0600062D RID: 1581 RVA: 0x0000E3A8 File Offset: 0x0000C5A8
		public DelegateCommand OnInfo { get; private set; }

		// Token: 0x0600062E RID: 1582 RVA: 0x0000CE62 File Offset: 0x0000B062
		private bool CanOnInfoCommand()
		{
			return true;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0000E3B4 File Offset: 0x0000C5B4
		private void OnInfoCommand()
		{
			ChooseFilesOnlyViewModel.<OnInfoCommand>d__27 <OnInfoCommand>d__;
			<OnInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnInfoCommand>d__.<>4__this = this;
			<OnInfoCommand>d__.<>1__state = -1;
			<OnInfoCommand>d__.<>t__builder.Start<ChooseFilesOnlyViewModel.<OnInfoCommand>d__27>(ref <OnInfoCommand>d__);
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0000E3EB File Offset: 0x0000C5EB
		private void OnPickCustomCommand(MigrationItemsOption selection)
		{
			if (selection == MigrationItemsOption.FilesOnly)
			{
				this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
				return;
			}
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0000E408 File Offset: 0x0000C608
		private void OnOtherPcChanged(string obj)
		{
			this.OtherPC = obj;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0000E411 File Offset: 0x0000C611
		private void OnThisPcChanged(string obj)
		{
			this.ThisPC = obj;
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0000CE62 File Offset: 0x0000B062
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0000CE65 File Offset: 0x0000B065
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000161 RID: 353
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000162 RID: 354
		private readonly IMigrationDefinition migrationDefinition;

		// Token: 0x04000163 RID: 355
		private readonly IUnityContainer container;

		// Token: 0x04000164 RID: 356
		private string _BoxUri;

		// Token: 0x04000165 RID: 357
		private string _OtherPC;

		// Token: 0x04000166 RID: 358
		private string _ThisPC;
	}
}
