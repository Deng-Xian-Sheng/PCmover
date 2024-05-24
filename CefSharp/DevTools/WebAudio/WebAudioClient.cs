using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.WebAudio
{
	// Token: 0x020001C0 RID: 448
	public class WebAudioClient : DevToolsDomainBase
	{
		// Token: 0x06000CEC RID: 3308 RVA: 0x00011E4D File Offset: 0x0001004D
		public WebAudioClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000031 RID: 49
		// (add) Token: 0x06000CED RID: 3309 RVA: 0x00011E5C File Offset: 0x0001005C
		// (remove) Token: 0x06000CEE RID: 3310 RVA: 0x00011E6F File Offset: 0x0001006F
		public event EventHandler<ContextCreatedEventArgs> ContextCreated
		{
			add
			{
				this._client.AddEventHandler<ContextCreatedEventArgs>("WebAudio.contextCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ContextCreatedEventArgs>("WebAudio.contextCreated", value);
			}
		}

		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000CEF RID: 3311 RVA: 0x00011E83 File Offset: 0x00010083
		// (remove) Token: 0x06000CF0 RID: 3312 RVA: 0x00011E96 File Offset: 0x00010096
		public event EventHandler<ContextWillBeDestroyedEventArgs> ContextWillBeDestroyed
		{
			add
			{
				this._client.AddEventHandler<ContextWillBeDestroyedEventArgs>("WebAudio.contextWillBeDestroyed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ContextWillBeDestroyedEventArgs>("WebAudio.contextWillBeDestroyed", value);
			}
		}

		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000CF1 RID: 3313 RVA: 0x00011EAA File Offset: 0x000100AA
		// (remove) Token: 0x06000CF2 RID: 3314 RVA: 0x00011EBD File Offset: 0x000100BD
		public event EventHandler<ContextChangedEventArgs> ContextChanged
		{
			add
			{
				this._client.AddEventHandler<ContextChangedEventArgs>("WebAudio.contextChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ContextChangedEventArgs>("WebAudio.contextChanged", value);
			}
		}

		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000CF3 RID: 3315 RVA: 0x00011ED1 File Offset: 0x000100D1
		// (remove) Token: 0x06000CF4 RID: 3316 RVA: 0x00011EE4 File Offset: 0x000100E4
		public event EventHandler<AudioListenerCreatedEventArgs> AudioListenerCreated
		{
			add
			{
				this._client.AddEventHandler<AudioListenerCreatedEventArgs>("WebAudio.audioListenerCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AudioListenerCreatedEventArgs>("WebAudio.audioListenerCreated", value);
			}
		}

		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06000CF5 RID: 3317 RVA: 0x00011EF8 File Offset: 0x000100F8
		// (remove) Token: 0x06000CF6 RID: 3318 RVA: 0x00011F0B File Offset: 0x0001010B
		public event EventHandler<AudioListenerWillBeDestroyedEventArgs> AudioListenerWillBeDestroyed
		{
			add
			{
				this._client.AddEventHandler<AudioListenerWillBeDestroyedEventArgs>("WebAudio.audioListenerWillBeDestroyed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AudioListenerWillBeDestroyedEventArgs>("WebAudio.audioListenerWillBeDestroyed", value);
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06000CF7 RID: 3319 RVA: 0x00011F1F File Offset: 0x0001011F
		// (remove) Token: 0x06000CF8 RID: 3320 RVA: 0x00011F32 File Offset: 0x00010132
		public event EventHandler<AudioNodeCreatedEventArgs> AudioNodeCreated
		{
			add
			{
				this._client.AddEventHandler<AudioNodeCreatedEventArgs>("WebAudio.audioNodeCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AudioNodeCreatedEventArgs>("WebAudio.audioNodeCreated", value);
			}
		}

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x06000CF9 RID: 3321 RVA: 0x00011F46 File Offset: 0x00010146
		// (remove) Token: 0x06000CFA RID: 3322 RVA: 0x00011F59 File Offset: 0x00010159
		public event EventHandler<AudioNodeWillBeDestroyedEventArgs> AudioNodeWillBeDestroyed
		{
			add
			{
				this._client.AddEventHandler<AudioNodeWillBeDestroyedEventArgs>("WebAudio.audioNodeWillBeDestroyed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AudioNodeWillBeDestroyedEventArgs>("WebAudio.audioNodeWillBeDestroyed", value);
			}
		}

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x06000CFB RID: 3323 RVA: 0x00011F6D File Offset: 0x0001016D
		// (remove) Token: 0x06000CFC RID: 3324 RVA: 0x00011F80 File Offset: 0x00010180
		public event EventHandler<AudioParamCreatedEventArgs> AudioParamCreated
		{
			add
			{
				this._client.AddEventHandler<AudioParamCreatedEventArgs>("WebAudio.audioParamCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AudioParamCreatedEventArgs>("WebAudio.audioParamCreated", value);
			}
		}

		// Token: 0x14000039 RID: 57
		// (add) Token: 0x06000CFD RID: 3325 RVA: 0x00011F94 File Offset: 0x00010194
		// (remove) Token: 0x06000CFE RID: 3326 RVA: 0x00011FA7 File Offset: 0x000101A7
		public event EventHandler<AudioParamWillBeDestroyedEventArgs> AudioParamWillBeDestroyed
		{
			add
			{
				this._client.AddEventHandler<AudioParamWillBeDestroyedEventArgs>("WebAudio.audioParamWillBeDestroyed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AudioParamWillBeDestroyedEventArgs>("WebAudio.audioParamWillBeDestroyed", value);
			}
		}

		// Token: 0x1400003A RID: 58
		// (add) Token: 0x06000CFF RID: 3327 RVA: 0x00011FBB File Offset: 0x000101BB
		// (remove) Token: 0x06000D00 RID: 3328 RVA: 0x00011FCE File Offset: 0x000101CE
		public event EventHandler<NodesConnectedEventArgs> NodesConnected
		{
			add
			{
				this._client.AddEventHandler<NodesConnectedEventArgs>("WebAudio.nodesConnected", value);
			}
			remove
			{
				this._client.RemoveEventHandler<NodesConnectedEventArgs>("WebAudio.nodesConnected", value);
			}
		}

		// Token: 0x1400003B RID: 59
		// (add) Token: 0x06000D01 RID: 3329 RVA: 0x00011FE2 File Offset: 0x000101E2
		// (remove) Token: 0x06000D02 RID: 3330 RVA: 0x00011FF5 File Offset: 0x000101F5
		public event EventHandler<NodesDisconnectedEventArgs> NodesDisconnected
		{
			add
			{
				this._client.AddEventHandler<NodesDisconnectedEventArgs>("WebAudio.nodesDisconnected", value);
			}
			remove
			{
				this._client.RemoveEventHandler<NodesDisconnectedEventArgs>("WebAudio.nodesDisconnected", value);
			}
		}

		// Token: 0x1400003C RID: 60
		// (add) Token: 0x06000D03 RID: 3331 RVA: 0x00012009 File Offset: 0x00010209
		// (remove) Token: 0x06000D04 RID: 3332 RVA: 0x0001201C File Offset: 0x0001021C
		public event EventHandler<NodeParamConnectedEventArgs> NodeParamConnected
		{
			add
			{
				this._client.AddEventHandler<NodeParamConnectedEventArgs>("WebAudio.nodeParamConnected", value);
			}
			remove
			{
				this._client.RemoveEventHandler<NodeParamConnectedEventArgs>("WebAudio.nodeParamConnected", value);
			}
		}

		// Token: 0x1400003D RID: 61
		// (add) Token: 0x06000D05 RID: 3333 RVA: 0x00012030 File Offset: 0x00010230
		// (remove) Token: 0x06000D06 RID: 3334 RVA: 0x00012043 File Offset: 0x00010243
		public event EventHandler<NodeParamDisconnectedEventArgs> NodeParamDisconnected
		{
			add
			{
				this._client.AddEventHandler<NodeParamDisconnectedEventArgs>("WebAudio.nodeParamDisconnected", value);
			}
			remove
			{
				this._client.RemoveEventHandler<NodeParamDisconnectedEventArgs>("WebAudio.nodeParamDisconnected", value);
			}
		}

		// Token: 0x06000D07 RID: 3335 RVA: 0x00012058 File Offset: 0x00010258
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAudio.enable", parameters);
		}

		// Token: 0x06000D08 RID: 3336 RVA: 0x00012078 File Offset: 0x00010278
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("WebAudio.disable", parameters);
		}

		// Token: 0x06000D09 RID: 3337 RVA: 0x00012098 File Offset: 0x00010298
		public Task<GetRealtimeDataResponse> GetRealtimeDataAsync(string contextId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("contextId", contextId);
			return this._client.ExecuteDevToolsMethodAsync<GetRealtimeDataResponse>("WebAudio.getRealtimeData", dictionary);
		}

		// Token: 0x040006C9 RID: 1737
		private IDevToolsClient _client;
	}
}
