using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003AD RID: 941
	[DataContract]
	public class GetQueryingDescendantsForContainerResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009E5 RID: 2533
		// (get) Token: 0x06001B4F RID: 6991 RVA: 0x0001F505 File Offset: 0x0001D705
		// (set) Token: 0x06001B50 RID: 6992 RVA: 0x0001F50D File Offset: 0x0001D70D
		[DataMember]
		internal int[] nodeIds { get; set; }

		// Token: 0x170009E6 RID: 2534
		// (get) Token: 0x06001B51 RID: 6993 RVA: 0x0001F516 File Offset: 0x0001D716
		public int[] NodeIds
		{
			get
			{
				return this.nodeIds;
			}
		}
	}
}
