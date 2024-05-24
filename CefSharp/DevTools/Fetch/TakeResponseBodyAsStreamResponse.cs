using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Fetch
{
	// Token: 0x020001CB RID: 459
	[DataContract]
	public class TakeResponseBodyAsStreamResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000D59 RID: 3417 RVA: 0x00012435 File Offset: 0x00010635
		// (set) Token: 0x06000D5A RID: 3418 RVA: 0x0001243D File Offset: 0x0001063D
		[DataMember]
		internal string stream { get; set; }

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00012446 File Offset: 0x00010646
		public string Stream
		{
			get
			{
				return this.stream;
			}
		}
	}
}
