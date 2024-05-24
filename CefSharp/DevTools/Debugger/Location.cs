using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000173 RID: 371
	[DataContract]
	public class Location : DevToolsDomainEntityBase
	{
		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0000FF64 File Offset: 0x0000E164
		// (set) Token: 0x06000AC1 RID: 2753 RVA: 0x0000FF6C File Offset: 0x0000E16C
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; set; }

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06000AC2 RID: 2754 RVA: 0x0000FF75 File Offset: 0x0000E175
		// (set) Token: 0x06000AC3 RID: 2755 RVA: 0x0000FF7D File Offset: 0x0000E17D
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06000AC4 RID: 2756 RVA: 0x0000FF86 File Offset: 0x0000E186
		// (set) Token: 0x06000AC5 RID: 2757 RVA: 0x0000FF8E File Offset: 0x0000E18E
		[DataMember(Name = "columnNumber", IsRequired = false)]
		public int? ColumnNumber { get; set; }
	}
}
