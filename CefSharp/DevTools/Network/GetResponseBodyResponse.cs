using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000304 RID: 772
	[DataContract]
	public class GetResponseBodyResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06001680 RID: 5760 RVA: 0x0001A186 File Offset: 0x00018386
		// (set) Token: 0x06001681 RID: 5761 RVA: 0x0001A18E File Offset: 0x0001838E
		[DataMember]
		internal string body { get; set; }

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x06001682 RID: 5762 RVA: 0x0001A197 File Offset: 0x00018397
		public string Body
		{
			get
			{
				return this.body;
			}
		}

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x06001683 RID: 5763 RVA: 0x0001A19F File Offset: 0x0001839F
		// (set) Token: 0x06001684 RID: 5764 RVA: 0x0001A1A7 File Offset: 0x000183A7
		[DataMember]
		internal bool base64Encoded { get; set; }

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x06001685 RID: 5765 RVA: 0x0001A1B0 File Offset: 0x000183B0
		public bool Base64Encoded
		{
			get
			{
				return this.base64Encoded;
			}
		}
	}
}
