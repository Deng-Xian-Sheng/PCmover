using System;
using System.Collections.ObjectModel;
using Laplink.Pcmover.Configurator.FolderTools;

namespace MainUI
{
	// Token: 0x02000003 RID: 3
	public interface ISummary
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600001E RID: 30
		// (set) Token: 0x0600001F RID: 31
		long ProgramsSize { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000020 RID: 32
		// (set) Token: 0x06000021 RID: 33
		long ProgramsCount { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000022 RID: 34
		// (set) Token: 0x06000023 RID: 35
		ObservableCollection<DriveDisplay> BeforeDrives { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000024 RID: 36
		// (set) Token: 0x06000025 RID: 37
		ObservableCollection<FolderDisplay> Folders { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000026 RID: 38
		// (set) Token: 0x06000027 RID: 39
		DriveDisplay SelectedFromDrive { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000028 RID: 40
		// (set) Token: 0x06000029 RID: 41
		DriveDisplay SelectedToDrive { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002A RID: 42
		// (set) Token: 0x0600002B RID: 43
		bool Undo { get; set; }
	}
}
