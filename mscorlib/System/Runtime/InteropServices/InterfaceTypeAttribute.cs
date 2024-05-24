using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000913 RID: 2323
	[AttributeUsage(AttributeTargets.Interface, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class InterfaceTypeAttribute : Attribute
	{
		// Token: 0x06005FF1 RID: 24561 RVA: 0x0014B572 File Offset: 0x00149772
		[__DynamicallyInvokable]
		public InterfaceTypeAttribute(ComInterfaceType interfaceType)
		{
			this._val = interfaceType;
		}

		// Token: 0x06005FF2 RID: 24562 RVA: 0x0014B581 File Offset: 0x00149781
		[__DynamicallyInvokable]
		public InterfaceTypeAttribute(short interfaceType)
		{
			this._val = (ComInterfaceType)interfaceType;
		}

		// Token: 0x170010D2 RID: 4306
		// (get) Token: 0x06005FF3 RID: 24563 RVA: 0x0014B590 File Offset: 0x00149790
		[__DynamicallyInvokable]
		public ComInterfaceType Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A63 RID: 10851
		internal ComInterfaceType _val;
	}
}
