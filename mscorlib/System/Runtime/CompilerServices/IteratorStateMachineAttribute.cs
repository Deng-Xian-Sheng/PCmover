using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008EA RID: 2282
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class IteratorStateMachineAttribute : StateMachineAttribute
	{
		// Token: 0x06005E01 RID: 24065 RVA: 0x0014A4ED File Offset: 0x001486ED
		[__DynamicallyInvokable]
		public IteratorStateMachineAttribute(Type stateMachineType) : base(stateMachineType)
		{
		}
	}
}
