using System;
using System.Runtime.CompilerServices;
using Laplink.Pcmover.Contracts;
using Microsoft.Practices.Unity;
using PcmBrandUI.Properties;
using PCmover.Infrastructure;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace WizardModule.ViewModels
{
	// Token: 0x0200006E RID: 110
	public class AdvancedOptionFileBasedViewModel : BindableBase
	{
		// Token: 0x170003AC RID: 940
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x0000C27B File Offset: 0x0000A47B
		// (set) Token: 0x0600053E RID: 1342 RVA: 0x0000C283 File Offset: 0x0000A483
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

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x0000C298 File Offset: 0x0000A498
		public string AOFB_TransferAll
		{
			get
			{
				return Resources.AOFB_TransferAll;
			}
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
		public AdvancedOptionFileBasedViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnFileBased = new DelegateCommand(new Action(this.OnFileBasedCommand));
			this.OnFileBasedInfo = new DelegateCommand(new Action(this.OnFileBasedInfoCommand));
			eventAggregator.GetEvent<Events.ChangedOptionSelections>().Subscribe(new Action<MigrationTypeOption>(this.OnPickCustomCommand));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0000C312 File Offset: 0x0000A512
		private void OnPickCustomCommand(MigrationTypeOption selection)
		{
			if (selection == MigrationTypeOption.FileBased)
			{
				this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
				return;
			}
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000542 RID: 1346 RVA: 0x0000C32F File Offset: 0x0000A52F
		// (set) Token: 0x06000543 RID: 1347 RVA: 0x0000C337 File Offset: 0x0000A537
		public DelegateCommand OnFileBased { get; private set; }

		// Token: 0x06000544 RID: 1348 RVA: 0x0000C340 File Offset: 0x0000A540
		private void OnFileBasedCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.FileBased);
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x0000C353 File Offset: 0x0000A553
		// (set) Token: 0x06000546 RID: 1350 RVA: 0x0000C35B File Offset: 0x0000A55B
		public DelegateCommand OnFileBasedInfo { get; private set; }

		// Token: 0x06000547 RID: 1351 RVA: 0x0000C364 File Offset: 0x0000A564
		private void OnFileBasedInfoCommand()
		{
			AdvancedOptionFileBasedViewModel.<OnFileBasedInfoCommand>d__19 <OnFileBasedInfoCommand>d__;
			<OnFileBasedInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnFileBasedInfoCommand>d__.<>4__this = this;
			<OnFileBasedInfoCommand>d__.<>1__state = -1;
			<OnFileBasedInfoCommand>d__.<>t__builder.Start<AdvancedOptionFileBasedViewModel.<OnFileBasedInfoCommand>d__19>(ref <OnFileBasedInfoCommand>d__);
		}

		// Token: 0x040000FB RID: 251
		private readonly IEventAggregator eventAggregator;

		// Token: 0x040000FC RID: 252
		private readonly IUnityContainer container;

		// Token: 0x040000FD RID: 253
		private string _BoxUri;
	}
}
