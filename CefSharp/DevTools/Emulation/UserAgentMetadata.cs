using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000356 RID: 854
	[DataContract]
	public class UserAgentMetadata : DevToolsDomainEntityBase
	{
		// Token: 0x170008C2 RID: 2242
		// (get) Token: 0x060018A5 RID: 6309 RVA: 0x0001D1E7 File Offset: 0x0001B3E7
		// (set) Token: 0x060018A6 RID: 6310 RVA: 0x0001D1EF File Offset: 0x0001B3EF
		[DataMember(Name = "brands", IsRequired = false)]
		public IList<UserAgentBrandVersion> Brands { get; set; }

		// Token: 0x170008C3 RID: 2243
		// (get) Token: 0x060018A7 RID: 6311 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
		// (set) Token: 0x060018A8 RID: 6312 RVA: 0x0001D200 File Offset: 0x0001B400
		[DataMember(Name = "fullVersionList", IsRequired = false)]
		public IList<UserAgentBrandVersion> FullVersionList { get; set; }

		// Token: 0x170008C4 RID: 2244
		// (get) Token: 0x060018A9 RID: 6313 RVA: 0x0001D209 File Offset: 0x0001B409
		// (set) Token: 0x060018AA RID: 6314 RVA: 0x0001D211 File Offset: 0x0001B411
		[DataMember(Name = "fullVersion", IsRequired = false)]
		public string FullVersion { get; set; }

		// Token: 0x170008C5 RID: 2245
		// (get) Token: 0x060018AB RID: 6315 RVA: 0x0001D21A File Offset: 0x0001B41A
		// (set) Token: 0x060018AC RID: 6316 RVA: 0x0001D222 File Offset: 0x0001B422
		[DataMember(Name = "platform", IsRequired = true)]
		public string Platform { get; set; }

		// Token: 0x170008C6 RID: 2246
		// (get) Token: 0x060018AD RID: 6317 RVA: 0x0001D22B File Offset: 0x0001B42B
		// (set) Token: 0x060018AE RID: 6318 RVA: 0x0001D233 File Offset: 0x0001B433
		[DataMember(Name = "platformVersion", IsRequired = true)]
		public string PlatformVersion { get; set; }

		// Token: 0x170008C7 RID: 2247
		// (get) Token: 0x060018AF RID: 6319 RVA: 0x0001D23C File Offset: 0x0001B43C
		// (set) Token: 0x060018B0 RID: 6320 RVA: 0x0001D244 File Offset: 0x0001B444
		[DataMember(Name = "architecture", IsRequired = true)]
		public string Architecture { get; set; }

		// Token: 0x170008C8 RID: 2248
		// (get) Token: 0x060018B1 RID: 6321 RVA: 0x0001D24D File Offset: 0x0001B44D
		// (set) Token: 0x060018B2 RID: 6322 RVA: 0x0001D255 File Offset: 0x0001B455
		[DataMember(Name = "model", IsRequired = true)]
		public string Model { get; set; }

		// Token: 0x170008C9 RID: 2249
		// (get) Token: 0x060018B3 RID: 6323 RVA: 0x0001D25E File Offset: 0x0001B45E
		// (set) Token: 0x060018B4 RID: 6324 RVA: 0x0001D266 File Offset: 0x0001B466
		[DataMember(Name = "mobile", IsRequired = true)]
		public bool Mobile { get; set; }
	}
}
