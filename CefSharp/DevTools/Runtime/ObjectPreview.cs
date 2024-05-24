using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000133 RID: 307
	[DataContract]
	public class ObjectPreview : DevToolsDomainEntityBase
	{
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x060008CC RID: 2252 RVA: 0x0000E095 File Offset: 0x0000C295
		// (set) Token: 0x060008CD RID: 2253 RVA: 0x0000E0B1 File Offset: 0x0000C2B1
		public ObjectPreviewType Type
		{
			get
			{
				return (ObjectPreviewType)DevToolsDomainEntityBase.StringToEnum(typeof(ObjectPreviewType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700027B RID: 635
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x0000E0C4 File Offset: 0x0000C2C4
		// (set) Token: 0x060008CF RID: 2255 RVA: 0x0000E0CC File Offset: 0x0000C2CC
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x1700027C RID: 636
		// (get) Token: 0x060008D0 RID: 2256 RVA: 0x0000E0D5 File Offset: 0x0000C2D5
		// (set) Token: 0x060008D1 RID: 2257 RVA: 0x0000E0F1 File Offset: 0x0000C2F1
		public ObjectPreviewSubtype? Subtype
		{
			get
			{
				return (ObjectPreviewSubtype?)DevToolsDomainEntityBase.StringToEnum(typeof(ObjectPreviewSubtype?), this.subtype);
			}
			set
			{
				this.subtype = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700027D RID: 637
		// (get) Token: 0x060008D2 RID: 2258 RVA: 0x0000E104 File Offset: 0x0000C304
		// (set) Token: 0x060008D3 RID: 2259 RVA: 0x0000E10C File Offset: 0x0000C30C
		[DataMember(Name = "subtype", IsRequired = false)]
		internal string subtype { get; set; }

		// Token: 0x1700027E RID: 638
		// (get) Token: 0x060008D4 RID: 2260 RVA: 0x0000E115 File Offset: 0x0000C315
		// (set) Token: 0x060008D5 RID: 2261 RVA: 0x0000E11D File Offset: 0x0000C31D
		[DataMember(Name = "description", IsRequired = false)]
		public string Description { get; set; }

		// Token: 0x1700027F RID: 639
		// (get) Token: 0x060008D6 RID: 2262 RVA: 0x0000E126 File Offset: 0x0000C326
		// (set) Token: 0x060008D7 RID: 2263 RVA: 0x0000E12E File Offset: 0x0000C32E
		[DataMember(Name = "overflow", IsRequired = true)]
		public bool Overflow { get; set; }

		// Token: 0x17000280 RID: 640
		// (get) Token: 0x060008D8 RID: 2264 RVA: 0x0000E137 File Offset: 0x0000C337
		// (set) Token: 0x060008D9 RID: 2265 RVA: 0x0000E13F File Offset: 0x0000C33F
		[DataMember(Name = "properties", IsRequired = true)]
		public IList<PropertyPreview> Properties { get; set; }

		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060008DA RID: 2266 RVA: 0x0000E148 File Offset: 0x0000C348
		// (set) Token: 0x060008DB RID: 2267 RVA: 0x0000E150 File Offset: 0x0000C350
		[DataMember(Name = "entries", IsRequired = false)]
		public IList<EntryPreview> Entries { get; set; }
	}
}
