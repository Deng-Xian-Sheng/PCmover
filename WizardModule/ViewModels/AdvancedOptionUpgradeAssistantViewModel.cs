using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace WizardModule.ViewModels
{
	// Token: 0x02000072 RID: 114
	public class AdvancedOptionUpgradeAssistantViewModel : BindableBase
	{
		// Token: 0x170003DE RID: 990
		// (get) Token: 0x060005C9 RID: 1481 RVA: 0x0000D512 File Offset: 0x0000B712
		// (set) Token: 0x060005CA RID: 1482 RVA: 0x0000D51A File Offset: 0x0000B71A
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

		// Token: 0x060005CB RID: 1483 RVA: 0x0000D530 File Offset: 0x0000B730
		public AdvancedOptionUpgradeAssistantViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnUpgradeAssistant = new DelegateCommand(new Action(this.OnUpgradeAssistantCommand));
			this.OnUpgradeAssistantInfo = new DelegateCommand(new Action(this.OnUpgradeAssistantInfoCommand));
			eventAggregator.GetEvent<Events.ChangedOptionSelections>().Subscribe(new Action<MigrationTypeOption>(this.OnPickCustomCommand));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x0000D5A2 File Offset: 0x0000B7A2
		private void OnPickCustomCommand(MigrationTypeOption selection)
		{
			if (selection == MigrationTypeOption.WinUpgrade)
			{
				this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
				return;
			}
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x0000D5BF File Offset: 0x0000B7BF
		// (set) Token: 0x060005CE RID: 1486 RVA: 0x0000D5C7 File Offset: 0x0000B7C7
		public DelegateCommand OnUpgradeAssistant { get; private set; }

		// Token: 0x060005CF RID: 1487 RVA: 0x0000D5D0 File Offset: 0x0000B7D0
		private void OnUpgradeAssistantCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.WinUpgrade);
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x060005D0 RID: 1488 RVA: 0x0000D5E3 File Offset: 0x0000B7E3
		// (set) Token: 0x060005D1 RID: 1489 RVA: 0x0000D5EB File Offset: 0x0000B7EB
		public DelegateCommand OnUpgradeAssistantInfo { get; private set; }

		// Token: 0x060005D2 RID: 1490 RVA: 0x0000D5F4 File Offset: 0x0000B7F4
		private void OnUpgradeAssistantInfoCommand()
		{
			AdvancedOptionUpgradeAssistantViewModel.<OnUpgradeAssistantInfoCommand>d__17 <OnUpgradeAssistantInfoCommand>d__;
			<OnUpgradeAssistantInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnUpgradeAssistantInfoCommand>d__.<>4__this = this;
			<OnUpgradeAssistantInfoCommand>d__.<>1__state = -1;
			<OnUpgradeAssistantInfoCommand>d__.<>t__builder.Start<AdvancedOptionUpgradeAssistantViewModel.<OnUpgradeAssistantInfoCommand>d__17>(ref <OnUpgradeAssistantInfoCommand>d__);
		}

		// Token: 0x04000138 RID: 312
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000139 RID: 313
		private readonly IUnityContainer container;

		// Token: 0x0400013A RID: 314
		private string _BoxUri;
	}
}
