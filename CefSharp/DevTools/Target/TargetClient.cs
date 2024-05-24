using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Target
{
	// Token: 0x020001EE RID: 494
	public class TargetClient : DevToolsDomainBase
	{
		// Token: 0x06000E12 RID: 3602 RVA: 0x000130C2 File Offset: 0x000112C2
		public TargetClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000044 RID: 68
		// (add) Token: 0x06000E13 RID: 3603 RVA: 0x000130D1 File Offset: 0x000112D1
		// (remove) Token: 0x06000E14 RID: 3604 RVA: 0x000130E4 File Offset: 0x000112E4
		public event EventHandler<AttachedToTargetEventArgs> AttachedToTarget
		{
			add
			{
				this._client.AddEventHandler<AttachedToTargetEventArgs>("Target.attachedToTarget", value);
			}
			remove
			{
				this._client.RemoveEventHandler<AttachedToTargetEventArgs>("Target.attachedToTarget", value);
			}
		}

		// Token: 0x14000045 RID: 69
		// (add) Token: 0x06000E15 RID: 3605 RVA: 0x000130F8 File Offset: 0x000112F8
		// (remove) Token: 0x06000E16 RID: 3606 RVA: 0x0001310B File Offset: 0x0001130B
		public event EventHandler<DetachedFromTargetEventArgs> DetachedFromTarget
		{
			add
			{
				this._client.AddEventHandler<DetachedFromTargetEventArgs>("Target.detachedFromTarget", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DetachedFromTargetEventArgs>("Target.detachedFromTarget", value);
			}
		}

		// Token: 0x14000046 RID: 70
		// (add) Token: 0x06000E17 RID: 3607 RVA: 0x0001311F File Offset: 0x0001131F
		// (remove) Token: 0x06000E18 RID: 3608 RVA: 0x00013132 File Offset: 0x00011332
		public event EventHandler<ReceivedMessageFromTargetEventArgs> ReceivedMessageFromTarget
		{
			add
			{
				this._client.AddEventHandler<ReceivedMessageFromTargetEventArgs>("Target.receivedMessageFromTarget", value);
			}
			remove
			{
				this._client.RemoveEventHandler<ReceivedMessageFromTargetEventArgs>("Target.receivedMessageFromTarget", value);
			}
		}

		// Token: 0x14000047 RID: 71
		// (add) Token: 0x06000E19 RID: 3609 RVA: 0x00013146 File Offset: 0x00011346
		// (remove) Token: 0x06000E1A RID: 3610 RVA: 0x00013159 File Offset: 0x00011359
		public event EventHandler<TargetCreatedEventArgs> TargetCreated
		{
			add
			{
				this._client.AddEventHandler<TargetCreatedEventArgs>("Target.targetCreated", value);
			}
			remove
			{
				this._client.RemoveEventHandler<TargetCreatedEventArgs>("Target.targetCreated", value);
			}
		}

		// Token: 0x14000048 RID: 72
		// (add) Token: 0x06000E1B RID: 3611 RVA: 0x0001316D File Offset: 0x0001136D
		// (remove) Token: 0x06000E1C RID: 3612 RVA: 0x00013180 File Offset: 0x00011380
		public event EventHandler<TargetDestroyedEventArgs> TargetDestroyed
		{
			add
			{
				this._client.AddEventHandler<TargetDestroyedEventArgs>("Target.targetDestroyed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<TargetDestroyedEventArgs>("Target.targetDestroyed", value);
			}
		}

		// Token: 0x14000049 RID: 73
		// (add) Token: 0x06000E1D RID: 3613 RVA: 0x00013194 File Offset: 0x00011394
		// (remove) Token: 0x06000E1E RID: 3614 RVA: 0x000131A7 File Offset: 0x000113A7
		public event EventHandler<TargetCrashedEventArgs> TargetCrashed
		{
			add
			{
				this._client.AddEventHandler<TargetCrashedEventArgs>("Target.targetCrashed", value);
			}
			remove
			{
				this._client.RemoveEventHandler<TargetCrashedEventArgs>("Target.targetCrashed", value);
			}
		}

		// Token: 0x1400004A RID: 74
		// (add) Token: 0x06000E1F RID: 3615 RVA: 0x000131BB File Offset: 0x000113BB
		// (remove) Token: 0x06000E20 RID: 3616 RVA: 0x000131CE File Offset: 0x000113CE
		public event EventHandler<TargetInfoChangedEventArgs> TargetInfoChanged
		{
			add
			{
				this._client.AddEventHandler<TargetInfoChangedEventArgs>("Target.targetInfoChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<TargetInfoChangedEventArgs>("Target.targetInfoChanged", value);
			}
		}

		// Token: 0x06000E21 RID: 3617 RVA: 0x000131E4 File Offset: 0x000113E4
		public Task<DevToolsMethodResponse> ActivateTargetAsync(string targetId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("targetId", targetId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.activateTarget", dictionary);
		}

		// Token: 0x06000E22 RID: 3618 RVA: 0x00013214 File Offset: 0x00011414
		public Task<AttachToTargetResponse> AttachToTargetAsync(string targetId, bool? flatten = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("targetId", targetId);
			if (flatten != null)
			{
				dictionary.Add("flatten", flatten.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<AttachToTargetResponse>("Target.attachToTarget", dictionary);
		}

		// Token: 0x06000E23 RID: 3619 RVA: 0x00013264 File Offset: 0x00011464
		public Task<AttachToBrowserTargetResponse> AttachToBrowserTargetAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<AttachToBrowserTargetResponse>("Target.attachToBrowserTarget", parameters);
		}

		// Token: 0x06000E24 RID: 3620 RVA: 0x00013284 File Offset: 0x00011484
		public Task<CloseTargetResponse> CloseTargetAsync(string targetId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("targetId", targetId);
			return this._client.ExecuteDevToolsMethodAsync<CloseTargetResponse>("Target.closeTarget", dictionary);
		}

		// Token: 0x06000E25 RID: 3621 RVA: 0x000132B4 File Offset: 0x000114B4
		public Task<DevToolsMethodResponse> ExposeDevToolsProtocolAsync(string targetId, string bindingName = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("targetId", targetId);
			if (!string.IsNullOrEmpty(bindingName))
			{
				dictionary.Add("bindingName", bindingName);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.exposeDevToolsProtocol", dictionary);
		}

		// Token: 0x06000E26 RID: 3622 RVA: 0x000132F8 File Offset: 0x000114F8
		public Task<CreateBrowserContextResponse> CreateBrowserContextAsync(bool? disposeOnDetach = null, string proxyServer = null, string proxyBypassList = null, string[] originsWithUniversalNetworkAccess = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (disposeOnDetach != null)
			{
				dictionary.Add("disposeOnDetach", disposeOnDetach.Value);
			}
			if (!string.IsNullOrEmpty(proxyServer))
			{
				dictionary.Add("proxyServer", proxyServer);
			}
			if (!string.IsNullOrEmpty(proxyBypassList))
			{
				dictionary.Add("proxyBypassList", proxyBypassList);
			}
			if (originsWithUniversalNetworkAccess != null)
			{
				dictionary.Add("originsWithUniversalNetworkAccess", originsWithUniversalNetworkAccess);
			}
			return this._client.ExecuteDevToolsMethodAsync<CreateBrowserContextResponse>("Target.createBrowserContext", dictionary);
		}

		// Token: 0x06000E27 RID: 3623 RVA: 0x00013378 File Offset: 0x00011578
		public Task<GetBrowserContextsResponse> GetBrowserContextsAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetBrowserContextsResponse>("Target.getBrowserContexts", parameters);
		}

		// Token: 0x06000E28 RID: 3624 RVA: 0x00013398 File Offset: 0x00011598
		public Task<CreateTargetResponse> CreateTargetAsync(string url, int? width = null, int? height = null, string browserContextId = null, bool? enableBeginFrameControl = null, bool? newWindow = null, bool? background = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("url", url);
			if (width != null)
			{
				dictionary.Add("width", width.Value);
			}
			if (height != null)
			{
				dictionary.Add("height", height.Value);
			}
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			if (enableBeginFrameControl != null)
			{
				dictionary.Add("enableBeginFrameControl", enableBeginFrameControl.Value);
			}
			if (newWindow != null)
			{
				dictionary.Add("newWindow", newWindow.Value);
			}
			if (background != null)
			{
				dictionary.Add("background", background.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<CreateTargetResponse>("Target.createTarget", dictionary);
		}

		// Token: 0x06000E29 RID: 3625 RVA: 0x00013480 File Offset: 0x00011680
		public Task<DevToolsMethodResponse> DetachFromTargetAsync(string sessionId = null, string targetId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(sessionId))
			{
				dictionary.Add("sessionId", sessionId);
			}
			if (!string.IsNullOrEmpty(targetId))
			{
				dictionary.Add("targetId", targetId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.detachFromTarget", dictionary);
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x000134CC File Offset: 0x000116CC
		public Task<DevToolsMethodResponse> DisposeBrowserContextAsync(string browserContextId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("browserContextId", browserContextId);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.disposeBrowserContext", dictionary);
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x000134FC File Offset: 0x000116FC
		public Task<GetTargetInfoResponse> GetTargetInfoAsync(string targetId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(targetId))
			{
				dictionary.Add("targetId", targetId);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetTargetInfoResponse>("Target.getTargetInfo", dictionary);
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x00013534 File Offset: 0x00011734
		public Task<GetTargetsResponse> GetTargetsAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetTargetsResponse>("Target.getTargets", parameters);
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00013554 File Offset: 0x00011754
		public Task<DevToolsMethodResponse> SetAutoAttachAsync(bool autoAttach, bool waitForDebuggerOnStart, bool? flatten = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("autoAttach", autoAttach);
			dictionary.Add("waitForDebuggerOnStart", waitForDebuggerOnStart);
			if (flatten != null)
			{
				dictionary.Add("flatten", flatten.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.setAutoAttach", dictionary);
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x000135BC File Offset: 0x000117BC
		public Task<DevToolsMethodResponse> AutoAttachRelatedAsync(string targetId, bool waitForDebuggerOnStart)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("targetId", targetId);
			dictionary.Add("waitForDebuggerOnStart", waitForDebuggerOnStart);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.autoAttachRelated", dictionary);
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00013600 File Offset: 0x00011800
		public Task<DevToolsMethodResponse> SetDiscoverTargetsAsync(bool discover)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("discover", discover);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.setDiscoverTargets", dictionary);
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00013638 File Offset: 0x00011838
		public Task<DevToolsMethodResponse> SetRemoteLocationsAsync(IList<RemoteLocation> locations)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("locations", from x in locations
			select x.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Target.setRemoteLocations", dictionary);
		}

		// Token: 0x04000740 RID: 1856
		private IDevToolsClient _client;
	}
}
