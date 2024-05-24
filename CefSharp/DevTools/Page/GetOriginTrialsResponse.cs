using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000283 RID: 643
	[DataContract]
	public class GetOriginTrialsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000644 RID: 1604
		// (get) Token: 0x0600121E RID: 4638 RVA: 0x000162C9 File Offset: 0x000144C9
		// (set) Token: 0x0600121F RID: 4639 RVA: 0x000162D1 File Offset: 0x000144D1
		[DataMember]
		internal IList<OriginTrial> originTrials { get; set; }

		// Token: 0x17000645 RID: 1605
		// (get) Token: 0x06001220 RID: 4640 RVA: 0x000162DA File Offset: 0x000144DA
		public IList<OriginTrial> OriginTrials
		{
			get
			{
				return this.originTrials;
			}
		}
	}
}
