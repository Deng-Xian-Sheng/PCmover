using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Page
{
	// Token: 0x02000260 RID: 608
	[DataContract]
	public class DocumentOpenedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x06001137 RID: 4407 RVA: 0x00015A96 File Offset: 0x00013C96
		// (set) Token: 0x06001138 RID: 4408 RVA: 0x00015A9E File Offset: 0x00013C9E
		[DataMember(Name = "frame", IsRequired = true)]
		public Frame Frame { get; private set; }
	}
}
