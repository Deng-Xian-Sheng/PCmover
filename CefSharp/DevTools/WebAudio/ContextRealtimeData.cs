using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001AD RID: 429
	[DataContract]
	public class ContextRealtimeData : DevToolsDomainEntityBase
	{
		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000C54 RID: 3156 RVA: 0x000118B5 File Offset: 0x0000FAB5
		// (set) Token: 0x06000C55 RID: 3157 RVA: 0x000118BD File Offset: 0x0000FABD
		[DataMember(Name = "currentTime", IsRequired = true)]
		public double CurrentTime { get; set; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000C56 RID: 3158 RVA: 0x000118C6 File Offset: 0x0000FAC6
		// (set) Token: 0x06000C57 RID: 3159 RVA: 0x000118CE File Offset: 0x0000FACE
		[DataMember(Name = "renderCapacity", IsRequired = true)]
		public double RenderCapacity { get; set; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06000C58 RID: 3160 RVA: 0x000118D7 File Offset: 0x0000FAD7
		// (set) Token: 0x06000C59 RID: 3161 RVA: 0x000118DF File Offset: 0x0000FADF
		[DataMember(Name = "callbackIntervalMean", IsRequired = true)]
		public double CallbackIntervalMean { get; set; }

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06000C5A RID: 3162 RVA: 0x000118E8 File Offset: 0x0000FAE8
		// (set) Token: 0x06000C5B RID: 3163 RVA: 0x000118F0 File Offset: 0x0000FAF0
		[DataMember(Name = "callbackIntervalVariance", IsRequired = true)]
		public double CallbackIntervalVariance { get; set; }
	}
}
