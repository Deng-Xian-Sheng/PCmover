using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002BE RID: 702
	[DataContract]
	public class WebSocketFrame : DevToolsDomainEntityBase
	{
		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x06001433 RID: 5171 RVA: 0x00018A5F File Offset: 0x00016C5F
		// (set) Token: 0x06001434 RID: 5172 RVA: 0x00018A67 File Offset: 0x00016C67
		[DataMember(Name = "opcode", IsRequired = true)]
		public double Opcode { get; set; }

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x06001435 RID: 5173 RVA: 0x00018A70 File Offset: 0x00016C70
		// (set) Token: 0x06001436 RID: 5174 RVA: 0x00018A78 File Offset: 0x00016C78
		[DataMember(Name = "mask", IsRequired = true)]
		public bool Mask { get; set; }

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06001437 RID: 5175 RVA: 0x00018A81 File Offset: 0x00016C81
		// (set) Token: 0x06001438 RID: 5176 RVA: 0x00018A89 File Offset: 0x00016C89
		[DataMember(Name = "payloadData", IsRequired = true)]
		public string PayloadData { get; set; }
	}
}
