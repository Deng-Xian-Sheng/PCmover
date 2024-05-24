using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002EA RID: 746
	[DataContract]
	public class SignedExchangeReceivedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170007BD RID: 1981
		// (get) Token: 0x060015CA RID: 5578 RVA: 0x00019B11 File Offset: 0x00017D11
		// (set) Token: 0x060015CB RID: 5579 RVA: 0x00019B19 File Offset: 0x00017D19
		[DataMember(Name = "requestId", IsRequired = true)]
		public string RequestId { get; private set; }

		// Token: 0x170007BE RID: 1982
		// (get) Token: 0x060015CC RID: 5580 RVA: 0x00019B22 File Offset: 0x00017D22
		// (set) Token: 0x060015CD RID: 5581 RVA: 0x00019B2A File Offset: 0x00017D2A
		[DataMember(Name = "info", IsRequired = true)]
		public SignedExchangeInfo Info { get; private set; }
	}
}
