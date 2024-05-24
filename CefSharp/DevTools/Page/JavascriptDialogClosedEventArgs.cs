using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000268 RID: 616
	[DataContract]
	public class JavascriptDialogClosedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x0600116C RID: 4460 RVA: 0x00015CCD File Offset: 0x00013ECD
		// (set) Token: 0x0600116D RID: 4461 RVA: 0x00015CD5 File Offset: 0x00013ED5
		[DataMember(Name = "result", IsRequired = true)]
		public bool Result { get; private set; }

		// Token: 0x170005EA RID: 1514
		// (get) Token: 0x0600116E RID: 4462 RVA: 0x00015CDE File Offset: 0x00013EDE
		// (set) Token: 0x0600116F RID: 4463 RVA: 0x00015CE6 File Offset: 0x00013EE6
		[DataMember(Name = "userInput", IsRequired = true)]
		public string UserInput { get; private set; }
	}
}
