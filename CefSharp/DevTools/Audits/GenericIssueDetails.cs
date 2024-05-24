using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000426 RID: 1062
	[DataContract]
	public class GenericIssueDetails : DevToolsDomainEntityBase
	{
		// Token: 0x17000B44 RID: 2884
		// (get) Token: 0x06001EDD RID: 7901 RVA: 0x000230C0 File Offset: 0x000212C0
		// (set) Token: 0x06001EDE RID: 7902 RVA: 0x000230DC File Offset: 0x000212DC
		public GenericIssueErrorType ErrorType
		{
			get
			{
				return (GenericIssueErrorType)DevToolsDomainEntityBase.StringToEnum(typeof(GenericIssueErrorType), this.errorType);
			}
			set
			{
				this.errorType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000B45 RID: 2885
		// (get) Token: 0x06001EDF RID: 7903 RVA: 0x000230EF File Offset: 0x000212EF
		// (set) Token: 0x06001EE0 RID: 7904 RVA: 0x000230F7 File Offset: 0x000212F7
		[DataMember(Name = "errorType", IsRequired = true)]
		internal string errorType { get; set; }

		// Token: 0x17000B46 RID: 2886
		// (get) Token: 0x06001EE1 RID: 7905 RVA: 0x00023100 File Offset: 0x00021300
		// (set) Token: 0x06001EE2 RID: 7906 RVA: 0x00023108 File Offset: 0x00021308
		[DataMember(Name = "frameId", IsRequired = false)]
		public string FrameId { get; set; }
	}
}
