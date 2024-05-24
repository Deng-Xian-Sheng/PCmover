using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x0200043B RID: 1083
	[DataContract]
	public class GetCurrentTimeResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000B87 RID: 2951
		// (get) Token: 0x06001F76 RID: 8054 RVA: 0x0002376E File Offset: 0x0002196E
		// (set) Token: 0x06001F77 RID: 8055 RVA: 0x00023776 File Offset: 0x00021976
		[DataMember]
		internal double currentTime { get; set; }

		// Token: 0x17000B88 RID: 2952
		// (get) Token: 0x06001F78 RID: 8056 RVA: 0x0002377F File Offset: 0x0002197F
		public double CurrentTime
		{
			get
			{
				return this.currentTime;
			}
		}
	}
}
