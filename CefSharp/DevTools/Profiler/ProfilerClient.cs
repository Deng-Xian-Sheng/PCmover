using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Profiler
{
	// Token: 0x02000166 RID: 358
	public class ProfilerClient : DevToolsDomainBase
	{
		// Token: 0x06000A5F RID: 2655 RVA: 0x0000F770 File Offset: 0x0000D970
		public ProfilerClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400001F RID: 31
		// (add) Token: 0x06000A60 RID: 2656 RVA: 0x0000F77F File Offset: 0x0000D97F
		// (remove) Token: 0x06000A61 RID: 2657 RVA: 0x0000F792 File Offset: 0x0000D992
		public event EventHandler<ConsoleProfileFinishedEventArgs> ConsoleProfileFinished
		{
			add
			{
				this._client.AddEventHandler<ConsoleProfileFinishedEventArgs>("Profiler.consoleProfileFinished", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ConsoleProfileFinishedEventArgs>("Profiler.consoleProfileFinished", value);
			}
		}

		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000A62 RID: 2658 RVA: 0x0000F7A6 File Offset: 0x0000D9A6
		// (remove) Token: 0x06000A63 RID: 2659 RVA: 0x0000F7B9 File Offset: 0x0000D9B9
		public event EventHandler<ConsoleProfileStartedEventArgs> ConsoleProfileStarted
		{
			add
			{
				this._client.AddEventHandler<ConsoleProfileStartedEventArgs>("Profiler.consoleProfileStarted", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ConsoleProfileStartedEventArgs>("Profiler.consoleProfileStarted", value);
			}
		}

		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06000A64 RID: 2660 RVA: 0x0000F7CD File Offset: 0x0000D9CD
		// (remove) Token: 0x06000A65 RID: 2661 RVA: 0x0000F7E0 File Offset: 0x0000D9E0
		public event EventHandler<PreciseCoverageDeltaUpdateEventArgs> PreciseCoverageDeltaUpdate
		{
			add
			{
				this._client.AddEventHandler<PreciseCoverageDeltaUpdateEventArgs>("Profiler.preciseCoverageDeltaUpdate", value);
			}
			remove
			{
				this._client.RemoveEventHandler<PreciseCoverageDeltaUpdateEventArgs>("Profiler.preciseCoverageDeltaUpdate", value);
			}
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0000F7F4 File Offset: 0x0000D9F4
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Profiler.disable", parameters);
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0000F814 File Offset: 0x0000DA14
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Profiler.enable", parameters);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0000F834 File Offset: 0x0000DA34
		public Task<GetBestEffortCoverageResponse> GetBestEffortCoverageAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetBestEffortCoverageResponse>("Profiler.getBestEffortCoverage", parameters);
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0000F854 File Offset: 0x0000DA54
		public Task<DevToolsMethodResponse> SetSamplingIntervalAsync(int interval)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("interval", interval);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Profiler.setSamplingInterval", dictionary);
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0000F88C File Offset: 0x0000DA8C
		public Task<DevToolsMethodResponse> StartAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Profiler.start", parameters);
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0000F8AC File Offset: 0x0000DAAC
		public Task<StartPreciseCoverageResponse> StartPreciseCoverageAsync(bool? callCount = null, bool? detailed = null, bool? allowTriggeredUpdates = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (callCount != null)
			{
				dictionary.Add("callCount", callCount.Value);
			}
			if (detailed != null)
			{
				dictionary.Add("detailed", detailed.Value);
			}
			if (allowTriggeredUpdates != null)
			{
				dictionary.Add("allowTriggeredUpdates", allowTriggeredUpdates.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<StartPreciseCoverageResponse>("Profiler.startPreciseCoverage", dictionary);
		}

		// Token: 0x06000A6C RID: 2668 RVA: 0x0000F930 File Offset: 0x0000DB30
		public Task<DevToolsMethodResponse> StartTypeProfileAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Profiler.startTypeProfile", parameters);
		}

		// Token: 0x06000A6D RID: 2669 RVA: 0x0000F950 File Offset: 0x0000DB50
		public Task<StopResponse> StopAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<StopResponse>("Profiler.stop", parameters);
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0000F970 File Offset: 0x0000DB70
		public Task<DevToolsMethodResponse> StopPreciseCoverageAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Profiler.stopPreciseCoverage", parameters);
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0000F990 File Offset: 0x0000DB90
		public Task<DevToolsMethodResponse> StopTypeProfileAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Profiler.stopTypeProfile", parameters);
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0000F9B0 File Offset: 0x0000DBB0
		public Task<TakePreciseCoverageResponse> TakePreciseCoverageAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<TakePreciseCoverageResponse>("Profiler.takePreciseCoverage", parameters);
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0000F9D0 File Offset: 0x0000DBD0
		public Task<TakeTypeProfileResponse> TakeTypeProfileAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<TakeTypeProfileResponse>("Profiler.takeTypeProfile", parameters);
		}

		// Token: 0x0400059E RID: 1438
		private IDevToolsClient _client;
	}
}
