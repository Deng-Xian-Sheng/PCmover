using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Animation
{
	// Token: 0x0200043E RID: 1086
	public class AnimationClient : DevToolsDomainBase
	{
		// Token: 0x06001F82 RID: 8066 RVA: 0x000237D1 File Offset: 0x000219D1
		public AnimationClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x140000B4 RID: 180
		// (add) Token: 0x06001F83 RID: 8067 RVA: 0x000237E0 File Offset: 0x000219E0
		// (remove) Token: 0x06001F84 RID: 8068 RVA: 0x000237F3 File Offset: 0x000219F3
		public event EventHandler<AnimationCanceledEventArgs> AnimationCanceled
		{
			add
			{
				this._client.AddEventHandler<AnimationCanceledEventArgs>("Animation.animationCanceled", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AnimationCanceledEventArgs>("Animation.animationCanceled", value);
			}
		}

		// Token: 0x140000B5 RID: 181
		// (add) Token: 0x06001F85 RID: 8069 RVA: 0x00023807 File Offset: 0x00021A07
		// (remove) Token: 0x06001F86 RID: 8070 RVA: 0x0002381A File Offset: 0x00021A1A
		public event EventHandler<AnimationCreatedEventArgs> AnimationCreated
		{
			add
			{
				this._client.AddEventHandler<AnimationCreatedEventArgs>("Animation.animationCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AnimationCreatedEventArgs>("Animation.animationCreated", value);
			}
		}

		// Token: 0x140000B6 RID: 182
		// (add) Token: 0x06001F87 RID: 8071 RVA: 0x0002382E File Offset: 0x00021A2E
		// (remove) Token: 0x06001F88 RID: 8072 RVA: 0x00023841 File Offset: 0x00021A41
		public event EventHandler<AnimationStartedEventArgs> AnimationStarted
		{
			add
			{
				this._client.AddEventHandler<AnimationStartedEventArgs>("Animation.animationStarted", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AnimationStartedEventArgs>("Animation.animationStarted", value);
			}
		}

		// Token: 0x06001F89 RID: 8073 RVA: 0x00023858 File Offset: 0x00021A58
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Animation.disable", parameters);
		}

		// Token: 0x06001F8A RID: 8074 RVA: 0x00023878 File Offset: 0x00021A78
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Animation.enable", parameters);
		}

		// Token: 0x06001F8B RID: 8075 RVA: 0x00023898 File Offset: 0x00021A98
		public Task<GetCurrentTimeResponse> GetCurrentTimeAsync(string id)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("id", id);
			return this._client.ExecuteDevToolsMethodAsync<GetCurrentTimeResponse>("Animation.getCurrentTime", dictionary);
		}

		// Token: 0x06001F8C RID: 8076 RVA: 0x000238C8 File Offset: 0x00021AC8
		public Task<GetPlaybackRateResponse> GetPlaybackRateAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetPlaybackRateResponse>("Animation.getPlaybackRate", parameters);
		}

		// Token: 0x06001F8D RID: 8077 RVA: 0x000238E8 File Offset: 0x00021AE8
		public Task<DevToolsMethodResponse> ReleaseAnimationsAsync(string[] animations)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("animations", animations);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Animation.releaseAnimations", dictionary);
		}

		// Token: 0x06001F8E RID: 8078 RVA: 0x00023918 File Offset: 0x00021B18
		public Task<ResolveAnimationResponse> ResolveAnimationAsync(string animationId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("animationId", animationId);
			return this._client.ExecuteDevToolsMethodAsync<ResolveAnimationResponse>("Animation.resolveAnimation", dictionary);
		}

		// Token: 0x06001F8F RID: 8079 RVA: 0x00023948 File Offset: 0x00021B48
		public Task<DevToolsMethodResponse> SeekAnimationsAsync(string[] animations, double currentTime)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("animations", animations);
			dictionary.Add("currentTime", currentTime);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Animation.seekAnimations", dictionary);
		}

		// Token: 0x06001F90 RID: 8080 RVA: 0x0002398C File Offset: 0x00021B8C
		public Task<DevToolsMethodResponse> SetPausedAsync(string[] animations, bool paused)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("animations", animations);
			dictionary.Add("paused", paused);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Animation.setPaused", dictionary);
		}

		// Token: 0x06001F91 RID: 8081 RVA: 0x000239D0 File Offset: 0x00021BD0
		public Task<DevToolsMethodResponse> SetPlaybackRateAsync(double playbackRate)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("playbackRate", playbackRate);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Animation.setPlaybackRate", dictionary);
		}

		// Token: 0x06001F92 RID: 8082 RVA: 0x00023A08 File Offset: 0x00021C08
		public Task<DevToolsMethodResponse> SetTimingAsync(string animationId, double duration, double delay)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("animationId", animationId);
			dictionary.Add("duration", duration);
			dictionary.Add("delay", delay);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Animation.setTiming", dictionary);
		}

		// Token: 0x0400110F RID: 4367
		private IDevToolsClient _client;
	}
}
