using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x0200021B RID: 539
	[DataContract]
	public class SecurityStateExplanation : DevToolsDomainEntityBase
	{
		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x0001489E File Offset: 0x00012A9E
		// (set) Token: 0x06000F8B RID: 3979 RVA: 0x000148BA File Offset: 0x00012ABA
		public SecurityState SecurityState
		{
			get
			{
				return (SecurityState)DevToolsDomainEntityBase.StringToEnum(typeof(SecurityState), this.securityState);
			}
			set
			{
				this.securityState = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06000F8C RID: 3980 RVA: 0x000148CD File Offset: 0x00012ACD
		// (set) Token: 0x06000F8D RID: 3981 RVA: 0x000148D5 File Offset: 0x00012AD5
		[DataMember(Name = "securityState", IsRequired = true)]
		internal string securityState { get; set; }

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06000F8E RID: 3982 RVA: 0x000148DE File Offset: 0x00012ADE
		// (set) Token: 0x06000F8F RID: 3983 RVA: 0x000148E6 File Offset: 0x00012AE6
		[DataMember(Name = "title", IsRequired = true)]
		public string Title { get; set; }

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06000F90 RID: 3984 RVA: 0x000148EF File Offset: 0x00012AEF
		// (set) Token: 0x06000F91 RID: 3985 RVA: 0x000148F7 File Offset: 0x00012AF7
		[DataMember(Name = "summary", IsRequired = true)]
		public string Summary { get; set; }

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06000F92 RID: 3986 RVA: 0x00014900 File Offset: 0x00012B00
		// (set) Token: 0x06000F93 RID: 3987 RVA: 0x00014908 File Offset: 0x00012B08
		[DataMember(Name = "description", IsRequired = true)]
		public string Description { get; set; }

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06000F94 RID: 3988 RVA: 0x00014911 File Offset: 0x00012B11
		// (set) Token: 0x06000F95 RID: 3989 RVA: 0x0001492D File Offset: 0x00012B2D
		public MixedContentType MixedContentType
		{
			get
			{
				return (MixedContentType)DevToolsDomainEntityBase.StringToEnum(typeof(MixedContentType), this.mixedContentType);
			}
			set
			{
				this.mixedContentType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06000F96 RID: 3990 RVA: 0x00014940 File Offset: 0x00012B40
		// (set) Token: 0x06000F97 RID: 3991 RVA: 0x00014948 File Offset: 0x00012B48
		[DataMember(Name = "mixedContentType", IsRequired = true)]
		internal string mixedContentType { get; set; }

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06000F98 RID: 3992 RVA: 0x00014951 File Offset: 0x00012B51
		// (set) Token: 0x06000F99 RID: 3993 RVA: 0x00014959 File Offset: 0x00012B59
		[DataMember(Name = "certificate", IsRequired = true)]
		public string[] Certificate { get; set; }

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06000F9A RID: 3994 RVA: 0x00014962 File Offset: 0x00012B62
		// (set) Token: 0x06000F9B RID: 3995 RVA: 0x0001496A File Offset: 0x00012B6A
		[DataMember(Name = "recommendations", IsRequired = false)]
		public string[] Recommendations { get; set; }
	}
}
