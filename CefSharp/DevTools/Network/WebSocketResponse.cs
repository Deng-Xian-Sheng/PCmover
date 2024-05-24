using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x020002BD RID: 701
	[DataContract]
	public class WebSocketResponse : DevToolsDomainEntityBase
	{
		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06001426 RID: 5158 RVA: 0x000189F1 File Offset: 0x00016BF1
		// (set) Token: 0x06001427 RID: 5159 RVA: 0x000189F9 File Offset: 0x00016BF9
		[DataMember(Name = "status", IsRequired = true)]
		public int Status { get; set; }

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x06001428 RID: 5160 RVA: 0x00018A02 File Offset: 0x00016C02
		// (set) Token: 0x06001429 RID: 5161 RVA: 0x00018A0A File Offset: 0x00016C0A
		[DataMember(Name = "statusText", IsRequired = true)]
		public string StatusText { get; set; }

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x0600142A RID: 5162 RVA: 0x00018A13 File Offset: 0x00016C13
		// (set) Token: 0x0600142B RID: 5163 RVA: 0x00018A1B File Offset: 0x00016C1B
		[DataMember(Name = "headers", IsRequired = true)]
		public Headers Headers { get; set; }

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x0600142C RID: 5164 RVA: 0x00018A24 File Offset: 0x00016C24
		// (set) Token: 0x0600142D RID: 5165 RVA: 0x00018A2C File Offset: 0x00016C2C
		[DataMember(Name = "headersText", IsRequired = false)]
		public string HeadersText { get; set; }

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x0600142E RID: 5166 RVA: 0x00018A35 File Offset: 0x00016C35
		// (set) Token: 0x0600142F RID: 5167 RVA: 0x00018A3D File Offset: 0x00016C3D
		[DataMember(Name = "requestHeaders", IsRequired = false)]
		public Headers RequestHeaders { get; set; }

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06001430 RID: 5168 RVA: 0x00018A46 File Offset: 0x00016C46
		// (set) Token: 0x06001431 RID: 5169 RVA: 0x00018A4E File Offset: 0x00016C4E
		[DataMember(Name = "requestHeadersText", IsRequired = false)]
		public string RequestHeadersText { get; set; }
	}
}
