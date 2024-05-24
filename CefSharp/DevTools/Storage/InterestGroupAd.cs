using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Storage
{
	// Token: 0x020001FF RID: 511
	[DataContract]
	public class InterestGroupAd : DevToolsDomainEntityBase
	{
		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06000E9A RID: 3738 RVA: 0x00013A8B File Offset: 0x00011C8B
		// (set) Token: 0x06000E9B RID: 3739 RVA: 0x00013A93 File Offset: 0x00011C93
		[DataMember(Name = "renderUrl", IsRequired = true)]
		public string RenderUrl { get; set; }

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000E9C RID: 3740 RVA: 0x00013A9C File Offset: 0x00011C9C
		// (set) Token: 0x06000E9D RID: 3741 RVA: 0x00013AA4 File Offset: 0x00011CA4
		[DataMember(Name = "metadata", IsRequired = false)]
		public string Metadata { get; set; }
	}
}
