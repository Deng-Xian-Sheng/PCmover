using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002D2 RID: 722
	[DataContract]
	public class SignedExchangeInfo : DevToolsDomainEntityBase
	{
		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x060014F4 RID: 5364 RVA: 0x00019279 File Offset: 0x00017479
		// (set) Token: 0x060014F5 RID: 5365 RVA: 0x00019281 File Offset: 0x00017481
		[DataMember(Name = "outerResponse", IsRequired = true)]
		public Response OuterResponse { get; set; }

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x060014F6 RID: 5366 RVA: 0x0001928A File Offset: 0x0001748A
		// (set) Token: 0x060014F7 RID: 5367 RVA: 0x00019292 File Offset: 0x00017492
		[DataMember(Name = "header", IsRequired = false)]
		public SignedExchangeHeader Header { get; set; }

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x060014F8 RID: 5368 RVA: 0x0001929B File Offset: 0x0001749B
		// (set) Token: 0x060014F9 RID: 5369 RVA: 0x000192A3 File Offset: 0x000174A3
		[DataMember(Name = "securityDetails", IsRequired = false)]
		public SecurityDetails SecurityDetails { get; set; }

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x060014FA RID: 5370 RVA: 0x000192AC File Offset: 0x000174AC
		// (set) Token: 0x060014FB RID: 5371 RVA: 0x000192B4 File Offset: 0x000174B4
		[DataMember(Name = "errors", IsRequired = false)]
		public IList<SignedExchangeError> Errors { get; set; }
	}
}
