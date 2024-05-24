using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.BackgroundService
{
	// Token: 0x02000408 RID: 1032
	public class BackgroundServiceClient : DevToolsDomainBase
	{
		// Token: 0x06001E1A RID: 7706 RVA: 0x000227C1 File Offset: 0x000209C1
		public BackgroundServiceClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x140000B1 RID: 177
		// (add) Token: 0x06001E1B RID: 7707 RVA: 0x000227D0 File Offset: 0x000209D0
		// (remove) Token: 0x06001E1C RID: 7708 RVA: 0x000227E3 File Offset: 0x000209E3
		public event EventHandler<RecordingStateChangedEventArgs> RecordingStateChanged
		{
			add
			{
				this._client.AddEventHandler<RecordingStateChangedEventArgs>("BackgroundService.recordingStateChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<RecordingStateChangedEventArgs>("BackgroundService.recordingStateChanged", value);
			}
		}

		// Token: 0x140000B2 RID: 178
		// (add) Token: 0x06001E1D RID: 7709 RVA: 0x000227F7 File Offset: 0x000209F7
		// (remove) Token: 0x06001E1E RID: 7710 RVA: 0x0002280A File Offset: 0x00020A0A
		public event EventHandler<BackgroundServiceEventReceivedEventArgs> BackgroundServiceEventReceived
		{
			add
			{
				this._client.AddEventHandler<BackgroundServiceEventReceivedEventArgs>("BackgroundService.backgroundServiceEventReceived", value);
			}
			remove
			{
				this._client.RemoveEventHandler<BackgroundServiceEventReceivedEventArgs>("BackgroundService.backgroundServiceEventReceived", value);
			}
		}

		// Token: 0x06001E1F RID: 7711 RVA: 0x00022820 File Offset: 0x00020A20
		public Task<DevToolsMethodResponse> StartObservingAsync(ServiceName service)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("service", base.EnumToString(service));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("BackgroundService.startObserving", dictionary);
		}

		// Token: 0x06001E20 RID: 7712 RVA: 0x0002285C File Offset: 0x00020A5C
		public Task<DevToolsMethodResponse> StopObservingAsync(ServiceName service)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("service", base.EnumToString(service));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("BackgroundService.stopObserving", dictionary);
		}

		// Token: 0x06001E21 RID: 7713 RVA: 0x00022898 File Offset: 0x00020A98
		public Task<DevToolsMethodResponse> SetRecordingAsync(bool shouldRecord, ServiceName service)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("shouldRecord", shouldRecord);
			dictionary.Add("service", base.EnumToString(service));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("BackgroundService.setRecording", dictionary);
		}

		// Token: 0x06001E22 RID: 7714 RVA: 0x000228E4 File Offset: 0x00020AE4
		public Task<DevToolsMethodResponse> ClearEventsAsync(ServiceName service)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("service", base.EnumToString(service));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("BackgroundService.clearEvents", dictionary);
		}

		// Token: 0x04000FFA RID: 4090
		private IDevToolsClient _client;
	}
}
