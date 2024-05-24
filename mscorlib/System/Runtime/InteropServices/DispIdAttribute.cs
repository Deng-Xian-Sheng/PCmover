using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000911 RID: 2321
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DispIdAttribute : Attribute
	{
		// Token: 0x06005FEF RID: 24559 RVA: 0x0014B55B File Offset: 0x0014975B
		[__DynamicallyInvokable]
		public DispIdAttribute(int dispId)
		{
			this._val = dispId;
		}

		// Token: 0x170010D1 RID: 4305
		// (get) Token: 0x06005FF0 RID: 24560 RVA: 0x0014B56A File Offset: 0x0014976A
		[__DynamicallyInvokable]
		public int Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A5D RID: 10845
		internal int _val;
	}
}
