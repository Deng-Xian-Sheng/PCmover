using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x02000311 RID: 785
	[DataContract]
	public class Module : DevToolsDomainEntityBase
	{
		// Token: 0x17000826 RID: 2086
		// (get) Token: 0x06001710 RID: 5904 RVA: 0x0001B1BF File Offset: 0x000193BF
		// (set) Token: 0x06001711 RID: 5905 RVA: 0x0001B1C7 File Offset: 0x000193C7
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x17000827 RID: 2087
		// (get) Token: 0x06001712 RID: 5906 RVA: 0x0001B1D0 File Offset: 0x000193D0
		// (set) Token: 0x06001713 RID: 5907 RVA: 0x0001B1D8 File Offset: 0x000193D8
		[DataMember(Name = "uuid", IsRequired = true)]
		public string Uuid { get; set; }

		// Token: 0x17000828 RID: 2088
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x0001B1E1 File Offset: 0x000193E1
		// (set) Token: 0x06001715 RID: 5909 RVA: 0x0001B1E9 File Offset: 0x000193E9
		[DataMember(Name = "baseAddress", IsRequired = true)]
		public string BaseAddress { get; set; }

		// Token: 0x17000829 RID: 2089
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x0001B1F2 File Offset: 0x000193F2
		// (set) Token: 0x06001717 RID: 5911 RVA: 0x0001B1FA File Offset: 0x000193FA
		[DataMember(Name = "size", IsRequired = true)]
		public double Size { get; set; }
	}
}
