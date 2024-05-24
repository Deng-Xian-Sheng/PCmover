using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools.Security
{
	// Token: 0x02000221 RID: 545
	public class SecurityClient : DevToolsDomainBase
	{
		// Token: 0x06000FC7 RID: 4039 RVA: 0x00014B38 File Offset: 0x00012D38
		public SecurityClient(IDevToolsClient client)
		{
			this._client = client;
		}

		// Token: 0x14000053 RID: 83
		// (add) Token: 0x06000FC8 RID: 4040 RVA: 0x00014B47 File Offset: 0x00012D47
		// (remove) Token: 0x06000FC9 RID: 4041 RVA: 0x00014B5A File Offset: 0x00012D5A
		public event EventHandler<VisibleSecurityStateChangedEventArgs> VisibleSecurityStateChanged
		{
			add
			{
				this._client.AddEventHandler<VisibleSecurityStateChangedEventArgs>("Security.visibleSecurityStateChanged", value);
			}
			remove
			{
				this._client.RemoveEventHandler<VisibleSecurityStateChangedEventArgs>("Security.visibleSecurityStateChanged", value);
			}
		}

		// Token: 0x06000FCA RID: 4042 RVA: 0x00014B70 File Offset: 0x00012D70
		public Task<DevToolsMethodResponse> DisableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Security.disable", parameters);
		}

		// Token: 0x06000FCB RID: 4043 RVA: 0x00014B90 File Offset: 0x00012D90
		public Task<DevToolsMethodResponse> EnableAsync()
		{
			Dictionary<string, object> parameters = null;
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Security.enable", parameters);
		}

		// Token: 0x06000FCC RID: 4044 RVA: 0x00014BB0 File Offset: 0x00012DB0
		public Task<DevToolsMethodResponse> SetIgnoreCertificateErrorsAsync(bool ignore)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("ignore", ignore);
			return this._client.ExecuteDevToolsMethodAsync<DevToolsMethodResponse>("Security.setIgnoreCertificateErrors", dictionary);
		}

		// Token: 0x04000809 RID: 2057
		private IDevToolsClient _client;
	}
}
