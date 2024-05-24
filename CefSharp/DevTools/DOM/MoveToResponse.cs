using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A0 RID: 928
	[DataContract]
	public class MoveToResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009C7 RID: 2503
		// (get) Token: 0x06001B15 RID: 6933 RVA: 0x0001F326 File Offset: 0x0001D526
		// (set) Token: 0x06001B16 RID: 6934 RVA: 0x0001F32E File Offset: 0x0001D52E
		[DataMember]
		internal int nodeId { get; set; }

		// Token: 0x170009C8 RID: 2504
		// (get) Token: 0x06001B17 RID: 6935 RVA: 0x0001F337 File Offset: 0x0001D537
		public int NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
