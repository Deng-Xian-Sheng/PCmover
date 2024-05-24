using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003CE RID: 974
	[DataContract]
	public class MediaQueryExpression : DevToolsDomainEntityBase
	{
		// Token: 0x17000A4B RID: 2635
		// (get) Token: 0x06001C8D RID: 7309 RVA: 0x0002107E File Offset: 0x0001F27E
		// (set) Token: 0x06001C8E RID: 7310 RVA: 0x00021086 File Offset: 0x0001F286
		[DataMember(Name = "value", IsRequired = true)]
		public double Value { get; set; }

		// Token: 0x17000A4C RID: 2636
		// (get) Token: 0x06001C8F RID: 7311 RVA: 0x0002108F File Offset: 0x0001F28F
		// (set) Token: 0x06001C90 RID: 7312 RVA: 0x00021097 File Offset: 0x0001F297
		[DataMember(Name = "unit", IsRequired = true)]
		public string Unit { get; set; }

		// Token: 0x17000A4D RID: 2637
		// (get) Token: 0x06001C91 RID: 7313 RVA: 0x000210A0 File Offset: 0x0001F2A0
		// (set) Token: 0x06001C92 RID: 7314 RVA: 0x000210A8 File Offset: 0x0001F2A8
		[DataMember(Name = "feature", IsRequired = true)]
		public string Feature { get; set; }

		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x06001C93 RID: 7315 RVA: 0x000210B1 File Offset: 0x0001F2B1
		// (set) Token: 0x06001C94 RID: 7316 RVA: 0x000210B9 File Offset: 0x0001F2B9
		[DataMember(Name = "valueRange", IsRequired = false)]
		public SourceRange ValueRange { get; set; }

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x06001C95 RID: 7317 RVA: 0x000210C2 File Offset: 0x0001F2C2
		// (set) Token: 0x06001C96 RID: 7318 RVA: 0x000210CA File Offset: 0x0001F2CA
		[DataMember(Name = "computedLength", IsRequired = false)]
		public double? ComputedLength { get; set; }
	}
}
