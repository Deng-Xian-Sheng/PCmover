using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B2 RID: 690
	[DataContract]
	public class SecurityDetails : DevToolsDomainEntityBase
	{
		// Token: 0x170006CB RID: 1739
		// (get) Token: 0x060013C1 RID: 5057 RVA: 0x000185E5 File Offset: 0x000167E5
		// (set) Token: 0x060013C2 RID: 5058 RVA: 0x000185ED File Offset: 0x000167ED
		[DataMember(Name = "protocol", IsRequired = true)]
		public string Protocol { get; set; }

		// Token: 0x170006CC RID: 1740
		// (get) Token: 0x060013C3 RID: 5059 RVA: 0x000185F6 File Offset: 0x000167F6
		// (set) Token: 0x060013C4 RID: 5060 RVA: 0x000185FE File Offset: 0x000167FE
		[DataMember(Name = "keyExchange", IsRequired = true)]
		public string KeyExchange { get; set; }

		// Token: 0x170006CD RID: 1741
		// (get) Token: 0x060013C5 RID: 5061 RVA: 0x00018607 File Offset: 0x00016807
		// (set) Token: 0x060013C6 RID: 5062 RVA: 0x0001860F File Offset: 0x0001680F
		[DataMember(Name = "keyExchangeGroup", IsRequired = false)]
		public string KeyExchangeGroup { get; set; }

		// Token: 0x170006CE RID: 1742
		// (get) Token: 0x060013C7 RID: 5063 RVA: 0x00018618 File Offset: 0x00016818
		// (set) Token: 0x060013C8 RID: 5064 RVA: 0x00018620 File Offset: 0x00016820
		[DataMember(Name = "cipher", IsRequired = true)]
		public string Cipher { get; set; }

		// Token: 0x170006CF RID: 1743
		// (get) Token: 0x060013C9 RID: 5065 RVA: 0x00018629 File Offset: 0x00016829
		// (set) Token: 0x060013CA RID: 5066 RVA: 0x00018631 File Offset: 0x00016831
		[DataMember(Name = "mac", IsRequired = false)]
		public string Mac { get; set; }

		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x060013CB RID: 5067 RVA: 0x0001863A File Offset: 0x0001683A
		// (set) Token: 0x060013CC RID: 5068 RVA: 0x00018642 File Offset: 0x00016842
		[DataMember(Name = "certificateId", IsRequired = true)]
		public int CertificateId { get; set; }

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x060013CD RID: 5069 RVA: 0x0001864B File Offset: 0x0001684B
		// (set) Token: 0x060013CE RID: 5070 RVA: 0x00018653 File Offset: 0x00016853
		[DataMember(Name = "subjectName", IsRequired = true)]
		public string SubjectName { get; set; }

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x060013CF RID: 5071 RVA: 0x0001865C File Offset: 0x0001685C
		// (set) Token: 0x060013D0 RID: 5072 RVA: 0x00018664 File Offset: 0x00016864
		[DataMember(Name = "sanList", IsRequired = true)]
		public string[] SanList { get; set; }

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x060013D1 RID: 5073 RVA: 0x0001866D File Offset: 0x0001686D
		// (set) Token: 0x060013D2 RID: 5074 RVA: 0x00018675 File Offset: 0x00016875
		[DataMember(Name = "issuer", IsRequired = true)]
		public string Issuer { get; set; }

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x060013D3 RID: 5075 RVA: 0x0001867E File Offset: 0x0001687E
		// (set) Token: 0x060013D4 RID: 5076 RVA: 0x00018686 File Offset: 0x00016886
		[DataMember(Name = "validFrom", IsRequired = true)]
		public double ValidFrom { get; set; }

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x060013D5 RID: 5077 RVA: 0x0001868F File Offset: 0x0001688F
		// (set) Token: 0x060013D6 RID: 5078 RVA: 0x00018697 File Offset: 0x00016897
		[DataMember(Name = "validTo", IsRequired = true)]
		public double ValidTo { get; set; }

		// Token: 0x170006D6 RID: 1750
		// (get) Token: 0x060013D7 RID: 5079 RVA: 0x000186A0 File Offset: 0x000168A0
		// (set) Token: 0x060013D8 RID: 5080 RVA: 0x000186A8 File Offset: 0x000168A8
		[DataMember(Name = "signedCertificateTimestampList", IsRequired = true)]
		public IList<SignedCertificateTimestamp> SignedCertificateTimestampList { get; set; }

		// Token: 0x170006D7 RID: 1751
		// (get) Token: 0x060013D9 RID: 5081 RVA: 0x000186B1 File Offset: 0x000168B1
		// (set) Token: 0x060013DA RID: 5082 RVA: 0x000186CD File Offset: 0x000168CD
		public CertificateTransparencyCompliance CertificateTransparencyCompliance
		{
			get
			{
				return (CertificateTransparencyCompliance)DevToolsDomainEntityBase.StringToEnum(typeof(CertificateTransparencyCompliance), this.certificateTransparencyCompliance);
			}
			set
			{
				this.certificateTransparencyCompliance = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006D8 RID: 1752
		// (get) Token: 0x060013DB RID: 5083 RVA: 0x000186E0 File Offset: 0x000168E0
		// (set) Token: 0x060013DC RID: 5084 RVA: 0x000186E8 File Offset: 0x000168E8
		[DataMember(Name = "certificateTransparencyCompliance", IsRequired = true)]
		internal string certificateTransparencyCompliance { get; set; }
	}
}
