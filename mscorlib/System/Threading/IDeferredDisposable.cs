using System;
using System.Security;

namespace System.Threading
{
	// Token: 0x02000509 RID: 1289
	internal interface IDeferredDisposable
	{
		// Token: 0x06003CBD RID: 15549
		[SecurityCritical]
		void OnFinalRelease(bool disposed);
	}
}
