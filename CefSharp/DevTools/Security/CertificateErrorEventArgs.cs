using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x0200021E RID: 542
	[DataContract]
	public class CertificateErrorEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06000FB0 RID: 4016 RVA: 0x00014A58 File Offset: 0x00012C58
		// (set) Token: 0x06000FB1 RID: 4017 RVA: 0x00014A60 File Offset: 0x00012C60
		[DataMember(Name = "eventId", IsRequired = true)]
		public int EventId { get; private set; }

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x00014A69 File Offset: 0x00012C69
		// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x00014A71 File Offset: 0x00012C71
		[DataMember(Name = "errorType", IsRequired = true)]
		public string ErrorType { get; private set; }

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x00014A7A File Offset: 0x00012C7A
		// (set) Token: 0x06000FB5 RID: 4021 RVA: 0x00014A82 File Offset: 0x00012C82
		[DataMember(Name = "requestURL", IsRequired = true)]
		public string RequestURL { get; private set; }
	}
}
