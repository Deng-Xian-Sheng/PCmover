using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E7 RID: 999
	[DataContract]
	public class SetMediaTextResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A9E RID: 2718
		// (get) Token: 0x06001D38 RID: 7480 RVA: 0x00021633 File Offset: 0x0001F833
		// (set) Token: 0x06001D39 RID: 7481 RVA: 0x0002163B File Offset: 0x0001F83B
		[DataMember]
		internal CSSMedia media { get; set; }

		// Token: 0x17000A9F RID: 2719
		// (get) Token: 0x06001D3A RID: 7482 RVA: 0x00021644 File Offset: 0x0001F844
		public CSSMedia Media
		{
			get
			{
				return this.media;
			}
		}
	}
}
