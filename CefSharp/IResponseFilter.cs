using System;
using System.IO;

namespace CefSharp
{
	// Token: 0x0200007B RID: 123
	public interface IResponseFilter : IDisposable
	{
		// Token: 0x0600033D RID: 829
		bool InitFilter();

		// Token: 0x0600033E RID: 830
		FilterStatus Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten);
	}
}
