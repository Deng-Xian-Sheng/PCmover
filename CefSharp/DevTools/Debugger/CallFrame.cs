using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CefSharp.DevTools.Runtime;

namespace CefSharp.DevTools.Debugger
{
	// Token: 0x02000176 RID: 374
	[DataContract]
	public class CallFrame : DevToolsDomainEntityBase
	{
		// Token: 0x17000345 RID: 837
		// (get) Token: 0x06000AD3 RID: 2771 RVA: 0x00010004 File Offset: 0x0000E204
		// (set) Token: 0x06000AD4 RID: 2772 RVA: 0x0001000C File Offset: 0x0000E20C
		[DataMember(Name = "callFrameId", IsRequired = true)]
		public string CallFrameId { get; set; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06000AD5 RID: 2773 RVA: 0x00010015 File Offset: 0x0000E215
		// (set) Token: 0x06000AD6 RID: 2774 RVA: 0x0001001D File Offset: 0x0000E21D
		[DataMember(Name = "functionName", IsRequired = true)]
		public string FunctionName { get; set; }

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000AD7 RID: 2775 RVA: 0x00010026 File Offset: 0x0000E226
		// (set) Token: 0x06000AD8 RID: 2776 RVA: 0x0001002E File Offset: 0x0000E22E
		[DataMember(Name = "functionLocation", IsRequired = false)]
		public Location FunctionLocation { get; set; }

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000AD9 RID: 2777 RVA: 0x00010037 File Offset: 0x0000E237
		// (set) Token: 0x06000ADA RID: 2778 RVA: 0x0001003F File Offset: 0x0000E23F
		[DataMember(Name = "location", IsRequired = true)]
		public Location Location { get; set; }

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000ADB RID: 2779 RVA: 0x00010048 File Offset: 0x0000E248
		// (set) Token: 0x06000ADC RID: 2780 RVA: 0x00010050 File Offset: 0x0000E250
		[DataMember(Name = "url", IsRequired = true)]
		public string Url { get; set; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000ADD RID: 2781 RVA: 0x00010059 File Offset: 0x0000E259
		// (set) Token: 0x06000ADE RID: 2782 RVA: 0x00010061 File Offset: 0x0000E261
		[DataMember(Name = "scopeChain", IsRequired = true)]
		public IList<Scope> ScopeChain { get; set; }

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000ADF RID: 2783 RVA: 0x0001006A File Offset: 0x0000E26A
		// (set) Token: 0x06000AE0 RID: 2784 RVA: 0x00010072 File Offset: 0x0000E272
		[DataMember(Name = "this", IsRequired = true)]
		public RemoteObject This { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000AE1 RID: 2785 RVA: 0x0001007B File Offset: 0x0000E27B
		// (set) Token: 0x06000AE2 RID: 2786 RVA: 0x00010083 File Offset: 0x0000E283
		[DataMember(Name = "returnValue", IsRequired = false)]
		public RemoteObject ReturnValue { get; set; }
	}
}
