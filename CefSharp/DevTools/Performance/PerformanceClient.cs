using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Performance
{
	// Token: 0x0200022C RID: 556
	public class PerformanceClient : DevToolsDomainBase
	{
		// Token: 0x0600100E RID: 4110 RVA: 0x00014E4D File Offset: 0x0001304D
		public PerformanceClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000055 RID: 85
		// (add) Token: 0x0600100F RID: 4111 RVA: 0x00014E5C File Offset: 0x0001305C
		// (remove) Token: 0x06001010 RID: 4112 RVA: 0x00014E6F File Offset: 0x0001306F
		public event EventHandler<MetricsEventArgs> Metrics
		{
			add
			{
				this._client.AddEventHandler<MetricsEventArgs>("Performance.metrics", value);
			}
			remove
			{
				this._client.RemoveEventHandler<MetricsEventArgs>("Performance.metrics", value);
			}
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x00014E84 File Offset: 0x00013084
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Performance.disable", parameters);
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x00014EA4 File Offset: 0x000130A4
		public Task<DevToolsMethodResponse> EnableAsync(EnableTimeDomain? timeDomain = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (timeDomain != null)
			{
				dictionary.Add("timeDomain", base.EnumToString(timeDomain));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Performance.enable", dictionary);
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x00014EE8 File Offset: 0x000130E8
		public Task<GetMetricsResponse> GetMetricsAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetMetricsResponse>("Performance.getMetrics", parameters);
		}

		// Token: 0x04000828 RID: 2088
		private IDevToolsClient _client;
	}
}
