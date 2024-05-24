using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Network
{
	// Token: 0x02000307 RID: 775
	[DataContract]
	public class TakeResponseBodyForInterceptionAsStreamResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06001692 RID: 5778 RVA: 0x0001A21B File Offset: 0x0001841B
		// (set) Token: 0x06001693 RID: 5779 RVA: 0x0001A223 File Offset: 0x00018423
		[DataMember]
		internal string stream { get; set; }

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x06001694 RID: 5780 RVA: 0x0001A22C File Offset: 0x0001842C
		public string Stream
		{
			get
			{
				return this.stream;
			}
		}
	}
}
