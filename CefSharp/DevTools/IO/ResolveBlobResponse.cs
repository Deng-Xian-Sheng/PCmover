using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IO
{
	// Token: 0x02000129 RID: 297
	[DataContract]
	public class ResolveBlobResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700026B RID: 619
		// (get) Token: 0x060008A2 RID: 2210 RVA: 0x0000DD71 File Offset: 0x0000BF71
		// (set) Token: 0x060008A3 RID: 2211 RVA: 0x0000DD79 File Offset: 0x0000BF79
		[DataMember]
		internal string uuid { get; set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x060008A4 RID: 2212 RVA: 0x0000DD82 File Offset: 0x0000BF82
		public string Uuid
		{
			get
			{
				return this.uuid;
			}
		}
	}
}
