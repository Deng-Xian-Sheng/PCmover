using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001C3 RID: 451
	[DataContract]
	public class HeaderEntry : DevToolsDomainEntityBase
	{
		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000D15 RID: 3349 RVA: 0x00012161 File Offset: 0x00010361
		// (set) Token: 0x06000D16 RID: 3350 RVA: 0x00012169 File Offset: 0x00010369
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000D17 RID: 3351 RVA: 0x00012172 File Offset: 0x00010372
		// (set) Token: 0x06000D18 RID: 3352 RVA: 0x0001217A File Offset: 0x0001037A
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
