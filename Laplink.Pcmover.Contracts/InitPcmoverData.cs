using System;
using System.Collections;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000053 RID: 83
	public class InitPcmoverData
	{
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000033B0 File Offset: 0x000015B0
		// (set) Token: 0x0600023D RID: 573 RVA: 0x000033B8 File Offset: 0x000015B8
		public PcmoverEdition Edition { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600023E RID: 574 RVA: 0x000033C1 File Offset: 0x000015C1
		// (set) Token: 0x0600023F RID: 575 RVA: 0x000033C9 File Offset: 0x000015C9
		public string Oem { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000240 RID: 576 RVA: 0x000033D2 File Offset: 0x000015D2
		// (set) Token: 0x06000241 RID: 577 RVA: 0x000033DA File Offset: 0x000015DA
		public string PolicyFile { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000242 RID: 578 RVA: 0x000033E3 File Offset: 0x000015E3
		// (set) Token: 0x06000243 RID: 579 RVA: 0x000033EB File Offset: 0x000015EB
		public string PolicyId { get; set; }

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000244 RID: 580 RVA: 0x000033F4 File Offset: 0x000015F4
		// (set) Token: 0x06000245 RID: 581 RVA: 0x000033FC File Offset: 0x000015FC
		public bool Deferred { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000246 RID: 582 RVA: 0x00003405 File Offset: 0x00001605
		// (set) Token: 0x06000247 RID: 583 RVA: 0x0000340D File Offset: 0x0000160D
		public bool CreateRulesOnly { get; set; }

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000248 RID: 584 RVA: 0x00003416 File Offset: 0x00001616
		// (set) Token: 0x06000249 RID: 585 RVA: 0x0000341E File Offset: 0x0000161E
		public IDictionary ControllerEnvironment { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600024A RID: 586 RVA: 0x00003427 File Offset: 0x00001627
		// (set) Token: 0x0600024B RID: 587 RVA: 0x0000342F File Offset: 0x0000162F
		public string Language { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600024C RID: 588 RVA: 0x00003438 File Offset: 0x00001638
		// (set) Token: 0x0600024D RID: 589 RVA: 0x00003440 File Offset: 0x00001640
		public string Country { get; set; }

		// Token: 0x040001EA RID: 490
		public const string StreamPolicyFile = "*SPF*";
	}
}
