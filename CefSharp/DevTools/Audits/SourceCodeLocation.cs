using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000419 RID: 1049
	[DataContract]
	public class SourceCodeLocation : DevToolsDomainEntityBase
	{
		// Token: 0x17000B12 RID: 2834
		// (get) Token: 0x06001E70 RID: 7792 RVA: 0x00022C90 File Offset: 0x00020E90
		// (set) Token: 0x06001E71 RID: 7793 RVA: 0x00022C98 File Offset: 0x00020E98
		[DataMember(Name = "scriptId", IsRequired = false)]
		public string ScriptId { get; set; }

		// Token: 0x17000B13 RID: 2835
		// (get) Token: 0x06001E72 RID: 7794 RVA: 0x00022CA1 File Offset: 0x00020EA1
		// (set) Token: 0x06001E73 RID: 7795 RVA: 0x00022CA9 File Offset: 0x00020EA9
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x17000B14 RID: 2836
		// (get) Token: 0x06001E74 RID: 7796 RVA: 0x00022CB2 File Offset: 0x00020EB2
		// (set) Token: 0x06001E75 RID: 7797 RVA: 0x00022CBA File Offset: 0x00020EBA
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x17000B15 RID: 2837
		// (get) Token: 0x06001E76 RID: 7798 RVA: 0x00022CC3 File Offset: 0x00020EC3
		// (set) Token: 0x06001E77 RID: 7799 RVA: 0x00022CCB File Offset: 0x00020ECB
		[DataMember(Name = "columnNumber", IsRequired = true)]
		public int ColumnNumber { get; set; }
	}
}
