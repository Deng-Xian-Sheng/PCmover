using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F6 RID: 502
	[DataContract]
	public class GPUInfo : DevToolsDomainEntityBase
	{
		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x00013872 File Offset: 0x00011A72
		// (set) Token: 0x06000E65 RID: 3685 RVA: 0x0001387A File Offset: 0x00011A7A
		[DataMember(Name = "devices", IsRequired = true)]
		public IList<GPUDevice> Devices { get; set; }

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x00013883 File Offset: 0x00011A83
		// (set) Token: 0x06000E67 RID: 3687 RVA: 0x0001388B File Offset: 0x00011A8B
		[DataMember(Name = "auxAttributes", IsRequired = false)]
		public object AuxAttributes { get; set; }

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x00013894 File Offset: 0x00011A94
		// (set) Token: 0x06000E69 RID: 3689 RVA: 0x0001389C File Offset: 0x00011A9C
		[DataMember(Name = "featureStatus", IsRequired = false)]
		public object FeatureStatus { get; set; }

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000E6A RID: 3690 RVA: 0x000138A5 File Offset: 0x00011AA5
		// (set) Token: 0x06000E6B RID: 3691 RVA: 0x000138AD File Offset: 0x00011AAD
		[DataMember(Name = "driverBugWorkarounds", IsRequired = true)]
		public string[] DriverBugWorkarounds { get; set; }

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000E6C RID: 3692 RVA: 0x000138B6 File Offset: 0x00011AB6
		// (set) Token: 0x06000E6D RID: 3693 RVA: 0x000138BE File Offset: 0x00011ABE
		[DataMember(Name = "videoDecoding", IsRequired = true)]
		public IList<VideoDecodeAcceleratorCapability> VideoDecoding { get; set; }

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000E6E RID: 3694 RVA: 0x000138C7 File Offset: 0x00011AC7
		// (set) Token: 0x06000E6F RID: 3695 RVA: 0x000138CF File Offset: 0x00011ACF
		[DataMember(Name = "videoEncoding", IsRequired = true)]
		public IList<VideoEncodeAcceleratorCapability> VideoEncoding { get; set; }

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x000138D8 File Offset: 0x00011AD8
		// (set) Token: 0x06000E71 RID: 3697 RVA: 0x000138E0 File Offset: 0x00011AE0
		[DataMember(Name = "imageDecoding", IsRequired = true)]
		public IList<ImageDecodeAcceleratorCapability> ImageDecoding { get; set; }
	}
}
