using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.PerformanceTimeline
{
	// Token: 0x02000227 RID: 551
	public class PerformanceTimelineClient : DevToolsDomainBase
	{
		// Token: 0x06000FFC RID: 4092 RVA: 0x00014D72 File Offset: 0x00012F72
		public PerformanceTimelineClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000054 RID: 84
		// (add) Token: 0x06000FFD RID: 4093 RVA: 0x00014D81 File Offset: 0x00012F81
		// (remove) Token: 0x06000FFE RID: 4094 RVA: 0x00014D94 File Offset: 0x00012F94
		public event EventHandler<TimelineEventAddedEventArgs> TimelineEventAdded
		{
			add
			{
				this._client.AddEventHandler<TimelineEventAddedEventArgs>("PerformanceTimeline.timelineEventAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<TimelineEventAddedEventArgs>("PerformanceTimeline.timelineEventAdded", value);
			}
		}

		// Token: 0x06000FFF RID: 4095 RVA: 0x00014DA8 File Offset: 0x00012FA8
		public Task<DevToolsMethodResponse> EnableAsync(string[] eventTypes)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("eventTypes", eventTypes);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("PerformanceTimeline.enable", dictionary);
		}

		// Token: 0x0400081F RID: 2079
		private IDevToolsClient _client;
	}
}
