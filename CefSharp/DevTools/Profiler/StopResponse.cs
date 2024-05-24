using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000163 RID: 355
	[DataContract]
	public class StopResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06000A50 RID: 2640 RVA: 0x0000F6F4 File Offset: 0x0000D8F4
		// (set) Token: 0x06000A51 RID: 2641 RVA: 0x0000F6FC File Offset: 0x0000D8FC
		[DataMember]
		internal Profile profile { get; set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x0000F705 File Offset: 0x0000D905
		public Profile Profile
		{
			get
			{
				return this.profile;
			}
		}
	}
}
