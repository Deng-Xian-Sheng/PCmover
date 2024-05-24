using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CacheStorage
{
	// Token: 0x020003B7 RID: 951
	[DataContract]
	public class Header : DevToolsDomainEntityBase
	{
		// Token: 0x170009F8 RID: 2552
		// (get) Token: 0x06001BD1 RID: 7121 RVA: 0x0002086A File Offset: 0x0001EA6A
		// (set) Token: 0x06001BD2 RID: 7122 RVA: 0x00020872 File Offset: 0x0001EA72
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170009F9 RID: 2553
		// (get) Token: 0x06001BD3 RID: 7123 RVA: 0x0002087B File Offset: 0x0001EA7B
		// (set) Token: 0x06001BD4 RID: 7124 RVA: 0x00020883 File Offset: 0x0001EA83
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
