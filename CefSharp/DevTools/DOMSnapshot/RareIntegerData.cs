using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000371 RID: 881
	[DataContract]
	public class RareIntegerData : DevToolsDomainEntityBase
	{
		// Token: 0x17000919 RID: 2329
		// (get) Token: 0x06001993 RID: 6547 RVA: 0x0001E2FF File Offset: 0x0001C4FF
		// (set) Token: 0x06001994 RID: 6548 RVA: 0x0001E307 File Offset: 0x0001C507
		[DataMember(Name = "index", IsRequired = true)]
		public int[] Index { get; set; }

		// Token: 0x1700091A RID: 2330
		// (get) Token: 0x06001995 RID: 6549 RVA: 0x0001E310 File Offset: 0x0001C510
		// (set) Token: 0x06001996 RID: 6550 RVA: 0x0001E318 File Offset: 0x0001C518
		[DataMember(Name = "value", IsRequired = true)]
		public int[] Value { get; set; }
	}
}
