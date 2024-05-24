using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200040F RID: 1039
	[DataContract]
	public class SameSiteCookieIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000AF5 RID: 2805
		// (get) Token: 0x06001E32 RID: 7730 RVA: 0x0002299D File Offset: 0x00020B9D
		// (set) Token: 0x06001E33 RID: 7731 RVA: 0x000229A5 File Offset: 0x00020BA5
		[DataMember(Name = "cookie", IsRequired = false)]
		public AffectedCookie Cookie { get; set; }

		// Token: 0x17000AF6 RID: 2806
		// (get) Token: 0x06001E34 RID: 7732 RVA: 0x000229AE File Offset: 0x00020BAE
		// (set) Token: 0x06001E35 RID: 7733 RVA: 0x000229B6 File Offset: 0x00020BB6
		[DataMember(Name = "rawCookieLine", IsRequired = false)]
		public string RawCookieLine { get; set; }

		// Token: 0x17000AF7 RID: 2807
		// (get) Token: 0x06001E36 RID: 7734 RVA: 0x000229BF File Offset: 0x00020BBF
		// (set) Token: 0x06001E37 RID: 7735 RVA: 0x000229DB File Offset: 0x00020BDB
		public SameSiteCookieWarningReason[] CookieWarningReasons
		{
			get
			{
				return (SameSiteCookieWarningReason[])DevToolsDomainEntityBase.StringToEnum(typeof(SameSiteCookieWarningReason[]), this.cookieWarningReasons);
			}
			set
			{
				this.cookieWarningReasons = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000AF8 RID: 2808
		// (get) Token: 0x06001E38 RID: 7736 RVA: 0x000229E9 File Offset: 0x00020BE9
		// (set) Token: 0x06001E39 RID: 7737 RVA: 0x000229F1 File Offset: 0x00020BF1
		[DataMember(Name = "cookieWarningReasons", IsRequired = true)]
		internal string cookieWarningReasons { get; set; }

		// Token: 0x17000AF9 RID: 2809
		// (get) Token: 0x06001E3A RID: 7738 RVA: 0x000229FA File Offset: 0x00020BFA
		// (set) Token: 0x06001E3B RID: 7739 RVA: 0x00022A16 File Offset: 0x00020C16
		public SameSiteCookieExclusionReason[] CookieExclusionReasons
		{
			get
			{
				return (SameSiteCookieExclusionReason[])DevToolsDomainEntityBase.StringToEnum(typeof(SameSiteCookieExclusionReason[]), this.cookieExclusionReasons);
			}
			set
			{
				this.cookieExclusionReasons = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000AFA RID: 2810
		// (get) Token: 0x06001E3C RID: 7740 RVA: 0x00022A24 File Offset: 0x00020C24
		// (set) Token: 0x06001E3D RID: 7741 RVA: 0x00022A2C File Offset: 0x00020C2C
		[DataMember(Name = "cookieExclusionReasons", IsRequired = true)]
		internal string cookieExclusionReasons { get; set; }

		// Token: 0x17000AFB RID: 2811
		// (get) Token: 0x06001E3E RID: 7742 RVA: 0x00022A35 File Offset: 0x00020C35
		// (set) Token: 0x06001E3F RID: 7743 RVA: 0x00022A51 File Offset: 0x00020C51
		public SameSiteCookieOperation Operation
		{
			get
			{
				return (SameSiteCookieOperation)DevToolsDomainEntityBase.StringToEnum(typeof(SameSiteCookieOperation), this.operation);
			}
			set
			{
				this.operation = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000AFC RID: 2812
		// (get) Token: 0x06001E40 RID: 7744 RVA: 0x00022A64 File Offset: 0x00020C64
		// (set) Token: 0x06001E41 RID: 7745 RVA: 0x00022A6C File Offset: 0x00020C6C
		[DataMember(Name = "operation", IsRequired = true)]
		internal string operation { get; set; }

		// Token: 0x17000AFD RID: 2813
		// (get) Token: 0x06001E42 RID: 7746 RVA: 0x00022A75 File Offset: 0x00020C75
		// (set) Token: 0x06001E43 RID: 7747 RVA: 0x00022A7D File Offset: 0x00020C7D
		[DataMember(Name = "siteForCookies", IsRequired = false)]
		public string SiteForCookies { get; set; }

		// Token: 0x17000AFE RID: 2814
		// (get) Token: 0x06001E44 RID: 7748 RVA: 0x00022A86 File Offset: 0x00020C86
		// (set) Token: 0x06001E45 RID: 7749 RVA: 0x00022A8E File Offset: 0x00020C8E
		[DataMember(Name = "cookieUrl", IsRequired = false)]
		public string CookieUrl { get; set; }

		// Token: 0x17000AFF RID: 2815
		// (get) Token: 0x06001E46 RID: 7750 RVA: 0x00022A97 File Offset: 0x00020C97
		// (set) Token: 0x06001E47 RID: 7751 RVA: 0x00022A9F File Offset: 0x00020C9F
		[DataMember(Name = "request", IsRequired = false)]
		public AffectedRequest Request { get; set; }
	}
}
