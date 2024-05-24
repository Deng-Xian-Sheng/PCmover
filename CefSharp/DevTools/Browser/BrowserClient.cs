using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Browser
{
	// Token: 0x02000402 RID: 1026
	public class BrowserClient : DevToolsDomainBase
	{
		// Token: 0x06001DE4 RID: 7652 RVA: 0x000221B7 File Offset: 0x000203B7
		public BrowserClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x140000AF RID: 175
		// (add) Token: 0x06001DE5 RID: 7653 RVA: 0x000221C6 File Offset: 0x000203C6
		// (remove) Token: 0x06001DE6 RID: 7654 RVA: 0x000221D9 File Offset: 0x000203D9
		public event EventHandler<DownloadWillBeginEventArgs> DownloadWillBegin
		{
			add
			{
				this._client.AddEventHandler<DownloadWillBeginEventArgs>("Browser.downloadWillBegin", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DownloadWillBeginEventArgs>("Browser.downloadWillBegin", value);
			}
		}

		// Token: 0x140000B0 RID: 176
		// (add) Token: 0x06001DE7 RID: 7655 RVA: 0x000221ED File Offset: 0x000203ED
		// (remove) Token: 0x06001DE8 RID: 7656 RVA: 0x00022200 File Offset: 0x00020400
		public event EventHandler<DownloadProgressEventArgs> DownloadProgress
		{
			add
			{
				this._client.AddEventHandler<DownloadProgressEventArgs>("Browser.downloadProgress", value);
			}
			remove
			{
				this._client.RemoveEventHandler<DownloadProgressEventArgs>("Browser.downloadProgress", value);
			}
		}

		// Token: 0x06001DE9 RID: 7657 RVA: 0x00022214 File Offset: 0x00020414
		public Task<DevToolsMethodResponse> SetPermissionAsync(PermissionDescriptor permission, PermissionSetting setting, string origin = null, string browserContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("permission", permission.ToDictionary());
			dictionary.Add("setting", base.EnumToString(setting));
			if (!string.IsNullOrEmpty(origin))
			{
				dictionary.Add("origin", origin);
			}
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.setPermission", dictionary);
		}

		// Token: 0x06001DEA RID: 7658 RVA: 0x0002228C File Offset: 0x0002048C
		public Task<DevToolsMethodResponse> GrantPermissionsAsync(PermissionType[] permissions, string origin = null, string browserContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("permissions", base.EnumToString(permissions));
			if (!string.IsNullOrEmpty(origin))
			{
				dictionary.Add("origin", origin);
			}
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.grantPermissions", dictionary);
		}

		// Token: 0x06001DEB RID: 7659 RVA: 0x000222EC File Offset: 0x000204EC
		public Task<DevToolsMethodResponse> ResetPermissionsAsync(string browserContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.resetPermissions", dictionary);
		}

		// Token: 0x06001DEC RID: 7660 RVA: 0x00022324 File Offset: 0x00020524
		public Task<DevToolsMethodResponse> SetDownloadBehaviorAsync(SetDownloadBehaviorBehavior behavior, string browserContextId = null, string downloadPath = null, bool? eventsEnabled = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("behavior", base.EnumToString(behavior));
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			if (!string.IsNullOrEmpty(downloadPath))
			{
				dictionary.Add("downloadPath", downloadPath);
			}
			if (eventsEnabled != null)
			{
				dictionary.Add("eventsEnabled", eventsEnabled.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.setDownloadBehavior", dictionary);
		}

		// Token: 0x06001DED RID: 7661 RVA: 0x000223A8 File Offset: 0x000205A8
		public Task<DevToolsMethodResponse> CancelDownloadAsync(string guid, string browserContextId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("guid", guid);
			if (!string.IsNullOrEmpty(browserContextId))
			{
				dictionary.Add("browserContextId", browserContextId);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.cancelDownload", dictionary);
		}

		// Token: 0x06001DEE RID: 7662 RVA: 0x000223EC File Offset: 0x000205EC
		public Task<DevToolsMethodResponse> CloseAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.close", parameters);
		}

		// Token: 0x06001DEF RID: 7663 RVA: 0x0002240C File Offset: 0x0002060C
		public Task<DevToolsMethodResponse> CrashAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.crash", parameters);
		}

		// Token: 0x06001DF0 RID: 7664 RVA: 0x0002242C File Offset: 0x0002062C
		public Task<DevToolsMethodResponse> CrashGpuProcessAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.crashGpuProcess", parameters);
		}

		// Token: 0x06001DF1 RID: 7665 RVA: 0x0002244C File Offset: 0x0002064C
		public Task<GetVersionResponse> GetVersionAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetVersionResponse>("Browser.getVersion", parameters);
		}

		// Token: 0x06001DF2 RID: 7666 RVA: 0x0002246C File Offset: 0x0002066C
		public Task<GetBrowserCommandLineResponse> GetBrowserCommandLineAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<GetBrowserCommandLineResponse>("Browser.getBrowserCommandLine", parameters);
		}

		// Token: 0x06001DF3 RID: 7667 RVA: 0x0002248C File Offset: 0x0002068C
		public Task<GetHistogramsResponse> GetHistogramsAsync(string query = null, bool? delta = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(query))
			{
				dictionary.Add("query", query);
			}
			if (delta != null)
			{
				dictionary.Add("delta", delta.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetHistogramsResponse>("Browser.getHistograms", dictionary);
		}

		// Token: 0x06001DF4 RID: 7668 RVA: 0x000224E4 File Offset: 0x000206E4
		public Task<GetHistogramResponse> GetHistogramAsync(string name, bool? delta = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("name", name);
			if (delta != null)
			{
				dictionary.Add("delta", delta.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetHistogramResponse>("Browser.getHistogram", dictionary);
		}

		// Token: 0x06001DF5 RID: 7669 RVA: 0x00022534 File Offset: 0x00020734
		public Task<GetWindowBoundsResponse> GetWindowBoundsAsync(int windowId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("windowId", windowId);
			return this._client.ExecuteDevToolsMethodAsync<GetWindowBoundsResponse>("Browser.getWindowBounds", dictionary);
		}

		// Token: 0x06001DF6 RID: 7670 RVA: 0x0002256C File Offset: 0x0002076C
		public Task<GetWindowForTargetResponse> GetWindowForTargetAsync(string targetId = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(targetId))
			{
				dictionary.Add("targetId", targetId);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetWindowForTargetResponse>("Browser.getWindowForTarget", dictionary);
		}

		// Token: 0x06001DF7 RID: 7671 RVA: 0x000225A4 File Offset: 0x000207A4
		public Task<DevToolsMethodResponse> SetWindowBoundsAsync(int windowId, Bounds bounds)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("windowId", windowId);
			dictionary.Add("bounds", bounds.ToDictionary());
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.setWindowBounds", dictionary);
		}

		// Token: 0x06001DF8 RID: 7672 RVA: 0x000225EC File Offset: 0x000207EC
		public Task<DevToolsMethodResponse> SetDockTileAsync(string badgeLabel = null, byte[] image = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (!string.IsNullOrEmpty(badgeLabel))
			{
				dictionary.Add("badgeLabel", badgeLabel);
			}
			if (image != null)
			{
				dictionary.Add("image", base.ToBase64String(image));
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.setDockTile", dictionary);
		}

		// Token: 0x06001DF9 RID: 7673 RVA: 0x0002263C File Offset: 0x0002083C
		public Task<DevToolsMethodResponse> ExecuteBrowserCommandAsync(BrowserCommandId commandId)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("commandId", base.EnumToString(commandId));
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Browser.executeBrowserCommand", dictionary);
		}

		// Token: 0x04000FE6 RID: 4070
		private IDevToolsClient _client;
	}
}
