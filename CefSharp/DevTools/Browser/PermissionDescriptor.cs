using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003F4 RID: 1012
	[DataContract]
	public class PermissionDescriptor : DevToolsDomainEntityBase
	{
		// Token: 0x17000AB6 RID: 2742
		// (get) Token: 0x06001D8E RID: 7566 RVA: 0x00021EC9 File Offset: 0x000200C9
		// (set) Token: 0x06001D8F RID: 7567 RVA: 0x00021ED1 File Offset: 0x000200D1
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000AB7 RID: 2743
		// (get) Token: 0x06001D90 RID: 7568 RVA: 0x00021EDA File Offset: 0x000200DA
		// (set) Token: 0x06001D91 RID: 7569 RVA: 0x00021EE2 File Offset: 0x000200E2
		[DataMember(Name = "sysex", IsRequired = false)]
		public bool? Sysex { get; set; }

		// Token: 0x17000AB8 RID: 2744
		// (get) Token: 0x06001D92 RID: 7570 RVA: 0x00021EEB File Offset: 0x000200EB
		// (set) Token: 0x06001D93 RID: 7571 RVA: 0x00021EF3 File Offset: 0x000200F3
		[DataMember(Name = "userVisibleOnly", IsRequired = false)]
		public bool? UserVisibleOnly { get; set; }

		// Token: 0x17000AB9 RID: 2745
		// (get) Token: 0x06001D94 RID: 7572 RVA: 0x00021EFC File Offset: 0x000200FC
		// (set) Token: 0x06001D95 RID: 7573 RVA: 0x00021F04 File Offset: 0x00020104
		[DataMember(Name = "allowWithoutSanitization", IsRequired = false)]
		public bool? AllowWithoutSanitization { get; set; }

		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x06001D96 RID: 7574 RVA: 0x00021F0D File Offset: 0x0002010D
		// (set) Token: 0x06001D97 RID: 7575 RVA: 0x00021F15 File Offset: 0x00020115
		[DataMember(Name = "panTiltZoom", IsRequired = false)]
		public bool? PanTiltZoom { get; set; }
	}
}
