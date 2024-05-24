using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x0200042E RID: 1070
	[DataContract]
	public class InspectorIssue : DevToolsDomainEntityBase
	{
		// Token: 0x17000B60 RID: 2912
		// (get) Token: 0x06001F1A RID: 7962 RVA: 0x0002331E File Offset: 0x0002151E
		// (set) Token: 0x06001F1B RID: 7963 RVA: 0x0002333A File Offset: 0x0002153A
		public InspectorIssueCode Code
		{
			get
			{
				return (InspectorIssueCode)DevToolsDomainEntityBase.StringToEnum(typeof(InspectorIssueCode), this.code);
			}
			set
			{
				this.code = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B61 RID: 2913
		// (get) Token: 0x06001F1C RID: 7964 RVA: 0x0002334D File Offset: 0x0002154D
		// (set) Token: 0x06001F1D RID: 7965 RVA: 0x00023355 File Offset: 0x00021555
		[DataMember(Name = "code", IsRequired = true)]
		internal string code { get; set; }

		// Token: 0x17000B62 RID: 2914
		// (get) Token: 0x06001F1E RID: 7966 RVA: 0x0002335E File Offset: 0x0002155E
		// (set) Token: 0x06001F1F RID: 7967 RVA: 0x00023366 File Offset: 0x00021566
		[DataMember(Name = "details", IsRequired = true)]
		public InspectorIssueDetails Details { get; set; }

		// Token: 0x17000B63 RID: 2915
		// (get) Token: 0x06001F20 RID: 7968 RVA: 0x0002336F File Offset: 0x0002156F
		// (set) Token: 0x06001F21 RID: 7969 RVA: 0x00023377 File Offset: 0x00021577
		[DataMember(Name = "issueId", IsRequired = false)]
		public string IssueId { get; set; }
	}
}
