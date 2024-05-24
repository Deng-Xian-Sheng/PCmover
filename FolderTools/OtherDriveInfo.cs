using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Laplink.Pcmover.Configurator.FolderTools
{
	// Token: 0x02000007 RID: 7
	public class OtherDriveInfo
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002DA8 File Offset: 0x00000FA8
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00002DB0 File Offset: 0x00000FB0
		public bool HasDriveC { get; private set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002DB9 File Offset: 0x00000FB9
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00002DC1 File Offset: 0x00000FC1
		public bool HasOtherDrives { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002DCA File Offset: 0x00000FCA
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00002DD2 File Offset: 0x00000FD2
		public IReadOnlyList<DriveInfo> OtherDrives { get; private set; }

		// Token: 0x0600003F RID: 63 RVA: 0x00002DDC File Offset: 0x00000FDC
		public OtherDriveInfo()
		{
			IEnumerable<DriveInfo> enumerable = from drive in DriveInfo.GetDrives()
			where drive.DriveType == DriveType.Fixed
			select drive;
			List<DriveInfo> list = new List<DriveInfo>();
			this.OtherDrives = list;
			using (IEnumerator<DriveInfo> enumerator = enumerable.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					DriveInfo driveInfo = enumerator.Current;
					if (driveInfo.Name == "C:\\")
					{
						this.HasDriveC = true;
					}
					else
					{
						this.HasOtherDrives = true;
						list.Add(driveInfo);
					}
				}
			}
		}
	}
}
