using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F3 RID: 2291
	[__DynamicallyInvokable]
	public interface INotifyCompletion
	{
		// Token: 0x06005E34 RID: 24116
		[__DynamicallyInvokable]
		void OnCompleted(Action continuation);
	}
}
