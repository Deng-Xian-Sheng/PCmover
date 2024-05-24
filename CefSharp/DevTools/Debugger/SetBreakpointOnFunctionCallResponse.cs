using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x0200018D RID: 397
	[DataContract]
	public class SetBreakpointOnFunctionCallResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000B9C RID: 2972 RVA: 0x0001075B File Offset: 0x0000E95B
		// (set) Token: 0x06000B9D RID: 2973 RVA: 0x00010763 File Offset: 0x0000E963
		[DataMember]
		internal string breakpointId { get; set; }

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000B9E RID: 2974 RVA: 0x0001076C File Offset: 0x0000E96C
		public string BreakpointId
		{
			get
			{
				return this.breakpointId;
			}
		}
	}
}
