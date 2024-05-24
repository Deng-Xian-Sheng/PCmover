using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x02000291 RID: 657
	[DataContract]
	public class BoxStyle : DevToolsDomainEntityBase
	{
		// Token: 0x1700066A RID: 1642
		// (get) Token: 0x060012CA RID: 4810 RVA: 0x000175DF File Offset: 0x000157DF
		// (set) Token: 0x060012CB RID: 4811 RVA: 0x000175E7 File Offset: 0x000157E7
		[DataMember(Name = "fillColor", IsRequired = false)]
		public RGBA FillColor { get; set; }

		// Token: 0x1700066B RID: 1643
		// (get) Token: 0x060012CC RID: 4812 RVA: 0x000175F0 File Offset: 0x000157F0
		// (set) Token: 0x060012CD RID: 4813 RVA: 0x000175F8 File Offset: 0x000157F8
		[DataMember(Name = "hatchColor", IsRequired = false)]
		public RGBA HatchColor { get; set; }
	}
}
