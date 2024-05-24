using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001EA RID: 490
	[DataContract]
	public class GetBrowserContextsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06000E02 RID: 3586 RVA: 0x0001303E File Offset: 0x0001123E
		// (set) Token: 0x06000E03 RID: 3587 RVA: 0x00013046 File Offset: 0x00011246
		[DataMember]
		internal string[] browserContextIds { get; set; }

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x0001304F File Offset: 0x0001124F
		public string[] BrowserContextIds
		{
			get
			{
				return this.browserContextIds;
			}
		}
	}
}
