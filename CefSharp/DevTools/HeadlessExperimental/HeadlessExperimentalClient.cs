using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.HeadlessExperimental
{
	// Token: 0x0200034E RID: 846
	public class HeadlessExperimentalClient : DevToolsDomainBase
	{
		// Token: 0x06001887 RID: 6279 RVA: 0x0001CFE2 File Offset: 0x0001B1E2
		public HeadlessExperimentalClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x0001CFF4 File Offset: 0x0001B1F4
		public Task<BeginFrameResponse> BeginFrameAsync(double? frameTimeTicks = null, double? interval = null, bool? noDisplayUpdates = null, ScreenshotParams screenshot = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (frameTimeTicks != null)
			{
				dictionary.Add("frameTimeTicks", frameTimeTicks.Value);
			}
			if (interval != null)
			{
				dictionary.Add("interval", interval.Value);
			}
			if (noDisplayUpdates != null)
			{
				dictionary.Add("noDisplayUpdates", noDisplayUpdates.Value);
			}
			if (screenshot != null)
			{
				dictionary.Add("screenshot", screenshot.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<BeginFrameResponse>("HeadlessExperimental.beginFrame", dictionary);
		}

		// Token: 0x06001889 RID: 6281 RVA: 0x0001D090 File Offset: 0x0001B290
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeadlessExperimental.disable", parameters);
		}

		// Token: 0x0600188A RID: 6282 RVA: 0x0001D0B0 File Offset: 0x0001B2B0
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeadlessExperimental.enable", parameters);
		}

		// Token: 0x04000D92 RID: 3474
		private IDevToolsClient _client;
	}
}
