using System;

namespace System.Diagnostics.Tracing
{
	// Token: 0x02000423 RID: 1059
	public class EventSourceCreatedEventArgs : EventArgs
	{
		// Token: 0x170007D2 RID: 2002
		// (get) Token: 0x06003509 RID: 13577 RVA: 0x000CE300 File Offset: 0x000CC500
		// (set) Token: 0x0600350A RID: 13578 RVA: 0x000CE308 File Offset: 0x000CC508
		public EventSource EventSource { get; internal set; }
	}
}
