using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200012F RID: 303
	[DataContract]
	public class RemoteObject : DevToolsDomainEntityBase
	{
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x060008B0 RID: 2224 RVA: 0x0000DF6C File Offset: 0x0000C16C
		// (set) Token: 0x060008B1 RID: 2225 RVA: 0x0000DF88 File Offset: 0x0000C188
		public RemoteObjectType Type
		{
			get
			{
				return (RemoteObjectType)DevToolsDomainEntityBase.StringToEnum(typeof(RemoteObjectType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700026E RID: 622
		// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0000DF9B File Offset: 0x0000C19B
		// (set) Token: 0x060008B3 RID: 2227 RVA: 0x0000DFA3 File Offset: 0x0000C1A3
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x1700026F RID: 623
		// (get) Token: 0x060008B4 RID: 2228 RVA: 0x0000DFAC File Offset: 0x0000C1AC
		// (set) Token: 0x060008B5 RID: 2229 RVA: 0x0000DFC8 File Offset: 0x0000C1C8
		public RemoteObjectSubtype? Subtype
		{
			get
			{
				return (RemoteObjectSubtype?)DevToolsDomainEntityBase.StringToEnum(typeof(RemoteObjectSubtype?), this.subtype);
			}
			set
			{
				this.subtype = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x0000DFDB File Offset: 0x0000C1DB
		// (set) Token: 0x060008B7 RID: 2231 RVA: 0x0000DFE3 File Offset: 0x0000C1E3
		[DataMember(Name = "subtype", IsRequired = false)]
		internal string subtype { get; set; }

		// Token: 0x17000271 RID: 625
		// (get) Token: 0x060008B8 RID: 2232 RVA: 0x0000DFEC File Offset: 0x0000C1EC
		// (set) Token: 0x060008B9 RID: 2233 RVA: 0x0000DFF4 File Offset: 0x0000C1F4
		[DataMember(Name = "className", IsRequired = false)]
		public string ClassName { get; set; }

		// Token: 0x17000272 RID: 626
		// (get) Token: 0x060008BA RID: 2234 RVA: 0x0000DFFD File Offset: 0x0000C1FD
		// (set) Token: 0x060008BB RID: 2235 RVA: 0x0000E005 File Offset: 0x0000C205
		[DataMember(Name = "value", IsRequired = false)]
		public object Value { get; set; }

		// Token: 0x17000273 RID: 627
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x0000E00E File Offset: 0x0000C20E
		// (set) Token: 0x060008BD RID: 2237 RVA: 0x0000E016 File Offset: 0x0000C216
		[DataMember(Name = "unserializableValue", IsRequired = false)]
		public string UnserializableValue { get; set; }

		// Token: 0x17000274 RID: 628
		// (get) Token: 0x060008BE RID: 2238 RVA: 0x0000E01F File Offset: 0x0000C21F
		// (set) Token: 0x060008BF RID: 2239 RVA: 0x0000E027 File Offset: 0x0000C227
		[DataMember(Name = "description", IsRequired = false)]
		public string Description { get; set; }

		// Token: 0x17000275 RID: 629
		// (get) Token: 0x060008C0 RID: 2240 RVA: 0x0000E030 File Offset: 0x0000C230
		// (set) Token: 0x060008C1 RID: 2241 RVA: 0x0000E038 File Offset: 0x0000C238
		[DataMember(Name = "objectId", IsRequired = false)]
		public string ObjectId { get; set; }

		// Token: 0x17000276 RID: 630
		// (get) Token: 0x060008C2 RID: 2242 RVA: 0x0000E041 File Offset: 0x0000C241
		// (set) Token: 0x060008C3 RID: 2243 RVA: 0x0000E049 File Offset: 0x0000C249
		[DataMember(Name = "preview", IsRequired = false)]
		public ObjectPreview Preview { get; set; }

		// Token: 0x17000277 RID: 631
		// (get) Token: 0x060008C4 RID: 2244 RVA: 0x0000E052 File Offset: 0x0000C252
		// (set) Token: 0x060008C5 RID: 2245 RVA: 0x0000E05A File Offset: 0x0000C25A
		[DataMember(Name = "customPreview", IsRequired = false)]
		public CustomPreview CustomPreview { get; set; }
	}
}
