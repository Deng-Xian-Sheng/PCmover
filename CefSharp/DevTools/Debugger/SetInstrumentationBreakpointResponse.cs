using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200018B RID: 395
	[DataContract]
	public class SetInstrumentationBreakpointResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06000B91 RID: 2961 RVA: 0x00010700 File Offset: 0x0000E900
		// (set) Token: 0x06000B92 RID: 2962 RVA: 0x00010708 File Offset: 0x0000E908
		[DataMember]
		internal string breakpointId { get; set; }

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06000B93 RID: 2963 RVA: 0x00010711 File Offset: 0x0000E911
		public string BreakpointId
		{
			get
			{
				return this.breakpointId;
			}
		}
	}
}
