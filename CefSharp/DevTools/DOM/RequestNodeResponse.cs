using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x020003A6 RID: 934
	[DataContract]
	public class RequestNodeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x06001B30 RID: 6960 RVA: 0x0001F405 File Offset: 0x0001D605
		// (set) Token: 0x06001B31 RID: 6961 RVA: 0x0001F40D File Offset: 0x0001D60D
		[DataMember]
		internal int nodeId { get; set; }

		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x06001B32 RID: 6962 RVA: 0x0001F416 File Offset: 0x0001D616
		public int NodeId
		{
			get
			{
				return this.nodeId;
			}
		}
	}
}
