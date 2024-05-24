using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x0200039F RID: 927
	[DataContract]
	public class GetSearchResultsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009C5 RID: 2501
		// (get) Token: 0x06001B11 RID: 6929 RVA: 0x0001F305 File Offset: 0x0001D505
		// (set) Token: 0x06001B12 RID: 6930 RVA: 0x0001F30D File Offset: 0x0001D50D
		[DataMember]
		internal int[] nodeIds { get; set; }

		// Token: 0x170009C6 RID: 2502
		// (get) Token: 0x06001B13 RID: 6931 RVA: 0x0001F316 File Offset: 0x0001D516
		public int[] NodeIds
		{
			get
			{
				return this.nodeIds;
			}
		}
	}
}
