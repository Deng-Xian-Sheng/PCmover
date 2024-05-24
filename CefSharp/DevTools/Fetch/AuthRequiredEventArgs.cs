using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Network;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001C9 RID: 457
	[DataContract]
	public class AuthRequiredEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06000D45 RID: 3397 RVA: 0x0001236F File Offset: 0x0001056F
		// (set) Token: 0x06000D46 RID: 3398 RVA: 0x00012377 File Offset: 0x00010577
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000D47 RID: 3399 RVA: 0x00012380 File Offset: 0x00010580
		// (set) Token: 0x06000D48 RID: 3400 RVA: 0x00012388 File Offset: 0x00010588
		[DataMember(Name = "request", IsRequired = true)]
		public Request Request { get; private set; }

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000D49 RID: 3401 RVA: 0x00012391 File Offset: 0x00010591
		// (set) Token: 0x06000D4A RID: 3402 RVA: 0x00012399 File Offset: 0x00010599
		[DataMember(Name = "frameId", IsRequired = true)]
		public string FrameId { get; private set; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000D4B RID: 3403 RVA: 0x000123A2 File Offset: 0x000105A2
		// (set) Token: 0x06000D4C RID: 3404 RVA: 0x000123BE File Offset: 0x000105BE
		public ResourceType ResourceType
		{
			get
			{
				return (ResourceType)DevToolsDomainEventArgsBase.StringToEnum(typeof(ResourceType), this.resourceType);
			}
			set
			{
				this.resourceType = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000D4D RID: 3405 RVA: 0x000123D1 File Offset: 0x000105D1
		// (set) Token: 0x06000D4E RID: 3406 RVA: 0x000123D9 File Offset: 0x000105D9
		[DataMember(Name = "resourceType", IsRequired = true)]
		internal string resourceType { get; private set; }

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000D4F RID: 3407 RVA: 0x000123E2 File Offset: 0x000105E2
		// (set) Token: 0x06000D50 RID: 3408 RVA: 0x000123EA File Offset: 0x000105EA
		[DataMember(Name = "authChallenge", IsRequired = true)]
		public AuthChallenge AuthChallenge { get; private set; }
	}
}
