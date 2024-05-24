using System;
using System.IO;

namespace CefSharp.Callback
{
	// Token: 0x02000451 RID: 1105
	public interface IDevToolsMessageObserver : IDisposable
	{
		// Token: 0x06002007 RID: 8199
		bool OnDevToolsMessage(IBrowser browser, Stream message);

		// Token: 0x06002008 RID: 8200
		void OnDevToolsMethodResult(IBrowser browser, int messageId, bool success, Stream result);

		// Token: 0x06002009 RID: 8201
		void OnDevToolsEvent(IBrowser browser, string method, Stream parameters);

		// Token: 0x0600200A RID: 8202
		void OnDevToolsAgentAttached(IBrowser browser);

		// Token: 0x0600200B RID: 8203
		void OnDevToolsAgentDetached(IBrowser browser);
	}
}
