using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x0200015B RID: 347
	[DataContract]
	public class TypeObject : DevToolsDomainEntityBase
	{
		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000A22 RID: 2594 RVA: 0x0000F572 File Offset: 0x0000D772
		// (set) Token: 0x06000A23 RID: 2595 RVA: 0x0000F57A File Offset: 0x0000D77A
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }
	}
}
