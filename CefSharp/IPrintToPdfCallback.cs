using System;

namespace CefSharp
{
	// Token: 0x0200000E RID: 14
	public interface IPrintToPdfCallback : IDisposable
	{
		// Token: 0x0600002D RID: 45
		void OnPdfPrintFinished(string path, bool ok);

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002E RID: 46
		bool IsDisposed { get; }
	}
}
