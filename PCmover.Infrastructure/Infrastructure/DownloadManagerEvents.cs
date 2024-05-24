using System;
using System.Collections.Generic;
using Laplink.Download.Contracts;
using Prism.Events;

namespace PCmover.Infrastructure
{
	// Token: 0x02000012 RID: 18
	public class DownloadManagerEvents
	{
		// Token: 0x0200006B RID: 107
		public class PackageUpdatedEvent : PubSubEvent<DownloadPackage>
		{
		}

		// Token: 0x0200006C RID: 108
		public class DownloadManagerCompletedEvent : PubSubEvent<bool>
		{
		}

		// Token: 0x0200006D RID: 109
		public class DownloadManagerRebootRequiredEvent : PubSubEvent
		{
		}

		// Token: 0x0200006E RID: 110
		public class DownloadManagerDisplayErrorEvent : PubSubEvent<IEnumerable<string>>
		{
		}
	}
}
