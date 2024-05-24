using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x0200043C RID: 1084
	[DataContract]
	public class GetPlaybackRateResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000B89 RID: 2953
		// (get) Token: 0x06001F7A RID: 8058 RVA: 0x0002378F File Offset: 0x0002198F
		// (set) Token: 0x06001F7B RID: 8059 RVA: 0x00023797 File Offset: 0x00021997
		[DataMember]
		internal double playbackRate { get; set; }

		// Token: 0x17000B8A RID: 2954
		// (get) Token: 0x06001F7C RID: 8060 RVA: 0x000237A0 File Offset: 0x000219A0
		public double PlaybackRate
		{
			get
			{
				return this.playbackRate;
			}
		}
	}
}
