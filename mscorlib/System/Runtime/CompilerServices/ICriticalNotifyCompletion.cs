using System;
using System.Security;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F4 RID: 2292
	[__DynamicallyInvokable]
	public interface ICriticalNotifyCompletion : INotifyCompletion
	{
		// Token: 0x06005E35 RID: 24117
		[SecurityCritical]
		[__DynamicallyInvokable]
		void UnsafeOnCompleted(Action continuation);
	}
}
