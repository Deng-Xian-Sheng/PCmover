using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Accessibility
{
	// Token: 0x0200044C RID: 1100
	[DataContract]
	public class GetRootAXNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000BB5 RID: 2997
		// (get) Token: 0x06001FEA RID: 8170 RVA: 0x00023DB0 File Offset: 0x00021FB0
		// (set) Token: 0x06001FEB RID: 8171 RVA: 0x00023DB8 File Offset: 0x00021FB8
		[DataMember]
		internal AXNode node { get; set; }

		// Token: 0x17000BB6 RID: 2998
		// (get) Token: 0x06001FEC RID: 8172 RVA: 0x00023DC1 File Offset: 0x00021FC1
		public AXNode Node
		{
			get
			{
				return this.node;
			}
		}
	}
}
