using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000153 RID: 339
	[DataContract]
	public class GetExceptionDetailsResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x0000E94F File Offset: 0x0000CB4F
		// (set) Token: 0x060009C5 RID: 2501 RVA: 0x0000E957 File Offset: 0x0000CB57
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0000E960 File Offset: 0x0000CB60
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
