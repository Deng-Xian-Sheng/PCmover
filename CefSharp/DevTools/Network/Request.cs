using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Security;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002B0 RID: 688
	[DataContract]
	public class Request : DevToolsDomainEntityBase
	{
		// Token: 0x170006B3 RID: 1715
		// (get) Token: 0x0600138F RID: 5007 RVA: 0x000183E3 File Offset: 0x000165E3
		// (set) Token: 0x06001390 RID: 5008 RVA: 0x000183EB File Offset: 0x000165EB
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x170006B4 RID: 1716
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x000183F4 File Offset: 0x000165F4
		// (set) Token: 0x06001392 RID: 5010 RVA: 0x000183FC File Offset: 0x000165FC
		[DataMember(Name = "urlFragment", IsRequired = false)]
		public string UrlFragment { get; set; }

		// Token: 0x170006B5 RID: 1717
		// (get) Token: 0x06001393 RID: 5011 RVA: 0x00018405 File Offset: 0x00016605
		// (set) Token: 0x06001394 RID: 5012 RVA: 0x0001840D File Offset: 0x0001660D
		[DataMember(Name = "method", IsRequired = true)]
		public string Method { get; set; }

		// Token: 0x170006B6 RID: 1718
		// (get) Token: 0x06001395 RID: 5013 RVA: 0x00018416 File Offset: 0x00016616
		// (set) Token: 0x06001396 RID: 5014 RVA: 0x0001841E File Offset: 0x0001661E
		[DataMember(Name = "headers", IsRequired = true)]
		public Headers Headers { get; set; }

		// Token: 0x170006B7 RID: 1719
		// (get) Token: 0x06001397 RID: 5015 RVA: 0x00018427 File Offset: 0x00016627
		// (set) Token: 0x06001398 RID: 5016 RVA: 0x0001842F File Offset: 0x0001662F
		[DataMember(Name = "postData", IsRequired = false)]
		public string PostData { get; set; }

		// Token: 0x170006B8 RID: 1720
		// (get) Token: 0x06001399 RID: 5017 RVA: 0x00018438 File Offset: 0x00016638
		// (set) Token: 0x0600139A RID: 5018 RVA: 0x00018440 File Offset: 0x00016640
		[DataMember(Name = "hasPostData", IsRequired = false)]
		public bool? HasPostData { get; set; }

		// Token: 0x170006B9 RID: 1721
		// (get) Token: 0x0600139B RID: 5019 RVA: 0x00018449 File Offset: 0x00016649
		// (set) Token: 0x0600139C RID: 5020 RVA: 0x00018451 File Offset: 0x00016651
		[DataMember(Name = "postDataEntries", IsRequired = false)]
		public IList<PostDataEntry> PostDataEntries { get; set; }

		// Token: 0x170006BA RID: 1722
		// (get) Token: 0x0600139D RID: 5021 RVA: 0x0001845A File Offset: 0x0001665A
		// (set) Token: 0x0600139E RID: 5022 RVA: 0x00018476 File Offset: 0x00016676
		public MixedContentType? MixedContentType
		{
			get
			{
				return (MixedContentType?)DevToolsDomainEntityBase.StringToEnum(typeof(MixedContentType?), this.mixedContentType);
			}
			set
			{
				this.mixedContentType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006BB RID: 1723
		// (get) Token: 0x0600139F RID: 5023 RVA: 0x00018489 File Offset: 0x00016689
		// (set) Token: 0x060013A0 RID: 5024 RVA: 0x00018491 File Offset: 0x00016691
		[DataMember(Name = "mixedContentType", IsRequired = false)]
		internal string mixedContentType { get; set; }

		// Token: 0x170006BC RID: 1724
		// (get) Token: 0x060013A1 RID: 5025 RVA: 0x0001849A File Offset: 0x0001669A
		// (set) Token: 0x060013A2 RID: 5026 RVA: 0x000184B6 File Offset: 0x000166B6
		public ResourcePriority InitialPriority
		{
			get
			{
				return (ResourcePriority)DevToolsDomainEntityBase.StringToEnum(typeof(ResourcePriority), this.initialPriority);
			}
			set
			{
				this.initialPriority = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006BD RID: 1725
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x000184C9 File Offset: 0x000166C9
		// (set) Token: 0x060013A4 RID: 5028 RVA: 0x000184D1 File Offset: 0x000166D1
		[DataMember(Name = "initialPriority", IsRequired = true)]
		internal string initialPriority { get; set; }

		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x060013A5 RID: 5029 RVA: 0x000184DA File Offset: 0x000166DA
		// (set) Token: 0x060013A6 RID: 5030 RVA: 0x000184F6 File Offset: 0x000166F6
		public RequestReferrerPolicy ReferrerPolicy
		{
			get
			{
				return (RequestReferrerPolicy)DevToolsDomainEntityBase.StringToEnum(typeof(RequestReferrerPolicy), this.referrerPolicy);
			}
			set
			{
				this.referrerPolicy = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x060013A7 RID: 5031 RVA: 0x00018509 File Offset: 0x00016709
		// (set) Token: 0x060013A8 RID: 5032 RVA: 0x00018511 File Offset: 0x00016711
		[DataMember(Name = "referrerPolicy", IsRequired = true)]
		internal string referrerPolicy { get; set; }

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x060013A9 RID: 5033 RVA: 0x0001851A File Offset: 0x0001671A
		// (set) Token: 0x060013AA RID: 5034 RVA: 0x00018522 File Offset: 0x00016722
		[DataMember(Name = "isLinkPreload", IsRequired = false)]
		public bool? IsLinkPreload { get; set; }

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x060013AB RID: 5035 RVA: 0x0001852B File Offset: 0x0001672B
		// (set) Token: 0x060013AC RID: 5036 RVA: 0x00018533 File Offset: 0x00016733
		[DataMember(Name = "trustTokenParams", IsRequired = false)]
		public TrustTokenParams TrustTokenParams { get; set; }

		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x060013AD RID: 5037 RVA: 0x0001853C File Offset: 0x0001673C
		// (set) Token: 0x060013AE RID: 5038 RVA: 0x00018544 File Offset: 0x00016744
		[DataMember(Name = "isSameSite", IsRequired = false)]
		public bool? IsSameSite { get; set; }
	}
}
