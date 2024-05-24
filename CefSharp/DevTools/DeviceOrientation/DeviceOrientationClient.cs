using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.DeviceOrientation
{
	// Token: 0x0200012B RID: 299
	public class DeviceOrientationClient : DevToolsDomainBase
	{
		// Token: 0x060008AA RID: 2218 RVA: 0x0000DE74 File Offset: 0x0000C074
		public DeviceOrientationClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0000DE84 File Offset: 0x0000C084
		public Task<DevToolsMethodResponse> ClearDeviceOrientationOverrideAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DeviceOrientation.clearDeviceOrientationOverride", parameters);
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0000DEA4 File Offset: 0x0000C0A4
		public Task<DevToolsMethodResponse> SetDeviceOrientationOverrideAsync(double alpha, double beta, double gamma)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("alpha", alpha);
			dictionary.Add("beta", beta);
			dictionary.Add("gamma", gamma);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DeviceOrientation.setDeviceOrientationOverride", dictionary);
		}

		// Token: 0x04000499 RID: 1177
		private IDevToolsClient _client;
	}
}
