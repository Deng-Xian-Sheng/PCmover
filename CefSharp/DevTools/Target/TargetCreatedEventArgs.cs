using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001E2 RID: 482
	[DataContract]
	public class TargetCreatedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x00012F34 File Offset: 0x00011134
		// (set) Token: 0x06000DE3 RID: 3555 RVA: 0x00012F3C File Offset: 0x0001113C
		[DataMember(Name = "targetInfo", IsRequired = true)]
		public TargetInfo TargetInfo { get; private set; }
	}
}
