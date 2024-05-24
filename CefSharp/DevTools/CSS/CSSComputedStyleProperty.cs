using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.CSS
{
	// Token: 0x020003C8 RID: 968
	[DataContract]
	public class CSSComputedStyleProperty : DevToolsDomainEntityBase
	{
		// Token: 0x17000A33 RID: 2611
		// (get) Token: 0x06001C58 RID: 7256 RVA: 0x00020EA0 File Offset: 0x0001F0A0
		// (set) Token: 0x06001C59 RID: 7257 RVA: 0x00020EA8 File Offset: 0x0001F0A8
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000A34 RID: 2612
		// (get) Token: 0x06001C5A RID: 7258 RVA: 0x00020EB1 File Offset: 0x0001F0B1
		// (set) Token: 0x06001C5B RID: 7259 RVA: 0x00020EB9 File Offset: 0x0001F0B9
		[DataMember(Name = "value", IsRequired = true)]
		public string Value { get; set; }
	}
}
