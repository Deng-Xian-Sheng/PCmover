using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x0200021C RID: 540
	[DataContract]
	public class InsecureContentStatus : DevToolsDomainEntityBase
	{
		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06000F9D RID: 3997 RVA: 0x0001497B File Offset: 0x00012B7B
		// (set) Token: 0x06000F9E RID: 3998 RVA: 0x00014983 File Offset: 0x00012B83
		[DataMember(Name = "ranMixedContent", IsRequired = true)]
		public bool RanMixedContent { get; set; }

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x0001498C File Offset: 0x00012B8C
		// (set) Token: 0x06000FA0 RID: 4000 RVA: 0x00014994 File Offset: 0x00012B94
		[DataMember(Name = "displayedMixedContent", IsRequired = true)]
		public bool DisplayedMixedContent { get; set; }

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x0001499D File Offset: 0x00012B9D
		// (set) Token: 0x06000FA2 RID: 4002 RVA: 0x000149A5 File Offset: 0x00012BA5
		[DataMember(Name = "containedMixedForm", IsRequired = true)]
		public bool ContainedMixedForm { get; set; }

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x000149AE File Offset: 0x00012BAE
		// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x000149B6 File Offset: 0x00012BB6
		[DataMember(Name = "ranContentWithCertErrors", IsRequired = true)]
		public bool RanContentWithCertErrors { get; set; }

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06000FA5 RID: 4005 RVA: 0x000149BF File Offset: 0x00012BBF
		// (set) Token: 0x06000FA6 RID: 4006 RVA: 0x000149C7 File Offset: 0x00012BC7
		[DataMember(Name = "displayedContentWithCertErrors", IsRequired = true)]
		public bool DisplayedContentWithCertErrors { get; set; }

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06000FA7 RID: 4007 RVA: 0x000149D0 File Offset: 0x00012BD0
		// (set) Token: 0x06000FA8 RID: 4008 RVA: 0x000149EC File Offset: 0x00012BEC
		public SecurityState RanInsecureContentStyle
		{
			get
			{
				return (SecurityState)DevToolsDomainEntityBase.StringToEnum(typeof(SecurityState), this.ranInsecureContentStyle);
			}
			set
			{
				this.ranInsecureContentStyle = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06000FA9 RID: 4009 RVA: 0x000149FF File Offset: 0x00012BFF
		// (set) Token: 0x06000FAA RID: 4010 RVA: 0x00014A07 File Offset: 0x00012C07
		[DataMember(Name = "ranInsecureContentStyle", IsRequired = true)]
		internal string ranInsecureContentStyle { get; set; }

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06000FAB RID: 4011 RVA: 0x00014A10 File Offset: 0x00012C10
		// (set) Token: 0x06000FAC RID: 4012 RVA: 0x00014A2C File Offset: 0x00012C2C
		public SecurityState DisplayedInsecureContentStyle
		{
			get
			{
				return (SecurityState)DevToolsDomainEntityBase.StringToEnum(typeof(SecurityState), this.displayedInsecureContentStyle);
			}
			set
			{
				this.displayedInsecureContentStyle = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06000FAD RID: 4013 RVA: 0x00014A3F File Offset: 0x00012C3F
		// (set) Token: 0x06000FAE RID: 4014 RVA: 0x00014A47 File Offset: 0x00012C47
		[DataMember(Name = "displayedInsecureContentStyle", IsRequired = true)]
		internal string displayedInsecureContentStyle { get; set; }
	}
}
