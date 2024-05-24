using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.SystemInfo
{
	// Token: 0x020001F0 RID: 496
	[DataContract]
	public class Size : DevToolsDomainEntityBase
	{
		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x0001371C File Offset: 0x0001191C
		// (set) Token: 0x06000E43 RID: 3651 RVA: 0x00013724 File Offset: 0x00011924
		[DataMember(Name = "width", IsRequired = true)]
		public int Width { get; set; }

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06000E44 RID: 3652 RVA: 0x0001372D File Offset: 0x0001192D
		// (set) Token: 0x06000E45 RID: 3653 RVA: 0x00013735 File Offset: 0x00011935
		[DataMember(Name = "height", IsRequired = true)]
		public int Height { get; set; }
	}
}
