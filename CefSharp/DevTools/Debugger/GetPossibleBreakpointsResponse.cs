using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000186 RID: 390
	[DataContract]
	public class GetPossibleBreakpointsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06000B77 RID: 2935 RVA: 0x00010623 File Offset: 0x0000E823
		// (set) Token: 0x06000B78 RID: 2936 RVA: 0x0001062B File Offset: 0x0000E82B
		[DataMember]
		internal IList<BreakLocation> locations { get; set; }

		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06000B79 RID: 2937 RVA: 0x00010634 File Offset: 0x0000E834
		public IList<BreakLocation> Locations
		{
			get
			{
				return this.locations;
			}
		}
	}
}
