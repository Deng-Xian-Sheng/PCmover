using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002BC RID: 700
	[DataContract]
	public class WebSocketRequest : DevToolsDomainEntityBase
	{
		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06001423 RID: 5155 RVA: 0x000189D8 File Offset: 0x00016BD8
		// (set) Token: 0x06001424 RID: 5156 RVA: 0x000189E0 File Offset: 0x00016BE0
		[DataMember(Name = "headers", IsRequired = true)]
		public Headers Headers { get; set; }
	}
}
