using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002C2 RID: 706
	[DataContract]
	public class Cookie : DevToolsDomainEntityBase
	{
		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x06001454 RID: 5204 RVA: 0x00018BB2 File Offset: 0x00016DB2
		// (set) Token: 0x06001455 RID: 5205 RVA: 0x00018BBA File Offset: 0x00016DBA
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x06001456 RID: 5206 RVA: 0x00018BC3 File Offset: 0x00016DC3
		// (set) Token: 0x06001457 RID: 5207 RVA: 0x00018BCB File Offset: 0x00016DCB
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06001458 RID: 5208 RVA: 0x00018BD4 File Offset: 0x00016DD4
		// (set) Token: 0x06001459 RID: 5209 RVA: 0x00018BDC File Offset: 0x00016DDC
		[DataMember(Name = "domain", IsRequired = true)]
		public string Domain { get; set; }

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x0600145A RID: 5210 RVA: 0x00018BE5 File Offset: 0x00016DE5
		// (set) Token: 0x0600145B RID: 5211 RVA: 0x00018BED File Offset: 0x00016DED
		[DataMember(Name = "path", IsRequired = true)]
		public string Path { get; set; }

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x0600145C RID: 5212 RVA: 0x00018BF6 File Offset: 0x00016DF6
		// (set) Token: 0x0600145D RID: 5213 RVA: 0x00018BFE File Offset: 0x00016DFE
		[DataMember(Name = "expires", IsRequired = true)]
		public double Expires { get; set; }

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x0600145E RID: 5214 RVA: 0x00018C07 File Offset: 0x00016E07
		// (set) Token: 0x0600145F RID: 5215 RVA: 0x00018C0F File Offset: 0x00016E0F
		[DataMember(Name = "size", IsRequired = true)]
		public int Size { get; set; }

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06001460 RID: 5216 RVA: 0x00018C18 File Offset: 0x00016E18
		// (set) Token: 0x06001461 RID: 5217 RVA: 0x00018C20 File Offset: 0x00016E20
		[DataMember(Name = "httpOnly", IsRequired = true)]
		public bool HttpOnly { get; set; }

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x06001462 RID: 5218 RVA: 0x00018C29 File Offset: 0x00016E29
		// (set) Token: 0x06001463 RID: 5219 RVA: 0x00018C31 File Offset: 0x00016E31
		[DataMember(Name = "secure", IsRequired = true)]
		public bool Secure { get; set; }

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x06001464 RID: 5220 RVA: 0x00018C3A File Offset: 0x00016E3A
		// (set) Token: 0x06001465 RID: 5221 RVA: 0x00018C42 File Offset: 0x00016E42
		[DataMember(Name = "session", IsRequired = true)]
		public bool Session { get; set; }

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x06001466 RID: 5222 RVA: 0x00018C4B File Offset: 0x00016E4B
		// (set) Token: 0x06001467 RID: 5223 RVA: 0x00018C67 File Offset: 0x00016E67
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

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x06001468 RID: 5224 RVA: 0x00018C7A File Offset: 0x00016E7A
		// (set) Token: 0x06001469 RID: 5225 RVA: 0x00018C82 File Offset: 0x00016E82
		[DataMember(Name = "sameSite", IsRequired = false)]
		internal string sameSite { get; set; }

		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x0600146A RID: 5226 RVA: 0x00018C8B File Offset: 0x00016E8B
		// (set) Token: 0x0600146B RID: 5227 RVA: 0x00018CA7 File Offset: 0x00016EA7
		public CookiePriority Priority
		{
			get
			{
				return (CookiePriority)DevToolsDomainEntityBase.StringToEnum(typeof(CookiePriority), this.priority);
			}
			set
			{
				this.priority = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x0600146C RID: 5228 RVA: 0x00018CBA File Offset: 0x00016EBA
		// (set) Token: 0x0600146D RID: 5229 RVA: 0x00018CC2 File Offset: 0x00016EC2
		[DataMember(Name = "priority", IsRequired = true)]
		internal string priority { get; set; }

		// Token: 0x1700071D RID: 1821
		// (get) Token: 0x0600146E RID: 5230 RVA: 0x00018CCB File Offset: 0x00016ECB
		// (set) Token: 0x0600146F RID: 5231 RVA: 0x00018CD3 File Offset: 0x00016ED3
		[DataMember(Name = "sameParty", IsRequired = true)]
		public bool SameParty { get; set; }

		// Token: 0x1700071E RID: 1822
		// (get) Token: 0x06001470 RID: 5232 RVA: 0x00018CDC File Offset: 0x00016EDC
		// (set) Token: 0x06001471 RID: 5233 RVA: 0x00018CF8 File Offset: 0x00016EF8
		public CookieSourceScheme SourceScheme
		{
			get
			{
				return (CookieSourceScheme)DevToolsDomainEntityBase.StringToEnum(typeof(CookieSourceScheme), this.sourceScheme);
			}
			set
			{
				this.sourceScheme = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700071F RID: 1823
		// (get) Token: 0x06001472 RID: 5234 RVA: 0x00018D0B File Offset: 0x00016F0B
		// (set) Token: 0x06001473 RID: 5235 RVA: 0x00018D13 File Offset: 0x00016F13
		[DataMember(Name = "sourceScheme", IsRequired = true)]
		internal string sourceScheme { get; set; }

		// Token: 0x17000720 RID: 1824
		// (get) Token: 0x06001474 RID: 5236 RVA: 0x00018D1C File Offset: 0x00016F1C
		// (set) Token: 0x06001475 RID: 5237 RVA: 0x00018D24 File Offset: 0x00016F24
		[DataMember(Name = "sourcePort", IsRequired = true)]
		public int SourcePort { get; set; }

		// Token: 0x17000721 RID: 1825
		// (get) Token: 0x06001476 RID: 5238 RVA: 0x00018D2D File Offset: 0x00016F2D
		// (set) Token: 0x06001477 RID: 5239 RVA: 0x00018D35 File Offset: 0x00016F35
		[DataMember(Name = "partitionKey", IsRequired = false)]
		public string PartitionKey { get; set; }

		// Token: 0x17000722 RID: 1826
		// (get) Token: 0x06001478 RID: 5240 RVA: 0x00018D3E File Offset: 0x00016F3E
		// (set) Token: 0x06001479 RID: 5241 RVA: 0x00018D46 File Offset: 0x00016F46
		[DataMember(Name = "partitionKeyOpaque", IsRequired = false)]
		public bool? PartitionKeyOpaque { get; set; }
	}
}
