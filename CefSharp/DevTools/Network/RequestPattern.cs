using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002CD RID: 717
	[DataContract]
	public class RequestPattern : DevToolsDomainEntityBase
	{
		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x060014C2 RID: 5314 RVA: 0x00019078 File Offset: 0x00017278
		// (set) Token: 0x060014C3 RID: 5315 RVA: 0x00019080 File Offset: 0x00017280
		[DataMember(Name = "urlPattern", IsRequired = false)]
		public string UrlPattern { get; set; }

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x060014C4 RID: 5316 RVA: 0x00019089 File Offset: 0x00017289
		// (set) Token: 0x060014C5 RID: 5317 RVA: 0x000190A5 File Offset: 0x000172A5
		public ResourceType? ResourceType
		{
			get
			{
				return (ResourceType?)DevToolsDomainEntityBase.StringToEnum(typeof(ResourceType?), this.resourceType);
			}
			set
			{
				this.resourceType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x060014C6 RID: 5318 RVA: 0x000190B8 File Offset: 0x000172B8
		// (set) Token: 0x060014C7 RID: 5319 RVA: 0x000190C0 File Offset: 0x000172C0
		[DataMember(Name = "resourceType", IsRequired = false)]
		internal string resourceType { get; set; }

		// Token: 0x17000747 RID: 1863
		// (get) Token: 0x060014C8 RID: 5320 RVA: 0x000190C9 File Offset: 0x000172C9
		// (set) Token: 0x060014C9 RID: 5321 RVA: 0x000190E5 File Offset: 0x000172E5
		public InterceptionStage? InterceptionStage
		{
			get
			{
				return (InterceptionStage?)DevToolsDomainEntityBase.StringToEnum(typeof(InterceptionStage?), this.interceptionStage);
			}
			set
			{
				this.interceptionStage = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000748 RID: 1864
		// (get) Token: 0x060014CA RID: 5322 RVA: 0x000190F8 File Offset: 0x000172F8
		// (set) Token: 0x060014CB RID: 5323 RVA: 0x00019100 File Offset: 0x00017300
		[DataMember(Name = "interceptionStage", IsRequired = false)]
		internal string interceptionStage { get; set; }
	}
}
