using System;

namespace PCmover.Infrastructure
{
	// Token: 0x02000004 RID: 4
	public class BaseEditionData : IEditionData
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000021C1 File Offset: 0x000003C1
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000021C9 File Offset: 0x000003C9
		public VProFeature VPro { get; protected set; }
	}
}
