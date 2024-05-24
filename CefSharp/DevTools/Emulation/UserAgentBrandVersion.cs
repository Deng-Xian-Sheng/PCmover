using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Emulation
{
	// Token: 0x02000355 RID: 853
	[DataContract]
	public class UserAgentBrandVersion : DevToolsDomainEntityBase
	{
		// Token: 0x170008C0 RID: 2240
		// (get) Token: 0x060018A0 RID: 6304 RVA: 0x0001D1BD File Offset: 0x0001B3BD
		// (set) Token: 0x060018A1 RID: 6305 RVA: 0x0001D1C5 File Offset: 0x0001B3C5
		[DataMember(Name = "brand", IsRequired = true)]
		public string Brand { get; set; }

		// Token: 0x170008C1 RID: 2241
		// (get) Token: 0x060018A2 RID: 6306 RVA: 0x0001D1CE File Offset: 0x0001B3CE
		// (set) Token: 0x060018A3 RID: 6307 RVA: 0x0001D1D6 File Offset: 0x0001B3D6
		[DataMember(Name = "version", IsRequired = true)]
		public string Version { get; set; }
	}
}
