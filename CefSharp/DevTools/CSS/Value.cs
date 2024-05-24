using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C1 RID: 961
	[DataContract]
	public class Value : DevToolsDomainEntityBase
	{
		// Token: 0x17000A0A RID: 2570
		// (get) Token: 0x06001BFF RID: 7167 RVA: 0x00020B73 File Offset: 0x0001ED73
		// (set) Token: 0x06001C00 RID: 7168 RVA: 0x00020B7B File Offset: 0x0001ED7B
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }

		// Token: 0x17000A0B RID: 2571
		// (get) Token: 0x06001C01 RID: 7169 RVA: 0x00020B84 File Offset: 0x0001ED84
		// (set) Token: 0x06001C02 RID: 7170 RVA: 0x00020B8C File Offset: 0x0001ED8C
		[DataMember(Name = "range", IsRequired = false)]
		public SourceRange Range { get; set; }
	}
}
