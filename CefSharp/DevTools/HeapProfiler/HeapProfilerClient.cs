using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.HeapProfiler
{
	// Token: 0x02000172 RID: 370
	public class HeapProfilerClient : DevToolsDomainBase
	{
		// Token: 0x06000AA9 RID: 2729 RVA: 0x0000FBBC File Offset: 0x0000DDBC
		public HeapProfilerClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000AAA RID: 2730 RVA: 0x0000FBCB File Offset: 0x0000DDCB
		// (remove) Token: 0x06000AAB RID: 2731 RVA: 0x0000FBDE File Offset: 0x0000DDDE
		public event EventHandler<AddHeapSnapshotChunkEventArgs> AddHeapSnapshotChunk
		{
			add
			{
				this._client.AddEventHandler<AddHeapSnapshotChunkEventArgs>("HeapProfiler.addHeapSnapshotChunk", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AddHeapSnapshotChunkEventArgs>("HeapProfiler.addHeapSnapshotChunk", value);
			}
		}

		// Token: 0x14000023 RID: 35
		// (add) Token: 0x06000AAC RID: 2732 RVA: 0x0000FBF2 File Offset: 0x0000DDF2
		// (remove) Token: 0x06000AAD RID: 2733 RVA: 0x0000FC05 File Offset: 0x0000DE05
		public event EventHandler<HeapStatsUpdateEventArgs> HeapStatsUpdate
		{
			add
			{
				this._client.AddEventHandler<HeapStatsUpdateEventArgs>("HeapProfiler.heapStatsUpdate", value);
			}
			remove
			{
				this._client.RemoveEventHandler<HeapStatsUpdateEventArgs>("HeapProfiler.heapStatsUpdate", value);
			}
		}

		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000AAE RID: 2734 RVA: 0x0000FC19 File Offset: 0x0000DE19
		// (remove) Token: 0x06000AAF RID: 2735 RVA: 0x0000FC2C File Offset: 0x0000DE2C
		public event EventHandler<LastSeenObjectIdEventArgs> LastSeenObjectId
		{
			add
			{
				this._client.AddEventHandler<LastSeenObjectIdEventArgs>("HeapProfiler.lastSeenObjectId", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LastSeenObjectIdEventArgs>("HeapProfiler.lastSeenObjectId", value);
			}
		}

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000AB0 RID: 2736 RVA: 0x0000FC40 File Offset: 0x0000DE40
		// (remove) Token: 0x06000AB1 RID: 2737 RVA: 0x0000FC53 File Offset: 0x0000DE53
		public event EventHandler<ReportHeapSnapshotProgressEventArgs> ReportHeapSnapshotProgress
		{
			add
			{
				this._client.AddEventHandler<ReportHeapSnapshotProgressEventArgs>("HeapProfiler.reportHeapSnapshotProgress", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ReportHeapSnapshotProgressEventArgs>("HeapProfiler.reportHeapSnapshotProgress", value);
			}
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000AB2 RID: 2738 RVA: 0x0000FC67 File Offset: 0x0000DE67
		// (remove) Token: 0x06000AB3 RID: 2739 RVA: 0x0000FC7A File Offset: 0x0000DE7A
		public event EventHandler<EventArgs> ResetProfiles
		{
			add
			{
				this._client.AddEventHandler<EventArgs>("HeapProfiler.resetProfiles", value);
			}
			remove
			{
				this._client.RemoveEventHandler<EventArgs>("HeapProfiler.resetProfiles", value);
			}
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x0000FC90 File Offset: 0x0000DE90
		public Task<DevToolsMethodResponse> AddInspectedHeapObjectAsync(string heapObjectId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("heapObjectId", heapObjectId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.addInspectedHeapObject", dictionary);
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x0000FCC0 File Offset: 0x0000DEC0
		public Task<DevToolsMethodResponse> CollectGarbageAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.collectGarbage", parameters);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x0000FCE0 File Offset: 0x0000DEE0
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.disable", parameters);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0000FD00 File Offset: 0x0000DF00
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.enable", parameters);
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x0000FD20 File Offset: 0x0000DF20
		public Task<GetHeapObjectIdResponse> GetHeapObjectIdAsync(string objectId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			return this._client.ExecuteDevToolsMethodAsync<GetHeapObjectIdResponse>("HeapProfiler.getHeapObjectId", dictionary);
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x0000FD50 File Offset: 0x0000DF50
		public Task<GetObjectByHeapObjectIdResponse> GetObjectByHeapObjectIdAsync(string objectId, string objectGroup = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("objectId", objectId);
			if (!string.IsNullOrEmpty(objectGroup))
			{
				dictionary.Add("objectGroup", objectGroup);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetObjectByHeapObjectIdResponse>("HeapProfiler.getObjectByHeapObjectId", dictionary);
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x0000FD94 File Offset: 0x0000DF94
		public Task<GetSamplingProfileResponse> GetSamplingProfileAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetSamplingProfileResponse>("HeapProfiler.getSamplingProfile", parameters);
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x0000FDB4 File Offset: 0x0000DFB4
		public Task<DevToolsMethodResponse> StartSamplingAsync(double? samplingInterval = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (samplingInterval != null)
			{
				dictionary.Add("samplingInterval", samplingInterval.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.startSampling", dictionary);
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x0000FDF8 File Offset: 0x0000DFF8
		public Task<DevToolsMethodResponse> StartTrackingHeapObjectsAsync(bool? trackAllocations = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (trackAllocations != null)
			{
				dictionary.Add("trackAllocations", trackAllocations.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.startTrackingHeapObjects", dictionary);
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x0000FE3C File Offset: 0x0000E03C
		public Task<StopSamplingResponse> StopSamplingAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<StopSamplingResponse>("HeapProfiler.stopSampling", parameters);
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x0000FE5C File Offset: 0x0000E05C
		public Task<DevToolsMethodResponse> StopTrackingHeapObjectsAsync(bool? reportProgress = null, bool? treatGlobalObjectsAsRoots = null, bool? captureNumericValue = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (reportProgress != null)
			{
				dictionary.Add("reportProgress", reportProgress.Value);
			}
			if (treatGlobalObjectsAsRoots != null)
			{
				dictionary.Add("treatGlobalObjectsAsRoots", treatGlobalObjectsAsRoots.Value);
			}
			if (captureNumericValue != null)
			{
				dictionary.Add("captureNumericValue", captureNumericValue.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.stopTrackingHeapObjects", dictionary);
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x0000FEE0 File Offset: 0x0000E0E0
		public Task<DevToolsMethodResponse> TakeHeapSnapshotAsync(bool? reportProgress = null, bool? treatGlobalObjectsAsRoots = null, bool? captureNumericValue = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (reportProgress != null)
			{
				dictionary.Add("reportProgress", reportProgress.Value);
			}
			if (treatGlobalObjectsAsRoots != null)
			{
				dictionary.Add("treatGlobalObjectsAsRoots", treatGlobalObjectsAsRoots.Value);
			}
			if (captureNumericValue != null)
			{
				dictionary.Add("captureNumericValue", captureNumericValue.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("HeapProfiler.takeHeapSnapshot", dictionary);
		}

		// Token: 0x040005B3 RID: 1459
		private IDevToolsClient _client;
	}
}
