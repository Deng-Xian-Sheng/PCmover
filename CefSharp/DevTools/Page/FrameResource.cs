using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200023E RID: 574
	[DataContract]
	public class FrameResource : DevToolsDomainEntityBase
	{
		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x06001071 RID: 4209 RVA: 0x0001533D File Offset: 0x0001353D
		// (set) Token: 0x06001072 RID: 4210 RVA: 0x00015345 File Offset: 0x00013545
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x06001073 RID: 4211 RVA: 0x0001534E File Offset: 0x0001354E
		// (set) Token: 0x06001074 RID: 4212 RVA: 0x0001536A File Offset: 0x0001356A
		public ResourceType Type
		{
			get
			{
				return (ResourceType)DevToolsDomainEntityBase.StringToEnum(typeof(ResourceType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06001075 RID: 4213 RVA: 0x0001537D File Offset: 0x0001357D
		// (set) Token: 0x06001076 RID: 4214 RVA: 0x00015385 File Offset: 0x00013585
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06001077 RID: 4215 RVA: 0x0001538E File Offset: 0x0001358E
		// (set) Token: 0x06001078 RID: 4216 RVA: 0x00015396 File Offset: 0x00013596
		[DataMember(Name = "mimeType", IsRequired = true)]
		public string MimeType { get; set; }

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06001079 RID: 4217 RVA: 0x0001539F File Offset: 0x0001359F
		// (set) Token: 0x0600107A RID: 4218 RVA: 0x000153A7 File Offset: 0x000135A7
		[DataMember(Name = "lastModified", IsRequired = false)]
		public double? LastModified { get; set; }

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x0600107B RID: 4219 RVA: 0x000153B0 File Offset: 0x000135B0
		// (set) Token: 0x0600107C RID: 4220 RVA: 0x000153B8 File Offset: 0x000135B8
		[DataMember(Name = "contentSize", IsRequired = false)]
		public double? ContentSize { get; set; }

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x0600107D RID: 4221 RVA: 0x000153C1 File Offset: 0x000135C1
		// (set) Token: 0x0600107E RID: 4222 RVA: 0x000153C9 File Offset: 0x000135C9
		[DataMember(Name = "failed", IsRequired = false)]
		public bool? Failed { get; set; }

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x0600107F RID: 4223 RVA: 0x000153D2 File Offset: 0x000135D2
		// (set) Token: 0x06001080 RID: 4224 RVA: 0x000153DA File Offset: 0x000135DA
		[DataMember(Name = "canceled", IsRequired = false)]
		public bool? Canceled { get; set; }
	}
}
