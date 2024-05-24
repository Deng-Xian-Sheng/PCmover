using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x02000499 RID: 1177
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface ICollection : IEnumerable
	{
		// Token: 0x060038A2 RID: 14498
		[__DynamicallyInvokable]
		void CopyTo(Array array, int index);

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x060038A3 RID: 14499
		[__DynamicallyInvokable]
		int Count { [__DynamicallyInvokable] get; }

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x060038A4 RID: 14500
		[__DynamicallyInvokable]
		object SyncRoot { [__DynamicallyInvokable] get; }

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x060038A5 RID: 14501
		[__DynamicallyInvokable]
		bool IsSynchronized { [__DynamicallyInvokable] get; }
	}
}
