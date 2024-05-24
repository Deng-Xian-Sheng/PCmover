using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x02000442 RID: 1090
	[DataContract]
	public class AXValueSource : DevToolsDomainEntityBase
	{
		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x06001F93 RID: 8083 RVA: 0x00023A5A File Offset: 0x00021C5A
		// (set) Token: 0x06001F94 RID: 8084 RVA: 0x00023A76 File Offset: 0x00021C76
		public AXValueSourceType Type
		{
			get
			{
				return (AXValueSourceType)DevToolsDomainEntityBase.StringToEnum(typeof(AXValueSourceType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x06001F95 RID: 8085 RVA: 0x00023A89 File Offset: 0x00021C89
		// (set) Token: 0x06001F96 RID: 8086 RVA: 0x00023A91 File Offset: 0x00021C91
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x06001F97 RID: 8087 RVA: 0x00023A9A File Offset: 0x00021C9A
		// (set) Token: 0x06001F98 RID: 8088 RVA: 0x00023AA2 File Offset: 0x00021CA2
		[DataMember(Name = "value", IsRequired = false)]
		public AXValue Value { get; set; }

		// Token: 0x17000B90 RID: 2960
		// (get) Token: 0x06001F99 RID: 8089 RVA: 0x00023AAB File Offset: 0x00021CAB
		// (set) Token: 0x06001F9A RID: 8090 RVA: 0x00023AB3 File Offset: 0x00021CB3
		[DataMember(Name = "attribute", IsRequired = false)]
		public string Attribute { get; set; }

		// Token: 0x17000B91 RID: 2961
		// (get) Token: 0x06001F9B RID: 8091 RVA: 0x00023ABC File Offset: 0x00021CBC
		// (set) Token: 0x06001F9C RID: 8092 RVA: 0x00023AC4 File Offset: 0x00021CC4
		[DataMember(Name = "attributeValue", IsRequired = false)]
		public AXValue AttributeValue { get; set; }

		// Token: 0x17000B92 RID: 2962
		// (get) Token: 0x06001F9D RID: 8093 RVA: 0x00023ACD File Offset: 0x00021CCD
		// (set) Token: 0x06001F9E RID: 8094 RVA: 0x00023AD5 File Offset: 0x00021CD5
		[DataMember(Name = "superseded", IsRequired = false)]
		public bool? Superseded { get; set; }

		// Token: 0x17000B93 RID: 2963
		// (get) Token: 0x06001F9F RID: 8095 RVA: 0x00023ADE File Offset: 0x00021CDE
		// (set) Token: 0x06001FA0 RID: 8096 RVA: 0x00023AFA File Offset: 0x00021CFA
		public AXValueNativeSourceType? NativeSource
		{
			get
			{
				return (AXValueNativeSourceType?)DevToolsDomainEntityBase.StringToEnum(typeof(AXValueNativeSourceType?), this.nativeSource);
			}
			set
			{
				this.nativeSource = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B94 RID: 2964
		// (get) Token: 0x06001FA1 RID: 8097 RVA: 0x00023B0D File Offset: 0x00021D0D
		// (set) Token: 0x06001FA2 RID: 8098 RVA: 0x00023B15 File Offset: 0x00021D15
		[DataMember(Name = "nativeSource", IsRequired = false)]
		internal string nativeSource { get; set; }

		// Token: 0x17000B95 RID: 2965
		// (get) Token: 0x06001FA3 RID: 8099 RVA: 0x00023B1E File Offset: 0x00021D1E
		// (set) Token: 0x06001FA4 RID: 8100 RVA: 0x00023B26 File Offset: 0x00021D26
		[DataMember(Name = "nativeSourceValue", IsRequired = false)]
		public AXValue NativeSourceValue { get; set; }

		// Token: 0x17000B96 RID: 2966
		// (get) Token: 0x06001FA5 RID: 8101 RVA: 0x00023B2F File Offset: 0x00021D2F
		// (set) Token: 0x06001FA6 RID: 8102 RVA: 0x00023B37 File Offset: 0x00021D37
		[DataMember(Name = "invalid", IsRequired = false)]
		public bool? Invalid { get; set; }

		// Token: 0x17000B97 RID: 2967
		// (get) Token: 0x06001FA7 RID: 8103 RVA: 0x00023B40 File Offset: 0x00021D40
		// (set) Token: 0x06001FA8 RID: 8104 RVA: 0x00023B48 File Offset: 0x00021D48
		[DataMember(Name = "invalidReason", IsRequired = false)]
		public string InvalidReason { get; set; }
	}
}
