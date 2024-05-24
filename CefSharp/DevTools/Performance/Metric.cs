using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Performance
{
	// Token: 0x02000228 RID: 552
	[DataContract]
	public class Metric : DevToolsDomainEntityBase
	{
		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06001000 RID: 4096 RVA: 0x00014DD8 File Offset: 0x00012FD8
		// (set) Token: 0x06001001 RID: 4097 RVA: 0x00014DE0 File Offset: 0x00012FE0
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x06001002 RID: 4098 RVA: 0x00014DE9 File Offset: 0x00012FE9
		// (set) Token: 0x06001003 RID: 4099 RVA: 0x00014DF1 File Offset: 0x00012FF1
		[DataMember(Name = "value", IsRequired = true)]
		public double Value { get; set; }
	}
}
