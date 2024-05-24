using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E4 RID: 996
	[DataContract]
	public class GetStyleSheetTextResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A98 RID: 2712
		// (get) Token: 0x06001D2C RID: 7468 RVA: 0x000215D0 File Offset: 0x0001F7D0
		// (set) Token: 0x06001D2D RID: 7469 RVA: 0x000215D8 File Offset: 0x0001F7D8
		[DataMember]
		internal string text { get; set; }

		// Token: 0x17000A99 RID: 2713
		// (get) Token: 0x06001D2E RID: 7470 RVA: 0x000215E1 File Offset: 0x0001F7E1
		public string Text
		{
			get
			{
				return this.text;
			}
		}
	}
}
