using System;
using System.Runtime.Serialization;

namespace CefSharp.Internals
{
	// Token: 0x020000D8 RID: 216
	[DataContract]
	public class JavascriptCallback
	{
		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x00009C39 File Offset: 0x00007E39
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00009C41 File Offset: 0x00007E41
		[DataMember]
		public long Id { get; set; }

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x00009C4A File Offset: 0x00007E4A
		// (set) Token: 0x0600064A RID: 1610 RVA: 0x00009C52 File Offset: 0x00007E52
		[DataMember]
		public int BrowserId { get; set; }

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x00009C5B File Offset: 0x00007E5B
		// (set) Token: 0x0600064C RID: 1612 RVA: 0x00009C63 File Offset: 0x00007E63
		[DataMember]
		public long FrameId { get; set; }
	}
}
