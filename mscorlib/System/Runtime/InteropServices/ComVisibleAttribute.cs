using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000917 RID: 2327
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComVisibleAttribute : Attribute
	{
		// Token: 0x06005FF9 RID: 24569 RVA: 0x0014B5D5 File Offset: 0x001497D5
		[__DynamicallyInvokable]
		public ComVisibleAttribute(bool visibility)
		{
			this._val = visibility;
		}

		// Token: 0x170010D5 RID: 4309
		// (get) Token: 0x06005FFA RID: 24570 RVA: 0x0014B5E4 File Offset: 0x001497E4
		[__DynamicallyInvokable]
		public bool Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A6A RID: 10858
		internal bool _val;
	}
}
