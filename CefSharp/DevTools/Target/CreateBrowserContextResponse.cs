using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E9 RID: 489
	[DataContract]
	public class CreateBrowserContextResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06000DFE RID: 3582 RVA: 0x0001301D File Offset: 0x0001121D
		// (set) Token: 0x06000DFF RID: 3583 RVA: 0x00013025 File Offset: 0x00011225
		[DataMember]
		internal string browserContextId { get; set; }

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06000E00 RID: 3584 RVA: 0x0001302E File Offset: 0x0001122E
		public string BrowserContextId
		{
			get
			{
				return this.browserContextId;
			}
		}
	}
}
