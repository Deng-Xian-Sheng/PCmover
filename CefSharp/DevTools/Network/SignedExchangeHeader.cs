using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002CF RID: 719
	[DataContract]
	public class SignedExchangeHeader : DevToolsDomainEntityBase
	{
		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x000191B2 File Offset: 0x000173B2
		// (set) Token: 0x060014E1 RID: 5345 RVA: 0x000191BA File Offset: 0x000173BA
		[DataMember(Name = "requestUrl", IsRequired = true)]
		public string RequestUrl { get; set; }

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x060014E2 RID: 5346 RVA: 0x000191C3 File Offset: 0x000173C3
		// (set) Token: 0x060014E3 RID: 5347 RVA: 0x000191CB File Offset: 0x000173CB
		[DataMember(Name = "responseCode", IsRequired = true)]
		public int ResponseCode { get; set; }

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x060014E4 RID: 5348 RVA: 0x000191D4 File Offset: 0x000173D4
		// (set) Token: 0x060014E5 RID: 5349 RVA: 0x000191DC File Offset: 0x000173DC
		[DataMember(Name = "responseHeaders", IsRequired = true)]
		public Headers ResponseHeaders { get; set; }

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x060014E6 RID: 5350 RVA: 0x000191E5 File Offset: 0x000173E5
		// (set) Token: 0x060014E7 RID: 5351 RVA: 0x000191ED File Offset: 0x000173ED
		[DataMember(Name = "signatures", IsRequired = true)]
		public IList<SignedExchangeSignature> Signatures { get; set; }

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x060014E8 RID: 5352 RVA: 0x000191F6 File Offset: 0x000173F6
		// (set) Token: 0x060014E9 RID: 5353 RVA: 0x000191FE File Offset: 0x000173FE
		[DataMember(Name = "headerIntegrity", IsRequired = true)]
		public string HeaderIntegrity { get; set; }
	}
}
