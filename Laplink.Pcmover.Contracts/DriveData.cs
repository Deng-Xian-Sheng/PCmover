using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000037 RID: 55
	public class DriveData
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00002F35 File Offset: 0x00001135
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00002F3D File Offset: 0x0000113D
		public IEnumerable<string> OldDrives { get; set; }

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00002F46 File Offset: 0x00001146
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00002F4E File Offset: 0x0000114E
		public IEnumerable<string> NewDrives { get; set; }

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00002F57 File Offset: 0x00001157
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00002F5F File Offset: 0x0000115F
		public List<DrivePair> Matches { get; set; }
	}
}
