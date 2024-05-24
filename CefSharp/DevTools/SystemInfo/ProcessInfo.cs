using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F7 RID: 503
	[DataContract]
	public class ProcessInfo : DevToolsDomainEntityBase
	{
		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000E73 RID: 3699 RVA: 0x000138F1 File Offset: 0x00011AF1
		// (set) Token: 0x06000E74 RID: 3700 RVA: 0x000138F9 File Offset: 0x00011AF9
		[DataMember(Name = "type", IsRequired = true)]
		public string Type { get; set; }

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000E75 RID: 3701 RVA: 0x00013902 File Offset: 0x00011B02
		// (set) Token: 0x06000E76 RID: 3702 RVA: 0x0001390A File Offset: 0x00011B0A
		[DataMember(Name = "id", IsRequired = true)]
		public int Id { get; set; }

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000E77 RID: 3703 RVA: 0x00013913 File Offset: 0x00011B13
		// (set) Token: 0x06000E78 RID: 3704 RVA: 0x0001391B File Offset: 0x00011B1B
		[DataMember(Name = "cpuTime", IsRequired = true)]
		public double CpuTime { get; set; }
	}
}
