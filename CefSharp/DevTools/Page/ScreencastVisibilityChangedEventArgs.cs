using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x0200026F RID: 623
	[DataContract]
	public class ScreencastVisibilityChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x0600119F RID: 4511 RVA: 0x00015E99 File Offset: 0x00014099
		// (set) Token: 0x060011A0 RID: 4512 RVA: 0x00015EA1 File Offset: 0x000140A1
		[DataMember(Name = "visible", IsRequired = true)]
		public bool Visible { get; private set; }
	}
}
