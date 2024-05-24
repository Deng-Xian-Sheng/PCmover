using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using WizardModule.Properties;

namespace WizardModule.ViewModels
{
	// Token: 0x02000071 RID: 113
	public class AdvancedOptionTransferViewModel : BindableBase
	{
		// Token: 0x060005BE RID: 1470 RVA: 0x0000D3F8 File Offset: 0x0000B5F8
		public AdvancedOptionTransferViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnSelected = new DelegateCommand(new Action(this.OnSelectedCommand));
			this.OnInfo = new DelegateCommand(new Action(this.OnInfoCommand));
			eventAggregator.GetEvent<Events.ChangedOptionSelections>().Subscribe(new Action<MigrationTypeOption>(this.OnPickCustomCommand));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x060005BF RID: 1471 RVA: 0x0000D46A File Offset: 0x0000B66A
		// (set) Token: 0x060005C0 RID: 1472 RVA: 0x0000D472 File Offset: 0x0000B672
		public string BoxUri
		{
			get
			{
				return this._BoxUri;
			}
			private set
			{
				this.SetProperty<string>(ref this._BoxUri, value, "BoxUri");
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x060005C1 RID: 1473 RVA: 0x0000D487 File Offset: 0x0000B687
		public string Description
		{
			get
			{
				return Resources.AOT_Description;
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x060005C2 RID: 1474 RVA: 0x0000D48E File Offset: 0x0000B68E
		// (set) Token: 0x060005C3 RID: 1475 RVA: 0x0000D496 File Offset: 0x0000B696
		public DelegateCommand OnSelected { get; private set; }

		// Token: 0x060005C4 RID: 1476 RVA: 0x0000D49F File Offset: 0x0000B69F
		private void OnSelectedCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.Migration);
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x060005C5 RID: 1477 RVA: 0x0000D4B2 File Offset: 0x0000B6B2
		// (set) Token: 0x060005C6 RID: 1478 RVA: 0x0000D4BA File Offset: 0x0000B6BA
		public DelegateCommand OnInfo { get; private set; }

		// Token: 0x060005C7 RID: 1479 RVA: 0x0000D4C4 File Offset: 0x0000B6C4
		private void OnInfoCommand()
		{
			AdvancedOptionTransferViewModel.<OnInfoCommand>d__18 <OnInfoCommand>d__;
			<OnInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnInfoCommand>d__.<>4__this = this;
			<OnInfoCommand>d__.<>1__state = -1;
			<OnInfoCommand>d__.<>t__builder.Start<AdvancedOptionTransferViewModel.<OnInfoCommand>d__18>(ref <OnInfoCommand>d__);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x0000D4FB File Offset: 0x0000B6FB
		private void OnPickCustomCommand(MigrationTypeOption selection)
		{
			this.BoxUri = ((selection == MigrationTypeOption.Migration) ? "/WizardModule;component/Assets/OKBoxLarge.png" : "/WizardModule;component/Assets/BoxLarge.png");
		}

		// Token: 0x04000133 RID: 307
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000134 RID: 308
		private readonly IUnityContainer container;

		// Token: 0x04000135 RID: 309
		private string _BoxUri;
	}
}
