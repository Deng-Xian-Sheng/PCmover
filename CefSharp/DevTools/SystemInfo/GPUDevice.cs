using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001EF RID: 495
	[DataContract]
	public class GPUDevice : DevToolsDomainEntityBase
	{
		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000E31 RID: 3633 RVA: 0x0001368C File Offset: 0x0001188C
		// (set) Token: 0x06000E32 RID: 3634 RVA: 0x00013694 File Offset: 0x00011894
		[DataMember(Name = "vendorId", IsRequired = true)]
		public double VendorId { get; set; }

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000E33 RID: 3635 RVA: 0x0001369D File Offset: 0x0001189D
		// (set) Token: 0x06000E34 RID: 3636 RVA: 0x000136A5 File Offset: 0x000118A5
		[DataMember(Name = "deviceId", IsRequired = true)]
		public double DeviceId { get; set; }

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000E35 RID: 3637 RVA: 0x000136AE File Offset: 0x000118AE
		// (set) Token: 0x06000E36 RID: 3638 RVA: 0x000136B6 File Offset: 0x000118B6
		[DataMember(Name = "subSysId", IsRequired = false)]
		public double? SubSysId { get; set; }

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000E37 RID: 3639 RVA: 0x000136BF File Offset: 0x000118BF
		// (set) Token: 0x06000E38 RID: 3640 RVA: 0x000136C7 File Offset: 0x000118C7
		[DataMember(Name = "revision", IsRequired = false)]
		public double? Revision { get; set; }

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000E39 RID: 3641 RVA: 0x000136D0 File Offset: 0x000118D0
		// (set) Token: 0x06000E3A RID: 3642 RVA: 0x000136D8 File Offset: 0x000118D8
		[DataMember(Name = "vendorString", IsRequired = true)]
		public string VendorString { get; set; }

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000E3B RID: 3643 RVA: 0x000136E1 File Offset: 0x000118E1
		// (set) Token: 0x06000E3C RID: 3644 RVA: 0x000136E9 File Offset: 0x000118E9
		[DataMember(Name = "deviceString", IsRequired = true)]
		public string DeviceString { get; set; }

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000E3D RID: 3645 RVA: 0x000136F2 File Offset: 0x000118F2
		// (set) Token: 0x06000E3E RID: 3646 RVA: 0x000136FA File Offset: 0x000118FA
		[DataMember(Name = "driverVendor", IsRequired = true)]
		public string DriverVendor { get; set; }

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000E3F RID: 3647 RVA: 0x00013703 File Offset: 0x00011903
		// (set) Token: 0x06000E40 RID: 3648 RVA: 0x0001370B File Offset: 0x0001190B
		[DataMember(Name = "driverVersion", IsRequired = true)]
		public string DriverVersion { get; set; }
	}
}
