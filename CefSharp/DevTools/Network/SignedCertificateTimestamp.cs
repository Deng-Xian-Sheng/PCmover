using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B1 RID: 689
	[DataContract]
	public class SignedCertificateTimestamp : DevToolsDomainEntityBase
	{
		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x060013B0 RID: 5040 RVA: 0x00018555 File Offset: 0x00016755
		// (set) Token: 0x060013B1 RID: 5041 RVA: 0x0001855D File Offset: 0x0001675D
		[DataMember(Name = "status", IsRequired = true)]
		public string Status { get; set; }

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x060013B2 RID: 5042 RVA: 0x00018566 File Offset: 0x00016766
		// (set) Token: 0x060013B3 RID: 5043 RVA: 0x0001856E File Offset: 0x0001676E
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; set; }

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x060013B4 RID: 5044 RVA: 0x00018577 File Offset: 0x00016777
		// (set) Token: 0x060013B5 RID: 5045 RVA: 0x0001857F File Offset: 0x0001677F
		[DataMember(Name = "logDescription", IsRequired = true)]
		public string LogDescription { get; set; }

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x060013B6 RID: 5046 RVA: 0x00018588 File Offset: 0x00016788
		// (set) Token: 0x060013B7 RID: 5047 RVA: 0x00018590 File Offset: 0x00016790
		[DataMember(Name = "logId", IsRequired = true)]
		public string LogId { get; set; }

		// Token: 0x170006C7 RID: 1735
		// (get) Token: 0x060013B8 RID: 5048 RVA: 0x00018599 File Offset: 0x00016799
		// (set) Token: 0x060013B9 RID: 5049 RVA: 0x000185A1 File Offset: 0x000167A1
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; set; }

		// Token: 0x170006C8 RID: 1736
		// (get) Token: 0x060013BA RID: 5050 RVA: 0x000185AA File Offset: 0x000167AA
		// (set) Token: 0x060013BB RID: 5051 RVA: 0x000185B2 File Offset: 0x000167B2
		[DataMember(Name = "hashAlgorithm", IsRequired = true)]
		public string HashAlgorithm { get; set; }

		// Token: 0x170006C9 RID: 1737
		// (get) Token: 0x060013BC RID: 5052 RVA: 0x000185BB File Offset: 0x000167BB
		// (set) Token: 0x060013BD RID: 5053 RVA: 0x000185C3 File Offset: 0x000167C3
		[DataMember(Name = "signatureAlgorithm", IsRequired = true)]
		public string SignatureAlgorithm { get; set; }

		// Token: 0x170006CA RID: 1738
		// (get) Token: 0x060013BE RID: 5054 RVA: 0x000185CC File Offset: 0x000167CC
		// (set) Token: 0x060013BF RID: 5055 RVA: 0x000185D4 File Offset: 0x000167D4
		[DataMember(Name = "signatureData", IsRequired = true)]
		public string SignatureData { get; set; }
	}
}
