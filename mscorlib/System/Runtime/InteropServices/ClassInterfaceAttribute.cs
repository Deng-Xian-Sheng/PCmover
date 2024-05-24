using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000916 RID: 2326
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ClassInterfaceAttribute : Attribute
	{
		// Token: 0x06005FF6 RID: 24566 RVA: 0x0014B5AF File Offset: 0x001497AF
		[__DynamicallyInvokable]
		public ClassInterfaceAttribute(ClassInterfaceType classInterfaceType)
		{
			this._val = classInterfaceType;
		}

		// Token: 0x06005FF7 RID: 24567 RVA: 0x0014B5BE File Offset: 0x001497BE
		[__DynamicallyInvokable]
		public ClassInterfaceAttribute(short classInterfaceType)
		{
			this._val = (ClassInterfaceType)classInterfaceType;
		}

		// Token: 0x170010D4 RID: 4308
		// (get) Token: 0x06005FF8 RID: 24568 RVA: 0x0014B5CD File Offset: 0x001497CD
		[__DynamicallyInvokable]
		public ClassInterfaceType Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A69 RID: 10857
		internal ClassInterfaceType _val;
	}
}
