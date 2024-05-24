using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Memory
{
	// Token: 0x02000316 RID: 790
	public class MemoryClient : DevToolsDomainBase
	{
		// Token: 0x0600172F RID: 5935 RVA: 0x0001B2C1 File Offset: 0x000194C1
		public MemoryClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x06001730 RID: 5936 RVA: 0x0001B2D0 File Offset: 0x000194D0
		public Task<GetDOMCountersResponse> GetDOMCountersAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetDOMCountersResponse>("Memory.getDOMCounters", parameters);
		}

		// Token: 0x06001731 RID: 5937 RVA: 0x0001B2F0 File Offset: 0x000194F0
		public Task<DevToolsMethodResponse> PrepareForLeakDetectionAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Memory.prepareForLeakDetection", parameters);
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x0001B310 File Offset: 0x00019510
		public Task<DevToolsMethodResponse> ForciblyPurgeJavaScriptMemoryAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Memory.forciblyPurgeJavaScriptMemory", parameters);
		}

		// Token: 0x06001733 RID: 5939 RVA: 0x0001B330 File Offset: 0x00019530
		public Task<DevToolsMethodResponse> SetPressureNotificationsSuppressedAsync(bool suppressed)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("suppressed", suppressed);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Memory.setPressureNotificationsSuppressed", dictionary);
		}

		// Token: 0x06001734 RID: 5940 RVA: 0x0001B368 File Offset: 0x00019568
		public Task<DevToolsMethodResponse> SimulatePressureNotificationAsync(PressureLevel level)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("level", base.EnumToString(level));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Memory.simulatePressureNotification", dictionary);
		}

		// Token: 0x06001735 RID: 5941 RVA: 0x0001B3A4 File Offset: 0x000195A4
		public Task<DevToolsMethodResponse> StartSamplingAsync(int? samplingInterval = null, bool? suppressRandomness = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (samplingInterval != null)
			{
				dictionary.Add("samplingInterval", samplingInterval.Value);
			}
			if (suppressRandomness != null)
			{
				dictionary.Add("suppressRandomness", suppressRandomness.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Memory.startSampling", dictionary);
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x0001B408 File Offset: 0x00019608
		public Task<DevToolsMethodResponse> StopSamplingAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Memory.stopSampling", parameters);
		}

		// Token: 0x06001737 RID: 5943 RVA: 0x0001B428 File Offset: 0x00019628
		public Task<GetAllTimeSamplingProfileResponse> GetAllTimeSamplingProfileAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetAllTimeSamplingProfileResponse>("Memory.getAllTimeSamplingProfile", parameters);
		}

		// Token: 0x06001738 RID: 5944 RVA: 0x0001B448 File Offset: 0x00019648
		public Task<GetBrowserSamplingProfileResponse> GetBrowserSamplingProfileAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetBrowserSamplingProfileResponse>("Memory.getBrowserSamplingProfile", parameters);
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x0001B468 File Offset: 0x00019668
		public Task<GetSamplingProfileResponse> GetSamplingProfileAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetSamplingProfileResponse>("Memory.getSamplingProfile", parameters);
		}

		// Token: 0x04000CCE RID: 3278
		private IDevToolsClient _client;
	}
}
