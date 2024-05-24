using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000299 RID: 665
	[DataContract]
	public class HingeConfig : DevToolsDomainEntityBase
	{
		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x0001787C File Offset: 0x00015A7C
		// (set) Token: 0x06001313 RID: 4883 RVA: 0x00017884 File Offset: 0x00015A84
		[DataMember(Name = "rect", IsRequired = true)]
		public Rect Rect { get; set; }

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x0001788D File Offset: 0x00015A8D
		// (set) Token: 0x06001315 RID: 4885 RVA: 0x00017895 File Offset: 0x00015A95
		[DataMember(Name = "contentColor", IsRequired = false)]
		public RGBA ContentColor { get; set; }

		// Token: 0x1700068D RID: 1677
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x0001789E File Offset: 0x00015A9E
		// (set) Token: 0x06001317 RID: 4887 RVA: 0x000178A6 File Offset: 0x00015AA6
		[DataMember(Name = "outlineColor", IsRequired = false)]
		public RGBA OutlineColor { get; set; }
	}
}
