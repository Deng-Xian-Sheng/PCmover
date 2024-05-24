using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001C2 RID: 450
	[DataContract]
	public class RequestPattern : DevToolsDomainEntityBase
	{
		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000D0A RID: 3338 RVA: 0x000120C8 File Offset: 0x000102C8
		// (set) Token: 0x06000D0B RID: 3339 RVA: 0x000120D0 File Offset: 0x000102D0
		[DataMember(Name = "urlPattern", IsRequired = false)]
		public string UrlPattern { get; set; }

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000D0C RID: 3340 RVA: 0x000120D9 File Offset: 0x000102D9
		// (set) Token: 0x06000D0D RID: 3341 RVA: 0x000120F5 File Offset: 0x000102F5
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

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000D0E RID: 3342 RVA: 0x00012108 File Offset: 0x00010308
		// (set) Token: 0x06000D0F RID: 3343 RVA: 0x00012110 File Offset: 0x00010310
		[DataMember(Name = "resourceType", IsRequired = false)]
		internal string resourceType { get; set; }

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000D10 RID: 3344 RVA: 0x00012119 File Offset: 0x00010319
		// (set) Token: 0x06000D11 RID: 3345 RVA: 0x00012135 File Offset: 0x00010335
		public RequestStage? RequestStage
		{
			get
			{
				return (RequestStage?)DevToolsDomainEntityBase.StringToEnum(typeof(RequestStage?), this.requestStage);
			}
			set
			{
				this.requestStage = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000D12 RID: 3346 RVA: 0x00012148 File Offset: 0x00010348
		// (set) Token: 0x06000D13 RID: 3347 RVA: 0x00012150 File Offset: 0x00010350
		[DataMember(Name = "requestStage", IsRequired = false)]
		internal string requestStage { get; set; }
	}
}
