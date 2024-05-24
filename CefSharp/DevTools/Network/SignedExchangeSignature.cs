using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002CE RID: 718
	[DataContract]
	public class SignedExchangeSignature : DevToolsDomainEntityBase
	{
		// Token: 0x17000749 RID: 1865
		// (get) Token: 0x060014CD RID: 5325 RVA: 0x00019111 File Offset: 0x00017311
		// (set) Token: 0x060014CE RID: 5326 RVA: 0x00019119 File Offset: 0x00017319
		[DataMember(Name = "label", IsRequired = true)]
		public string Label { get; set; }

		// Token: 0x1700074A RID: 1866
		// (get) Token: 0x060014CF RID: 5327 RVA: 0x00019122 File Offset: 0x00017322
		// (set) Token: 0x060014D0 RID: 5328 RVA: 0x0001912A File Offset: 0x0001732A
		[DataMember(Name = "signature", IsRequired = true)]
		public string Signature { get; set; }

		// Token: 0x1700074B RID: 1867
		// (get) Token: 0x060014D1 RID: 5329 RVA: 0x00019133 File Offset: 0x00017333
		// (set) Token: 0x060014D2 RID: 5330 RVA: 0x0001913B File Offset: 0x0001733B
		[DataMember(Name = "integrity", IsRequired = true)]
		public string Integrity { get; set; }

		// Token: 0x1700074C RID: 1868
		// (get) Token: 0x060014D3 RID: 5331 RVA: 0x00019144 File Offset: 0x00017344
		// (set) Token: 0x060014D4 RID: 5332 RVA: 0x0001914C File Offset: 0x0001734C
		[DataMember(Name = "certUrl", IsRequired = false)]
		public string CertUrl { get; set; }

		// Token: 0x1700074D RID: 1869
		// (get) Token: 0x060014D5 RID: 5333 RVA: 0x00019155 File Offset: 0x00017355
		// (set) Token: 0x060014D6 RID: 5334 RVA: 0x0001915D File Offset: 0x0001735D
		[DataMember(Name = "certSha256", IsRequired = false)]
		public string CertSha256 { get; set; }

		// Token: 0x1700074E RID: 1870
		// (get) Token: 0x060014D7 RID: 5335 RVA: 0x00019166 File Offset: 0x00017366
		// (set) Token: 0x060014D8 RID: 5336 RVA: 0x0001916E File Offset: 0x0001736E
		[DataMember(Name = "validityUrl", IsRequired = true)]
		public string ValidityUrl { get; set; }

		// Token: 0x1700074F RID: 1871
		// (get) Token: 0x060014D9 RID: 5337 RVA: 0x00019177 File Offset: 0x00017377
		// (set) Token: 0x060014DA RID: 5338 RVA: 0x0001917F File Offset: 0x0001737F
		[DataMember(Name = "date", IsRequired = true)]
		public int Date { get; set; }

		// Token: 0x17000750 RID: 1872
		// (get) Token: 0x060014DB RID: 5339 RVA: 0x00019188 File Offset: 0x00017388
		// (set) Token: 0x060014DC RID: 5340 RVA: 0x00019190 File Offset: 0x00017390
		[DataMember(Name = "expires", IsRequired = true)]
		public int Expires { get; set; }

		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x060014DD RID: 5341 RVA: 0x00019199 File Offset: 0x00017399
		// (set) Token: 0x060014DE RID: 5342 RVA: 0x000191A1 File Offset: 0x000173A1
		[DataMember(Name = "certificates", IsRequired = false)]
		public string[] Certificates { get; set; }
	}
}
