using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000162 RID: 354
	[DataContract]
	public class StartPreciseCoverageResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06000A4C RID: 2636 RVA: 0x0000F6D3 File Offset: 0x0000D8D3
		// (set) Token: 0x06000A4D RID: 2637 RVA: 0x0000F6DB File Offset: 0x0000D8DB
		[DataMember]
		internal double timestamp { get; set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x0000F6E4 File Offset: 0x0000D8E4
		public double Timestamp
		{
			get
			{
				return this.timestamp;
			}
		}
	}
}
