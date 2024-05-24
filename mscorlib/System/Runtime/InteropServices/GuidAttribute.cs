using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200092C RID: 2348
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class GuidAttribute : Attribute
	{
		// Token: 0x06006024 RID: 24612 RVA: 0x0014B9A6 File Offset: 0x00149BA6
		[__DynamicallyInvokable]
		public GuidAttribute(string guid)
		{
			this._val = guid;
		}

		// Token: 0x170010E0 RID: 4320
		// (get) Token: 0x06006025 RID: 24613 RVA: 0x0014B9B5 File Offset: 0x00149BB5
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002B01 RID: 11009
		internal string _val;
	}
}
