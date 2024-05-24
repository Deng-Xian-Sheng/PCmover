using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Laplink.Pcmover.Configurator.FolderTools;
using MainUI.Properties;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Reconfigurator.Infrastructure;

namespace MainUI.ViewModels
{
	// Token: 0x02000018 RID: 24
	public class PickUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0000596C File Offset: 0x00003B6C
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00005974 File Offset: 0x00003B74
		public ObservableCollection<DriveDisplay> Drives { get; private set; }

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0000597D File Offset: 0x00003B7D
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00005985 File Offset: 0x00003B85
		public bool ATransferCompleted
		{
			get
			{
				return this._ATransferCompleted;
			}
			set
			{
				this.SetProperty<bool>(ref this._ATransferCompleted, value, "ATransferCompleted");
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x06000122 RID: 290 RVA: 0x0000599A File Offset: 0x00003B9A
		// (set) Token: 0x06000123 RID: 291 RVA: 0x000059A2 File Offset: 0x00003BA2
		public DriveDisplay SelectedFromDrive
		{
			get
			{
				return this._SelectedFromDrive;
			}
			set
			{
				this.SetProperty<DriveDisplay>(ref this._SelectedFromDrive, value, "SelectedFromDrive");
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x06000124 RID: 292 RVA: 0x000059B7 File Offset: 0x00003BB7
		// (set) Token: 0x06000125 RID: 293 RVA: 0x000059BF File Offset: 0x00003BBF
		public DriveDisplay SelectedToDrive
		{
			get
			{
				return this._SelectedToDrive;
			}
			set
			{
				this.SetProperty<DriveDisplay>(ref this._SelectedToDrive, value, "SelectedToDrive");
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x000059D4 File Offset: 0x00003BD4
		public PickUserControlViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ISummary summary)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.summary = summary;
			eventAggregator.GetEvent<Events.ChangedCustomSelection>().Subscribe(new Action<Events.CustomSelection>(this.OnPickCustomCommand));
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnDone = new DelegateCommand(new Action(this.OnDoneCommand), new Func<bool>(this.CanOnDoneCommand));
			this.ATransferCompleted = false;
			IEnumerable<DriveInfo> enumerable = from drive in DriveInfo.GetDrives()
			where drive.DriveType == DriveType.Fixed
			select drive;
			this.Drives = new ObservableCollection<DriveDisplay>();
			int num = 0;
			foreach (DriveInfo driveInfo in enumerable)
			{
				DriveDisplay driveDisplay = new DriveDisplay(driveInfo, Resources.FreeString);
				this.Drives.Add(driveDisplay);
				if (num == 0)
				{
					this.SelectedFromDrive = driveDisplay;
				}
				else if (num == 1)
				{
					this.SelectedToDrive = driveDisplay;
				}
				num++;
			}
			summary.BeforeDrives = this.Drives;
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00005B2C File Offset: 0x00003D2C
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00005B34 File Offset: 0x00003D34
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000129 RID: 297 RVA: 0x00005B3D File Offset: 0x00003D3D
		private bool CanOnNextCommand()
		{
			return this.NextPageFolders || this.NextPagePrograms;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00005B50 File Offset: 0x00003D50
		private void OnNextCommand()
		{
			this.summary.SelectedFromDrive = this.SelectedFromDrive;
			this.summary.SelectedToDrive = this.SelectedToDrive;
			if (this.NextPageFolders)
			{
				this.regionManager.RequestNavigate("MainRegion", new Uri("FoldersUserControl", UriKind.Relative), new NavigationParameters
				{
					{
						"DoPrograms",
						true
					}
				});
				this.NextPageFolders = false;
			}
			else if (this.NextPagePrograms)
			{
				this.regionManager.RequestNavigate("MainRegion", new Uri("ProgramsUserControl", UriKind.Relative));
				this.NextPagePrograms = false;
			}
			this.ATransferCompleted = true;
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00005BF2 File Offset: 0x00003DF2
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00005BFA File Offset: 0x00003DFA
		public DelegateCommand OnDone { get; private set; }

		// Token: 0x0600012D RID: 301 RVA: 0x00005C03 File Offset: 0x00003E03
		private bool CanOnDoneCommand()
		{
			return true;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00005C06 File Offset: 0x00003E06
		private void OnDoneCommand()
		{
			this.summary.SelectedFromDrive = this.SelectedFromDrive;
			this.summary.SelectedToDrive = this.SelectedToDrive;
			this.regionManager.RequestNavigate("MainRegion", new Uri("SummaryUserControl", UriKind.Relative));
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00005C48 File Offset: 0x00003E48
		private void OnPickCustomCommand(Events.CustomSelection selection)
		{
			switch (selection)
			{
			case Events.CustomSelection.Programs:
				this.NextPagePrograms = true;
				break;
			case Events.CustomSelection.Folders:
				this.NextPageFolders = true;
				break;
			case Events.CustomSelection.ProgramsOff:
				this.NextPagePrograms = false;
				break;
			case Events.CustomSelection.FoldersOff:
				this.NextPageFolders = false;
				break;
			}
			this.OnNext.RaiseCanExecuteChanged();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00005C9A File Offset: 0x00003E9A
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00005CA2 File Offset: 0x00003EA2
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x06000132 RID: 306 RVA: 0x00005CAB File Offset: 0x00003EAB
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005CAE File Offset: 0x00003EAE
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate("MainRegion", new Uri("MainUserControl", UriKind.Relative));
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00005CCB File Offset: 0x00003ECB
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00005CCD File Offset: 0x00003ECD
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00005CD0 File Offset: 0x00003ED0
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x04000075 RID: 117
		private readonly IRegionManager regionManager;

		// Token: 0x04000076 RID: 118
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000077 RID: 119
		private readonly ISummary summary;

		// Token: 0x04000079 RID: 121
		private bool NextPagePrograms;

		// Token: 0x0400007A RID: 122
		private bool NextPageFolders;

		// Token: 0x0400007B RID: 123
		private bool _ATransferCompleted;

		// Token: 0x0400007C RID: 124
		private DriveDisplay _SelectedFromDrive;

		// Token: 0x0400007D RID: 125
		private DriveDisplay _SelectedToDrive;
	}
}
