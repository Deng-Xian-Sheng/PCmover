using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Security
{
	// Token: 0x0200021F RID: 543
	[DataContract]
	public class VisibleSecurityStateChangedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x00014A93 File Offset: 0x00012C93
		// (set) Token: 0x06000FB8 RID: 4024 RVA: 0x00014A9B File Offset: 0x00012C9B
		[DataMember(Name = "visibleSecurityState", IsRequired = true)]
		public VisibleSecurityState VisibleSecurityState { get; private set; }
	}
}
