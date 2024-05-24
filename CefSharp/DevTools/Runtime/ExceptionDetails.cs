using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Runtime
{
	// Token: 0x0200013D RID: 317
	[DataContract]
	public class ExceptionDetails : DevToolsDomainEntityBase
	{
		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x06000926 RID: 2342 RVA: 0x0000E406 File Offset: 0x0000C606
		// (set) Token: 0x06000927 RID: 2343 RVA: 0x0000E40E File Offset: 0x0000C60E
		[DataMember(Name = "exceptionId", IsRequired = true)]
		public int ExceptionId { get; set; }

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x06000928 RID: 2344 RVA: 0x0000E417 File Offset: 0x0000C617
		// (set) Token: 0x06000929 RID: 2345 RVA: 0x0000E41F File Offset: 0x0000C61F
		[DataMember(Name = "text", IsRequired = true)]
		public string Text { get; set; }

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x0600092A RID: 2346 RVA: 0x0000E428 File Offset: 0x0000C628
		// (set) Token: 0x0600092B RID: 2347 RVA: 0x0000E430 File Offset: 0x0000C630
		[DataMember(Name = "lineNumber", IsRequired = true)]
		public int LineNumber { get; set; }

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x0600092C RID: 2348 RVA: 0x0000E439 File Offset: 0x0000C639
		// (set) Token: 0x0600092D RID: 2349 RVA: 0x0000E441 File Offset: 0x0000C641
		[DataMember(Name = "columnNumber", IsRequired = true)]
		public int ColumnNumber { get; set; }

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x0600092E RID: 2350 RVA: 0x0000E44A File Offset: 0x0000C64A
		// (set) Token: 0x0600092F RID: 2351 RVA: 0x0000E452 File Offset: 0x0000C652
		[DataMember(Name = "scriptId", IsRequired = false)]
		public string ScriptId { get; set; }

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000930 RID: 2352 RVA: 0x0000E45B File Offset: 0x0000C65B
		// (set) Token: 0x06000931 RID: 2353 RVA: 0x0000E463 File Offset: 0x0000C663
		[DataMember(Name = "url", IsRequired = false)]
		public string Url { get; set; }

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x0000E46C File Offset: 0x0000C66C
		// (set) Token: 0x06000933 RID: 2355 RVA: 0x0000E474 File Offset: 0x0000C674
		[DataMember(Name = "stackTrace", IsRequired = false)]
		public StackTrace StackTrace { get; set; }

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x06000934 RID: 2356 RVA: 0x0000E47D File Offset: 0x0000C67D
		// (set) Token: 0x06000935 RID: 2357 RVA: 0x0000E485 File Offset: 0x0000C685
		[DataMember(Name = "exception", IsRequired = false)]
		public RemoteObject Exception { get; set; }

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x06000936 RID: 2358 RVA: 0x0000E48E File Offset: 0x0000C68E
		// (set) Token: 0x06000937 RID: 2359 RVA: 0x0000E496 File Offset: 0x0000C696
		[DataMember(Name = "executionContextId", IsRequired = false)]
		public int? ExecutionContextId { get; set; }

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x0000E49F File Offset: 0x0000C69F
		// (set) Token: 0x06000939 RID: 2361 RVA: 0x0000E4A7 File Offset: 0x0000C6A7
		[DataMember(Name = "exceptionMetaData", IsRequired = false)]
		public object ExceptionMetaData { get; set; }
	}
}
