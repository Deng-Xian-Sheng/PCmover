using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CefSharp.DevTools
{
	// Token: 0x02000126 RID: 294
	public interface IDevToolsClient
	{
		// Token: 0x14000015 RID: 21
		// (add) Token: 0x06000890 RID: 2192
		// (remove) Token: 0x06000891 RID: 2193
		event EventHandler<DevToolsEventArgs> DevToolsEvent;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000892 RID: 2194
		// (remove) Token: 0x06000893 RID: 2195
		event EventHandler<DevToolsErrorEventArgs> DevToolsEventError;

		// Token: 0x06000894 RID: 2196
		void AddEventHandler<T>(string eventName, EventHandler<T> eventHandler) where T : EventArgs;

		// Token: 0x06000895 RID: 2197
		bool RemoveEventHandler<T>(string eventName, EventHandler<T> eventHandler) where T : EventArgs;

		// Token: 0x06000896 RID: 2198
		Task<T> ExecuteDevToolsMethodAsync<T>(string method, IDictionary<string, object> parameters = null) where T : DevToolsDomainResponseBase;
	}
}
