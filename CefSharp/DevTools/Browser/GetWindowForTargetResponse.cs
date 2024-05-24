using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x02000400 RID: 1024
	[DataContract]
	public class GetWindowForTargetResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x06001DDD RID: 7645 RVA: 0x0002217D File Offset: 0x0002037D
		// (set) Token: 0x06001DDE RID: 7646 RVA: 0x00022185 File Offset: 0x00020385
		[DataMember]
		internal int windowId { get; set; }

		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x06001DDF RID: 7647 RVA: 0x0002218E File Offset: 0x0002038E
		public int WindowId
		{
			get
			{
				return this.windowId;
			}
		}

		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x06001DE0 RID: 7648 RVA: 0x00022196 File Offset: 0x00020396
		// (set) Token: 0x06001DE1 RID: 7649 RVA: 0x0002219E File Offset: 0x0002039E
		[DataMember]
		internal Bounds bounds { get; set; }

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x06001DE2 RID: 7650 RVA: 0x000221A7 File Offset: 0x000203A7
		public Bounds Bounds
		{
			get
			{
				return this.bounds;
			}
		}
	}
}
