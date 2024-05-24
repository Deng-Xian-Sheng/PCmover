using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003D2 RID: 978
	[DataContract]
	public class FontVariationAxis : DevToolsDomainEntityBase
	{
		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x06001CAF RID: 7343 RVA: 0x0002119D File Offset: 0x0001F39D
		// (set) Token: 0x06001CB0 RID: 7344 RVA: 0x000211A5 File Offset: 0x0001F3A5
		[DataMember(Name = "tag", IsRequired = true)]
		public string Tag { get; set; }

		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x06001CB1 RID: 7345 RVA: 0x000211AE File Offset: 0x0001F3AE
		// (set) Token: 0x06001CB2 RID: 7346 RVA: 0x000211B6 File Offset: 0x0001F3B6
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x06001CB3 RID: 7347 RVA: 0x000211BF File Offset: 0x0001F3BF
		// (set) Token: 0x06001CB4 RID: 7348 RVA: 0x000211C7 File Offset: 0x0001F3C7
		[DataMember(Name = "minValue", IsRequired = true)]
		public double MinValue { get; set; }

		// Token: 0x17000A5D RID: 2653
		// (get) Token: 0x06001CB5 RID: 7349 RVA: 0x000211D0 File Offset: 0x0001F3D0
		// (set) Token: 0x06001CB6 RID: 7350 RVA: 0x000211D8 File Offset: 0x0001F3D8
		[DataMember(Name = "maxValue", IsRequired = true)]
		public double MaxValue { get; set; }

		// Token: 0x17000A5E RID: 2654
		// (get) Token: 0x06001CB7 RID: 7351 RVA: 0x000211E1 File Offset: 0x0001F3E1
		// (set) Token: 0x06001CB8 RID: 7352 RVA: 0x000211E9 File Offset: 0x0001F3E9
		[DataMember(Name = "defaultValue", IsRequired = true)]
		public double DefaultValue { get; set; }
	}
}
