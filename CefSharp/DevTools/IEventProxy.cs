using System;
using System.IO;
using System.Threading;

namespace CefSharp.DevTools
{
	// Token: 0x02000127 RID: 295
	internal interface IEventProxy : IDisposable
	{
		// Token: 0x06000897 RID: 2199
		void Raise(object sender, string eventName, Stream stream, SynchronizationContext syncContext);
	}
}
