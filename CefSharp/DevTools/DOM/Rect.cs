using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.DOM
{
	// Token: 0x02000385 RID: 901
	[DataContract]
	public class Rect : DevToolsDomainEntityBase
	{
		// Token: 0x1700098A RID: 2442
		// (get) Token: 0x06001A8E RID: 6798 RVA: 0x0001EEBF File Offset: 0x0001D0BF
		// (set) Token: 0x06001A8F RID: 6799 RVA: 0x0001EEC7 File Offset: 0x0001D0C7
		[DataMember(Name = "x", IsRequired = true)]
		public double X { get; set; }

		// Token: 0x1700098B RID: 2443
		// (get) Token: 0x06001A90 RID: 6800 RVA: 0x0001EED0 File Offset: 0x0001D0D0
		// (set) Token: 0x06001A91 RID: 6801 RVA: 0x0001EED8 File Offset: 0x0001D0D8
		[DataMember(Name = "y", IsRequired = true)]
		public double Y { get; set; }

		// Token: 0x1700098C RID: 2444
		// (get) Token: 0x06001A92 RID: 6802 RVA: 0x0001EEE1 File Offset: 0x0001D0E1
		// (set) Token: 0x06001A93 RID: 6803 RVA: 0x0001EEE9 File Offset: 0x0001D0E9
		[DataMember(Name = "width", IsRequired = true)]
		public double Width { get; set; }

		// Token: 0x1700098D RID: 2445
		// (get) Token: 0x06001A94 RID: 6804 RVA: 0x0001EEF2 File Offset: 0x0001D0F2
		// (set) Token: 0x06001A95 RID: 6805 RVA: 0x0001EEFA File Offset: 0x0001D0FA
		[DataMember(Name = "height", IsRequired = true)]
		public double Height { get; set; }
	}
}
