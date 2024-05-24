using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200018A RID: 394
	[DataContract]
	public class SetBreakpointResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000B8A RID: 2954 RVA: 0x000106C6 File Offset: 0x0000E8C6
		// (set) Token: 0x06000B8B RID: 2955 RVA: 0x000106CE File Offset: 0x0000E8CE
		[DataMember]
		internal string breakpointId { get; set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06000B8C RID: 2956 RVA: 0x000106D7 File Offset: 0x0000E8D7
		public string BreakpointId
		{
			get
			{
				return this.breakpointId;
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000B8D RID: 2957 RVA: 0x000106DF File Offset: 0x0000E8DF
		// (set) Token: 0x06000B8E RID: 2958 RVA: 0x000106E7 File Offset: 0x0000E8E7
		[DataMember]
		internal Location actualLocation { get; set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06000B8F RID: 2959 RVA: 0x000106F0 File Offset: 0x0000E8F0
		public Location ActualLocation
		{
			get
			{
				return this.actualLocation;
			}
		}
	}
}
