using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F1 RID: 1009
	[DataContract]
	public class Bounds : DevToolsDomainEntityBase
	{
		// Token: 0x17000AB0 RID: 2736
		// (get) Token: 0x06001D81 RID: 7553 RVA: 0x00021E3D File Offset: 0x0002003D
		// (set) Token: 0x06001D82 RID: 7554 RVA: 0x00021E45 File Offset: 0x00020045
		[DataMember(Name = "left", IsRequired = false)]
		public int? Left { get; set; }

		// Token: 0x17000AB1 RID: 2737
		// (get) Token: 0x06001D83 RID: 7555 RVA: 0x00021E4E File Offset: 0x0002004E
		// (set) Token: 0x06001D84 RID: 7556 RVA: 0x00021E56 File Offset: 0x00020056
		[DataMember(Name = "top", IsRequired = false)]
		public int? Top { get; set; }

		// Token: 0x17000AB2 RID: 2738
		// (get) Token: 0x06001D85 RID: 7557 RVA: 0x00021E5F File Offset: 0x0002005F
		// (set) Token: 0x06001D86 RID: 7558 RVA: 0x00021E67 File Offset: 0x00020067
		[DataMember(Name = "width", IsRequired = false)]
		public int? Width { get; set; }

		// Token: 0x17000AB3 RID: 2739
		// (get) Token: 0x06001D87 RID: 7559 RVA: 0x00021E70 File Offset: 0x00020070
		// (set) Token: 0x06001D88 RID: 7560 RVA: 0x00021E78 File Offset: 0x00020078
		[DataMember(Name = "height", IsRequired = false)]
		public int? Height { get; set; }

		// Token: 0x17000AB4 RID: 2740
		// (get) Token: 0x06001D89 RID: 7561 RVA: 0x00021E81 File Offset: 0x00020081
		// (set) Token: 0x06001D8A RID: 7562 RVA: 0x00021E9D File Offset: 0x0002009D
		public WindowState? WindowState
		{
			get
			{
				return (WindowState?)DevToolsDomainEntityBase.StringToEnum(typeof(WindowState?), this.windowState);
			}
			set
			{
				this.windowState = DevToolsDomainEntityBase.EnumToString(value);
			}
		}

		// Token: 0x17000AB5 RID: 2741
		// (get) Token: 0x06001D8B RID: 7563 RVA: 0x00021EB0 File Offset: 0x000200B0
		// (set) Token: 0x06001D8C RID: 7564 RVA: 0x00021EB8 File Offset: 0x000200B8
		[DataMember(Name = "windowState", IsRequired = false)]
		internal string windowState { get; set; }
	}
}
