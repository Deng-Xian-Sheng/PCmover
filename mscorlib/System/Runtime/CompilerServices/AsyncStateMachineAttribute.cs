using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008EC RID: 2284
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class AsyncStateMachineAttribute : StateMachineAttribute
	{
		// Token: 0x06005E04 RID: 24068 RVA: 0x0014A4F6 File Offset: 0x001486F6
		[__DynamicallyInvokable]
		public AsyncStateMachineAttribute(Type stateMachineType) : base(stateMachineType)
		{
		}
	}
}
