using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Threading;
using Laplink.Pcmover.Configurator.FolderTools;
using MainUI.Properties;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MainUI.ViewModels
{
	// Token: 0x02000019 RID: 25
	public class ProgramsUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00005CD2 File Offset: 0x00003ED2
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00005CDA File Offset: 0x00003EDA
		public ObservableCollection<ProgramFilesFolder> ProgramFilesFolders
		{
			get
			{
				return this._ProgramFilesFolders;
			}
			set
			{
				this.SetProperty<ObservableCollection<ProgramFilesFolder>>(ref this._ProgramFilesFolders, value, "ProgramFilesFolders");
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00005CEF File Offset: 0x00003EEF
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00005CF7 File Offset: 0x00003EF7
		public ProgramFilesFolder SelectedPfFolder
		{
			get
			{
				return this._selectedPfFolder;
			}
			set
			{
				if (this._selectedPfFolder != value)
				{
					this.SetProperty<ProgramFilesFolder>(ref this._selectedPfFolder, value, "SelectedPfFolder");
				}
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00005D15 File Offset: 0x00003F15
		// (set) Token: 0x0600013C RID: 316 RVA: 0x00005D1D File Offset: 0x00003F1D
		public bool TransferComplete
		{
			get
			{
				return this._TransferComplete;
			}
			set
			{
				this.SetProperty<bool>(ref this._TransferComplete, value, "TransferComplete");
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600013D RID: 317 RVA: 0x00005D32 File Offset: 0x00003F32
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00005D3A File Offset: 0x00003F3A
		public ObservableCollection<DriveDisplay> Drives { get; private set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600013F RID: 319 RVA: 0x00005D43 File Offset: 0x00003F43
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00005D4B File Offset: 0x00003F4B
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

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00005D60 File Offset: 0x00003F60
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00005D68 File Offset: 0x00003F68
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

		// Token: 0x06000143 RID: 323 RVA: 0x00005D80 File Offset: 0x00003F80
		public ProgramsUserControlViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ISummary summary)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.summary = summary;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.OnBack = new DelegateCommand(new Action(this.OnBackCommand), new Func<bool>(this.CanOnBackCommand));
			this.OnTransfer = new DelegateCommand(new Action(this.OnTransferCommand), new Func<bool>(this.CanOnTransferCommand));
			this.SelectAll = new DelegateCommand(new Action(this.DoSelectAllCommand), new Func<bool>(this.CanDoSelectAllCommand));
			this.TransferComplete = false;
			this.InitProgramFiles();
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
			this.tempTimer.Tick += this.TempTimer_Tick;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x00005F00 File Offset: 0x00004100
		private void TempTimer_Tick(object sender, EventArgs e)
		{
			bool flag = false;
			foreach (ProgramFilesFolder programFilesFolder in this.ProgramFilesFolders)
			{
				if (programFilesFolder.IsBusy)
				{
					flag = true;
					programFilesFolder.IsBusy = false;
					programFilesFolder.IsDone = true;
					break;
				}
			}
			if (!flag)
			{
				this.TransferComplete = true;
				this.OnNext.RaiseCanExecuteChanged();
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000145 RID: 325 RVA: 0x00005F78 File Offset: 0x00004178
		// (set) Token: 0x06000146 RID: 326 RVA: 0x00005F80 File Offset: 0x00004180
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x06000147 RID: 327 RVA: 0x00005F89 File Offset: 0x00004189
		private bool CanOnNextCommand()
		{
			return this.TransferComplete;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x00005F91 File Offset: 0x00004191
		private void OnNextCommand()
		{
			this.regionManager.RequestNavigate("MainRegion", new Uri("SummaryUserControl", UriKind.Relative));
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000149 RID: 329 RVA: 0x00005FAE File Offset: 0x000041AE
		// (set) Token: 0x0600014A RID: 330 RVA: 0x00005FB6 File Offset: 0x000041B6
		public DelegateCommand OnBack { get; private set; }

		// Token: 0x0600014B RID: 331 RVA: 0x00005FBF File Offset: 0x000041BF
		private bool CanOnBackCommand()
		{
			return true;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00005FC2 File Offset: 0x000041C2
		private void OnBackCommand()
		{
			this.regionManager.RequestNavigate("MainRegion", new Uri("PickUserControl", UriKind.Relative));
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600014D RID: 333 RVA: 0x00005FDF File Offset: 0x000041DF
		// (set) Token: 0x0600014E RID: 334 RVA: 0x00005FE7 File Offset: 0x000041E7
		public DelegateCommand OnTransfer { get; private set; }

		// Token: 0x0600014F RID: 335 RVA: 0x00005FF0 File Offset: 0x000041F0
		private bool CanOnTransferCommand()
		{
			return !this.TransferComplete;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x00005FFC File Offset: 0x000041FC
		private void OnTransferCommand()
		{
			foreach (ProgramFilesFolder programFilesFolder in this.ProgramFilesFolders)
			{
				if (programFilesFolder.Selected)
				{
					programFilesFolder.IsBusy = true;
					if (programFilesFolder.Folder32 != null)
					{
						this.summary.ProgramsSize += programFilesFolder.Folder32.Size;
					}
					else
					{
						this.summary.ProgramsSize += programFilesFolder.Folder64.Size;
					}
					ISummary summary = this.summary;
					long programsCount = summary.ProgramsCount;
					summary.ProgramsCount = programsCount + 1L;
				}
			}
			this.tempTimer.Interval = TimeSpan.FromSeconds(1.0);
			this.tempTimer.Start();
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000151 RID: 337 RVA: 0x000060D0 File Offset: 0x000042D0
		// (set) Token: 0x06000152 RID: 338 RVA: 0x000060D8 File Offset: 0x000042D8
		public DelegateCommand SelectAll { get; private set; }

		// Token: 0x06000153 RID: 339 RVA: 0x000060E1 File Offset: 0x000042E1
		private bool CanDoSelectAllCommand()
		{
			return true;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000060E4 File Offset: 0x000042E4
		private void DoSelectAllCommand()
		{
			this.allSelected = !this.allSelected;
			foreach (ProgramFilesFolder programFilesFolder in this.ProgramFilesFolders)
			{
				programFilesFolder.Selected = this.allSelected;
			}
			this.OnTransfer.RaiseCanExecuteChanged();
		}

		// Token: 0x06000155 RID: 341 RVA: 0x00006150 File Offset: 0x00004350
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000156 RID: 342 RVA: 0x00006152 File Offset: 0x00004352
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00006155 File Offset: 0x00004355
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00006158 File Offset: 0x00004358
		private void InitProgramFiles()
		{
			this.TransferComplete = false;
			bool? is64Bit;
			if (Environment.Is64BitOperatingSystem)
			{
				this._pf32 = Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%");
				this._pf64 = Environment.ExpandEnvironmentVariables("%ProgramW6432%");
				is64Bit = new bool?(false);
			}
			else
			{
				this._pf32 = Environment.ExpandEnvironmentVariables("%ProgramFiles%");
				is64Bit = null;
			}
			List<ProgramFilesFolder> list = new List<ProgramFilesFolder>();
			DirectoryInfo[] directories = new DirectoryInfo(this._pf32).GetDirectories();
			for (int i = 0; i < directories.Length; i++)
			{
				list.Add(new ProgramFilesFolder(directories[i], is64Bit)
				{
					IsBusy = false
				});
			}
			if (Environment.Is64BitOperatingSystem)
			{
				is64Bit = new bool?(true);
				directories = new DirectoryInfo(this._pf64).GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					DirectoryInfo subDir = directories[i];
					ProgramFilesFolder programFilesFolder = list.FirstOrDefault((ProgramFilesFolder f) => string.Compare(f.Name, subDir.Name, true) == 0);
					if (programFilesFolder == null)
					{
						list.Add(new ProgramFilesFolder(subDir, is64Bit));
					}
					else
					{
						programFilesFolder.AddFolder(subDir);
					}
				}
			}
			this.ProgramFilesFolders = new ObservableCollection<ProgramFilesFolder>(from f in list
			orderby f.Name
			select f);
		}

		// Token: 0x04000081 RID: 129
		private readonly IRegionManager regionManager;

		// Token: 0x04000082 RID: 130
		private readonly IEventAggregator eventAggregator;

		// Token: 0x04000083 RID: 131
		private readonly ISummary summary;

		// Token: 0x04000084 RID: 132
		private string _pf32;

		// Token: 0x04000085 RID: 133
		private string _pf64;

		// Token: 0x04000086 RID: 134
		private bool allSelected;

		// Token: 0x04000087 RID: 135
		private readonly DispatcherTimer tempTimer = new DispatcherTimer();

		// Token: 0x04000088 RID: 136
		private ObservableCollection<ProgramFilesFolder> _ProgramFilesFolders;

		// Token: 0x04000089 RID: 137
		private ProgramFilesFolder _selectedPfFolder;

		// Token: 0x0400008A RID: 138
		private bool _TransferComplete;

		// Token: 0x0400008C RID: 140
		private DriveDisplay _SelectedFromDrive;

		// Token: 0x0400008D RID: 141
		private DriveDisplay _SelectedToDrive;
	}
}
