using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003EE RID: 1006
	[DataContract]
	public class TakeCoverageDeltaResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AAC RID: 2732
		// (get) Token: 0x06001D54 RID: 7508 RVA: 0x0002171A File Offset: 0x0001F91A
		// (set) Token: 0x06001D55 RID: 7509 RVA: 0x00021722 File Offset: 0x0001F922
		[DataMember]
		internal IList<RuleUsage> coverage { get; set; }

		// Token: 0x17000AAD RID: 2733
		// (get) Token: 0x06001D56 RID: 7510 RVA: 0x0002172B File Offset: 0x0001F92B
		public IList<RuleUsage> Coverage
		{
			get
			{
				return this.coverage;
			}
		}

		// Token: 0x17000AAE RID: 2734
		// (get) Token: 0x06001D57 RID: 7511 RVA: 0x00021733 File Offset: 0x0001F933
		// (set) Token: 0x06001D58 RID: 7512 RVA: 0x0002173B File Offset: 0x0001F93B
		[DataMember]
		internal double timestamp { get; set; }

		// Token: 0x17000AAF RID: 2735
		// (get) Token: 0x06001D59 RID: 7513 RVA: 0x00021744 File Offset: 0x0001F944
		public double Timestamp
		{
			get
			{
				return this.timestamp;
			}
		}
	}
}
