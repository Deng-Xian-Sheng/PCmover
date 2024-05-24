using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008F2 RID: 2290
	[__DynamicallyInvokable]
	public interface IAsyncStateMachine
	{
		// Token: 0x06005E32 RID: 24114
		[__DynamicallyInvokable]
		void MoveNext();

		// Token: 0x06005E33 RID: 24115
		[__DynamicallyInvokable]
		void SetStateMachine(IAsyncStateMachine stateMachine);
	}
}
