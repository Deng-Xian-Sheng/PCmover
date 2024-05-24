using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000274 RID: 628
	[DataContract]
	public class CaptureSnapshotResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700060A RID: 1546
		// (get) Token: 0x060011B8 RID: 4536 RVA: 0x00015F70 File Offset: 0x00014170
		// (set) Token: 0x060011B9 RID: 4537 RVA: 0x00015F78 File Offset: 0x00014178
		[DataMember]
		internal string data { get; set; }

		// Token: 0x1700060B RID: 1547
		// (get) Token: 0x060011BA RID: 4538 RVA: 0x00015F81 File Offset: 0x00014181
		public string Data
		{
			get
			{
				return this.data;
			}
		}
	}
}
