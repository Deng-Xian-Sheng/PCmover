using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F7 RID: 1015
	[DataContract]
	public class Histogram : DevToolsDomainEntityBase
	{
		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x06001DA0 RID: 7584 RVA: 0x00021F61 File Offset: 0x00020161
		// (set) Token: 0x06001DA1 RID: 7585 RVA: 0x00021F69 File Offset: 0x00020169
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x06001DA2 RID: 7586 RVA: 0x00021F72 File Offset: 0x00020172
		// (set) Token: 0x06001DA3 RID: 7587 RVA: 0x00021F7A File Offset: 0x0002017A
		[DataMember(Name = "sum", IsRequired = true)]
		public int Sum { get; set; }

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x06001DA4 RID: 7588 RVA: 0x00021F83 File Offset: 0x00020183
		// (set) Token: 0x06001DA5 RID: 7589 RVA: 0x00021F8B File Offset: 0x0002018B
		[DataMember(Name = "count", IsRequired = true)]
		public int Count { get; set; }

		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x06001DA6 RID: 7590 RVA: 0x00021F94 File Offset: 0x00020194
		// (set) Token: 0x06001DA7 RID: 7591 RVA: 0x00021F9C File Offset: 0x0002019C
		[DataMember(Name = "buckets", IsRequired = true)]
		public IList<Bucket> Buckets { get; set; }
	}
}
