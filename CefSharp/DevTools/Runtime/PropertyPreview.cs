using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000136 RID: 310
	[DataContract]
	public class PropertyPreview : DevToolsDomainEntityBase
	{
		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x0000E161 File Offset: 0x0000C361
		// (set) Token: 0x060008DE RID: 2270 RVA: 0x0000E169 File Offset: 0x0000C369
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000283 RID: 643
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x0000E172 File Offset: 0x0000C372
		// (set) Token: 0x060008E0 RID: 2272 RVA: 0x0000E18E File Offset: 0x0000C38E
		public PropertyPreviewType Type
		{
			get
			{
				return (PropertyPreviewType)DevToolsDomainEntityBase.StringToEnum(typeof(PropertyPreviewType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000284 RID: 644
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x0000E1A1 File Offset: 0x0000C3A1
		// (set) Token: 0x060008E2 RID: 2274 RVA: 0x0000E1A9 File Offset: 0x0000C3A9
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x17000285 RID: 645
		// (get) Token: 0x060008E3 RID: 2275 RVA: 0x0000E1B2 File Offset: 0x0000C3B2
		// (set) Token: 0x060008E4 RID: 2276 RVA: 0x0000E1BA File Offset: 0x0000C3BA
		[DataMember(Name = "value", IsRequired = false)]
		public string Value { get; set; }

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x060008E5 RID: 2277 RVA: 0x0000E1C3 File Offset: 0x0000C3C3
		// (set) Token: 0x060008E6 RID: 2278 RVA: 0x0000E1CB File Offset: 0x0000C3CB
		[DataMember(Name = "valuePreview", IsRequired = false)]
		public ObjectPreview ValuePreview { get; set; }

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x060008E7 RID: 2279 RVA: 0x0000E1D4 File Offset: 0x0000C3D4
		// (set) Token: 0x060008E8 RID: 2280 RVA: 0x0000E1F0 File Offset: 0x0000C3F0
		public PropertyPreviewSubtype? Subtype
		{
			get
			{
				return (PropertyPreviewSubtype?)DevToolsDomainEntityBase.StringToEnum(typeof(PropertyPreviewSubtype?), this.subtype);
			}
			set
			{
				this.subtype = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x060008E9 RID: 2281 RVA: 0x0000E203 File Offset: 0x0000C403
		// (set) Token: 0x060008EA RID: 2282 RVA: 0x0000E20B File Offset: 0x0000C40B
		[DataMember(Name = "subtype", IsRequired = false)]
		internal string subtype { get; set; }
	}
}
