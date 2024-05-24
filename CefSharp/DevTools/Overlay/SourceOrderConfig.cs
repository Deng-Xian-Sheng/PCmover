using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.Overlay
{
	// Token: 0x0200028B RID: 651
	[DataContract]
	public class SourceOrderConfig : DevToolsDomainEntityBase
	{
		// Token: 0x17000646 RID: 1606
		// (get) Token: 0x0600127D RID: 4733 RVA: 0x00017335 File Offset: 0x00015535
		// (set) Token: 0x0600127E RID: 4734 RVA: 0x0001733D File Offset: 0x0001553D
		[DataMember(Name = "parentOutlineColor", IsRequired = true)]
		public RGBA ParentOutlineColor { get; set; }

		// Token: 0x17000647 RID: 1607
		// (get) Token: 0x0600127F RID: 4735 RVA: 0x00017346 File Offset: 0x00015546
		// (set) Token: 0x06001280 RID: 4736 RVA: 0x0001734E File Offset: 0x0001554E
		[DataMember(Name = "childOutlineColor", IsRequired = true)]
		public RGBA ChildOutlineColor { get; set; }
	}
}
