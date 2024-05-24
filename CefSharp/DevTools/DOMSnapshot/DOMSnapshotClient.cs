using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.DOMSnapshot
{
	// Token: 0x02000377 RID: 887
	public class DOMSnapshotClient : DevToolsDomainBase
	{
		// Token: 0x060019FF RID: 6655 RVA: 0x0001E691 File Offset: 0x0001C891
		public DOMSnapshotClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x0001E6A0 File Offset: 0x0001C8A0
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMSnapshot.disable", parameters);
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x0001E6C0 File Offset: 0x0001C8C0
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("DOMSnapshot.enable", parameters);
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x0001E6E0 File Offset: 0x0001C8E0
		public Task<CaptureSnapshotResponse> CaptureSnapshotAsync(string[] computedStyles, bool? includePaintOrder = null, bool? includeDOMRects = null, bool? includeBlendedBackgroundColors = null, bool? includeTextColorOpacities = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("computedStyles", computedStyles);
			if (includePaintOrder != null)
			{
				dictionary.Add("includePaintOrder", includePaintOrder.Value);
			}
			if (includeDOMRects != null)
			{
				dictionary.Add("includeDOMRects", includeDOMRects.Value);
			}
			if (includeBlendedBackgroundColors != null)
			{
				dictionary.Add("includeBlendedBackgroundColors", includeBlendedBackgroundColors.Value);
			}
			if (includeTextColorOpacities != null)
			{
				dictionary.Add("includeTextColorOpacities", includeTextColorOpacities.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<CaptureSnapshotResponse>("DOMSnapshot.captureSnapshot", dictionary);
		}

		// Token: 0x04000E39 RID: 3641
		private IDevToolsClient _client;
	}
}
