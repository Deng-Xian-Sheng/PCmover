using System;
using System.Collections.Generic;

namespace CefSharp
{
	// Token: 0x0200001E RID: 30
	public class DefaultApp : IApp, IDisposable
	{
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600009C RID: 156 RVA: 0x0000296A File Offset: 0x00000B6A
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00002972 File Offset: 0x00000B72
		public IBrowserProcessHandler BrowserProcessHandler { get; private set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600009E RID: 158 RVA: 0x0000297B File Offset: 0x00000B7B
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00002983 File Offset: 0x00000B83
		public IEnumerable<CefCustomScheme> Schemes { get; private set; }

		// Token: 0x060000A0 RID: 160 RVA: 0x0000298C File Offset: 0x00000B8C
		public DefaultApp(IBrowserProcessHandler browserProcessHandler, IEnumerable<CefCustomScheme> schemes)
		{
			this.BrowserProcessHandler = browserProcessHandler;
			this.Schemes = schemes;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000029A2 File Offset: 0x00000BA2
		void IApp.OnRegisterCustomSchemes(ISchemeRegistrar registrar)
		{
			this.OnRegisterCustomSchemes(registrar);
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000029AC File Offset: 0x00000BAC
		protected virtual void OnRegisterCustomSchemes(ISchemeRegistrar registrar)
		{
			List<string> list = new List<string>();
			foreach (CefCustomScheme cefCustomScheme in this.Schemes)
			{
				if (!(cefCustomScheme.SchemeName == "http") && !(cefCustomScheme.SchemeName == "https") && !list.Contains(cefCustomScheme.SchemeName))
				{
					bool flag = registrar.AddCustomScheme(cefCustomScheme.SchemeName, cefCustomScheme.Options);
					if (flag)
					{
						list.Add(cefCustomScheme.SchemeName);
					}
					else
					{
						string text = "CefSchemeRegistrar::AddCustomScheme failed for schemeName:" + cefCustomScheme.SchemeName;
					}
				}
			}
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002A60 File Offset: 0x00000C60
		protected virtual void Dispose(bool disposing)
		{
			if (!this.isDisposed)
			{
				if (disposing)
				{
					IBrowserProcessHandler browserProcessHandler = this.BrowserProcessHandler;
					if (browserProcessHandler != null)
					{
						browserProcessHandler.Dispose();
					}
					this.BrowserProcessHandler = null;
				}
				this.isDisposed = true;
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00002A8C File Offset: 0x00000C8C
		void IDisposable.Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x0400002B RID: 43
		private bool isDisposed;
	}
}
