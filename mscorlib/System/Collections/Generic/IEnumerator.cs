using System;

namespace System.Collections.Generic
{
	// Token: 0x020004D3 RID: 1235
	[__DynamicallyInvokable]
	public interface IEnumerator<out T> : IDisposable, IEnumerator
	{
		// Token: 0x170008EB RID: 2283
		// (get) Token: 0x06003ACF RID: 15055
		[__DynamicallyInvokable]
		T Current { [__DynamicallyInvokable] get; }
	}
}
