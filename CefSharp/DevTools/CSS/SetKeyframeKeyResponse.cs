using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003E6 RID: 998
	[DataContract]
	public class SetKeyframeKeyResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000A9C RID: 2716
		// (get) Token: 0x06001D34 RID: 7476 RVA: 0x00021612 File Offset: 0x0001F812
		// (set) Token: 0x06001D35 RID: 7477 RVA: 0x0002161A File Offset: 0x0001F81A
		[DataMember]
		internal Value keyText { get; set; }

		// Token: 0x17000A9D RID: 2717
		// (get) Token: 0x06001D36 RID: 7478 RVA: 0x00021623 File Offset: 0x0001F823
		public Value KeyText
		{
			get
			{
				return this.keyText;
			}
		}
	}
}
