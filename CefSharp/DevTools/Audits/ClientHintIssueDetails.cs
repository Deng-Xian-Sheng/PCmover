using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200042B RID: 1067
	[DataContract]
	public class ClientHintIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B4D RID: 2893
		// (get) Token: 0x06001EF2 RID: 7922 RVA: 0x000231AD File Offset: 0x000213AD
		// (set) Token: 0x06001EF3 RID: 7923 RVA: 0x000231B5 File Offset: 0x000213B5
		[DataMember(Name = "sourceCodeLocation", IsRequired = true)]
		public SourceCodeLocation SourceCodeLocation { get; set; }

		// Token: 0x17000B4E RID: 2894
		// (get) Token: 0x06001EF4 RID: 7924 RVA: 0x000231BE File Offset: 0x000213BE
		// (set) Token: 0x06001EF5 RID: 7925 RVA: 0x000231DA File Offset: 0x000213DA
		public ClientHintIssueReason ClientHintIssueReason
		{
			get
			{
				return (ClientHintIssueReason)DevToolsDomainEntityBase.StringToEnum(typeof(ClientHintIssueReason), this.clientHintIssueReason);
			}
			set
			{
				this.clientHintIssueReason = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B4F RID: 2895
		// (get) Token: 0x06001EF6 RID: 7926 RVA: 0x000231ED File Offset: 0x000213ED
		// (set) Token: 0x06001EF7 RID: 7927 RVA: 0x000231F5 File Offset: 0x000213F5
		[DataMember(Name = "clientHintIssueReason", IsRequired = true)]
		internal string clientHintIssueReason { get; set; }
	}
}
