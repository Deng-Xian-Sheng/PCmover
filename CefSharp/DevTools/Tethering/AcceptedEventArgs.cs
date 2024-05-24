using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Tethering
{
	// Token: 0x020001DB RID: 475
	[DataContract]
	public class AcceptedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000DAD RID: 3501 RVA: 0x00012CF9 File Offset: 0x00010EF9
		// (set) Token: 0x06000DAE RID: 3502 RVA: 0x00012D01 File Offset: 0x00010F01
		[DataMember(Name = "port", IsRequired = true)]
		public int Port { get; private set; }

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00012D0A File Offset: 0x00010F0A
		// (set) Token: 0x06000DB0 RID: 3504 RVA: 0x00012D12 File Offset: 0x00010F12
		[DataMember(Name = "connectionId", IsRequired = true)]
		public string ConnectionId { get; private set; }
	}
}
