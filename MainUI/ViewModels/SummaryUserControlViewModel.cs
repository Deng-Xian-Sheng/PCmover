using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Laplink.Pcmover.Configurator.FolderTools;
using Laplink.Tools.Helpers;
using Laplink.Tools.Ui.Converters;
using MainUI.Properties;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace MainUI.ViewModels
{
	// Token: 0x0200001B RID: 27
	internal class SummaryUserControlViewModel : BindableBase, INavigationAware
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000170 RID: 368 RVA: 0x0000653B File Offset: 0x0000473B
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00006543 File Offset: 0x00004743
		public ObservableCollection<DriveDisplay> BeforeDrives
		{
			get
			{
				return this._BeforeDrives;
			}
			private set
			{
				this.SetProperty<ObservableCollection<DriveDisplay>>(ref this._BeforeDrives, value, "BeforeDrives");
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000172 RID: 370 RVA: 0x00006558 File Offset: 0x00004758
		// (set) Token: 0x06000173 RID: 371 RVA: 0x00006560 File Offset: 0x00004760
		public ObservableCollection<DriveDisplay> AfterDrives
		{
			get
			{
				return this._AfterDrives;
			}
			private set
			{
				this.SetProperty<ObservableCollection<DriveDisplay>>(ref this._AfterDrives, value, "AfterDrives");
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000174 RID: 372 RVA: 0x00006575 File Offset: 0x00004775
		// (set) Token: 0x06000175 RID: 373 RVA: 0x0000657D File Offset: 0x0000477D
		public ObservableCollection<FolderDisplay> Folders
		{
			get
			{
				return this._Folders;
			}
			private set
			{
				this.SetProperty<ObservableCollection<FolderDisplay>>(ref this._Folders, value, "Folders");
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000176 RID: 374 RVA: 0x00006592 File Offset: 0x00004792
		// (set) Token: 0x06000177 RID: 375 RVA: 0x0000659A File Offset: 0x0000479A
		public string ProgramsText
		{
			get
			{
				return this._ProgramsText;
			}
			set
			{
				this.SetProperty<string>(ref this._ProgramsText, value, "ProgramsText");
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000178 RID: 376 RVA: 0x000065AF File Offset: 0x000047AF
		// (set) Token: 0x06000179 RID: 377 RVA: 0x000065B7 File Offset: 0x000047B7
		public bool IsIntegrated
		{
			get
			{
				return this._IsIntegrated;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsIntegrated, value, "IsIntegrated");
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600017A RID: 378 RVA: 0x000065CC File Offset: 0x000047CC
		// (set) Token: 0x0600017B RID: 379 RVA: 0x000065D4 File Offset: 0x000047D4
		public bool IsRestartEnabled
		{
			get
			{
				return this._IsRestartEnabled;
			}
			set
			{
				this.SetProperty<bool>(ref this._IsRestartEnabled, value, "IsRestartEnabled");
			}
		}

		// Token: 0x0600017C RID: 380 RVA: 0x000065EC File Offset: 0x000047EC
		public SummaryUserControlViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, ISummary summary, LlTraceSource ts)
		{
			this.regionManager = regionManager;
			this.eventAggregator = eventAggregator;
			this.summary = summary;
			this.ts = ts;
			this.OnNext = new DelegateCommand(new Action(this.OnNextCommand), new Func<bool>(this.CanOnNextCommand));
			this.IsIntegrated = false;
			this.IsRestartEnabled = !this.IsIntegrated;
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600017D RID: 381 RVA: 0x00006655 File Offset: 0x00004855
		// (set) Token: 0x0600017E RID: 382 RVA: 0x0000665D File Offset: 0x0000485D
		public DelegateCommand OnNext { get; private set; }

		// Token: 0x0600017F RID: 383 RVA: 0x00006666 File Offset: 0x00004866
		private bool CanOnNextCommand()
		{
			return true;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x00006669 File Offset: 0x00004869
		private void OnNextCommand()
		{
			if (this.IsRestartEnabled)
			{
				Process.Start("shutdown.exe", "-r -t 0");
			}
			Environment.Exit(0);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000668C File Offset: 0x0000488C
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.BeforeDrives = this.summary.BeforeDrives;
			this.Folders = this.summary.Folders;
			this.ProgramsText = this.summary.ProgramsCount.ToString() + " Applications (" + FileSizeConverter.ToString(this.summary.ProgramsSize) + ")";
			long num = this.summary.ProgramsSize;
			foreach (FolderDisplay folderDisplay in this.Folders)
			{
				num += folderDisplay.ShellFolderData.Folder.Size;
			}
			IEnumerable<DriveInfo> enumerable = from drive in DriveInfo.GetDrives()
			where drive.DriveType == DriveType.Fixed
			select drive;
			this.AfterDrives = new ObservableCollection<DriveDisplay>();
			foreach (DriveInfo driveInfo in enumerable)
			{
				DriveDisplay item = new DriveDisplay(driveInfo, Resources.FreeString);
				this.AfterDrives.Add(item);
			}
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000067CC File Offset: 0x000049CC
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000067CF File Offset: 0x000049CF
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
		}

		// Token: 0x0400009D RID: 157
		private readonly IRegionManager regionManager;

		// Token: 0x0400009E RID: 158
		private readonly IEventAggregator eventAggregator;

		// Token: 0x0400009F RID: 159
		private readonly ISummary summary;

		// Token: 0x040000A0 RID: 160
		private readonly LlTraceSource ts;

		// Token: 0x040000A1 RID: 161
		private ObservableCollection<DriveDisplay> _BeforeDrives;

		// Token: 0x040000A2 RID: 162
		private ObservableCollection<DriveDisplay> _AfterDrives;

		// Token: 0x040000A3 RID: 163
		public ObservableCollection<FolderDisplay> _Folders;

		// Token: 0x040000A4 RID: 164
		private string _ProgramsText;

		// Token: 0x040000A5 RID: 165
		private bool _IsIntegrated;

		// Token: 0x040000A6 RID: 166
		private bool _IsRestartEnabled;
	}
}
