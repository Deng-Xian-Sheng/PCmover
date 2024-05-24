using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CefSharp.DevTools.DOM;

namespace CefSharp.DevTools.LayerTree
{
	// Token: 0x0200032C RID: 812
	public class LayerTreeClient : DevToolsDomainBase
	{
		// Token: 0x060017C4 RID: 6084 RVA: 0x0001BA6E File Offset: 0x00019C6E
		public LayerTreeClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x1400008E RID: 142
		// (add) Token: 0x060017C5 RID: 6085 RVA: 0x0001BA7D File Offset: 0x00019C7D
		// (remove) Token: 0x060017C6 RID: 6086 RVA: 0x0001BA90 File Offset: 0x00019C90
		public event EventHandler<LayerPaintedEventArgs> LayerPainted
		{
			add
			{
				this._client.AddEventHandler<LayerPaintedEventArgs>("LayerTree.layerPainted", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LayerPaintedEventArgs>("LayerTree.layerPainted", value);
			}
		}

		// Token: 0x1400008F RID: 143
		// (add) Token: 0x060017C7 RID: 6087 RVA: 0x0001BAA4 File Offset: 0x00019CA4
		// (remove) Token: 0x060017C8 RID: 6088 RVA: 0x0001BAB7 File Offset: 0x00019CB7
		public event EventHandler<LayerTreeDidChangeEventArgs> LayerTreeDidChange
		{
			add
			{
				this._client.AddEventHandler<LayerTreeDidChangeEventArgs>("LayerTree.layerTreeDidChange", value);
			}
			remove
			{
				this._client.RemoveEventHandler<LayerTreeDidChangeEventArgs>("LayerTree.layerTreeDidChange", value);
			}
		}

		// Token: 0x060017C9 RID: 6089 RVA: 0x0001BACC File Offset: 0x00019CCC
		public Task<CompositingReasonsResponse> CompositingReasonsAsync(string layerId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("layerId", layerId);
			return this._client.ExecuteDevToolsMethodAsync<CompositingReasonsResponse>("LayerTree.compositingReasons", dictionary);
		}

		// Token: 0x060017CA RID: 6090 RVA: 0x0001BAFC File Offset: 0x00019CFC
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("LayerTree.disable", parameters);
		}

		// Token: 0x060017CB RID: 6091 RVA: 0x0001BB1C File Offset: 0x00019D1C
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("LayerTree.enable", parameters);
		}

		// Token: 0x060017CC RID: 6092 RVA: 0x0001BB3C File Offset: 0x00019D3C
		public Task<LoadSnapshotResponse> LoadSnapshotAsync(IList<PictureTile> tiles)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("tiles", from x in tiles
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<LoadSnapshotResponse>("LayerTree.loadSnapshot", dictionary);
		}

		// Token: 0x060017CD RID: 6093 RVA: 0x0001BB90 File Offset: 0x00019D90
		public Task<MakeSnapshotResponse> MakeSnapshotAsync(string layerId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("layerId", layerId);
			return this._client.ExecuteDevToolsMethodAsync<MakeSnapshotResponse>("LayerTree.makeSnapshot", dictionary);
		}

		// Token: 0x060017CE RID: 6094 RVA: 0x0001BBC0 File Offset: 0x00019DC0
		public Task<ProfileSnapshotResponse> ProfileSnapshotAsync(string snapshotId, int? minRepeatCount = null, double? minDuration = null, Rect clipRect = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("snapshotId", snapshotId);
			if (minRepeatCount != null)
			{
				dictionary.Add("minRepeatCount", minRepeatCount.Value);
			}
			if (minDuration != null)
			{
				dictionary.Add("minDuration", minDuration.Value);
			}
			if (clipRect != null)
			{
				dictionary.Add("clipRect", clipRect.ToDictionary());
			}
			return this._client.ExecuteDevToolsMethodAsync<ProfileSnapshotResponse>("LayerTree.profileSnapshot", dictionary);
		}

		// Token: 0x060017CF RID: 6095 RVA: 0x0001BC48 File Offset: 0x00019E48
		public Task<DevToolsMethodResponse> ReleaseSnapshotAsync(string snapshotId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("snapshotId", snapshotId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("LayerTree.releaseSnapshot", dictionary);
		}

		// Token: 0x060017D0 RID: 6096 RVA: 0x0001BC78 File Offset: 0x00019E78
		public Task<ReplaySnapshotResponse> ReplaySnapshotAsync(string snapshotId, int? fromStep = null, int? toStep = null, double? scale = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("snapshotId", snapshotId);
			if (fromStep != null)
			{
				dictionary.Add("fromStep", fromStep.Value);
			}
			if (toStep != null)
			{
				dictionary.Add("toStep", toStep.Value);
			}
			if (scale != null)
			{
				dictionary.Add("scale", scale.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<ReplaySnapshotResponse>("LayerTree.replaySnapshot", dictionary);
		}

		// Token: 0x060017D1 RID: 6097 RVA: 0x0001BD08 File Offset: 0x00019F08
		public Task<SnapshotCommandLogResponse> SnapshotCommandLogAsync(string snapshotId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("snapshotId", snapshotId);
			return this._client.ExecuteDevToolsMethodAsync<SnapshotCommandLogResponse>("LayerTree.snapshotCommandLog", dictionary);
		}

		// Token: 0x04000D22 RID: 3362
		private IDevToolsClient _client;
	}
}
