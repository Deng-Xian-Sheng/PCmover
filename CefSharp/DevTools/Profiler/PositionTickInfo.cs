using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000157 RID: 343
	[DataContract]
	public class PositionTickInfo : DevToolsDomainEntityBase
	{
		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000A08 RID: 2568 RVA: 0x0000F497 File Offset: 0x0000D697
		// (set) Token: 0x06000A09 RID: 2569 RVA: 0x0000F49F File Offset: 0x0000D69F
		[DataMember(Name = "line", IsRequired = true)]
		public int Line { get; set; }

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x06000A0A RID: 2570 RVA: 0x0000F4A8 File Offset: 0x0000D6A8
		// (set) Token: 0x06000A0B RID: 2571 RVA: 0x0000F4B0 File Offset: 0x0000D6B0
		[DataMember(Name = "ticks", IsRequired = true)]
		public int Ticks { get; set; }
	}
}
