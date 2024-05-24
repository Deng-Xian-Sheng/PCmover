using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200049C RID: 1180
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IDictionaryEnumerator : IEnumerator
	{
		// Token: 0x17000875 RID: 2165
		// (get) Token: 0x060038B2 RID: 14514
		[__DynamicallyInvokable]
		object Key { [__DynamicallyInvokable] get; }

		// Token: 0x17000876 RID: 2166
		// (get) Token: 0x060038B3 RID: 14515
		[__DynamicallyInvokable]
		object Value { [__DynamicallyInvokable] get; }

		// Token: 0x17000877 RID: 2167
		// (get) Token: 0x060038B4 RID: 14516
		[__DynamicallyInvokable]
		DictionaryEntry Entry { [__DynamicallyInvokable] get; }
	}
}
