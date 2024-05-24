using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.IndexedDB
{
	// Token: 0x02000346 RID: 838
	[DataContract]
	public class GetMetadataResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x0600185D RID: 6237 RVA: 0x0001CC41 File Offset: 0x0001AE41
		// (set) Token: 0x0600185E RID: 6238 RVA: 0x0001CC49 File Offset: 0x0001AE49
		[DataMember]
		internal double entriesCount { get; set; }

		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x0600185F RID: 6239 RVA: 0x0001CC52 File Offset: 0x0001AE52
		public double EntriesCount
		{
			get
			{
				return this.entriesCount;
			}
		}

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x06001860 RID: 6240 RVA: 0x0001CC5A File Offset: 0x0001AE5A
		// (set) Token: 0x06001861 RID: 6241 RVA: 0x0001CC62 File Offset: 0x0001AE62
		[DataMember]
		internal double keyGeneratorValue { get; set; }

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x06001862 RID: 6242 RVA: 0x0001CC6B File Offset: 0x0001AE6B
		public double KeyGeneratorValue
		{
			get
			{
				return this.keyGeneratorValue;
			}
		}
	}
}
