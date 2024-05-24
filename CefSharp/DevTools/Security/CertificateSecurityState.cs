using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x02000217 RID: 535
	[DataContract]
	public class CertificateSecurityState : DevToolsDomainEntityBase
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06000F53 RID: 3923 RVA: 0x00014690 File Offset: 0x00012890
		// (set) Token: 0x06000F54 RID: 3924 RVA: 0x00014698 File Offset: 0x00012898
		[DataMember(Name = "protocol", IsRequired = true)]
		public string Protocol { get; set; }

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06000F55 RID: 3925 RVA: 0x000146A1 File Offset: 0x000128A1
		// (set) Token: 0x06000F56 RID: 3926 RVA: 0x000146A9 File Offset: 0x000128A9
		[DataMember(Name = "keyExchange", IsRequired = true)]
		public string KeyExchange { get; set; }

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06000F57 RID: 3927 RVA: 0x000146B2 File Offset: 0x000128B2
		// (set) Token: 0x06000F58 RID: 3928 RVA: 0x000146BA File Offset: 0x000128BA
		[DataMember(Name = "keyExchangeGroup", IsRequired = false)]
		public string KeyExchangeGroup { get; set; }

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x000146C3 File Offset: 0x000128C3
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x000146CB File Offset: 0x000128CB
		[DataMember(Name = "cipher", IsRequired = true)]
		public string Cipher { get; set; }

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x000146D4 File Offset: 0x000128D4
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x000146DC File Offset: 0x000128DC
		[DataMember(Name = "mac", IsRequired = false)]
		public string Mac { get; set; }

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x000146E5 File Offset: 0x000128E5
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x000146ED File Offset: 0x000128ED
		[DataMember(Name = "certificate", IsRequired = true)]
		public string[] Certificate { get; set; }

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x000146F6 File Offset: 0x000128F6
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x000146FE File Offset: 0x000128FE
		[DataMember(Name = "subjectName", IsRequired = true)]
		public string SubjectName { get; set; }

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x00014707 File Offset: 0x00012907
		// (set) Token: 0x06000F62 RID: 3938 RVA: 0x0001470F File Offset: 0x0001290F
		[DataMember(Name = "issuer", IsRequired = true)]
		public string Issuer { get; set; }

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x00014718 File Offset: 0x00012918
		// (set) Token: 0x06000F64 RID: 3940 RVA: 0x00014720 File Offset: 0x00012920
		[DataMember(Name = "validFrom", IsRequired = true)]
		public double ValidFrom { get; set; }

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06000F65 RID: 3941 RVA: 0x00014729 File Offset: 0x00012929
		// (set) Token: 0x06000F66 RID: 3942 RVA: 0x00014731 File Offset: 0x00012931
		[DataMember(Name = "validTo", IsRequired = true)]
		public double ValidTo { get; set; }

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06000F67 RID: 3943 RVA: 0x0001473A File Offset: 0x0001293A
		// (set) Token: 0x06000F68 RID: 3944 RVA: 0x00014742 File Offset: 0x00012942
		[DataMember(Name = "certificateNetworkError", IsRequired = false)]
		public string CertificateNetworkError { get; set; }

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06000F69 RID: 3945 RVA: 0x0001474B File Offset: 0x0001294B
		// (set) Token: 0x06000F6A RID: 3946 RVA: 0x00014753 File Offset: 0x00012953
		[DataMember(Name = "certificateHasWeakSignature", IsRequired = true)]
		public bool CertificateHasWeakSignature { get; set; }

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06000F6B RID: 3947 RVA: 0x0001475C File Offset: 0x0001295C
		// (set) Token: 0x06000F6C RID: 3948 RVA: 0x00014764 File Offset: 0x00012964
		[DataMember(Name = "certificateHasSha1Signature", IsRequired = true)]
		public bool CertificateHasSha1Signature { get; set; }

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x06000F6D RID: 3949 RVA: 0x0001476D File Offset: 0x0001296D
		// (set) Token: 0x06000F6E RID: 3950 RVA: 0x00014775 File Offset: 0x00012975
		[DataMember(Name = "modernSSL", IsRequired = true)]
		public bool ModernSSL { get; set; }

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x06000F6F RID: 3951 RVA: 0x0001477E File Offset: 0x0001297E
		// (set) Token: 0x06000F70 RID: 3952 RVA: 0x00014786 File Offset: 0x00012986
		[DataMember(Name = "obsoleteSslProtocol", IsRequired = true)]
		public bool ObsoleteSslProtocol { get; set; }

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06000F71 RID: 3953 RVA: 0x0001478F File Offset: 0x0001298F
		// (set) Token: 0x06000F72 RID: 3954 RVA: 0x00014797 File Offset: 0x00012997
		[DataMember(Name = "obsoleteSslKeyExchange", IsRequired = true)]
		public bool ObsoleteSslKeyExchange { get; set; }

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x000147A0 File Offset: 0x000129A0
		// (set) Token: 0x06000F74 RID: 3956 RVA: 0x000147A8 File Offset: 0x000129A8
		[DataMember(Name = "obsoleteSslCipher", IsRequired = true)]
		public bool ObsoleteSslCipher { get; set; }

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06000F75 RID: 3957 RVA: 0x000147B1 File Offset: 0x000129B1
		// (set) Token: 0x06000F76 RID: 3958 RVA: 0x000147B9 File Offset: 0x000129B9
		[DataMember(Name = "obsoleteSslSignature", IsRequired = true)]
		public bool ObsoleteSslSignature { get; set; }
	}
}
