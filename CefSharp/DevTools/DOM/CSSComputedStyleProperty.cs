using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000386 RID: 902
	[DataContract]
	public class CSSComputedStyleProperty : DevToolsDomainEntityBase
	{
		// Token: 0x1700098E RID: 2446
		// (get) Token: 0x06001A97 RID: 6807 RVA: 0x0001EF0B File Offset: 0x0001D10B
		// (set) Token: 0x06001A98 RID: 6808 RVA: 0x0001EF13 File Offset: 0x0001D113
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x1700098F RID: 2447
		// (get) Token: 0x06001A99 RID: 6809 RVA: 0x0001EF1C File Offset: 0x0001D11C
		// (set) Token: 0x06001A9A RID: 6810 RVA: 0x0001EF24 File Offset: 0x0001D124
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
