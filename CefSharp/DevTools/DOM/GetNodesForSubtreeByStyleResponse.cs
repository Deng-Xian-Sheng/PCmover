using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200039B RID: 923
	[DataContract]
	public class GetNodesForSubtreeByStyleResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009B9 RID: 2489
		// (get) Token: 0x06001AFB RID: 6907 RVA: 0x0001F24F File Offset: 0x0001D44F
		// (set) Token: 0x06001AFC RID: 6908 RVA: 0x0001F257 File Offset: 0x0001D457
		[DataMember]
		internal int[] nodeIds { get; set; }

		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06001AFD RID: 6909 RVA: 0x0001F260 File Offset: 0x0001D460
		public int[] NodeIds
		{
			get
			{
				return this.nodeIds;
			}
		}
	}
}
