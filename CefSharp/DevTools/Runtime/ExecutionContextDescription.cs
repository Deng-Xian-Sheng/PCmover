using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200013C RID: 316
	[DataContract]
	public class ExecutionContextDescription : DevToolsDomainEntityBase
	{
		// Token: 0x1700029E RID: 670
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x0000E3A9 File Offset: 0x0000C5A9
		// (set) Token: 0x0600091C RID: 2332 RVA: 0x0000E3B1 File Offset: 0x0000C5B1
		[DataMember(Name = "id", IsRequired = true)]
		public int Id { get; set; }

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x0000E3BA File Offset: 0x0000C5BA
		// (set) Token: 0x0600091E RID: 2334 RVA: 0x0000E3C2 File Offset: 0x0000C5C2
		[DataMember(Name = "origin", IsRequired = true)]
		public string Origin { get; set; }

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x0000E3CB File Offset: 0x0000C5CB
		// (set) Token: 0x06000920 RID: 2336 RVA: 0x0000E3D3 File Offset: 0x0000C5D3
		[DataMember(Name = "name", IsRequired = true)]
		public string Name { get; set; }

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x06000921 RID: 2337 RVA: 0x0000E3DC File Offset: 0x0000C5DC
		// (set) Token: 0x06000922 RID: 2338 RVA: 0x0000E3E4 File Offset: 0x0000C5E4
		[DataMember(Name = "uniqueId", IsRequired = true)]
		public string UniqueId { get; set; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x06000923 RID: 2339 RVA: 0x0000E3ED File Offset: 0x0000C5ED
		// (set) Token: 0x06000924 RID: 2340 RVA: 0x0000E3F5 File Offset: 0x0000C5F5
		[DataMember(Name = "auxData", IsRequired = false)]
		public object AuxData { get; set; }
	}
}
