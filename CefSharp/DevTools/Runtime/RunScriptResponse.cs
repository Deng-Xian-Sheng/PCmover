using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x02000152 RID: 338
	[DataContract]
	public class RunScriptResponse : DevToolsDomainResponseBase
	{
		// Token: 0x170002ED RID: 749
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x0000E915 File Offset: 0x0000CB15
		// (set) Token: 0x060009BE RID: 2494 RVA: 0x0000E91D File Offset: 0x0000CB1D
		[DataMember]
		internal RemoteObject result { get; set; }

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0000E926 File Offset: 0x0000CB26
		public RemoteObject Result
		{
			get
			{
				return this.result;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0000E92E File Offset: 0x0000CB2E
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x0000E936 File Offset: 0x0000CB36
		[DataMember]
		internal ExceptionDetails exceptionDetails { get; set; }

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x0000E93F File Offset: 0x0000CB3F
		public ExceptionDetails ExceptionDetails
		{
			get
			{
				return this.exceptionDetails;
			}
		}
	}
}
