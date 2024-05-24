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
	// Token: 0x0200006F RID: 111
	internal class AdvancedOptionProfileViewModel : BindableBase
	{
		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000548 RID: 1352 RVA: 0x0000C39B File Offset: 0x0000A59B
		// (set) Token: 0x06000549 RID: 1353 RVA: 0x0000C3A3 File Offset: 0x0000A5A3
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

		// Token: 0x0600054A RID: 1354 RVA: 0x0000C3B8 File Offset: 0x0000A5B8
		public AdvancedOptionProfileViewModel(IUnityContainer container, IEventAggregator eventAggregator)
		{
			this.eventAggregator = eventAggregator;
			this.container = container;
			this.OnProfile = new DelegateCommand(new Action(this.OnProfileCommand));
			this.OnProfileInfo = new DelegateCommand(new Action(this.OnProfileInfoCommand));
			eventAggregator.GetEvent<Events.ChangedOptionSelections>().Subscribe(new Action<MigrationTypeOption>(this.OnPickCustomCommand));
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0000C42A File Offset: 0x0000A62A
		private void OnPickCustomCommand(MigrationTypeOption selection)
		{
			if (selection == MigrationTypeOption.Profile)
			{
				this.BoxUri = "/WizardModule;component/Assets/OKBoxLarge.png";
				return;
			}
			this.BoxUri = "/WizardModule;component/Assets/BoxLarge.png";
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x0000C447 File Offset: 0x0000A647
		// (set) Token: 0x0600054D RID: 1357 RVA: 0x0000C44F File Offset: 0x0000A64F
		public DelegateCommand OnProfile { get; private set; }

		// Token: 0x0600054E RID: 1358 RVA: 0x0000C458 File Offset: 0x0000A658
		private void OnProfileCommand()
		{
			this.eventAggregator.GetEvent<Events.ChangedOptionSelections>().Publish(MigrationTypeOption.Profile);
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0000C46B File Offset: 0x0000A66B
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0000C473 File Offset: 0x0000A673
		public DelegateCommand OnProfileInfo { get; private set; }

		// Token: 0x06000551 RID: 1361 RVA: 0x0000C47C File Offset: 0x0000A67C
		private void OnProfileInfoCommand()
		{
			AdvancedOptionProfileViewModel.<OnProfileInfoCommand>d__17 <OnProfileInfoCommand>d__;
			<OnProfileInfoCommand>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<OnProfileInfoCommand>d__.<>4__this = this;
			<OnProfileInfoCommand>d__.<>1__state = -1;
			<OnProfileInfoCommand>d__.<>t__builder.Start<AdvancedOptionProfileViewModel.<OnProfileInfoCommand>d__17>(ref <OnProfileInfoCommand>d__);
		}

		// Token: 0x04000100 RID: 256
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000101 RID: 257
		private readonly IUnityContainer container;

		// Token: 0x04000102 RID: 258
		private string _BoxUri;
	}
}
