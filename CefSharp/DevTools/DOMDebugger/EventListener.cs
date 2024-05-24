using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.DOMDebugger
{
	// Token: 0x0200037A RID: 890
	[DataContract]
	public class EventListener : DevToolsDomainEntityBase
	{
		// Token: 0x1700094D RID: 2381
		// (get) Token: 0x06001A03 RID: 6659 RVA: 0x0001E790 File Offset: 0x0001C990
		// (set) Token: 0x06001A04 RID: 6660 RVA: 0x0001E798 File Offset: 0x0001C998
		[DataMember(Name = "type", IsRequired = true)]
		public string Type { get; set; }

		// Token: 0x1700094E RID: 2382
		// (get) Token: 0x06001A05 RID: 6661 RVA: 0x0001E7A1 File Offset: 0x0001C9A1
		// (set) Token: 0x06001A06 RID: 6662 RVA: 0x0001E7A9 File Offset: 0x0001C9A9
		[DataMember(Name = "useCapture", IsRequired = true)]
		public bool UseCapture { get; set; }

		// Token: 0x1700094F RID: 2383
		// (get) Token: 0x06001A07 RID: 6663 RVA: 0x0001E7B2 File Offset: 0x0001C9B2
		// (set) Token: 0x06001A08 RID: 6664 RVA: 0x0001E7BA File Offset: 0x0001C9BA
		[DataMember(Name = "passive", IsRequired = true)]
		public bool Passive { get; set; }

		// Token: 0x17000950 RID: 2384
		// (get) Token: 0x06001A09 RID: 6665 RVA: 0x0001E7C3 File Offset: 0x0001C9C3
		// (set) Token: 0x06001A0A RID: 6666 RVA: 0x0001E7CB File Offset: 0x0001C9CB
		[DataMember(Name = "once", IsRequired = true)]
		public bool Once { get; set; }

		// Token: 0x17000951 RID: 2385
		// (get) Token: 0x06001A0B RID: 6667 RVA: 0x0001E7D4 File Offset: 0x0001C9D4
		// (set) Token: 0x06001A0C RID: 6668 RVA: 0x0001E7DC File Offset: 0x0001C9DC
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; set; }

		// Token: 0x17000952 RID: 2386
		// (get) Token: 0x06001A0D RID: 6669 RVA: 0x0001E7E5 File Offset: 0x0001C9E5
		// (set) Token: 0x06001A0E RID: 6670 RVA: 0x0001E7ED File Offset: 0x0001C9ED
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x17000953 RID: 2387
		// (get) Token: 0x06001A0F RID: 6671 RVA: 0x0001E7F6 File Offset: 0x0001C9F6
		// (set) Token: 0x06001A10 RID: 6672 RVA: 0x0001E7FE File Offset: 0x0001C9FE
		[DataMember(Name = "columnNumber", IsRequired = true)]
		public int ColumnNumber { get; set; }

		// Token: 0x17000954 RID: 2388
		// (get) Token: 0x06001A11 RID: 6673 RVA: 0x0001E807 File Offset: 0x0001CA07
		// (set) Token: 0x06001A12 RID: 6674 RVA: 0x0001E80F File Offset: 0x0001CA0F
		[DataMember(Name = "handler", IsRequired = false)]
		public RemoteObject Handler { get; set; }

		// Token: 0x17000955 RID: 2389
		// (get) Token: 0x06001A13 RID: 6675 RVA: 0x0001E818 File Offset: 0x0001CA18
		// (set) Token: 0x06001A14 RID: 6676 RVA: 0x0001E820 File Offset: 0x0001CA20
		[DataMember(Name = "originalHandler", IsRequired = false)]
		public RemoteObject OriginalHandler { get; set; }

		// Token: 0x17000956 RID: 2390
		// (get) Token: 0x06001A15 RID: 6677 RVA: 0x0001E829 File Offset: 0x0001CA29
		// (set) Token: 0x06001A16 RID: 6678 RVA: 0x0001E831 File Offset: 0x0001CA31
		[DataMember(Name = "backendNodeId", IsRequired = false)]
		public int? BackendNodeId { get; set; }
	}
}
