using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200041C RID: 1052
	[DataContract]
	public class SharedArrayBufferIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B1E RID: 2846
		// (get) Token: 0x06001E8A RID: 7818 RVA: 0x00022D8A File Offset: 0x00020F8A
		// (set) Token: 0x06001E8B RID: 7819 RVA: 0x00022D92 File Offset: 0x00020F92
		[DataMember(Name = "sourceCodeLocation", IsRequired = true)]
		public SourceCodeLocation SourceCodeLocation { get; set; }

		// Token: 0x17000B1F RID: 2847
		// (get) Token: 0x06001E8C RID: 7820 RVA: 0x00022D9B File Offset: 0x00020F9B
		// (set) Token: 0x06001E8D RID: 7821 RVA: 0x00022DA3 File Offset: 0x00020FA3
		[DataMember(Name = "isWarning", IsRequired = true)]
		public bool IsWarning { get; set; }

		// Token: 0x17000B20 RID: 2848
		// (get) Token: 0x06001E8E RID: 7822 RVA: 0x00022DAC File Offset: 0x00020FAC
		// (set) Token: 0x06001E8F RID: 7823 RVA: 0x00022DC8 File Offset: 0x00020FC8
		public SharedArrayBufferIssueType Type
		{
			get
			{
				return (SharedArrayBufferIssueType)DevToolsDomainEntityBase.StringToEnum(typeof(SharedArrayBufferIssueType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B21 RID: 2849
		// (get) Token: 0x06001E90 RID: 7824 RVA: 0x00022DDB File Offset: 0x00020FDB
		// (set) Token: 0x06001E91 RID: 7825 RVA: 0x00022DE3 File Offset: 0x00020FE3
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; set; }
	}
}
