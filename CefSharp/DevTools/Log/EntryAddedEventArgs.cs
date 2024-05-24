using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.Log
{
	// Token: 0x0200031D RID: 797
	[DataContract]
	public class EntryAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000847 RID: 2119
		// (get) Token: 0x0600175E RID: 5982 RVA: 0x0001B631 File Offset: 0x00019831
		// (set) Token: 0x0600175F RID: 5983 RVA: 0x0001B639 File Offset: 0x00019839
		[DataMember(Name = "entry", IsRequired = true)]
		public LogEntry Entry { get; private set; }
	}
}
