using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x02000167 RID: 359
	[DataContract]
	public class SamplingHeapProfileNode : DevToolsDomainEntityBase
	{
		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000A72 RID: 2674 RVA: 0x0000F9F0 File Offset: 0x0000DBF0
		// (set) Token: 0x06000A73 RID: 2675 RVA: 0x0000F9F8 File Offset: 0x0000DBF8
		[DataMember(Name = "callFrame", IsRequired = true)]
		public CallFrame CallFrame { get; set; }

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0000FA01 File Offset: 0x0000DC01
		// (set) Token: 0x06000A75 RID: 2677 RVA: 0x0000FA09 File Offset: 0x0000DC09
		[DataMember(Name = "selfSize", IsRequired = true)]
		public double SelfSize { get; set; }

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0000FA12 File Offset: 0x0000DC12
		// (set) Token: 0x06000A77 RID: 2679 RVA: 0x0000FA1A File Offset: 0x0000DC1A
		[DataMember(Name = "id", IsRequired = true)]
		public int Id { get; set; }

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0000FA23 File Offset: 0x0000DC23
		// (set) Token: 0x06000A79 RID: 2681 RVA: 0x0000FA2B File Offset: 0x0000DC2B
		[DataMember(Name = "children", IsRequired = true)]
		public IList<SamplingHeapProfileNode> Children { get; set; }
	}
}
