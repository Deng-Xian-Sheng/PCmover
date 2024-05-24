using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E5 RID: 997
	[DataContract]
	public class TakeComputedStyleUpdatesResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A9A RID: 2714
		// (get) Token: 0x06001D30 RID: 7472 RVA: 0x000215F1 File Offset: 0x0001F7F1
		// (set) Token: 0x06001D31 RID: 7473 RVA: 0x000215F9 File Offset: 0x0001F7F9
		[DataMember]
		internal int[] nodeIds { get; set; }

		// Token: 0x17000A9B RID: 2715
		// (get) Token: 0x06001D32 RID: 7474 RVA: 0x00021602 File Offset: 0x0001F802
		public int[] NodeIds
		{
			get
			{
				return this.nodeIds;
			}
		}
	}
}
