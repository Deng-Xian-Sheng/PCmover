using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200049E RID: 1182
	[Guid("496B0ABF-CDEE-11d3-88E8-00902754C43A")]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IEnumerator
	{
		// Token: 0x060038B6 RID: 14518
		[__DynamicallyInvokable]
		bool MoveNext();

		// Token: 0x17000878 RID: 2168
		// (get) Token: 0x060038B7 RID: 14519
		[__DynamicallyInvokable]
		object Current { [__DynamicallyInvokable] get; }

		// Token: 0x060038B8 RID: 14520
		[__DynamicallyInvokable]
		void Reset();
	}
}
