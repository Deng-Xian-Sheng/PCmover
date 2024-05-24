using System;
using System.IO;

namespace CefSharp
{
	// Token: 0x0200000B RID: 11
	public interface IGetExtensionResourceCallback : IDisposable
	{
		// Token: 0x06000022 RID: 34
		void Continue(Stream stream);

		// Token: 0x06000023 RID: 35
		void Continue(byte[] data);

		// Token: 0x06000024 RID: 36
		void Cancel();
	}
}
