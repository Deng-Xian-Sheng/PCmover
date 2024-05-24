using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003AC RID: 940
	[DataContract]
	public class GetContainerForNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009E3 RID: 2531
		// (get) Token: 0x06001B4B RID: 6987 RVA: 0x0001F4E4 File Offset: 0x0001D6E4
		// (set) Token: 0x06001B4C RID: 6988 RVA: 0x0001F4EC File Offset: 0x0001D6EC
		[DataMember]
		internal int? nodeId { get; set; }

		// Token: 0x170009E4 RID: 2532
		// (get) Token: 0x06001B4D RID: 6989 RVA: 0x0001F4F5 File Offset: 0x0001D6F5
		public int? NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
