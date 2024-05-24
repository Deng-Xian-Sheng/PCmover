using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C7 RID: 711
	[DataContract]
	public class CookieParam : DevToolsDomainEntityBase
	{
		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x0600148B RID: 5259 RVA: 0x00018E10 File Offset: 0x00017010
		// (set) Token: 0x0600148C RID: 5260 RVA: 0x00018E18 File Offset: 0x00017018
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x0600148D RID: 5261 RVA: 0x00018E21 File Offset: 0x00017021
		// (set) Token: 0x0600148E RID: 5262 RVA: 0x00018E29 File Offset: 0x00017029
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x0600148F RID: 5263 RVA: 0x00018E32 File Offset: 0x00017032
		// (set) Token: 0x06001490 RID: 5264 RVA: 0x00018E3A File Offset: 0x0001703A
		[DataMember(Name = "url", IsRequired = false)]
		public string Url { get; set; }

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06001491 RID: 5265 RVA: 0x00018E43 File Offset: 0x00017043
		// (set) Token: 0x06001492 RID: 5266 RVA: 0x00018E4B File Offset: 0x0001704B
		[DataMember(Name = "domain", IsRequired = false)]
		public string Domain { get; set; }

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06001493 RID: 5267 RVA: 0x00018E54 File Offset: 0x00017054
		// (set) Token: 0x06001494 RID: 5268 RVA: 0x00018E5C File Offset: 0x0001705C
		[DataMember(Name = "path", IsRequired = false)]
		public string Path { get; set; }

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06001495 RID: 5269 RVA: 0x00018E65 File Offset: 0x00017065
		// (set) Token: 0x06001496 RID: 5270 RVA: 0x00018E6D File Offset: 0x0001706D
		[DataMember(Name = "secure", IsRequired = false)]
		public bool? Secure { get; set; }

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06001497 RID: 5271 RVA: 0x00018E76 File Offset: 0x00017076
		// (set) Token: 0x06001498 RID: 5272 RVA: 0x00018E7E File Offset: 0x0001707E
		[DataMember(Name = "httpOnly", IsRequired = false)]
		public bool? HttpOnly { get; set; }

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06001499 RID: 5273 RVA: 0x00018E87 File Offset: 0x00017087
		// (set) Token: 0x0600149A RID: 5274 RVA: 0x00018EA3 File Offset: 0x000170A3
		public CookieSameSite? SameSite
		{
			get
			{
				return (CookieSameSite?)DevToolsDomainEntityBase.StringToEnum(typeof(CookieSameSite?), this.sameSite);
			}
			set
			{
				this.sameSite = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x0600149B RID: 5275 RVA: 0x00018EB6 File Offset: 0x000170B6
		// (set) Token: 0x0600149C RID: 5276 RVA: 0x00018EBE File Offset: 0x000170BE
		[DataMember(Name = "sameSite", IsRequired = false)]
		internal string sameSite { get; set; }

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x0600149D RID: 5277 RVA: 0x00018EC7 File Offset: 0x000170C7
		// (set) Token: 0x0600149E RID: 5278 RVA: 0x00018ECF File Offset: 0x000170CF
		[DataMember(Name = "expires", IsRequired = false)]
		public double? Expires { get; set; }

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x0600149F RID: 5279 RVA: 0x00018ED8 File Offset: 0x000170D8
		// (set) Token: 0x060014A0 RID: 5280 RVA: 0x00018EF4 File Offset: 0x000170F4
		public CookiePriority? Priority
		{
			get
			{
				return (CookiePriority?)DevToolsDomainEntityBase.StringToEnum(typeof(CookiePriority?), this.priority);
			}
			set
			{
				this.priority = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x060014A1 RID: 5281 RVA: 0x00018F07 File Offset: 0x00017107
		// (set) Token: 0x060014A2 RID: 5282 RVA: 0x00018F0F File Offset: 0x0001710F
		[DataMember(Name = "priority", IsRequired = false)]
		internal string priority { get; set; }

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x060014A3 RID: 5283 RVA: 0x00018F18 File Offset: 0x00017118
		// (set) Token: 0x060014A4 RID: 5284 RVA: 0x00018F20 File Offset: 0x00017120
		[DataMember(Name = "sameParty", IsRequired = false)]
		public bool? SameParty { get; set; }

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x060014A5 RID: 5285 RVA: 0x00018F29 File Offset: 0x00017129
		// (set) Token: 0x060014A6 RID: 5286 RVA: 0x00018F45 File Offset: 0x00017145
		public CookieSourceScheme? SourceScheme
		{
			get
			{
				return (CookieSourceScheme?)DevToolsDomainEntityBase.StringToEnum(typeof(CookieSourceScheme?), this.sourceScheme);
			}
			set
			{
				this.sourceScheme = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x060014A7 RID: 5287 RVA: 0x00018F58 File Offset: 0x00017158
		// (set) Token: 0x060014A8 RID: 5288 RVA: 0x00018F60 File Offset: 0x00017160
		[DataMember(Name = "sourceScheme", IsRequired = false)]
		internal string sourceScheme { get; set; }

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x060014A9 RID: 5289 RVA: 0x00018F69 File Offset: 0x00017169
		// (set) Token: 0x060014AA RID: 5290 RVA: 0x00018F71 File Offset: 0x00017171
		[DataMember(Name = "sourcePort", IsRequired = false)]
		public int? SourcePort { get; set; }

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x060014AB RID: 5291 RVA: 0x00018F7A File Offset: 0x0001717A
		// (set) Token: 0x060014AC RID: 5292 RVA: 0x00018F82 File Offset: 0x00017182
		[DataMember(Name = "partitionKey", IsRequired = false)]
		public string PartitionKey { get; set; }
	}
}
