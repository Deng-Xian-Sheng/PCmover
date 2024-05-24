using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000165 RID: 357
	[DataContract]
	public class TakeTypeProfileResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x0000F74F File Offset: 0x0000D94F
		// (set) Token: 0x06000A5C RID: 2652 RVA: 0x0000F757 File Offset: 0x0000D957
		[DataMember]
		internal IList<ScriptTypeProfile> result { get; set; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x0000F760 File Offset: 0x0000D960
		public IList<ScriptTypeProfile> Result
		{
			get
			{
				return this.result;
			}
		}
	}
}
