using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000079 RID: 121
	public class TaskStats
	{
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000340 RID: 832 RVA: 0x00003FAC File Offset: 0x000021AC
		// (set) Token: 0x06000341 RID: 833 RVA: 0x00003FB4 File Offset: 0x000021B4
		public ContainerStats Disk { get; set; }

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000342 RID: 834 RVA: 0x00003FBD File Offset: 0x000021BD
		// (set) Token: 0x06000343 RID: 835 RVA: 0x00003FC5 File Offset: 0x000021C5
		public IEnumerable<DriveSpaceRequired> DriveSpaceRequired { get; set; }

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000344 RID: 836 RVA: 0x00003FCE File Offset: 0x000021CE
		// (set) Token: 0x06000345 RID: 837 RVA: 0x00003FD6 File Offset: 0x000021D6
		public ContainerStats Registry { get; set; }
	}
}
