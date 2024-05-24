using System;
using System.IO;
using Laplink.Tools.Ui.Converters;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000002 RID: 2
	public class DriveDisplay
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public string FormattedDriveName { get; private set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00000261
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00000269
		public long Percentage { get; private set; }

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00000272
		// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000027A
		public string FormattedDriveSpace { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00000283
		public string DriveName
		{
			get
			{
				DriveInfo driveInfo = this.driveInfo;
				if (driveInfo == null)
				{
					return null;
				}
				return driveInfo.Name;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002096 File Offset: 0x00000296
		public string Root
		{
			get
			{
				DriveInfo driveInfo = this.driveInfo;
				if (driveInfo == null)
				{
					return null;
				}
				return driveInfo.RootDirectory.Name;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000020AE File Offset: 0x000002AE
		public long GetFreeSpace
		{
			get
			{
				if (this.driveInfo != null)
				{
					return this.driveInfo.AvailableFreeSpace;
				}
				return 0L;
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020C6 File Offset: 0x000002C6
		private void SetFormattedDriveSpace(long free, long max, string formatString)
		{
			this.FormattedDriveSpace = string.Format(formatString, FileSizeConverter.ToString(free), FileSizeConverter.ToString(max));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000020E0 File Offset: 0x000002E0
		public DriveDisplay(DriveInfo driveInfo, string formatString)
		{
			this.driveInfo = driveInfo;
			this.formatString = formatString;
			this.FormattedDriveName = "(" + driveInfo.Name + ") " + driveInfo.VolumeLabel;
			this.Percentage = 100L - driveInfo.AvailableFreeSpace * 100L / driveInfo.TotalSize;
			this.SetFormattedDriveSpace(driveInfo.AvailableFreeSpace, driveInfo.TotalSize, formatString);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002150 File Offset: 0x00000350
		public void AddFree(long bytes)
		{
			this.Percentage = 100L - (this.driveInfo.AvailableFreeSpace + bytes) * 100L / this.driveInfo.TotalSize;
			this.SetFormattedDriveSpace(this.driveInfo.AvailableFreeSpace + bytes, this.driveInfo.TotalSize, this.formatString);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000021A8 File Offset: 0x000003A8
		public void SubFree(long bytes)
		{
			this.Percentage = 100L - (this.driveInfo.AvailableFreeSpace - bytes) * 100L / this.driveInfo.TotalSize;
			this.SetFormattedDriveSpace(this.driveInfo.AvailableFreeSpace - bytes, this.driveInfo.TotalSize, this.formatString);
		}

		// Token: 0x04000001 RID: 1
		private readonly DriveInfo driveInfo;

		// Token: 0x04000002 RID: 2
		private readonly string formatString;
	}
}
