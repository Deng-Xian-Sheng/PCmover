using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200013A RID: 314
	[DataContract]
	public class PrivatePropertyDescriptor : DevToolsDomainEntityBase
	{
		// Token: 0x17000297 RID: 663
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x0000E322 File Offset: 0x0000C522
		// (set) Token: 0x0600090C RID: 2316 RVA: 0x0000E32A File Offset: 0x0000C52A
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x0600090D RID: 2317 RVA: 0x0000E333 File Offset: 0x0000C533
		// (set) Token: 0x0600090E RID: 2318 RVA: 0x0000E33B File Offset: 0x0000C53B
		[DataMember(Name = "value", IsRequired = false)]
		public RemoteObject Value { get; set; }

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0000E344 File Offset: 0x0000C544
		// (set) Token: 0x06000910 RID: 2320 RVA: 0x0000E34C File Offset: 0x0000C54C
		[DataMember(Name = "get", IsRequired = false)]
		public RemoteObject Get { get; set; }

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0000E355 File Offset: 0x0000C555
		// (set) Token: 0x06000912 RID: 2322 RVA: 0x0000E35D File Offset: 0x0000C55D
		[DataMember(Name = "set", IsRequired = false)]
		public RemoteObject Set { get; set; }
	}
}
