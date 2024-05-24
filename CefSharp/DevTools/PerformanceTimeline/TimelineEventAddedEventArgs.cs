using System;
using System.Runtime.Serialization;

namespace CefSharp.DevTools.PerformanceTimeline
{
	// Token: 0x02000226 RID: 550
	[DataContract]
	public class TimelineEventAddedEventArgs : DevToolsDomainEventArgsBase
	{
		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x00014D59 File Offset: 0x00012F59
		// (set) Token: 0x06000FFA RID: 4090 RVA: 0x00014D61 File Offset: 0x00012F61
		[DataMember(Name = "event", IsRequired = true)]
		public TimelineEvent Event { get; private set; }
	}
}
