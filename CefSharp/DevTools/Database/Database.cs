using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Database
{
	// Token: 0x0200035D RID: 861
	[DataContract]
	public class Database : DevToolsDomainEntityBase
	{
		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x060018DA RID: 6362 RVA: 0x0001DA96 File Offset: 0x0001BC96
		// (set) Token: 0x060018DB RID: 6363 RVA: 0x0001DA9E File Offset: 0x0001BC9E
		[DataMember(Name = "id", IsRequired = true)]
		public string Id { get; set; }

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x060018DC RID: 6364 RVA: 0x0001DAA7 File Offset: 0x0001BCA7
		// (set) Token: 0x060018DD RID: 6365 RVA: 0x0001DAAF File Offset: 0x0001BCAF
		[DataMember(Name = "domain", IsRequired = true)]
		public string Domain { get; set; }

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x060018DE RID: 6366 RVA: 0x0001DAB8 File Offset: 0x0001BCB8
		// (set) Token: 0x060018DF RID: 6367 RVA: 0x0001DAC0 File Offset: 0x0001BCC0
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x060018E0 RID: 6368 RVA: 0x0001DAC9 File Offset: 0x0001BCC9
		// (set) Token: 0x060018E1 RID: 6369 RVA: 0x0001DAD1 File Offset: 0x0001BCD1
		[DataMember(Name = "version", IsRequired = true)]
		public string Version { get; set; }
	}
}
