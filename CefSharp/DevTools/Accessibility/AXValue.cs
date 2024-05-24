using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000445 RID: 1093
	[DataContract]
	public class AXValue : DevToolsDomainEntityBase
	{
		// Token: 0x17000B9E RID: 2974
		// (get) Token: 0x06001FB8 RID: 8120 RVA: 0x00023BED File Offset: 0x00021DED
		// (set) Token: 0x06001FB9 RID: 8121 RVA: 0x00023C09 File Offset: 0x00021E09
		public AXValueType Type
		{
			get
			{
				return (AXValueType)DevToolsDomainEntityBase.StringToEnum(typeof(AXValueType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B9F RID: 2975
		// (get) Token: 0x06001FBA RID: 8122 RVA: 0x00023C1C File Offset: 0x00021E1C
		// (set) Token: 0x06001FBB RID: 8123 RVA: 0x00023C24 File Offset: 0x00021E24
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x17000BA0 RID: 2976
		// (get) Token: 0x06001FBC RID: 8124 RVA: 0x00023C2D File Offset: 0x00021E2D
		// (set) Token: 0x06001FBD RID: 8125 RVA: 0x00023C35 File Offset: 0x00021E35
		[DataMember(Name = "value", IsRequired = false)]
		public object Value { get; set; }

		// Token: 0x17000BA1 RID: 2977
		// (get) Token: 0x06001FBE RID: 8126 RVA: 0x00023C3E File Offset: 0x00021E3E
		// (set) Token: 0x06001FBF RID: 8127 RVA: 0x00023C46 File Offset: 0x00021E46
		[DataMember(Name = "relatedNodes", IsRequired = false)]
		public IList<AXRelatedNode> RelatedNodes { get; set; }

		// Token: 0x17000BA2 RID: 2978
		// (get) Token: 0x06001FC0 RID: 8128 RVA: 0x00023C4F File Offset: 0x00021E4F
		// (set) Token: 0x06001FC1 RID: 8129 RVA: 0x00023C57 File Offset: 0x00021E57
		[DataMember(Name = "sources", IsRequired = false)]
		public IList<AXValueSource> Sources { get; set; }
	}
}
