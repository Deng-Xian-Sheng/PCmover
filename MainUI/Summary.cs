using System;
using System.Collections.ObjectModel;
using Laplink.Pcmover.Configurator.FolderTools;

namespace MainUI
{
	// Token: 0x02000007 RID: 7
	public class Summary : ISummary
	{
		// Token: 0x0600005F RID: 95 RVA: 0x00002BDF File Offset: 0x00000DDF
		public Summary()
		{
			this.ProgramsSize = 0L;
			this.ProgramsCount = 0L;
			this.Folders = new ObservableCollection<FolderDisplay>();
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002C02 File Offset: 0x00000E02
		// (set) Token: 0x06000061 RID: 97 RVA: 0x00002C0A File Offset: 0x00000E0A
		public long ProgramsSize { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002C13 File Offset: 0x00000E13
		// (set) Token: 0x06000063 RID: 99 RVA: 0x00002C1B File Offset: 0x00000E1B
		public long ProgramsCount { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002C24 File Offset: 0x00000E24
		// (set) Token: 0x06000065 RID: 101 RVA: 0x00002C2C File Offset: 0x00000E2C
		public ObservableCollection<DriveDisplay> BeforeDrives { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00002C35 File Offset: 0x00000E35
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00002C3D File Offset: 0x00000E3D
		public ObservableCollection<FolderDisplay> Folders { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000068 RID: 104 RVA: 0x00002C46 File Offset: 0x00000E46
		// (set) Token: 0x06000069 RID: 105 RVA: 0x00002C4E File Offset: 0x00000E4E
		public DriveDisplay SelectedFromDrive { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00002C57 File Offset: 0x00000E57
		// (set) Token: 0x0600006B RID: 107 RVA: 0x00002C5F File Offset: 0x00000E5F
		public DriveDisplay SelectedToDrive { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600006C RID: 108 RVA: 0x00002C68 File Offset: 0x00000E68
		// (set) Token: 0x0600006D RID: 109 RVA: 0x00002C70 File Offset: 0x00000E70
		public bool Undo { get; set; }
	}
}
