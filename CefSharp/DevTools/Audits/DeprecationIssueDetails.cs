using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000427 RID: 1063
	[DataContract]
	public class DeprecationIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B47 RID: 2887
		// (get) Token: 0x06001EE4 RID: 7908 RVA: 0x00023119 File Offset: 0x00021319
		// (set) Token: 0x06001EE5 RID: 7909 RVA: 0x00023121 File Offset: 0x00021321
		[DataMember(Name = "affectedFrame", IsRequired = false)]
		public AffectedFrame AffectedFrame { get; set; }

		// Token: 0x17000B48 RID: 2888
		// (get) Token: 0x06001EE6 RID: 7910 RVA: 0x0002312A File Offset: 0x0002132A
		// (set) Token: 0x06001EE7 RID: 7911 RVA: 0x00023132 File Offset: 0x00021332
		[DataMember(Name = "sourceCodeLocation", IsRequired = true)]
		public SourceCodeLocation SourceCodeLocation { get; set; }

		// Token: 0x17000B49 RID: 2889
		// (get) Token: 0x06001EE8 RID: 7912 RVA: 0x0002313B File Offset: 0x0002133B
		// (set) Token: 0x06001EE9 RID: 7913 RVA: 0x00023143 File Offset: 0x00021343
		[DataMember(Name = "message", IsRequired = false)]
		public string Message { get; set; }

		// Token: 0x17000B4A RID: 2890
		// (get) Token: 0x06001EEA RID: 7914 RVA: 0x0002314C File Offset: 0x0002134C
		// (set) Token: 0x06001EEB RID: 7915 RVA: 0x00023154 File Offset: 0x00021354
		[DataMember(Name = "deprecationType", IsRequired = true)]
		public string DeprecationType { get; set; }
	}
}
