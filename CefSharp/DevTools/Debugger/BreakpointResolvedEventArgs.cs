using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200017F RID: 383
	[DataContract]
	public class BreakpointResolvedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000B08 RID: 2824 RVA: 0x0001021E File Offset: 0x0000E41E
		// (set) Token: 0x06000B09 RID: 2825 RVA: 0x00010226 File Offset: 0x0000E426
		[DataMember(Name = "breakpointId", IsRequired = true)]
		public string BreakpointId { get; private set; }

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000B0A RID: 2826 RVA: 0x0001022F File Offset: 0x0000E42F
		// (set) Token: 0x06000B0B RID: 2827 RVA: 0x00010237 File Offset: 0x0000E437
		[DataMember(Name = "location", IsRequired = true)]
		public Location Location { get; private set; }
	}
}
