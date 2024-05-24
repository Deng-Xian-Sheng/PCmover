using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Audits
{
	// Token: 0x02000432 RID: 1074
	public class AuditsClient : DevToolsDomainBase
	{
		// Token: 0x06001F30 RID: 7984 RVA: 0x000233FA File Offset: 0x000215FA
		public AuditsClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x140000B3 RID: 179
		// (add) Token: 0x06001F31 RID: 7985 RVA: 0x00023409 File Offset: 0x00021609
		// (remove) Token: 0x06001F32 RID: 7986 RVA: 0x0002341C File Offset: 0x0002161C
		public event EventHandler<IssueAddedEventArgs> IssueAdded
		{
			add
			{
				this._client.AddEventHandler<IssueAddedEventArgs>("Audits.issueAdded", value);
			}
			remove
			{
				this._client.RemoveEventHandler<IssueAddedEventArgs>("Audits.issueAdded", value);
			}
		}

		// Token: 0x06001F33 RID: 7987 RVA: 0x00023430 File Offset: 0x00021630
		public Task<GetEncodedResponseResponse> GetEncodedResponseAsync(string requestId, GetEncodedResponseEncoding encoding, double? quality = null, bool? sizeOnly = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("requestId", requestId);
			dictionary.Add("encoding", base.EnumToString(encoding));
			if (quality != null)
			{
				dictionary.Add("quality", quality.Value);
			}
			if (sizeOnly != null)
			{
				dictionary.Add("sizeOnly", sizeOnly.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<GetEncodedResponseResponse>("Audits.getEncodedResponse", dictionary);
		}

		// Token: 0x06001F34 RID: 7988 RVA: 0x000234B8 File Offset: 0x000216B8
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Audits.disable", parameters);
		}

		// Token: 0x06001F35 RID: 7989 RVA: 0x000234D8 File Offset: 0x000216D8
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Audits.enable", parameters);
		}

		// Token: 0x06001F36 RID: 7990 RVA: 0x000234F8 File Offset: 0x000216F8
		public Task<DevToolsMethodResponse> CheckContrastAsync(bool? reportAAA = null)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			if (reportAAA != null)
			{
				dictionary.Add("reportAAA", reportAAA.Value);
			}
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Audits.checkContrast", dictionary);
		}

		// Token: 0x040010EC RID: 4332
		private IDevToolsClient _client;
	}
}
