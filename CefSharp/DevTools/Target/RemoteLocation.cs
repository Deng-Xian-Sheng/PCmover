using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001DE RID: 478
	[DataContract]
	public class RemoteLocation : DevToolsDomainEntityBase
	{
		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00012E6A File Offset: 0x0001106A
		// (set) Token: 0x06000DCB RID: 3531 RVA: 0x00012E72 File Offset: 0x00011072
		[DataMember(Name = "host", IsRequired = true)]
		public string Host { get; set; }

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00012E7B File Offset: 0x0001107B
		// (set) Token: 0x06000DCD RID: 3533 RVA: 0x00012E83 File Offset: 0x00011083
		[DataMember(Name = "port", IsRequired = true)]
		public int Port { get; set; }
	}
}
