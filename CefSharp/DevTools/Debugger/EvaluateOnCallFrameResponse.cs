using System;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000185 RID: 389
	[DataContract]
	public class EvaluateOnCallFrameResponse : DevToolsDomainResponseBase
	{
		// Token: 0x1700038F RID: 911
		// (get) Token: 0x06000B70 RID: 2928 RVA: 0x000105E9 File Offset: 0x0000E7E9
		// (set) Token: 0x06000B71 RID: 2929 RVA: 0x000105F1 File Offset: 0x0000E7F1
		[DataMember]
		internal RemoteObject result { get; set; }

		// Token: 0x17000390 RID: 912
		// (get) Token: 0x06000B72 RID: 2930 RVA: 0x000105FA File Offset: 0x0000E7FA
		public RemoteObject Result
		{
			get
			{
				return this.result;
			}
		}

		// Token: 0x17000391 RID: 913
		// (get) Token: 0x06000B73 RID: 2931 RVA: 0x00010602 File Offset: 0x0000E802
		// (set) Token: 0x06000B74 RID: 2932 RVA: 0x0001060A File Offset: 0x0000E80A
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06000B75 RID: 2933 RVA: 0x00010613 File Offset: 0x0000E813
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
