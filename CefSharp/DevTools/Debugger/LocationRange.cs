using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000175 RID: 373
	[DataContract]
	public class LocationRange : DevToolsDomainEntityBase
	{
		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06000ACC RID: 2764 RVA: 0x0000FFC9 File Offset: 0x0000E1C9
		// (set) Token: 0x06000ACD RID: 2765 RVA: 0x0000FFD1 File Offset: 0x0000E1D1
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; set; }

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06000ACE RID: 2766 RVA: 0x0000FFDA File Offset: 0x0000E1DA
		// (set) Token: 0x06000ACF RID: 2767 RVA: 0x0000FFE2 File Offset: 0x0000E1E2
		[DataMember(Name = "start", IsRequired = true)]
		public ScriptPosition Start { get; set; }

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06000AD0 RID: 2768 RVA: 0x0000FFEB File Offset: 0x0000E1EB
		// (set) Token: 0x06000AD1 RID: 2769 RVA: 0x0000FFF3 File Offset: 0x0000E1F3
		[DataMember(Name = "end", IsRequired = true)]
		public ScriptPosition End { get; set; }
	}
}
