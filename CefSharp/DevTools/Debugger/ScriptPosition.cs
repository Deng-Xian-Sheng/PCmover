using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000174 RID: 372
	[DataContract]
	public class ScriptPosition : DevToolsDomainEntityBase
	{
		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06000AC7 RID: 2759 RVA: 0x0000FF9F File Offset: 0x0000E19F
		// (set) Token: 0x06000AC8 RID: 2760 RVA: 0x0000FFA7 File Offset: 0x0000E1A7
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06000AC9 RID: 2761 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		// (set) Token: 0x06000ACA RID: 2762 RVA: 0x0000FFB8 File Offset: 0x0000E1B8
		[DataMember(Name = "columnNumber", IsRequired = true)]
		public int ColumnNumber { get; set; }
	}
}
