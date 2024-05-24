using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200014E RID: 334
	[DataContract]
	public class GetHeapUsageResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x0000E82D File Offset: 0x0000CA2D
		// (set) Token: 0x060009A2 RID: 2466 RVA: 0x0000E835 File Offset: 0x0000CA35
		[DataMember]
		internal double usedSize { get; set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x0000E83E File Offset: 0x0000CA3E
		public double UsedSize
		{
			get
			{
				return this.usedSize;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060009A4 RID: 2468 RVA: 0x0000E846 File Offset: 0x0000CA46
		// (set) Token: 0x060009A5 RID: 2469 RVA: 0x0000E84E File Offset: 0x0000CA4E
		[DataMember]
		internal double totalSize { get; set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x0000E857 File Offset: 0x0000CA57
		public double TotalSize
		{
			get
			{
				return this.totalSize;
			}
		}
	}
}
