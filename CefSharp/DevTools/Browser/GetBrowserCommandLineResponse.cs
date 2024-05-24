using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x020003FC RID: 1020
	[DataContract]
	public class GetBrowserCommandLineResponse : DevToolsDomainResponseBase
	{
		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x06001DCD RID: 7629 RVA: 0x000220F9 File Offset: 0x000202F9
		// (set) Token: 0x06001DCE RID: 7630 RVA: 0x00022101 File Offset: 0x00020301
		[DataMember]
		internal string[] arguments { get; set; }

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x06001DCF RID: 7631 RVA: 0x0002210A File Offset: 0x0002030A
		public string[] Arguments
		{
			get
			{
				return this.arguments;
			}
		}
	}
}
