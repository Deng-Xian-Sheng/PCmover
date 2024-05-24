using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002EB RID: 747
	[DataContract]
	public class ResponseReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007BF RID: 1983
		// (get) Token: 0x060015CF RID: 5583 RVA: 0x00019B3B File Offset: 0x00017D3B
		// (set) Token: 0x060015D0 RID: 5584 RVA: 0x00019B43 File Offset: 0x00017D43
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007C0 RID: 1984
		// (get) Token: 0x060015D1 RID: 5585 RVA: 0x00019B4C File Offset: 0x00017D4C
		// (set) Token: 0x060015D2 RID: 5586 RVA: 0x00019B54 File Offset: 0x00017D54
		[DataMember(Name = "loaderId", IsRequired = true)]
		public string LoaderId { get; private set; }

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x060015D3 RID: 5587 RVA: 0x00019B5D File Offset: 0x00017D5D
		// (set) Token: 0x060015D4 RID: 5588 RVA: 0x00019B65 File Offset: 0x00017D65
		[DataMember(Name = "timestamp", IsRequired = true)]
		public double Timestamp { get; private set; }

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x060015D5 RID: 5589 RVA: 0x00019B6E File Offset: 0x00017D6E
		// (set) Token: 0x060015D6 RID: 5590 RVA: 0x00019B8A File Offset: 0x00017D8A
		public ResourceType Type
		{
			get
			{
				return (ResourceType)DevToolsDomainEventArgsBase.StringToEnum(typeof(ResourceType), this.type);
			}
			set
			{
				this.type = DevToolsDomainEventArgsBase.EnumToString(value);
			}
		}

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x060015D7 RID: 5591 RVA: 0x00019B9D File Offset: 0x00017D9D
		// (set) Token: 0x060015D8 RID: 5592 RVA: 0x00019BA5 File Offset: 0x00017DA5
		[DataMember(Name = "type", IsRequired = true)]
		internal string type { get; private set; }

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x060015D9 RID: 5593 RVA: 0x00019BAE File Offset: 0x00017DAE
		// (set) Token: 0x060015DA RID: 5594 RVA: 0x00019BB6 File Offset: 0x00017DB6
		[DataMember(Name = "response", IsRequired = true)]
		public Response Response { get; private set; }

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x060015DB RID: 5595 RVA: 0x00019BBF File Offset: 0x00017DBF
		// (set) Token: 0x060015DC RID: 5596 RVA: 0x00019BC7 File Offset: 0x00017DC7
		[DataMember(Name = "hasExtraInfo", IsRequired = true)]
		public bool HasExtraInfo { get; private set; }

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x060015DD RID: 5597 RVA: 0x00019BD0 File Offset: 0x00017DD0
		// (set) Token: 0x060015DE RID: 5598 RVA: 0x00019BD8 File Offset: 0x00017DD8
		[DataMember(Name = "frameId", IsRequired = false)]
		public string FrameId { get; private set; }
	}
}
