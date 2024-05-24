using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F5 RID: 501
	[DataContract]
	public class ImageDecodeAcceleratorCapability : DevToolsDomainEntityBase
	{
		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x000137CD File Offset: 0x000119CD
		// (set) Token: 0x06000E58 RID: 3672 RVA: 0x000137E9 File Offset: 0x000119E9
		public ImageType ImageType
		{
			get
			{
				return (ImageType)DevToolsDomainEntityBase.StringToEnum(typeof(ImageType), this.imageType);
			}
			set
			{
				this.imageType = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x000137FC File Offset: 0x000119FC
		// (set) Token: 0x06000E5A RID: 3674 RVA: 0x00013804 File Offset: 0x00011A04
		[DataMember(Name = "imageType", IsRequired = true)]
		internal string imageType { get; set; }

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000E5B RID: 3675 RVA: 0x0001380D File Offset: 0x00011A0D
		// (set) Token: 0x06000E5C RID: 3676 RVA: 0x00013815 File Offset: 0x00011A15
		[DataMember(Name = "maxDimensions", IsRequired = true)]
		public Size MaxDimensions { get; set; }

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06000E5D RID: 3677 RVA: 0x0001381E File Offset: 0x00011A1E
		// (set) Token: 0x06000E5E RID: 3678 RVA: 0x00013826 File Offset: 0x00011A26
		[DataMember(Name = "minDimensions", IsRequired = true)]
		public Size MinDimensions { get; set; }

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06000E5F RID: 3679 RVA: 0x0001382F File Offset: 0x00011A2F
		// (set) Token: 0x06000E60 RID: 3680 RVA: 0x0001384B File Offset: 0x00011A4B
		public SubsamplingFormat[] Subsamplings
		{
			get
			{
				return (SubsamplingFormat[])DevToolsDomainEntityBase.StringToEnum(typeof(SubsamplingFormat[]), this.subsamplings);
			}
			set
			{
				this.subsamplings = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000E61 RID: 3681 RVA: 0x00013859 File Offset: 0x00011A59
		// (set) Token: 0x06000E62 RID: 3682 RVA: 0x00013861 File Offset: 0x00011A61
		[DataMember(Name = "subsamplings", IsRequired = true)]
		internal string subsamplings { get; set; }
	}
}
