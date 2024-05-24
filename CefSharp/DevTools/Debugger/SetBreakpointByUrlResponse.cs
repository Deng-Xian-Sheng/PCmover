using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200018C RID: 396
	[DataContract]
	public class SetBreakpointByUrlResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000B95 RID: 2965 RVA: 0x00010721 File Offset: 0x0000E921
		// (set) Token: 0x06000B96 RID: 2966 RVA: 0x00010729 File Offset: 0x0000E929
		[DataMember]
		internal string breakpointId { get; set; }

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000B97 RID: 2967 RVA: 0x00010732 File Offset: 0x0000E932
		public string BreakpointId
		{
			get
			{
				return this.breakpointId;
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000B98 RID: 2968 RVA: 0x0001073A File Offset: 0x0000E93A
		// (set) Token: 0x06000B99 RID: 2969 RVA: 0x00010742 File Offset: 0x0000E942
		[DataMember]
		internal IList<Location> locations { get; set; }

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000B9A RID: 2970 RVA: 0x0001074B File Offset: 0x0000E94B
		public IList<Location> Locations
		{
			get
			{
				return this.locations;
			}
		}
	}
}
