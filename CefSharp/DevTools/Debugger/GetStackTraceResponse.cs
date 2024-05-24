using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000188 RID: 392
	[DataContract]
	public class GetStackTraceResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06000B82 RID: 2946 RVA: 0x00010684 File Offset: 0x0000E884
		// (set) Token: 0x06000B83 RID: 2947 RVA: 0x0001068C File Offset: 0x0000E88C
		[DataMember]
		internal StackTrace stackTrace { get; set; }

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06000B84 RID: 2948 RVA: 0x00010695 File Offset: 0x0000E895
		public StackTrace StackTrace
		{
			get
			{
				return this.stackTrace;
			}
		}
	}
}
