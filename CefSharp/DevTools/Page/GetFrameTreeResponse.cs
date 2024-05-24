using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200027A RID: 634
	[DataContract]
	public class GetFrameTreeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x060011DC RID: 4572 RVA: 0x000160A0 File Offset: 0x000142A0
		// (set) Token: 0x060011DD RID: 4573 RVA: 0x000160A8 File Offset: 0x000142A8
		[DataMember]
		internal FrameTree frameTree { get; set; }

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x060011DE RID: 4574 RVA: 0x000160B1 File Offset: 0x000142B1
		public FrameTree FrameTree
		{
			get
			{
				return this.frameTree;
			}
		}
	}
}
