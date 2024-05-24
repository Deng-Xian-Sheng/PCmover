using System;

namespace System.Runtime.Remoting
{
	// Token: 0x020007C4 RID: 1988
	internal class RemoteAppEntry
	{
		// Token: 0x0600560B RID: 22027 RVA: 0x0013146F File Offset: 0x0012F66F
		internal RemoteAppEntry(string appName, string appURI)
		{
			this._remoteAppName = appName;
			this._remoteAppURI = appURI;
		}

		// Token: 0x0600560C RID: 22028 RVA: 0x00131485 File Offset: 0x0012F685
		internal string GetAppURI()
		{
			return this._remoteAppURI;
		}

		// Token: 0x04002781 RID: 10113
		private string _remoteAppName;

		// Token: 0x04002782 RID: 10114
		private string _remoteAppURI;
	}
}
