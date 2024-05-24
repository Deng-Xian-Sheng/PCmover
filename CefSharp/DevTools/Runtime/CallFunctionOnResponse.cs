using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200014A RID: 330
	[DataContract]
	public class CallFunctionOnResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x0000E75E File Offset: 0x0000C95E
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x0000E766 File Offset: 0x0000C966
		[DataMember]
		internal RemoteObject result { get; set; }

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x0000E76F File Offset: 0x0000C96F
		public RemoteObject Result
		{
			get
			{
				return this.result;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x0000E777 File Offset: 0x0000C977
		// (set) Token: 0x0600098C RID: 2444 RVA: 0x0000E77F File Offset: 0x0000C97F
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x0600098D RID: 2445 RVA: 0x0000E788 File Offset: 0x0000C988
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
