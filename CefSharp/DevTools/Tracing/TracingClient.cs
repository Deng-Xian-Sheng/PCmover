using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Tracing
{
	// Token: 0x020001D9 RID: 473
	public class TracingClient : DevToolsDomainBase
	{
		// Token: 0x06000DA0 RID: 3488 RVA: 0x00012A7C File Offset: 0x00010C7C
		public TracingClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000040 RID: 64
		// (add) Token: 0x06000DA1 RID: 3489 RVA: 0x00012A8B File Offset: 0x00010C8B
		// (remove) Token: 0x06000DA2 RID: 3490 RVA: 0x00012A9E File Offset: 0x00010C9E
		public event EventHandler<BufferUsageEventArgs> BufferUsage
		{
			add
			{
				this._client.AddEventHandler<BufferUsageEventArgs>("Tracing.bufferUsage", value);
			}
			remove
			{
				this._client.RemoveEventHandler<BufferUsageEventArgs>("Tracing.bufferUsage", value);
			}
		}

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x06000DA3 RID: 3491 RVA: 0x00012AB2 File Offset: 0x00010CB2
		// (remove) Token: 0x06000DA4 RID: 3492 RVA: 0x00012AC5 File Offset: 0x00010CC5
		public event EventHandler<DataCollectedEventArgs> DataCollected
		{
			add
			{
				this._client.AddEventHandler<DataCollectedEventArgs>("Tracing.dataCollected", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DataCollectedEventArgs>("Tracing.dataCollected", value);
			}
		}

		// Token: 0x14000042 RID: 66
		// (add) Token: 0x06000DA5 RID: 3493 RVA: 0x00012AD9 File Offset: 0x00010CD9
		// (remove) Token: 0x06000DA6 RID: 3494 RVA: 0x00012AEC File Offset: 0x00010CEC
		public event EventHandler<TracingCompleteEventArgs> TracingComplete
		{
			add
			{
				this._client.AddEventHandler<TracingCompleteEventArgs>("Tracing.tracingComplete", value);
			}
			remove
			{
				this._client.RemoveEventHandler<TracingCompleteEventArgs>("Tracing.tracingComplete", value);
			}
		}

		// Token: 0x06000DA7 RID: 3495 RVA: 0x00012B00 File Offset: 0x00010D00
		public Task<DevToolsMethodResponse> EndAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Tracing.end", parameters);
		}

		// Token: 0x06000DA8 RID: 3496 RVA: 0x00012B20 File Offset: 0x00010D20
		public Task<GetCategoriesResponse> GetCategoriesAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetCategoriesResponse>("Tracing.getCategories", parameters);
		}

		// Token: 0x06000DA9 RID: 3497 RVA: 0x00012B40 File Offset: 0x00010D40
		public Task<DevToolsMethodResponse> RecordClockSyncMarkerAsync(string syncId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("syncId", syncId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Tracing.recordClockSyncMarker", dictionary);
		}

		// Token: 0x06000DAA RID: 3498 RVA: 0x00012B70 File Offset: 0x00010D70
		public Task<RequestMemoryDumpResponse> RequestMemoryDumpAsync(bool? deterministic = null, MemoryDumpLevelOfDetail? levelOfDetail = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (deterministic != null)
			{
				dictionary.Add("deterministic", deterministic.Value);
			}
			if (levelOfDetail != null)
			{
				dictionary.Add("levelOfDetail", base.EnumToString(levelOfDetail));
			}
			return this._client.ExecuteDevToolsMethodAsync<RequestMemoryDumpResponse>("Tracing.requestMemoryDump", dictionary);
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x00012BD4 File Offset: 0x00010DD4
		public Task<DevToolsMethodResponse> StartAsync(string categories = null, string options = null, double? bufferUsageReportingInterval = null, StartTransferMode? transferMode = null, StreamFormat? streamFormat = null, StreamCompression? streamCompression = null, TraceConfig traceConfig = null, byte[] perfettoConfig = null, TracingBackend? tracingBackend = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(categories))
			{
				dictionary.Add("categories", categories);
			}
			if (!string.IsNullOrEmpty(options))
			{
				dictionary.Add("options", options);
			}
			if (bufferUsageReportingInterval != null)
			{
				dictionary.Add("bufferUsageReportingInterval", bufferUsageReportingInterval.Value);
			}
			if (transferMode != null)
			{
				dictionary.Add("transferMode", base.EnumToString(transferMode));
			}
			if (streamFormat != null)
			{
				dictionary.Add("streamFormat", base.EnumToString(streamFormat));
			}
			if (streamCompression != null)
			{
				dictionary.Add("streamCompression", base.EnumToString(streamCompression));
			}
			if (traceConfig != null)
			{
				dictionary.Add("traceConfig", traceConfig.ToDictionary());
			}
			if (perfettoConfig != null)
			{
				dictionary.Add("perfettoConfig", base.ToBase64String(perfettoConfig));
			}
			if (tracingBackend != null)
			{
				dictionary.Add("tracingBackend", base.EnumToString(tracingBackend));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Tracing.start", dictionary);
		}

		// Token: 0x0400071B RID: 1819
		private IDevToolsClient _client;
	}
}
