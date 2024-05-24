using System;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Reconfigurator.Infrastructure;

namespace MainUI.ViewModels
{
	// Token: 0x02000017 RID: 23
	public class PickProgramsUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00005884 File Offset: 0x00003A84
		// (set) Token: 0x06000115 RID: 277 RVA: 0x0000588C File Offset: 0x00003A8C
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

		// Token: 0x06000116 RID: 278 RVA: 0x000058A4 File Offset: 0x00003AA4
		public PickProgramsUserControlViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.OnPickPrograms = new DelegateCommand(new Action(this.OnPickProgramsCommand), new Func<bool>(this.CanOnPickProgramsCommand));
			this.BoxUri = "/MainUI;component/Assets/BoxLarge.png";
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000117 RID: 279 RVA: 0x000058F3 File Offset: 0x00003AF3
		// (set) Token: 0x06000118 RID: 280 RVA: 0x000058FB File Offset: 0x00003AFB
		public DelegateCommand OnPickPrograms { get; private set; }

		// Token: 0x06000119 RID: 281 RVA: 0x00005904 File Offset: 0x00003B04
		private bool CanOnPickProgramsCommand()
		{
			return true;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00005908 File Offset: 0x00003B08
		private void OnPickProgramsCommand()
		{
			this.isSelected = !this.isSelected;
			if (this.isSelected)
			{
				this.BoxUri = "/MainUI;component/Assets/OKBoxLarge.png";
				this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(Events.CustomSelection.Programs);
				return;
			}
			this.BoxUri = "/MainUI;component/Assets/BoxLarge.png";
			this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(Events.CustomSelection.ProgramsOff);
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00005965 File Offset: 0x00003B65
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00005967 File Offset: 0x00003B67
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0000596A File Offset: 0x00003B6A
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000070 RID: 112
		private readonly IRegionManager regionManager;

		// Token: 0x04000071 RID: 113
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000072 RID: 114
		private bool isSelected;

		// Token: 0x04000073 RID: 115
		private string _BoxUri;
	}
}
