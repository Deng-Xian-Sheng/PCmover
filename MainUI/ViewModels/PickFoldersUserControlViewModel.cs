using System;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Reconfigurator.Infrastructure;

namespace MainUI.ViewModels
{
	// Token: 0x02000016 RID: 22
	public class PickFoldersUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600010A RID: 266 RVA: 0x0000579F File Offset: 0x0000399F
		// (set) Token: 0x0600010B RID: 267 RVA: 0x000057A7 File Offset: 0x000039A7
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

		// Token: 0x0600010C RID: 268 RVA: 0x000057BC File Offset: 0x000039BC
		public PickFoldersUserControlViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.OnPickFolders = new DelegateCommand(new Action(this.OnPickFoldersCommand), new Func<bool>(this.CanOnPickFoldersCommand));
			this.BoxUri = "/MainUI;component/Assets/BoxLarge.png";
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x0600010D RID: 269 RVA: 0x0000580B File Offset: 0x00003A0B
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00005813 File Offset: 0x00003A13
		public DelegateCommand OnPickFolders { get; private set; }

		// Token: 0x0600010F RID: 271 RVA: 0x0000581C File Offset: 0x00003A1C
		private bool CanOnPickFoldersCommand()
		{
			return true;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x00005820 File Offset: 0x00003A20
		private void OnPickFoldersCommand()
		{
			this.isSelected = !this.isSelected;
			if (this.isSelected)
			{
				this.BoxUri = "/MainUI;component/Assets/OKBoxLarge.png";
				this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(Events.CustomSelection.Folders);
				return;
			}
			this.BoxUri = "/MainUI;component/Assets/BoxLarge.png";
			this.eventAggregator.GetEvent<Events.ChangedCustomSelection>().Publish(Events.CustomSelection.FoldersOff);
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000587D File Offset: 0x00003A7D
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000587F File Offset: 0x00003A7F
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x00005882 File Offset: 0x00003A82
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x0400006B RID: 107
		private readonly IRegionManager regionManager;

		// Token: 0x0400006C RID: 108
		private readonly IEventAggregator eventAggregator;

		// Token: 0x0400006D RID: 109
		private bool isSelected;

		// Token: 0x0400006E RID: 110
		private string _BoxUri;
	}
}
