using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200049F RID: 1183
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IEqualityComparer
	{
		// Token: 0x060038B9 RID: 14521
		[__DynamicallyInvokable]
		bool Equals(object x, object y);

		// Token: 0x060038BA RID: 14522
		[__DynamicallyInvokable]
		int GetHashCode(object obj);
	}
}
