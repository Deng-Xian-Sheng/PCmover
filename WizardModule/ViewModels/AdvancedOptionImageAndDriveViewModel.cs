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
	// Token: 0x0200006D RID: 109
	public class AdvancedOptionImageAndDriveViewModel : BindableBase
	{
		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0000C161 File Offset: 0x0000A361
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x0000C169 File Offset: 0x0000A369
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

		// Token: 0x06000535 RID: 1333 RVA: 0x0000C180 File Offset: 0x0000A380
		public AdvancedOptionImageAndDriveViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnImageAndDrive = new DelegateCommand(new Action(this.OnImageAndDriveCommand));
			this.OnImageAndDriveInfo = new DelegateCommand(new Action(this.OnImageAndDriveInfoCommand));
			eventAggregator.GetEvent<Events.ChangedOptionSelections>().Subscribe(new Action<MigrationTypeOption>(this.OnPickCustomCommand));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0000C1F2 File Offset: 0x0000A3F2
		private void OnPickCustomCommand(MigrationTypeOption selection)
		{
			if (selection == MigrationTypeOption.Image)
			{
				this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
				return;
			}
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x0000C20F File Offset: 0x0000A40F
		// (set) Token: 0x06000538 RID: 1336 RVA: 0x0000C217 File Offset: 0x0000A417
		public DelegateCommand OnImageAndDrive { get; private set; }

		// Token: 0x06000539 RID: 1337 RVA: 0x0000C220 File Offset: 0x0000A420
		private void OnImageAndDriveCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.Image);
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000C233 File Offset: 0x0000A433
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x0000C23B File Offset: 0x0000A43B
		public DelegateCommand OnImageAndDriveInfo { get; private set; }

		// Token: 0x0600053C RID: 1340 RVA: 0x0000C244 File Offset: 0x0000A444
		private void OnImageAndDriveInfoCommand()
		{
			AdvancedOptionImageAndDriveViewModel.<OnImageAndDriveInfoCommand>d__17 <OnImageAndDriveInfoCommand>d__;
			<OnImageAndDriveInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnImageAndDriveInfoCommand>d__.<>4__this = this;
			<OnImageAndDriveInfoCommand>d__.<>1__state = -1;
			<OnImageAndDriveInfoCommand>d__.<>t__builder.Start<AdvancedOptionImageAndDriveViewModel.<OnImageAndDriveInfoCommand>d__17>(ref <OnImageAndDriveInfoCommand>d__);
		}

		// Token: 0x040000F6 RID: 246
		private readonly IEventAggregator eventAggregator;

		// Token: 0x040000F7 RID: 247
		private readonly IUnityContainer container;

		// Token: 0x040000F8 RID: 248
		private string _BoxUri;
	}
}
