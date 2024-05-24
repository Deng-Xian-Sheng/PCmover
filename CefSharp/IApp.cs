using System;

namespace CefSharp
{
	// Token: 0x02000063 RID: 99
	public interface IApp
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000183 RID: 387
		IBrowserProcessHandler BrowserProcessHandler { get; }

		// Token: 0x06000184 RID: 388
		void OnRegisterCustomSchemes(ISchemeRegistrar registrar);
	}
}
