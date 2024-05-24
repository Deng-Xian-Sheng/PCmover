using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000302 RID: 770
	[DataContract]
	public class GetCertificateResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06001678 RID: 5752 RVA: 0x0001A144 File Offset: 0x00018344
		// (set) Token: 0x06001679 RID: 5753 RVA: 0x0001A14C File Offset: 0x0001834C
		[DataMember]
		internal string[] tableNames { get; set; }

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x0600167A RID: 5754 RVA: 0x0001A155 File Offset: 0x00018355
		public string[] TableNames
		{
			get
			{
				return this.tableNames;
			}
		}
	}
}
