using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F2 RID: 498
	[DataContract]
	public class VideoEncodeAcceleratorCapability : DevToolsDomainEntityBase
	{
		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000E4E RID: 3662 RVA: 0x00013781 File Offset: 0x00011981
		// (set) Token: 0x06000E4F RID: 3663 RVA: 0x00013789 File Offset: 0x00011989
		[DataMember(Name = "profile", IsRequired = true)]
		public string Profile { get; set; }

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000E50 RID: 3664 RVA: 0x00013792 File Offset: 0x00011992
		// (set) Token: 0x06000E51 RID: 3665 RVA: 0x0001379A File Offset: 0x0001199A
		[DataMember(Name = "maxResolution", IsRequired = true)]
		public Size MaxResolution { get; set; }

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000E52 RID: 3666 RVA: 0x000137A3 File Offset: 0x000119A3
		// (set) Token: 0x06000E53 RID: 3667 RVA: 0x000137AB File Offset: 0x000119AB
		[DataMember(Name = "maxFramerateNumerator", IsRequired = true)]
		public int MaxFramerateNumerator { get; set; }

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000E54 RID: 3668 RVA: 0x000137B4 File Offset: 0x000119B4
		// (set) Token: 0x06000E55 RID: 3669 RVA: 0x000137BC File Offset: 0x000119BC
		[DataMember(Name = "maxFramerateDenominator", IsRequired = true)]
		public int MaxFramerateDenominator { get; set; }
	}
}
