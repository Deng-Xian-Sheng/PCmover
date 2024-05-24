using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000270 RID: 624
	[DataContract]
	public class WindowOpenEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x060011A2 RID: 4514 RVA: 0x00015EB2 File Offset: 0x000140B2
		// (set) Token: 0x060011A3 RID: 4515 RVA: 0x00015EBA File Offset: 0x000140BA
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x060011A4 RID: 4516 RVA: 0x00015EC3 File Offset: 0x000140C3
		// (set) Token: 0x060011A5 RID: 4517 RVA: 0x00015ECB File Offset: 0x000140CB
		[DataMember(Name = "windowName", IsRequired = true)]
		public string WindowName { get; private set; }

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x060011A6 RID: 4518 RVA: 0x00015ED4 File Offset: 0x000140D4
		// (set) Token: 0x060011A7 RID: 4519 RVA: 0x00015EDC File Offset: 0x000140DC
		[DataMember(Name = "windowFeatures", IsRequired = true)]
		public string[] WindowFeatures { get; private set; }

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x060011A8 RID: 4520 RVA: 0x00015EE5 File Offset: 0x000140E5
		// (set) Token: 0x060011A9 RID: 4521 RVA: 0x00015EED File Offset: 0x000140ED
		[DataMember(Name = "userGesture", IsRequired = true)]
		public bool UserGesture { get; private set; }
	}
}
