using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200013E RID: 318
	[DataContract]
	public class CallFrame : DevToolsDomainEntityBase
	{
		// Token: 0x170002AD RID: 685
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x0000E4B8 File Offset: 0x0000C6B8
		// (set) Token: 0x0600093C RID: 2364 RVA: 0x0000E4C0 File Offset: 0x0000C6C0
		[DataMember(Name = "functionName", IsRequired = true)]
		public string FunctionName { get; set; }

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x0000E4C9 File Offset: 0x0000C6C9
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x0000E4D1 File Offset: 0x0000C6D1
		[DataMember(Name = "scriptId", IsRequired = true)]
		public string ScriptId { get; set; }

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x0000E4DA File Offset: 0x0000C6DA
		// (set) Token: 0x06000940 RID: 2368 RVA: 0x0000E4E2 File Offset: 0x0000C6E2
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x0000E4EB File Offset: 0x0000C6EB
		// (set) Token: 0x06000942 RID: 2370 RVA: 0x0000E4F3 File Offset: 0x0000C6F3
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x0000E4FC File Offset: 0x0000C6FC
		// (set) Token: 0x06000944 RID: 2372 RVA: 0x0000E504 File Offset: 0x0000C704
		[DataMember(Name = "columnNumber", IsRequired = true)]
		public int ColumnNumber { get; set; }
	}
}
