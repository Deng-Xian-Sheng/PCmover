using System;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008E9 RID: 2281
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	[Serializable]
	public class StateMachineAttribute : Attribute
	{
		// Token: 0x17001025 RID: 4133
		// (get) Token: 0x06005DFE RID: 24062 RVA: 0x0014A4CD File Offset: 0x001486CD
		// (set) Token: 0x06005DFF RID: 24063 RVA: 0x0014A4D5 File Offset: 0x001486D5
		[__DynamicallyInvokable]
		public Type StateMachineType { [__DynamicallyInvokable] get; private set; }

		// Token: 0x06005E00 RID: 24064 RVA: 0x0014A4DE File Offset: 0x001486DE
		[__DynamicallyInvokable]
		public StateMachineAttribute(Type stateMachineType)
		{
			this.StateMachineType = stateMachineType;
		}
	}
}
