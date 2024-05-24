using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000306 RID: 774
	[DataContract]
	public class GetResponseBodyForInterceptionResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x0600168B RID: 5771 RVA: 0x0001A1E1 File Offset: 0x000183E1
		// (set) Token: 0x0600168C RID: 5772 RVA: 0x0001A1E9 File Offset: 0x000183E9
		[DataMember]
		internal string body { get; set; }

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x0600168D RID: 5773 RVA: 0x0001A1F2 File Offset: 0x000183F2
		public string Body
		{
			get
			{
				return this.body;
			}
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x0600168E RID: 5774 RVA: 0x0001A1FA File Offset: 0x000183FA
		// (set) Token: 0x0600168F RID: 5775 RVA: 0x0001A202 File Offset: 0x00018402
		[DataMember]
		internal bool base64Encoded { get; set; }

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06001690 RID: 5776 RVA: 0x0001A20B File Offset: 0x0001840B
		public bool Base64Encoded
		{
			get
			{
				return this.base64Encoded;
			}
		}
	}
}
