using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B9 RID: 697
	[DataContract]
	public class TrustTokenParams : DevToolsDomainEntityBase
	{
		// Token: 0x170006DC RID: 1756
		// (get) Token: 0x060013E5 RID: 5093 RVA: 0x00018752 File Offset: 0x00016952
		// (set) Token: 0x060013E6 RID: 5094 RVA: 0x0001876E File Offset: 0x0001696E
		public TrustTokenOperationType Type
		{
			get
			{
				return (TrustTokenOperationType)DevToolsDomainEntityBase.StringToEnum(typeof(TrustTokenOperationType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006DD RID: 1757
		// (get) Token: 0x060013E7 RID: 5095 RVA: 0x00018781 File Offset: 0x00016981
		// (set) Token: 0x060013E8 RID: 5096 RVA: 0x00018789 File Offset: 0x00016989
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }

		// Token: 0x170006DE RID: 1758
		// (get) Token: 0x060013E9 RID: 5097 RVA: 0x00018792 File Offset: 0x00016992
		// (set) Token: 0x060013EA RID: 5098 RVA: 0x000187AE File Offset: 0x000169AE
		public TrustTokenParamsRefreshPolicy RefreshPolicy
		{
			get
			{
				return (TrustTokenParamsRefreshPolicy)DevToolsDomainEntityBase.StringToEnum(typeof(TrustTokenParamsRefreshPolicy), this.refreshPolicy);
			}
			set
			{
				this.refreshPolicy = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006DF RID: 1759
		// (get) Token: 0x060013EB RID: 5099 RVA: 0x000187C1 File Offset: 0x000169C1
		// (set) Token: 0x060013EC RID: 5100 RVA: 0x000187C9 File Offset: 0x000169C9
		[DataMember(Name = "refreshPolicy", IsRequired = true)]
		internal string refreshPolicy { get; set; }

		// Token: 0x170006E0 RID: 1760
		// (get) Token: 0x060013ED RID: 5101 RVA: 0x000187D2 File Offset: 0x000169D2
		// (set) Token: 0x060013EE RID: 5102 RVA: 0x000187DA File Offset: 0x000169DA
		[DataMember(Name = "issuers", IsRequired = false)]
		public string[] Issuers { get; set; }
	}
}
