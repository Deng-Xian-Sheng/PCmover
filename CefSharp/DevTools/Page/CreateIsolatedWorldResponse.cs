using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000275 RID: 629
	[DataContract]
	public class CreateIsolatedWorldResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700060C RID: 1548
		// (get) Token: 0x060011BC RID: 4540 RVA: 0x00015F91 File Offset: 0x00014191
		// (set) Token: 0x060011BD RID: 4541 RVA: 0x00015F99 File Offset: 0x00014199
		[DataMember]
		internal int executionContextId { get; set; }

		// Token: 0x1700060D RID: 1549
		// (get) Token: 0x060011BE RID: 4542 RVA: 0x00015FA2 File Offset: 0x000141A2
		public int ExecutionContextId
		{
			get
			{
				return this.executionContextId;
			}
		}
	}
}
