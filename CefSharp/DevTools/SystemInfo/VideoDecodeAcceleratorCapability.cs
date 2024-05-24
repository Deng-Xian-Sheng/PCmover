using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F1 RID: 497
	[DataContract]
	public class VideoDecodeAcceleratorCapability : DevToolsDomainEntityBase
	{
		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06000E47 RID: 3655 RVA: 0x00013746 File Offset: 0x00011946
		// (set) Token: 0x06000E48 RID: 3656 RVA: 0x0001374E File Offset: 0x0001194E
		[DataMember(Name = "profile", IsRequired = true)]
		public string Profile { get; set; }

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06000E49 RID: 3657 RVA: 0x00013757 File Offset: 0x00011957
		// (set) Token: 0x06000E4A RID: 3658 RVA: 0x0001375F File Offset: 0x0001195F
		[DataMember(Name = "maxResolution", IsRequired = true)]
		public Size MaxResolution { get; set; }

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x00013768 File Offset: 0x00011968
		// (set) Token: 0x06000E4C RID: 3660 RVA: 0x00013770 File Offset: 0x00011970
		[DataMember(Name = "minResolution", IsRequired = true)]
		public Size MinResolution { get; set; }
	}
}
