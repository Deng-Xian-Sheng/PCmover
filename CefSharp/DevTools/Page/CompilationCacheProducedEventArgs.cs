using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000271 RID: 625
	[DataContract]
	public class CompilationCacheProducedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x060011AB RID: 4523 RVA: 0x00015EFE File Offset: 0x000140FE
		// (set) Token: 0x060011AC RID: 4524 RVA: 0x00015F06 File Offset: 0x00014106
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; private set; }

		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x060011AD RID: 4525 RVA: 0x00015F0F File Offset: 0x0001410F
		// (set) Token: 0x060011AE RID: 4526 RVA: 0x00015F17 File Offset: 0x00014117
		[DataMember(Name = "data", IsRequired = true)]
		public byte[] Data { get; private set; }
	}
}
