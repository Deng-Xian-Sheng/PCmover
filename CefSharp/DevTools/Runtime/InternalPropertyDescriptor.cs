using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000139 RID: 313
	[DataContract]
	public class InternalPropertyDescriptor : DevToolsDomainEntityBase
	{
		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0000E2F8 File Offset: 0x0000C4F8
		// (set) Token: 0x06000907 RID: 2311 RVA: 0x0000E300 File Offset: 0x0000C500
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0000E309 File Offset: 0x0000C509
		// (set) Token: 0x06000909 RID: 2313 RVA: 0x0000E311 File Offset: 0x0000C511
		[DataMember(Name = "value", IsRequired = false)]
		public RemoteObject Value { get; set; }
	}
}
