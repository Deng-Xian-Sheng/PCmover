using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Database
{
	// Token: 0x0200035E RID: 862
	[DataContract]
	public class Error : DevToolsDomainEntityBase
	{
		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x060018E3 RID: 6371 RVA: 0x0001DAE2 File Offset: 0x0001BCE2
		// (set) Token: 0x060018E4 RID: 6372 RVA: 0x0001DAEA File Offset: 0x0001BCEA
		[DataMember(Name = "message", IsRequired = true)]
		public string Message { get; set; }

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x060018E5 RID: 6373 RVA: 0x0001DAF3 File Offset: 0x0001BCF3
		// (set) Token: 0x060018E6 RID: 6374 RVA: 0x0001DAFB File Offset: 0x0001BCFB
		[DataMember(Name = "code", IsRequired = true)]
		public int Code { get; set; }
	}
}
