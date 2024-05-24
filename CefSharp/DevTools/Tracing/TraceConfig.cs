using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001CE RID: 462
	[DataContract]
	public class TraceConfig : DevToolsDomainEntityBase
	{
		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x00012864 File Offset: 0x00010A64
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x00012880 File Offset: 0x00010A80
		public TraceConfigRecordMode? RecordMode
		{
			get
			{
				return (TraceConfigRecordMode?)DevToolsDomainEntityBase.StringToEnum(typeof(TraceConfigRecordMode?), this.recordMode);
			}
			set
			{
				this.recordMode = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x00012893 File Offset: 0x00010A93
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x0001289B File Offset: 0x00010A9B
		[DataMember(Name = "recordMode", IsRequired = false)]
		internal string recordMode { get; set; }

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000D6F RID: 3439 RVA: 0x000128A4 File Offset: 0x00010AA4
		// (set) Token: 0x06000D70 RID: 3440 RVA: 0x000128AC File Offset: 0x00010AAC
		[DataMember(Name = "enableSampling", IsRequired = false)]
		public bool? EnableSampling { get; set; }

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x000128B5 File Offset: 0x00010AB5
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x000128BD File Offset: 0x00010ABD
		[DataMember(Name = "enableSystrace", IsRequired = false)]
		public bool? EnableSystrace { get; set; }

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x000128C6 File Offset: 0x00010AC6
		// (set) Token: 0x06000D74 RID: 3444 RVA: 0x000128CE File Offset: 0x00010ACE
		[DataMember(Name = "enableArgumentFilter", IsRequired = false)]
		public bool? EnableArgumentFilter { get; set; }

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000D75 RID: 3445 RVA: 0x000128D7 File Offset: 0x00010AD7
		// (set) Token: 0x06000D76 RID: 3446 RVA: 0x000128DF File Offset: 0x00010ADF
		[DataMember(Name = "includedCategories", IsRequired = false)]
		public string[] IncludedCategories { get; set; }

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000D77 RID: 3447 RVA: 0x000128E8 File Offset: 0x00010AE8
		// (set) Token: 0x06000D78 RID: 3448 RVA: 0x000128F0 File Offset: 0x00010AF0
		[DataMember(Name = "excludedCategories", IsRequired = false)]
		public string[] ExcludedCategories { get; set; }

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000D79 RID: 3449 RVA: 0x000128F9 File Offset: 0x00010AF9
		// (set) Token: 0x06000D7A RID: 3450 RVA: 0x00012901 File Offset: 0x00010B01
		[DataMember(Name = "syntheticDelays", IsRequired = false)]
		public string[] SyntheticDelays { get; set; }

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x0001290A File Offset: 0x00010B0A
		// (set) Token: 0x06000D7C RID: 3452 RVA: 0x00012912 File Offset: 0x00010B12
		[DataMember(Name = "memoryDumpConfig", IsRequired = false)]
		public MemoryDumpConfig MemoryDumpConfig { get; set; }
	}
}
