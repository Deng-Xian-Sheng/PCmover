using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000179 RID: 377
	[DataContract]
	public class SearchMatch : DevToolsDomainEntityBase
	{
		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000AF1 RID: 2801 RVA: 0x00010120 File Offset: 0x0000E320
		// (set) Token: 0x06000AF2 RID: 2802 RVA: 0x00010128 File Offset: 0x0000E328
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public double LineNumber { get; set; }

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000AF3 RID: 2803 RVA: 0x00010131 File Offset: 0x0000E331
		// (set) Token: 0x06000AF4 RID: 2804 RVA: 0x00010139 File Offset: 0x0000E339
		[DataMember(Name = "lineContent", IsRequired = true)]
		public string LineContent { get; set; }
	}
}
