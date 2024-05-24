using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x02000200 RID: 512
	[DataContract]
	public class InterestGroupDetails : DevToolsDomainEntityBase
	{
		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06000E9F RID: 3743 RVA: 0x00013AB5 File Offset: 0x00011CB5
		// (set) Token: 0x06000EA0 RID: 3744 RVA: 0x00013ABD File Offset: 0x00011CBD
		[DataMember(Name = "ownerOrigin", IsRequired = true)]
		public string OwnerOrigin { get; set; }

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06000EA1 RID: 3745 RVA: 0x00013AC6 File Offset: 0x00011CC6
		// (set) Token: 0x06000EA2 RID: 3746 RVA: 0x00013ACE File Offset: 0x00011CCE
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06000EA3 RID: 3747 RVA: 0x00013AD7 File Offset: 0x00011CD7
		// (set) Token: 0x06000EA4 RID: 3748 RVA: 0x00013ADF File Offset: 0x00011CDF
		[DataMember(Name = "expirationTime", IsRequired = true)]
		public double ExpirationTime { get; set; }

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06000EA5 RID: 3749 RVA: 0x00013AE8 File Offset: 0x00011CE8
		// (set) Token: 0x06000EA6 RID: 3750 RVA: 0x00013AF0 File Offset: 0x00011CF0
		[DataMember(Name = "joiningOrigin", IsRequired = true)]
		public string JoiningOrigin { get; set; }

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06000EA7 RID: 3751 RVA: 0x00013AF9 File Offset: 0x00011CF9
		// (set) Token: 0x06000EA8 RID: 3752 RVA: 0x00013B01 File Offset: 0x00011D01
		[DataMember(Name = "biddingUrl", IsRequired = false)]
		public string BiddingUrl { get; set; }

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06000EA9 RID: 3753 RVA: 0x00013B0A File Offset: 0x00011D0A
		// (set) Token: 0x06000EAA RID: 3754 RVA: 0x00013B12 File Offset: 0x00011D12
		[DataMember(Name = "biddingWasmHelperUrl", IsRequired = false)]
		public string BiddingWasmHelperUrl { get; set; }

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06000EAB RID: 3755 RVA: 0x00013B1B File Offset: 0x00011D1B
		// (set) Token: 0x06000EAC RID: 3756 RVA: 0x00013B23 File Offset: 0x00011D23
		[DataMember(Name = "updateUrl", IsRequired = false)]
		public string UpdateUrl { get; set; }

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06000EAD RID: 3757 RVA: 0x00013B2C File Offset: 0x00011D2C
		// (set) Token: 0x06000EAE RID: 3758 RVA: 0x00013B34 File Offset: 0x00011D34
		[DataMember(Name = "trustedBiddingSignalsUrl", IsRequired = false)]
		public string TrustedBiddingSignalsUrl { get; set; }

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06000EAF RID: 3759 RVA: 0x00013B3D File Offset: 0x00011D3D
		// (set) Token: 0x06000EB0 RID: 3760 RVA: 0x00013B45 File Offset: 0x00011D45
		[DataMember(Name = "trustedBiddingSignalsKeys", IsRequired = true)]
		public string[] TrustedBiddingSignalsKeys { get; set; }

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06000EB1 RID: 3761 RVA: 0x00013B4E File Offset: 0x00011D4E
		// (set) Token: 0x06000EB2 RID: 3762 RVA: 0x00013B56 File Offset: 0x00011D56
		[DataMember(Name = "userBiddingSignals", IsRequired = false)]
		public string UserBiddingSignals { get; set; }

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06000EB3 RID: 3763 RVA: 0x00013B5F File Offset: 0x00011D5F
		// (set) Token: 0x06000EB4 RID: 3764 RVA: 0x00013B67 File Offset: 0x00011D67
		[DataMember(Name = "ads", IsRequired = true)]
		public IList<InterestGroupAd> Ads { get; set; }

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06000EB5 RID: 3765 RVA: 0x00013B70 File Offset: 0x00011D70
		// (set) Token: 0x06000EB6 RID: 3766 RVA: 0x00013B78 File Offset: 0x00011D78
		[DataMember(Name = "adComponents", IsRequired = true)]
		public IList<InterestGroupAd> AdComponents { get; set; }
	}
}
